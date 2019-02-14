using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Säosim
{
	class Switch {
		public bool isStraightTrack = true;
		public bool isCurvedTrack = false;
		public bool isMoving = false;
		public bool isLocked = false;
		public bool isOccupied = false;

		public void straightSwitch() {
			if ((isLocked || isOccupied) == false) {
					isMoving = true;
					isCurvedTrack = false;
					Thread.Sleep(2500);
					isStraightTrack = true;
					isMoving = false;
			}
		}

		public void curveSwitch() {
			if ((isLocked || isOccupied) == false) {
				isMoving = true;
				isStraightTrack = false;
				Thread.Sleep(2500);
				isCurvedTrack = true;
				isMoving = false;
			}
		}

		public void lockSwitch() {
			if ((isLocked == false) && (isMoving == false)) {
				isLocked = true;
			}
		}

		public void unlockSwitch() {
			if (isOccupied == false) {
				isLocked = false;
			}
		}
	}

	class Derail {
		bool lowered = true;
		bool raised = false;
		bool moving = false;
		bool locked = false;

		public void lower() {
			if (locked == false) {
				moving = true;
				raised = false;
				Thread.Sleep(2500);
				lowered = true;
				moving = false;
			}
		}

		public void raise() {
			if (locked == false) {
				moving = true;
				lowered = false;
				Thread.Sleep(2500);
				raised = true;
				moving = false;
			}
		}

		public void lockDerail() {
			if ((locked == false) && (moving == false)) {
				locked = true;
			}
		}

		public void unlockDerail() {
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
