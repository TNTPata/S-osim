using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	public class Interlocking {
		#region objectCreation
		//Not sure if everything should be static, but it works that way
		//Create the 6 switches and 2 derails
		static Switch switch1;
		static Switch switch2;
		static Switch switch3;
		static Switch switch4;
		static Switch switch5;
		static Switch switch6;

		static Derail derail1;
		static Derail derail2;

		//Create 3 entry signals
		static EntrySignal A;
		static EntrySignal B;
		static EntrySignal C;

		//Create 3 exit signals
		static ExitSignal D;
		static ExitSignal E;
		static ExitSignal F;

		//Create distant signal
		static DistSignal AFsi;

		//Create road signal
		static RoadSignal V1;

		//Create road distant signal
		static DistroadSignal V1Fsi;
		#endregion
		#region routeCreation
		//Create arrival routes
		static Route route_a1;
		static Route route_a2;
		static Route route_a3;
		static Route route_b1;
		static Route route_b2;
		static Route route_b3;
		static Route route_c1;
		static Route route_c2;

		//Create short arrival routes
		static Route route_a2k;
		static Route route_a3k;
		static Route route_c1k;
		static Route route_c2k;

		//Create departure routes
		static Route route_d1;
		static Route route_d2;
		static Route route_d3;
		static Route route_e1;
		static Route route_e2;
		static Route route_e3;
		static Route route_f1;
		static Route route_f2;

		//Create unmonitored route
		static Route route_o1;
		#endregion

		//Constructor
		public Interlocking() {
			#region objectInit
			//Init 6 switches and 2 derails
			switch1 = new Switch();
			switch2 = new Switch();
			switch3 = new Switch();
			switch4 = new Switch();
			switch5 = new Switch();
			switch6 = new Switch();

			derail1 = new Derail();
			derail2 = new Derail();

			//Init 3 exit signals
			D = new ExitSignal();
			E = new ExitSignal();
			F = new ExitSignal();

			//Init 3 entry signals
			A = new EntrySignal(E);
			B = new EntrySignal(D);
			C = new EntrySignal();

			//Init distant signal
			AFsi = new DistSignal(A);

			//Init road signal
			V1 = new RoadSignal();

			//Init road distant signal(s. There are actually two, but since they display the same aspect at all times, it is counted as one for simplicity)
			V1Fsi = new DistroadSignal(V1);
			#endregion
			#region routeInit
			//Init arrival routes
			route_a1 = new Route(AFsi, A, switch1, switch6, D, B);
			route_a2 = new Route(AFsi, A, switch1, switch6, switch5, switch4, D, B, C, F, derail2);
			route_a3 = new Route(AFsi, A, switch1, switch6, switch5, switch4, D, B, C, F, derail2);
			route_b1 = new Route(B, switch2, E, derail2, V1Fsi, V1);
			route_b2 = new Route(B, switch2, switch4, switch5, E, C, F, derail2, V1Fsi, V1);
			route_b3 = new Route(B, switch2, switch4, switch5, E, C, F, derail2, V1Fsi, V1);
			route_c1 = new Route(C, switch6, switch5, switch1, switch4, B, F, derail2);
			route_c2 = new Route(C, switch6, switch5, switch1, switch4, B, F, derail2);

			//Init short arrival routes
			route_a2k = new Route(AFsi, A, switch1, switch6, switch5, D, C, F, derail2);
			route_a3k = new Route(AFsi, A, switch1, switch6, switch5, D, C, F, derail2);
			route_c1k = new Route(C, switch6, switch5, switch6, F, derail2);
			route_c2k = new Route(C, switch6, switch5, switch6, F, derail2);

			//Init departure routes
			route_d1 = new Route(D, switch1, switch6, A);
			route_d2 = new Route(D, switch5, switch6, switch1, A, C, F);
			route_d3 = new Route(D, switch5, switch6, switch1, A, C, F);
			route_e1 = new Route(E, switch2, B, derail2, V1Fsi, V1);
			route_e2 = new Route(E, switch4, switch2, B, derail2, V1Fsi, V1);
			route_e3 = new Route(E, switch4, switch2, B, derail2, V1Fsi, V1);
			route_f1 = new Route(F, switch5, switch6, switch1, C);
			route_f2 = new Route(F, switch5, switch6, switch1, C);

			//Init unmonitored route
			route_o1 = new Route(A, B, D, E, switch1, switch2, switch6, C, F, derail2, V1Fsi, V1);
			#endregion
		}
	}
}