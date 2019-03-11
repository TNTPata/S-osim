using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	class Derail {

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
			}
			else { return false; }
		}

		public bool Raise() {
			if (isLocked == false) {
				isMoving = true;
				isLowered = false;
				Thread.Sleep(2500);
				isRaised = true;
				isMoving = false;
				return true;
			}
			else { return false; }
		}

		public bool LockDerail() {
			if ((isLocked == false) && (isMoving == false)) {
				isLocked = true;
				return true;
			}
			else { return false; }
		}

		public void UnlockDerail() {
			isLocked = false;
		}
	}
}
