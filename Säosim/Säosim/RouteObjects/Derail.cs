using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	public class Derail {

		//Takes in a name to display for debugging/user experience purposes
		public Derail(string displayName) {
			this.displayName = displayName;
			IsRaised = true;
			IsLowered = false;
			lockFactor = 0;
		}

		#region Fields
		public string displayName;
		public bool isMoving = false;
		#endregion

		#region Properties
		public bool IsLowered { get; private set; }
		public bool IsRaised { get; private set; }
		public int lockFactor { get; private set; }
		#endregion

		#region Methods/Tasks
		public async Task<bool> Lower() {
			if (lockFactor == 0)
			{
				isMoving = true;
				IsRaised = false;
				Thread.Sleep(2500);
				IsLowered = true;
				isMoving = false;
				Debug.WriteLine("[SIM/INFO] " + displayName + " i avlagt läge.");
				return true;
			}
			Debug.WriteLine("[SIM/WARN] " + displayName + " kan inte läggas om på grund av att den är förreglad i en tågväg."); return false;
		}
			
		public async Task<bool> Raise() {
			if (lockFactor == 0)
			{
				isMoving = true;
				IsLowered = false;
				Thread.Sleep(2500);
				IsRaised = true;
				isMoving = false;
				Debug.WriteLine("[SIM/INFO] " + displayName + " i pålagt läge.");
				return true;
			}
			Debug.WriteLine("[SIM/WARN] " + displayName + " kan inte läggas om på grund av att den är förreglad i en tågväg."); return false;
		}

		public bool LockDerail() {
			if (isMoving == false)
			{
				lockFactor++;
				Debug.WriteLine("[SIM/INFO] " + displayName + " låst");
				return true;
			}
			return false;
		}

		public void UnlockDerail() {
			lockFactor--;
			Debug.WriteLine("[SIM/INFO] " + displayName + " upplåst");
		}

		#region Saving
		public string SavePos() {
			if (IsRaised) {
				return Convert.ToString(lockFactor) + "R";
			} else {
				return Convert.ToString(lockFactor) + "L";
			}
		}

		public void ReadPos(string savedPosition) {
			if (savedPosition[1] is 'R') {
				lockFactor = Convert.ToInt32(Char.GetNumericValue(savedPosition[0]));
				IsRaised = true;
				IsLowered = false;
			} else if (savedPosition[1] is 'L') {
				lockFactor = Convert.ToInt32(Char.GetNumericValue(savedPosition[0]));
				IsRaised = false;
				IsLowered = true;
			}
		}
		#endregion
		#endregion
	}
}
