using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	public class Interlocking {
		#region objectCreation
		//Create the 6 switches and 2 derails
		public Switch switch1;
		public Switch switch2;
		public Switch switch3;
		public Switch switch4;
		public Switch switch5;
		public Switch switch6;

		public Derail derail1;
		public Derail derail2;

		//Create 3 entry signals
		public EntrySignal A;
		public EntrySignal B;
		public EntrySignal C;

		//Create 3 exit signals
		public ExitSignal D;
		public ExitSignal E;
		public ExitSignal F;

		//Create distant signal
		public DistSignal AFsi;

		//Create road signal
		public RoadSignal V1;

		//Create road distant signal
		public DistroadSignal V1Fsi;
		#endregion
		#region routeCreation
		//Create arrival routes
		public Route route_a1;
		public Route route_a2;
		public Route route_a3;
		public Route route_b1;
		public Route route_b2;
		public Route route_b3;
		public Route route_c1;
		public Route route_c2;

		//Create short arrival routes
		public Route route_a2k;
		public Route route_a3k;
		public Route route_c1k;
		public Route route_c2k;

		//Create departure routes
		public Route route_d1;
		public Route route_d2;
		public Route route_d3;
		public Route route_e1;
		public Route route_e2;
		public Route route_e3;
		public Route route_f1;
		public Route route_f2;

		//Create unmonitored route
		public Route route_o1;
		#endregion


		//Lists containing all objects of their type, for saving purposes
		public List<Switch> allSwitches = new List<Switch>();
		public List<Derail> allDerails = new List<Derail>();
		public List<Signal> allSignals = new List<Signal>();
		public List<Route> allRoutes = new List<Route>();


		//Constructor
		public Interlocking() {
			#region objectInit
			//Init 6 switches and 2 derails
			switch1 = new Switch("Växel 1");
			switch2 = new Switch("Växel 2");
			switch3 = new Switch("Växel 3");
			switch4 = new Switch("Växel 4");
			switch5 = new Switch("Växel 5");
			switch6 = new Switch("Växel 6");

			derail1 = new Derail("Spårspärr I");
			derail2 = new Derail("Spårspärr II");

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
			route_a2 = new Route(2, AFsi, A, switch1, switch6, switch5, switch4, D, B, C, F, derail2);
			route_a3 = new Route(3, AFsi, A, switch1, switch6, switch5, switch4, D, B, C, F, derail2);
			route_b1 = new Route(B, switch2, E, derail2, V1Fsi, V1);
			route_b2 = new Route(2, B, switch2, switch4, switch5, E, C, F, derail2, V1Fsi, V1);
			route_b3 = new Route(3, B, switch2, switch4, switch5, E, C, F, derail2, V1Fsi, V1);
			route_c1 = new Route(1, C, switch6, switch5, switch1, switch4, B, F, derail2);
			route_c2 = new Route(2, C, switch6, switch5, switch1, switch4, B, F, derail2);

			//Init short arrival routes
			route_a2k = new Route(2, AFsi, A, switch1, switch6, switch5, D, C, F, derail2);
			route_a3k = new Route(3, AFsi, A, switch1, switch6, switch5, D, C, F, derail2);
			route_c1k = new Route(1, C, switch6, switch5, switch6, F, derail2);
			route_c2k = new Route(2, C, switch6, switch5, switch6, F, derail2);

			//Init departure routes
			route_d1 = new Route(D, switch1, switch6, A);
			route_d2 = new Route(2, D, switch5, switch6, switch1, A, C, F);
			route_d3 = new Route(3, D, switch5, switch6, switch1, A, C, F);
			route_e1 = new Route(E, switch2, B, derail2, V1Fsi, V1);
			route_e2 = new Route(2, E, switch4, switch2, B, derail2, V1Fsi, V1);
			route_e3 = new Route(3, E, switch4, switch2, B, derail2, V1Fsi, V1);
			route_f1 = new Route(1, F, switch5, switch6, switch1, C);
			route_f2 = new Route(2, F, switch5, switch6, switch1, C);

			//Init unmonitored route
			route_o1 = new Route(A, B, D, E, switch1, switch2, switch6, C, F, derail2, V1Fsi, V1);
			Debug.WriteLine("Constructed interlocking objects.");
			#endregion

			#region Fill "saving" lists with objects
			//Fill "saving" lists with objects
			allSignals.Add(A);
			allSignals.Add(B);
			allSignals.Add(C);
			allSignals.Add(D);
			allSignals.Add(E);
			allSignals.Add(F);
			allSignals.Add(AFsi);
			allSignals.Add(V1);
			allSignals.Add(V1Fsi);

			allSwitches.Add(switch1);
			allSwitches.Add(switch2);
			allSwitches.Add(switch3);
			allSwitches.Add(switch4);
			allSwitches.Add(switch5);
			allSwitches.Add(switch6);

			allDerails.Add(derail1);
			allDerails.Add(derail2);

			allRoutes.Add(route_a1);
			allRoutes.Add(route_a2);
			allRoutes.Add(route_a3);
			allRoutes.Add(route_b1);
			allRoutes.Add(route_b2);
			allRoutes.Add(route_b2);
			allRoutes.Add(route_b3);
			allRoutes.Add(route_c1);
			allRoutes.Add(route_c2);
			allRoutes.Add(route_a2k);
			allRoutes.Add(route_a3k);
			allRoutes.Add(route_c1k);
			allRoutes.Add(route_c1k);
			allRoutes.Add(route_d1);
			allRoutes.Add(route_d2);
			allRoutes.Add(route_d3);
			allRoutes.Add(route_e1);
			allRoutes.Add(route_e2);
			allRoutes.Add(route_e3);
			allRoutes.Add(route_f1);
			allRoutes.Add(route_f2);
			allRoutes.Add(route_o1);
			#endregion

		}
	}
}