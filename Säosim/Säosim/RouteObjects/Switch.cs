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

		#region Fields
		public string displayName;
		public bool isMoving = false;
		private bool isOccupied = false;
		#endregion

		#region Properties
		public bool IsStraightTrack { get; private set; }
		public bool IsCurvedTrack { get; private set; }
		public bool IsLocked { get; private set; }
		#endregion

		#region Methods
		public async Task<bool> StraightSwitch() {
			if ((IsLocked || isOccupied) == false)
			{
				IsCurvedTrack = false;
				isMoving = true;
				Thread.Sleep(1000);
				isMoving = false;
				IsStraightTrack = true;
				Debug.WriteLine("[SIM/INFO] " + displayName + " i (+)");
				return true;
			}
			Debug.WriteLine("[SIM/WARN] " + displayName + " kan inte läggas om på grund av den är förreglad i en tågväg."); return false;
		}

		public async Task<bool> CurveSwitch() {
			if ((IsLocked || isOccupied) == false)
			{
				IsStraightTrack = false;
				isMoving = true;
				Thread.Sleep(1000);
				isMoving = false;
				IsCurvedTrack = true;
				Debug.WriteLine("[SIM/INFO] " + displayName + " i (-)");
				return true;
			}
			Debug.WriteLine("[SIM/WARN] " + displayName + " kan inte läggas om på grund av den är förreglad i en tågväg."); return false;
		}

		public bool LockSwitch() {
			if ((IsLocked == false) && (isMoving == false))
			{
				IsLocked = true;
				Debug.WriteLine("[SIM/INFO] " + displayName + " låst");
				return true;
			}
			return false;
		}

		public void UnlockSwitch() {
			if (isOccupied == false) {
				IsLocked = false;
				Debug.WriteLine("[SIM/INFO] " + displayName + " upplåst");
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
						Debug.WriteLine("[PRG/ERROR] " + "Error for " + displayName + ". Tried to inject " + savedPosition + " in ReadPos().");
						break;
					}
			}
		}
		#endregion

		#endregion
	}
}
