using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	public class Switch {
		//Takes in a name to display for debugging/user experience purposes
		public Switch(string displayName) {
			this.displayName = displayName;
			IsStraightTrack = true;
			IsCurvedTrack = false;
			IsLocked = false;
		}

		#region Fields(or whatever they're called)
		public string displayName;
		private bool _isMoving = false;
		private bool _isOccupied = false;
		#endregion

		#region Properties
		public bool IsStraightTrack { get; private set; }
		public bool IsCurvedTrack { get; private set; }
		public bool IsLocked { get; private set; }
		#endregion

		#region Methods
		public bool StraightSwitch() {
			if ((IsLocked || _isOccupied) == false) {
				_isMoving = true;
				IsCurvedTrack = false;
				Thread.Sleep(1000);
				IsStraightTrack = true;
				_isMoving = false;
				Debug.WriteLine(displayName + " i (+)");
				return true;
			}
			else { Debug.WriteLine(displayName + " kan inte läggas om på grund av den är förreglad i en tågväg."); return false; }
		}

		public bool CurveSwitch() {
			if ((IsLocked || _isOccupied) == false) {
				_isMoving = true;
				IsStraightTrack = false;
				Thread.Sleep(1000);
				IsCurvedTrack = true;
				_isMoving = false;
				Debug.WriteLine(displayName + " i (-)");
				return true;
			}
			else { Debug.WriteLine(displayName + " kan inte läggas om på grund av den är förreglad i en tågväg."); return false; }
		}

		public bool LockSwitch() {
			if ((IsLocked == false) && (_isMoving == false)) {
				IsLocked = true;
				Debug.WriteLine(displayName + " låst");
				return true;
			}
			else { return false; }
		}

		public void UnlockSwitch() {
			if (_isOccupied == false) {
				IsLocked = false;
				Debug.WriteLine(displayName + " upplåst");
			}
		}
		#region Saving
		public string SavePos() {
			if (IsLocked) {
				if (IsStraightTrack) {
					return "LS";
				} else {
					return "LC";
				}
			} else {
				if (IsStraightTrack) {
					return "US";
				}
				else {
					return "UC";
				}
			}
		}

		public void ReadPos(string savedPosition) {
			switch (savedPosition) {
				case "LS": {
						IsLocked = true;
						IsStraightTrack = true;
						IsCurvedTrack = false;
						break;
					}
				case "LC": {
						IsLocked = true;
						IsStraightTrack = false;
						IsCurvedTrack = true;
						break;
					}
				case "US": {
						IsLocked = false;
						IsStraightTrack = true;
						IsCurvedTrack = false;
						break;
					}
				case "UC": {
						IsLocked = false;
						IsStraightTrack = false;
						IsCurvedTrack = true;
						break;
					}
				default: {
						Console.WriteLine("Error for " + displayName + ". Tried to inject " + savedPosition + " in ReadPos().");
						break;
					}
			}
		}
		#endregion

		#endregion
	}
}
