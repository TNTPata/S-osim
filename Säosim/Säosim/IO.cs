using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Säosim {
	public class IO {
		public void SavePositions(ref Interlocking interlocking, string destinationFile) {

			StreamWriter sw = new StreamWriter(destinationFile);

			#region Save to Positions.txt
			sw.WriteLine("Switches");
			foreach (Switch s in interlocking.allSwitches) {
				sw.WriteLine(s.SavePos());
			}
			sw.WriteLine("");

			sw.WriteLine("Derails");
			foreach (Derail d in interlocking.allDerails) {
				sw.WriteLine(d.SavePos());
			}
			sw.WriteLine("");

			sw.WriteLine("Routes");
			foreach (Route r in interlocking.allRoutes) {
				sw.WriteLine(r.SavePos());
			}
			sw.WriteLine("");

			sw.WriteLine("Signals");
			foreach (Signal s in interlocking.allSignals) {
				sw.WriteLine(s.SavePos());
			}
			sw.WriteLine("");

			#endregion
			sw.Close();
		}


		public void ReadPositions(ref Interlocking interlocking, string destinationFile) {


			StreamReader sr = default(StreamReader);

			try {
				sr = new StreamReader(destinationFile);
			}
			catch (Exception e) {
				if (e is FileNotFoundException) {
					Debug.WriteLine(e.Message);
					return;
				}
			}

			//Variables
			string row;
			string currentSection = "";
			int objectCount = 0; //Lists start at 0...

			#region Read loop
			while ((row = sr.ReadLine()) != null) {

				//Ex: If row == "Switch" (which is more than 2 chars), the current section is Switches. 
				//If row contains less than 2 chars = no new section has begun, and thus the old value can be reused
				currentSection = row.Length > 2 ? row : currentSection;

				//Inserting anything else than a "position code" in ReadPos() will break it
				//If row is the same as the name of a section, go to the next row
				if (currentSection == row) { continue; }


				//If row = "" skip past everything and read next row, that will have some text. 
				//Count every time an object reads it's value. When all objects have read their value once: reset and *hopefully* move on to the next secttion
				switch (currentSection) {
					case "Switches": {
							if (objectCount >= interlocking.allSwitches.Count) {
								objectCount = 0;
								break;
							}
							else {
								interlocking.allSwitches[objectCount].ReadPos(row);
								objectCount++;
								break;
							}
						}
					case "Derails": {
							if (objectCount >= interlocking.allDerails.Count) {
								objectCount = 0;
								break;
							}
							else {
								interlocking.allDerails[objectCount].ReadPos(row);
								objectCount++;
								break;
							}
						}
					case "Routes": {
							if (objectCount >= interlocking.allRoutes.Count) {
								objectCount = 0;
								break;
							}
							else {
								interlocking.allRoutes[objectCount].ReadPos(row);
								objectCount++;
								break;
							}
						}
					case "Signals": {
							if (objectCount >= interlocking.allSignals.Count) {
								objectCount = 0;
								break;
							}
							else {
								interlocking.allSignals[objectCount].ReadPos(row);
								objectCount++;
								break;
							}
						}
					default: {
							break;
						}
				}
			}
			#endregion
			sr.Close();
		}
	}
}
