using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Säosim.RouteObjects;

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

		//Create road crossing
		public Crossing crossing_V1;
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

		//Also for saving/UI/UX reasons, explained at the bottom. 
		private Route lockedAroute;
		private Route lockedBroute;
		private Route lockedCroute;
		private Route lockedDroute;
		private Route lockedEroute;
		private Route lockedFroute;

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

			//Init road crossing
			crossing_V1 = new Crossing(V1, "Sundbyvägen");
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
			route_F = new Route(F, A, "F");

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
		//The currently locked route is saved in variable lockedXroute. If a route is stored in that variable, it is unlocked.
		//If there isn't a route stored in it, the program decides which of the applicable routes the user is trying to lock, and locks it
		public void a_toggle() {
			if (lockedAroute is null) {
				if (route_a1.ControlRoute()) {
					if (route_a1.LockRoute()) {
						lockedAroute = route_a1;
						Debug.WriteLine("[SIM/INFO] Tågväg " + route_a1.displayName + " låst.");
					} else {
						Debug.WriteLine("[SIM/WARN] Tågväg " + route_a1.displayName + " kunde inte låsas.");
					}
				}
				if (route_a2.ControlRoute()) {
					if (route_a2.LockRoute()) {
						lockedAroute = route_a2;
						Debug.WriteLine("[SIM/INFO] Tågväg " + route_a2.displayName + " låst.");
					} else {
						Debug.WriteLine("[SIM/WARN] Tågväg " + route_a2.displayName + " kunde inte låsas.");
					}
				}
				if (route_a3.ControlRoute()) {
					if (route_a3.LockRoute()) {
						lockedAroute = route_a3;
						Debug.WriteLine("[SIM/INFO] Tågväg " + route_a3.displayName + " låst.");
					} else {
						Debug.WriteLine("[SIM/WARN] Tågväg " + route_a3.displayName + " kunde inte låsas.");
					}
				}
			} else {
				lockedAroute.UnlockRoute();
				Debug.WriteLine("[SIM/INFO] Tågväg " + lockedAroute.displayName + " upplåst.");
				lockedAroute = null;
			}
		}

		public void b_toggle()
		{
			if (lockedBroute is null) {
				if (route_b1.ControlRoute()) {
					if (route_b1.LockRoute()) {
						lockedBroute = route_b1;
						Debug.WriteLine("[SIM/INFO] Tågväg " + route_b1.displayName + " låst.");
					} else {
						Debug.WriteLine("[SIM/WARN] Tågväg " + route_b1.displayName + " kunde inte låsas.");
					}
				}
				if (route_b2.ControlRoute()) {
					if (route_b2.LockRoute()) {
						lockedBroute = route_b2;
						Debug.WriteLine("[SIM/INFO] Tågväg " + route_b2.displayName + " låst.");
					} else {
						Debug.WriteLine("[SIM/WARN] Tågväg " + route_b2.displayName + " kunde inte låsas.");
					}
				}
			} else {
				lockedBroute.UnlockRoute();
				Debug.WriteLine("[SIM/INFO] Tågväg " + lockedBroute.displayName + " upplåst.");
				lockedBroute = null;
			}
		}

		public void c_toggle() {
			if (lockedCroute is null) {
				if (route_c1.ControlRoute()) {
					if (route_c1.LockRoute()) {
						lockedCroute = route_c1;
						Debug.WriteLine("[SIM/INFO] Tågväg " + route_c1.displayName + " låst.");
					} else {
						Debug.WriteLine("[SIM/WARN] Tågväg " + route_c1.displayName + " kunde inte låsas.");
					}
				}
				if (route_c2.ControlRoute()) {
					if (route_c2.LockRoute()) {
						lockedCroute = route_c2;
						Debug.WriteLine("[SIM/INFO] Tågväg " + route_c2.displayName + " låst.");
					} else {
						Debug.WriteLine("[SIM/WARN] Tågväg " + route_c2.displayName + " kunde inte låsas.");
					}
				}
				if (route_c3.ControlRoute()) {
					if (route_c3.LockRoute()) {
						lockedCroute = route_c3;
						Debug.WriteLine("[SIM/INFO] Tågväg " + route_c3.displayName + " låst.");
					} else {
						Debug.WriteLine("[SIM/WARN] Tågväg " + route_c3.displayName + " kunde inte låsas.");
					}
				}
			} else {
				lockedCroute.UnlockRoute();
				Debug.WriteLine("[SIM/INFO] Tågväg " + lockedCroute.displayName + " upplåst.");
				lockedCroute = null;
			}
		}

		public void d_toggle() {
			if (lockedDroute is null) {
				if (route_d1.ControlRoute()) {
					if (route_d1.LockRoute()) {
						lockedDroute = route_d1;
						Debug.WriteLine("[SIM/INFO] Tågväg " + route_d1.displayName + " låst.");
					} else {
						Debug.WriteLine("[SIM/WARN] Tågväg " + route_d1.displayName + " kunde inte låsas.");
					}
				}
				if (route_d2_3.ControlRoute()) {
					if (route_d2_3.LockRoute()) {
						lockedDroute = route_d2_3;
						Debug.WriteLine("[SIM/INFO] Tågväg " + route_d2_3.displayName + " låst.");
					} else {
						Debug.WriteLine("[SIM/WARN] Tågväg " + route_d2_3.displayName + " kunde inte låsas.");
					}
				}
			} else {
				lockedDroute.UnlockRoute();
				Debug.WriteLine("[SIM/INFO] Tågväg " + lockedDroute.displayName + " upplåst.");
				lockedDroute = null;
			}
		}


		public void e_toggle()
		{
			if (lockedEroute is null) {
				if (route_e1.ControlRoute()) {
					if (route_e1.LockRoute()) {
						lockedEroute = route_e1;
						Debug.WriteLine("[SIM/INFO] Tågväg " + route_e1.displayName + " låst.");
					} else {
						Debug.WriteLine("[SIM/WARN] Tågväg " + route_e1.displayName + " kunde inte låsas.");
					}
				}
				if (route_e2.ControlRoute()) {
					if (route_e2.LockRoute()) {
						lockedEroute = route_e2;
						Debug.WriteLine("[SIM/INFO] Tågväg " + route_e2.displayName + " låst.");
					} else {
						Debug.WriteLine("[SIM/WARN] Tågväg " + route_e2.displayName + " kunde inte låsas.");
					}
				}
			} else {
				lockedEroute.UnlockRoute();
				Debug.WriteLine("[SIM/INFO] Tågväg " + lockedEroute.displayName + " upplåst.");
				lockedEroute = null;
			}
		}

		public void F_toggle()
		{
			if (lockedFroute is null) {
				if (route_F.ControlRoute()) {
					if (route_F.LockRoute()) {
						lockedFroute = route_F;
						Debug.WriteLine("[SIM/INFO] Tågväg " + route_F.displayName + " låst.");
					} else {
						Debug.WriteLine("[SIM/WARN] Tågväg " + route_F.displayName + " kunde inte låsas.");
					}
				}
			} else {
				lockedFroute.UnlockRoute();
				Debug.WriteLine("[SIM/INFO] Tågväg " + lockedFroute.displayName + " upplåst.");
				lockedFroute = null;
			}
		}

		//This methods makes sure that a route can be unlocked if is was loaded as locked.
		//Otherwise, lockedXroute would be null, and thus it would try to lock a route that wasn't able to be locked. 
		public void storeLockedRoutes() {
			foreach (Route route in allRoutes) {
				if (route.isLocked) {
					switch (route.displayName[0]) { //Arrays start at 0...
						case 'a': {
								lockedAroute = route;
								break;
							}
						case 'b': {
								lockedBroute = route;
								break;
							}
						case 'c': {
								lockedCroute = route;
								break;
							}
						case 'd': {
								lockedDroute = route;
								break;
							}
						case 'e': {
								lockedEroute = route;
								break;
							}
						case 'F': {
								lockedFroute = route;
								break;
							}
						default: {
								break;
							}
					}
				}
			}
		}

		#endregion
	}
}