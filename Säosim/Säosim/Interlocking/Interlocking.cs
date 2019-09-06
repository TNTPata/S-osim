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
		public Switch switch8;

		public Derail derail1;
		public Derail derail2;

		//Create 3 entry signals
		public EntrySignal A;
		public EntrySignal B;
		public EntrySignal C;

		//Create 2 exit signals
		public ExitSignal D;
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
		public Route route_c1;
		public Route route_c2;
		public Route route_c3;

		//Create departure routes
		public Route route_d1;
		public Route route_d2_3;
		public Route route_e1;
		public Route route_e2;
		public Route route_F;

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
			switch8 = new Switch("Växel 8");

			derail1 = new Derail("Spårspärr I");
			derail2 = new Derail("Spårspärr II");

			//Init 2 exit signals
			D = new ExitSignal("D");
			F = new ExitSignal("F");

			//Init 3 entry signals
			A = new EntrySignal(D, "A");
			B = new EntrySignal("B");
			C = new EntrySignal(F, "C");

			//Init distant signal
			AFsi = new DistSignal(A, "AFsi");

			//Init road signal
			V1 = new RoadSignal("V1");

			//Init road distant signal(s. There are actually two, but since they display the same aspect at all times, it is counted as one for simplicity)
			V1Fsi = new DistroadSignal(V1, "V1Fsi");
			#endregion
			#region routeInit
			//Init arrival routes
			route_a1 = new Route(A, F, switch1, switch8, "a1");
			route_a2 = new Route(2, A, B, F, switch1, switch3, switch8, "a2");
			route_a3 = new Route(3, A, B, F, switch1, switch3, switch8, "a3");
			route_b1 = new Route(1, B, switch1, switch3, switch8, "b1");
			route_b2 = new Route(2, B, switch1, switch3, switch8, "b2");
			route_c1 = new Route(C, D, switch2, derail2, V1, "c1");
			route_c2 = new Route(2, C, D, switch2, switch4, derail2, V1, "c2");
			route_c3 = new Route(3, C, D, switch2, switch4, derail2, V1, "c3");

			//Init departure routes
			route_d1 = new Route(1, D, C, switch2, derail2, V1, "d1");
			route_d2_3 = new Route(2, D, C, switch2, derail2, V1, "d2/3");
			route_e1 = new Route(B, switch1, switch8, "e1");
			route_e2 = new Route(F, A, B, switch1, switch8, "e2");
			route_F = new Route(F, A, "f2");

			//Init unmonitored route
			route_o1 = new Route(A, C, D, F, B, switch1, switch2, switch8, derail2, V1, "o1");
			#endregion

			#region Fill "saving" lists with objects
			//Fill "saving" lists with objects
			allSignals.Add(A);
			allSignals.Add(B);
			allSignals.Add(C);
			allSignals.Add(D);
			allSignals.Add(F);
			allSignals.Add(AFsi);
			allSignals.Add(V1);
			allSignals.Add(V1Fsi);

			allSwitches.Add(switch1);
			allSwitches.Add(switch2);
			allSwitches.Add(switch3);
			allSwitches.Add(switch4);
			allSwitches.Add(switch5);
			allSwitches.Add(switch8);

			allDerails.Add(derail1);
			allDerails.Add(derail2);

			allRoutes.Add(route_a1);
			allRoutes.Add(route_a2);
			allRoutes.Add(route_a3);
			allRoutes.Add(route_b1);
			allRoutes.Add(route_b2);
			allRoutes.Add(route_b2);
			allRoutes.Add(route_c1);
			allRoutes.Add(route_c2);
			allRoutes.Add(route_c3);

			allRoutes.Add(route_d1);
			allRoutes.Add(route_d2_3);
			allRoutes.Add(route_e1);
			allRoutes.Add(route_e2);
			allRoutes.Add(route_F);
			allRoutes.Add(route_o1);
			#endregion

			#region Set forbidden routes
			//Add forbidden routes for some routes. 
			route_a1.forbiddenRoutes.Add(route_c1);
			route_a1.forbiddenRoutes.Add(route_F);
			route_a2.forbiddenRoutes.Add(route_c2);
			route_a2.forbiddenRoutes.Add(route_F);
			route_a3.forbiddenRoutes.Add(route_c3);
			route_a3.forbiddenRoutes.Add(route_F);

			route_b1.forbiddenRoutes.Add(route_c2);
			route_b1.forbiddenRoutes.Add(route_e1);
			route_b1.forbiddenRoutes.Add(route_e2);
			route_b2.forbiddenRoutes.Add(route_c3);
			route_b2.forbiddenRoutes.Add(route_e1);
			route_b2.forbiddenRoutes.Add(route_e2);

			route_c1.forbiddenRoutes.Add(route_a1);
			route_c2.forbiddenRoutes.Add(route_a2);
			route_c2.forbiddenRoutes.Add(route_b1);
			route_c3.forbiddenRoutes.Add(route_a3);
			route_c3.forbiddenRoutes.Add(route_b2);

			route_e2.forbiddenRoutes.Add(route_a2);
			route_e2.forbiddenRoutes.Add(route_a3);
			Debug.WriteLine("[PRG/INFO] Constructed interlocking.");
			#endregion

		}

		#region Methods
		//Lock/Unlock routes
		public void a1_toggle()
		{
			if (route_a1.isLocked)
			{
				if (route_a1.UnlockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_a1.displayName + " upplåst.");
				}
			}
			else
			{
				if (route_a1.LockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_a1.displayName + " låst.");
				}
			}
		}

		public void a2_toggle()
		{
			if (route_a2.isLocked)
			{
				if (route_a2.UnlockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_a2.displayName + " upplåst.");
				}
			}
			else
			{
				if (route_a2.LockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_a2.displayName + " låst.");
				}
			}
		}

		public void a3_toggle()
		{
			if (route_a3.isLocked)
			{
				if (route_a3.UnlockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_a3.displayName + " upplåst.");
				}
			}
			else
			{
				if (route_a3.LockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_a3.displayName + " låst.");
				}
			}
		}

		public void b1_toggle()
		{
			if (route_b1.isLocked)
			{
				if (route_b1.UnlockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_b1.displayName + " upplåst.");
				}
			}
			else
			{
				if (route_b1.LockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_b1.displayName + " låst.");
				}
			}
		}

		public void b2_toggle()
		{
			if (route_b2.isLocked)
			{
				if (route_b2.UnlockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_b2.displayName + " upplåst.");
				}
			}
			else
			{
				if (route_b2.LockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_b2.displayName + " låst.");
				}
			}
		}

		public void c1_toggle()
		{
			if (route_c1.isLocked)
			{
				if (route_c1.UnlockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_c1.displayName + " upplåst.");
				}
			}
			else
			{
				if (route_c1.LockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_c1.displayName + " låst.");
				}
			}
		}

		public void c2_toggle()
		{
			if (route_c2.isLocked)
			{
				if (route_c2.UnlockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_c2.displayName + " upplåst.");
				}
			}
			else
			{
				if (route_c2.LockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_c2.displayName + " låst.");
				}
			}
		}

		public void c3_toggle()
		{
			if (route_c3.isLocked)
			{
				if (route_c3.UnlockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_c3.displayName + " upplåst.");
				}
			}
			else
			{
				if (route_c3.LockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_c3.displayName + " låst.");
				}
			}
		}

		public void d1_toggle()
		{
			if (route_d1.isLocked)
			{
				if (route_d1.UnlockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_d1.displayName + " upplåst.");
				}
			}
			else
			{
				if (route_d1.LockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_d1.displayName + " låst.");
				}
			}
		}

		public void d2_3_toggle()
		{
			if (route_d2_3.isLocked)
			{
				if (route_d2_3.UnlockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_d2_3.displayName + " upplåst.");
				}
			}
			else
			{
				if (route_d2_3.LockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_d2_3.displayName + " låst.");
				}
			}
		}

		public void e1_toggle()
		{
			if (route_e1.isLocked)
			{
				if (route_e1.UnlockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_e1.displayName + " upplåst.");
				}
			}
			else
			{
				if (route_e1.LockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_e1.displayName + " låst.");
				}
			}
		}

		public void e2_toggle()
		{
			if (route_e2.isLocked)
			{
				if (route_e2.UnlockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_e2.displayName + " upplåst.");
				}
			}
			else
			{
				if (route_e2.LockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_e2.displayName + " låst.");
				}
			}
		}

		public void F_toggle()
		{
			if (route_F.isLocked)
			{
				if (route_F.UnlockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_F.displayName + " upplåst.");
				}
			}
			else
			{
				if (route_F.LockRoute())
				{
					Debug.WriteLine("[SIM/INFO] Tågväg " + route_F.displayName + " låst.");
				}
			}
		}

		#endregion
	}
}