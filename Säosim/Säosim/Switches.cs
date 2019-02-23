using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Säosim
{
	public class Switch {
		public Switch(string displayName) {
			this.displayName = displayName;
		}

		public string displayName;
		public bool isStraightTrack = true;
		public bool isCurvedTrack = false;
		bool isMoving = false;
		public bool isLocked = false;
		bool isOccupied = false;

		public void StraightSwitch() {
			if ((isLocked || isOccupied) == false) {
					isMoving = true;
					isCurvedTrack = false;
					Thread.Sleep(2500);
					isStraightTrack = true;
					isMoving = false;
			}
		}

		public void CurveSwitch() {
			if ((isLocked || isOccupied) == false) {
				isMoving = true;
				isStraightTrack = false;
				Thread.Sleep(2500);
				isCurvedTrack = true;
				isMoving = false;
			}
		}

		public void LockSwitch() {
			if ((isLocked == false) && (isMoving == false)) {
				isLocked = true;
			}
		}

		public void UnlockSwitch() {
			if (isOccupied == false) {
				isLocked = false;
			}
		}
	}

	public class Derail {
		public Derail(string displayName) {
			this.displayName = displayName;
		}

		public string displayName;
		bool lowered = true;
		bool raised = false;
		bool moving = false;
		bool locked = false;

		public void Lower() {
			if (locked == false) {
				moving = true;
				raised = false;
				Thread.Sleep(2500);
				lowered = true;
				moving = false;
			}
		}

		public void Raise() {
			if (locked == false) {
				moving = true;
				lowered = false;
				Thread.Sleep(2500);
				raised = true;
				moving = false;
			}
		}

		public void LockDerail() {
			if ((locked == false) && (moving == false)) {
				locked = true;
			}
		}

		public void UnlockDerail() {
			locked = false;
		}
	}

	/*class CentralControl {
		bool isRemoteControlled = true;
	}*/

	class Localcontrol {
		bool keyOut = true;

	}
}
