//
//  DataConverter.swift
//  Variant-Report
//
//  Created by Bacil Donovan Warren on 7/21/17.
//  Copyright © 2017 Quixotic Raindrop Software, LLC.
//
// Swift version of C# files, originally by Felix Immanuel (@fiidau at GitHub)

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

// this probably doesn't need to be a class. Refactor later.

class DataConverter {

	// swift version of DoWork 
	
	var inputFileName: String?
	var inputFileDirectory: URL?
	var inputFileFull: URL?
	var inputFileContents = "" 
	
	fileprivate func openInputFile() -> Bool {
		
		// get the inputFileName ... OpenSheet probably, or read from UserDefaults?
		
		do {
			
			self.inputFileContents = try String(contentsOf: self.inputFileFull!, encoding:String.Encoding.utf8)
			
		}
		catch {
			
			print("Couldn't read file: \(error)")
			// better error handling is indicated
			return false
			
		}
		
		
		return true
		
	}
	
	var variantReport = VariantReportForm()
	
	var line = ""
	var delimiters = ["\t", ","]
	
	var data = [String]()
	var userData = [String:String]()
	
	
	
	init () {
		
		self.inputFileName = "inputfile.vrff" // check TLA for correctness
		self.inputFileDirectory = FileManager.default.urls(for: .documentDirectory, in: .userDomainMask)[0]
		self.inputFileFull = self.inputFileDirectory?.appendingPathComponent(self.inputFileName!)
		
	}
	
	
}
