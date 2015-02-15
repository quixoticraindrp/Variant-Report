using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Variant_Report
{
    public partial class VariantReportFrm : Form
    {
        const string CONFIG_FILE="app.conf";
        StringBuilder html_report = new StringBuilder();

        public VariantReportFrm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.y-str.org/");
        }

        private void VariantReportFrm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(CONFIG_FILE))
            {
                MessageBox.Show("Configuration file for this application is missing! Variant Report cannot be generated and the application will exit.", "Config Missing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            statusLbl.Text = "Done.";            
        }

        public byte[] Zip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        public byte[] Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return mso.ToArray();
            }
        }

        public void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        private string getAutosomalText(string file)
        {
            string text = null;

            if (file.EndsWith(".gz"))
            {
                StringReader reader = new StringReader(Encoding.UTF8.GetString(Unzip(File.ReadAllBytes(file))));
                text = reader.ReadToEnd();
                reader.Close();

            }
            else if (file.EndsWith(".zip"))
            {
                using (var fs = new MemoryStream(File.ReadAllBytes(file)))
                using (var zf = new ZipFile(fs))
                {
                    var ze = zf[0];
                    if (ze == null)
                    {
                        throw new ArgumentException("file not found in Zip");
                    }
                    using (var s = zf.GetInputStream(ze))
                    {
                        using (StreamReader sr = new StreamReader(s))
                        {
                            text = sr.ReadToEnd();
                        }
                    }
                }
            }
            else
                text = File.ReadAllText(file);
            return text;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            statusLbl.Text = "Generating Report ..";
            btnSaveReport.Enabled = false;
            bwGenReport.RunWorkerAsync(tbFileName.Text);
        }


        private void bwGenReport_DoWork(object sender, DoWorkEventArgs e)
        {           
            string input_file = e.Argument.ToString();
            string at_text = getAutosomalText(input_file);
            StringReader reader = new StringReader(at_text);
            string line = null;
            char[] delim = new char[] {'\t',','};
            string[] data = null;
            //report rsid, allele
            Dictionary<string, string> user_data = new Dictionary<string, string>();
            while((line = reader.ReadLine())!=null)
            {
                if (line.StartsWith("#") || line.StartsWith("RSID") || line.StartsWith("rsid"))
                    continue;
                line = line.Replace("\"", "");
                data = line.Split(delim);
                if (data.Length == 5)
                {
                    user_data.Add(data[0], data[3] + data[4]);
                }
                else if (data.Length == 4)
                    user_data.Add(data[0], data[3]);                
            }
            reader.Close();
            //
            html_report.Clear();
            if (File.Exists(CONFIG_FILE))
            {
                string[] lines = File.ReadAllLines(CONFIG_FILE);
                data = null;
                delim = new char[] { ',' };

                string prev_cat = "";
                string your_allele = "";
                html_report.Append("<h1>Variant Report</h1>");
                html_report.Append("<table  cellpadding='5' cellspacing='5' style='border: 1px solid black; margin: 1em;'>");
                foreach (string cfg_line in lines)
                {
                    if (cfg_line.Trim().StartsWith("#"))
                        continue;
                    //DETOX,CYP1A1*2C A4889G,rs1048943,C,notes
                    data = cfg_line.Split(delim);
                    
                    if(data[0]!=prev_cat)
                    {
                        if(prev_cat!="")
                            html_report.Append("<tr><td colspan='6'>&nbsp;</td></tr>");
                        html_report.Append("<tr><td colspan='6' style='background-color: #CCFFFF;'><span style='font-weight: bold; font-family: Georgia, Times New Roman, serif;'>" + data[0] + "</span></td></tr>");
                        html_report.Append("<tr><td style='background-color: black; color: white; font-family: Georgia, Times New Roman, serif;'>Gene & Variation</td><td style='background-color: black; color: white;'>rsID #</td><td style='background-color: black; color: white;'>Risk Allele</td><td  style='background-color: black; color: white;' colspan='2'>Your Alleles & Results</td><td style='background-color: black; color: white;'>Notes</td></tr>");
                    }

                    if (user_data.ContainsKey(data[2]))
                        your_allele = user_data[data[2]];
                    else
                        your_allele = "NO CALL";

                    html_report.Append("<tr>");
                    html_report.Append("<td style='font-family: Georgia, Times New Roman, serif;'>" + data[1] + "</td>"); //Gene & Variation
                    html_report.Append("<td style='font-family: Georgia, Times New Roman, serif;'>" + data[2] + "</td>"); //rsid
                    html_report.Append("<td style='font-family: Georgia, Times New Roman, serif;'>" + data[3] + "</td>"); //risk-allele
                    html_report.Append("<td style='font-family: Georgia, Times New Roman, serif;'>" + your_allele + "</td>"); //your allele
                    html_report.Append(getColoredRepresentation(data[3][0],your_allele)); //colored
                    html_report.Append("<td style='font-family: Georgia, Times New Roman, serif;'>" + data[4] + "</td>"); //notes
                    html_report.Append("</tr>");

                    prev_cat = data[0];
                }
                html_report.Append("</table>");
                html_report.Append("<br/><br/><i><span style='font-family: Georgia, Times New Roman, serif;'>Generated using <a href='http://www.y-str.org/'>Variant Report</a>.</span></i>");
            }
        }

        private string getColoredRepresentation(char risk_allele, string your_allele)
        {
            if (your_allele == "NO CALL")
                return "<td style='font-family: Georgia, Times New Roman, serif;'>&nbsp;</td>";
            char allele1 = your_allele[0];
            char allele2 = your_allele[1];
            string result = "";
            if (risk_allele == allele1)
                result = "+";
            else
                result = "-";
            //
            if (risk_allele == allele2)
                result += "/+";
            else
                result += "/-";


            if(result=="+/+")
            {
                result = "<td style='background-color: #FF0000;font-family: Georgia, Times New Roman, serif; text-align:center;'>" + result + "</td>";
            }
            else if (result == "-/-")
            {
                result = "<td style='background-color: #00FF00;font-family: Georgia, Times New Roman, serif; text-align:center;'>" + result + "</td>";
            }
            else
            {
                result = "<td style='background-color: #FFFF00;font-family: Georgia, Times New Roman, serif; text-align:center;'>" + result + "</td>";
            }
            return result;
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Html Reports|*.html";
            if(dlg.ShowDialog(this)==DialogResult.OK)
            {
                File.WriteAllText(dlg.FileName, html_report.ToString());
                statusLbl.Text = "Report "+Path.GetFileName(dlg.FileName)+" saved.";
                Process.Start(dlg.FileName);
                statusLbl.Text = "Done.";
            }
        }

        private void bwGenReport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSaveReport.Enabled = true;
            statusLbl.Text = "Report generated. You can save the report now.";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                tbFileName.Text = dlg.FileName;
                btnReport.Enabled = true;
            }
        }
    }
}
