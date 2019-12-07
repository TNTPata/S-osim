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
			lockFactor = 0;
		}

		#region Fields
		public string displayName;
		public bool isMoving = false;
		private bool isOccupied = false;
		#endregion

		#region Properties
		public bool IsStraightTrack { get; private set; }
		public bool IsCurvedTrack { get; private set; }
		public int lockFactor { get; private set; }
		#endregion

		#region Methods
		public async Task<bool> StraightSwitch() {
			if ((lockFactor == 0) && !isOccupied) //Is not locked nor occupied
			{
				IsCurvedTrack = false;
				isMoving = true;
				Thread.Sleep(2250);
				isMoving = false;
				IsStraightTrack = true;
				Debug.WriteLine("[SIM/INFO] " + displayName + " i (+)");
				return true;
			}
			Debug.WriteLine("[SIM/WARN] " + displayName + " kan inte läggas om på grund av den är förreglad i en tågväg."); return false;
		}

		public async Task<bool> CurveSwitch() {
			if ((lockFactor == 0) && !isOccupied) //Is not locked nor occupied
			{
				IsStraightTrack = false;
				isMoving = true;
				Thread.Sleep(2250);
				isMoving = false;
				IsCurvedTrack = true;
				Debug.WriteLine("[SIM/INFO] " + displayName + " i (-)");
				return true;
			}
			Debug.WriteLine("[SIM/WARN] " + displayName + " kan inte läggas om på grund av den är förreglad i en tågväg."); return false;
		}

		public bool LockSwitch() {
			if (isMoving == false)
			{
				lockFactor++;
				Debug.WriteLine("[SIM/INFO] " + displayName + " låst");
				return true;
			}
			return false;
		}

		public void UnlockSwitch() {
			if (isOccupied == false) {
				lockFactor--;
				Debug.WriteLine("[SIM/INFO] " + displayName + " upplåst");
			}
		}

		#region Saving
		public string SavePos() {
			if (IsStraightTrack) {
				return Convert.ToString(lockFactor) + "S";
			} else {
				return Convert.ToString(lockFactor) + "C";
			}
		}

		public void ReadPos(string savedPosition) {
			if (savedPosition[1] is 'S') {
				lockFactor = Convert.ToInt32(Char.GetNumericValue(savedPosition[0]));
				IsStraightTrack = true;
				IsCurvedTrack = false;
			} else if (savedPosition[1] is 'C') {
				lockFactor = Convert.ToInt32(Char.GetNumericValue(savedPosition[0]));
				IsStraightTrack = false;
				IsCurvedTrack = true;
			}
		}
		#endregion

		#endregion
	}
}
