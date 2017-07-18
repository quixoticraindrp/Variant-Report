//
//  VariantReportForm.swift
//  Variant-Report
//
//  Created by Bacil Donovan Warren on 7/17/17.
//  Copyright © 2017 Quixotic Raindrop Software, LLC. All rights reserved.

// 

// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

import Cocoa

class VariantReportForm: NSObject {
	
	fileprivate let configFile = "app.conf"
	fileprivate let configDir = FileManager.default.urls(for: .documentDirectory, in: .userDomainMask)[0]
	fileprivate enum customError: Error {
		
		case NoDir(String)
		case NoPath(String)
		case NoRead(String)
		
	}
	
	fileprivate func getAutosomalText(_ file: String) -> String {
		
		var fileContents = ""
		let directory = FileManager.default.urls(for: .documentDirectory, in: .userDomainMask)[0]
		
		let fullPath = directory.appendingPathComponent(file)
		
		// replace with Open panel. This is just translation from C#
		
		if (file.substring(from: file.index(file.endIndex, offsetBy: -3)) == ".gz") {
			
			//gunzip file
			
		} // END if .gz
			
		else if (file.substring(from: file.index(file.endIndex, offsetBy: -4)) == ".zip") {
			
			// unzip
			
		} // END elsif .zip
			
		else {
			do {
				
				fileContents = try String(contentsOf: fullPath, encoding:String.Encoding.utf8)
				
			}
			catch {
				
				print("Couldn't read file: \(error)")
				// better error handling is indicated
				
			}
			
		}
		return fileContents
		
	} // END getAutosomalText
	
	//	fileprivate func generateReport( ) {
	//
	//		let inputFile =
	//
	//	} // END func generateReport()
	
	
}
