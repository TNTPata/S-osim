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
		}

		#region Fields(or whatever they're called)
		public string displayName;
		private bool isMoving = false;
		private bool isOccupied = false;
		#endregion

		#region Properties
		public bool isStraightTrack { get; private set; }
		public bool isCurvedTrack { get; private set; }
		public bool isLocked { get; private set; }
		#endregion

		#region Methods
		public bool StraightSwitch() {
			if ((isLocked || isOccupied) == false) {
				isMoving = true;
				isCurvedTrack = false;
				Thread.Sleep(1000);
				isStraightTrack = true;
				isMoving = false;
				Debug.WriteLine(displayName + " i (+)");
				return true;
			}
			else { return false; }
		}

		public bool CurveSwitch() {
			if ((isLocked || isOccupied) == false) {
				isMoving = true;
				isStraightTrack = false;
				Thread.Sleep(1000);
				isCurvedTrack = true;
				isMoving = false;
				Debug.WriteLine(displayName + " i (-)");
				return true;
			}
			else { return false; }
		}

		public bool LockSwitch() {
			if ((isLocked == false) && (isMoving == false)) {
				isLocked = true;
				Debug.WriteLine(displayName + "låst");
				return true;
			}
			else { return false; }
		}

		public void UnlockSwitch() {
			if (isOccupied == false) {
				Debug.WriteLine(displayName + "upplåst");
				isLocked = false;
			}
		}
		#endregion
	}
}
