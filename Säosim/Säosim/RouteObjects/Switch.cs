using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	class Switch {
		//Takes in a name to display for debugging/user experience purposes
		public Switch(string displayName) {
			this.displayName = displayName;
		}

		public string displayName;
		public bool isStraightTrack = true;
		public bool isCurvedTrack = false;
		bool isMoving = false;
		public bool isLocked = false;
		bool isOccupied = false;

		public bool StraightSwitch() {
			if ((isLocked || isOccupied) == false) {
				isMoving = true;
				isCurvedTrack = false;
				Thread.Sleep(1000);
				isStraightTrack = true;
				isMoving = false;
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
				return true;
			}
			else { return false; }
		}

		public bool LockSwitch() {
			if ((isLocked == false) && (isMoving == false)) {
				isLocked = true;
				return true;
			}
			else { return false; }
		}

		public void UnlockSwitch() {
			if (isOccupied == false) {
				isLocked = false;
			}
		}
	}
}
