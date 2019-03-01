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
			} else { return false; }
		}

		public bool CurveSwitch() {
			if ((isLocked || isOccupied) == false) {
				isMoving = true;
				isStraightTrack = false;
				Thread.Sleep(1000);
				isCurvedTrack = true;
				isMoving = false;
				return true;
			} else { return false; }
		}

		public bool LockSwitch() {
			if ((isLocked == false) && (isMoving == false)) {
				isLocked = true;
				return true;
			} else { return false; }
		}

		public void UnlockSwitch() {
			if (isOccupied == false) {
				isLocked = false;
			}
		}
	}

	public class Derail {

		//Takes in a name to display for debugging/user experience purposes
		public Derail(string displayName) {
			this.displayName = displayName;
		}

		public string displayName;
		public bool isLowered = true;
		public bool isRaised = false;
		private bool isMoving = false;
		public bool isLocked = false;

		public bool Lower() {
			if (isLocked == false) {
				isMoving = true;
				isRaised = false;
				Thread.Sleep(2500);
				isLowered = true;
				isMoving = false;
				return true;
			} else { return false; }
		}

		public bool Raise() {
			if (isLocked == false) {
				isMoving = true;
				isLowered = false;
				Thread.Sleep(2500);
				isRaised = true;
				isMoving = false;
				return true;
			} else { return false; }
		}

		public bool LockDerail() {
			if ((isLocked == false) && (isMoving == false)) {
				isLocked = true;
				return true;
			} else { return false; }
		}

		public void UnlockDerail() {
			isLocked = false;
		}
	}

	/*class CentralControl {
		bool isRemoteControlled = true;
	}*/

	class Localcontrol {
		bool keyOut = true;

	}
}
