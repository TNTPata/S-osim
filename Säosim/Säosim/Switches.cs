using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Säosim
{
	class Switch {
		bool straightTrack = true;
		bool curvedTrack = false;
		bool moving = false;
		bool locked = false;
		bool occupied = false;

		public void straightSwitch() {
			if ((locked || occupied) == false) {
					moving = true;
					curvedTrack = false;
					Thread.Sleep(2500);
					straightTrack = true;
					moving = false;
			}
		}

		public void curveSwitch() {
			if ((locked || occupied) == false) {
				moving = true;
				straightTrack = false;
				Thread.Sleep(2500);
				curvedTrack = true;
				moving = false;
			}
		}

		public void lockSwitch() {
			if ((locked == false) && (moving == false)) {
				locked = true;
			}
		}

		public void unlockSwitch() {
			if (occupied == false) {
				locked = false;
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

	class LocalControl {
		bool keyOut = true;

	}

	class TrackCircuit {
		int occupationState = 0;
		//0 = Unoccupied, 1 = Reserved, 2 = Occupied
	}
}
