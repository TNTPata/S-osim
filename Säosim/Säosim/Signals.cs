using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	class Signal {
		public bool isProtected = false;
		public int signalState = 0;
		//0 = Stop, 1 = Clear - Next Signal clear, 2 = Caution, 3 = Caution - Short route.

		void SetToStop() {
			signalState = 0;
		}
	}

	class EntrySignal : Signal {

		public EntrySignal() { }
		EntrySignal(Signal nextSignal) {
			//nextSignal = ??? Fill with the signal that
		}
		public void SetClear() {
			if (isProtected == false) {
				signalState = 1;
			}
		}
		public void SetCaution() {
			if (isProtected == false) {
				signalState = 2;
			}
		}
		public void SetCautionS() {
			if (isProtected == false) {
				signalState = 3;
			}
		}
	}

	class ExitSignal : Signal {

	}

	class DistSignal : Signal {

	}

	class RoadSignal : Signal {

	}

	class DistroadSignal : Signal {

	}
}
