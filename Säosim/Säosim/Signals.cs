using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	class Signal {
		public int signalState = 0;
		//0 = Stop

		void SetToStop() {
			signalState = 0;
		}
	}

	class EntrySignal : Signal{
		void SetToClear() {
			signalState = 1;
		}
	}

	class Exitsignal : Signal{

	}

	class Distsignal {
		Distsignal(Signal referenceSignal) {
			
		}
		Signal referanceSignal = new Signal();
	}

	class Roadsignal {

	}

	class Distroadsignal {

	}
}
