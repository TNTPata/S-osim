using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	class Interlocking {
		class TrackCircuit {
			int occupationState = 0;
			//0 = Unoccupied, 1 = Reserved, 2 = Occupied
		}

		class Route {
			enum includedSwitches {/*Fill with the switches (and signals?) a train will pass in a specific route*/};
		}

		#region objectInit
		//Create the 6 switches and 2 derails
		Switch switch1 = new Switch();
		Switch switch2 = new Switch();
		Switch switch3 = new Switch();
		Switch switch4 = new Switch();
		Switch switch5 = new Switch();
		Switch switch6 = new Switch();

		Derail derail1 = new Derail();
		Derail derail2 = new Derail();

		//Create 3 entry signals
		Signal A = new Signal();
		Signal B = new Signal();
		Signal C = new Signal();

		//Create 3 exit signals
		Signal D = new Signal();
		Signal E = new Signal();
		Signal F = new Signal();

		//Create distant signal
		Signal AFsi = new Signal();

		//Create road signal
		Signal V1 = new Signal();

		//Create 2 road distant signals
		Signal V1FsiA = new Signal();
		Signal V1FsiB = new Signal();
		
		#endregion
		#region routeInit
		//Create routes
		Route route_a1 = new Route();
		Route route_a2 = new Route();
		Route route_a3 = new Route();
		Route route_b1 = new Route();
		Route route_b2 = new Route();
		Route route_b3 = new Route();
		Route route_c1 = new Route();
		Route route_c2 = new Route();
		Route route_a2k = new Route();
		Route route_a3k = new Route();
		Route route_c1k = new Route();
		Route route_c2k = new Route();
		Route route_d1 = new Route();
		Route route_d2 = new Route();
		Route route_d3 = new Route();
		Route route_e1 = new Route();
		Route route_e2 = new Route();
		Route route_e3 = new Route();
		Route route_f1 = new Route();
		Route route_f2 = new Route();
		Route route_o1 = new Route();
		#endregion
	}
}
