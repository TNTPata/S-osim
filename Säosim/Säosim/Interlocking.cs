using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	public class Interlocking {

		//Constructor
		public Interlocking() {
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

			//Create 3 exit signals
			ExitSignal D = new ExitSignal();
			ExitSignal E = new ExitSignal();
			ExitSignal F = new ExitSignal();

			//Create 3 entry signals
			EntrySignal A = new EntrySignal(E);
			EntrySignal B = new EntrySignal(D);
			EntrySignal C = new EntrySignal();

			//Create distant signal
			DistSignal AFsi = new DistSignal(A);

			//Create road signal
			RoadSignal V1 = new RoadSignal();

			//Create road distant signal(s. There are actually two, but since they display the same aspect at all times, it is counted as one for simplicity)
			DistroadSignal V1Fsi = new DistroadSignal();

			#endregion
			#region routeInit
			//Create routes
			//Create arrival routes
			Route route_a1 = new Route(AFsi, A, switch1, switch6, D, B);
			Route route_a2 = new Route(AFsi, A, switch1, switch6, switch5, switch4, D, B, C, F, derail2);
			Route route_a3 = new Route(AFsi, A, switch1, switch6, switch5, switch4, D, B, C, F, derail2);
			Route route_b1 = new Route(B, switch2, E, derail2, V1Fsi, V1);
			Route route_b2 = new Route(B, switch2, switch4, switch5, E, C, F, derail2, V1Fsi, V1);
			Route route_b3 = new Route(B, switch2, switch4, switch5, E, C, F, derail2, V1Fsi, V1);
			Route route_c1 = new Route(C, switch6, switch5, switch1, switch4, B, F, derail2);
			Route route_c2 = new Route(C, switch6, switch5, switch1, switch4, B, F, derail2);

			//Create short arrival routes
			Route route_a2k = new Route(AFsi, A, switch1, switch6, switch5, D, C, F, derail2);
			Route route_a3k = new Route(AFsi, A, switch1, switch6, switch5, D, C, F, derail2);
			Route route_c1k = new Route(C, switch6, switch5, switch6, F, derail2);
			Route route_c2k = new Route(C, switch6, switch5, switch6, F, derail2);

			//Create departure routes
			Route route_d1 = new Route(D, switch1, switch6, A);
			Route route_d2 = new Route(D, switch5, switch6, switch1, A, C, F);
			Route route_d3 = new Route(D, switch5, switch6, switch1, A, C, F);
			Route route_e1 = new Route(E, switch2, B, derail2, V1Fsi, V1);
			Route route_e2 = new Route(E, switch4, switch2, B, derail2, V1Fsi, V1);
			Route route_e3 = new Route(E, switch4, switch2, B, derail2, V1Fsi, V1);
			Route route_f1 = new Route(F, switch5, switch6, switch1, C);
			Route route_f2 = new Route(F, switch5, switch6, switch1, C);

			//Create unmonitored route
			Route route_o1 = new Route(A, B, D, E, switch1, switch2, switch6, C, F, derail2, V1Fsi, V1);
			#endregion

		}

		class TrackCircuit {
			int occupationState = 0;
			//0 = Unoccupied, 1 = Reserved, 2 = Occupied
		}

		class Roadcrossing {

		}

		class Route { 
			#region Constructors
			//Overload for a1. 1 distant signal, 1 entry signal, 1 switch, 1 protected switch, 2 protected signals
			public Route(Signal includedDistSignal, Signal includedEntrySignal, Switch includeSwitch, Switch protectedSwitch, Signal protectedSignal1, Signal protectedSignal2) {
				includedSignals.Add(includedDistSignal);
				includedSignals.Add(includedEntrySignal);
				includedSwitches.Add(includeSwitch);
				protectedSwitches.Add(protectedSwitch);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
			}
			//Overload for a2/a3. 1 distant signal, 1 entry signal, 3 switches, 1 protected switch, 4 protected signals, 1 protected derail
			public Route(Signal includedDistSignal, Signal includedEntrySignal, Switch includeSwitch1, Switch includeSwitch2, Switch includeSwitch3, Switch protectedSwitch, Signal protectedSignal1, Signal protectedSignal2, Signal protectedSignal3, Signal protectedSignal4, Derail protectedDerail) {
				includedSignals.Add(includedDistSignal);
				includedSignals.Add(includedEntrySignal);
				includedSwitches.Add(includeSwitch1);
				includedSwitches.Add(includeSwitch2);
				includedSwitches.Add(includeSwitch3);
				protectedSwitches.Add(protectedSwitch);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedSignals.Add(protectedSignal3);
				protectedSignals.Add(protectedSignal4);
				protectedDerails.Add(protectedDerail);
			}
			//Overload for b1/e1. 1 entry or exit signal, 1 switch, 1 protected signal, 1 protected derail, 1 distant road signal, 1 road signal
			public Route(Signal includedSignal, Switch includeSwitch, Signal protectedSignal, Derail protectedDerail, Signal V1Fsi, Signal V1) {
				includedSignals.Add(includedSignal);
				includedSwitches.Add(includeSwitch);
				protectedSignals.Add(protectedSignal);
				protectedDerails.Add(protectedDerail);
				includedSignals.Add(V1Fsi);
				includedSignals.Add(V1);
			}
			//Overload for b2/b3. 1 entry signal, 3 switches, 3 protected signals, 1 protected derail, 1 distant road signal, 1 road signal
			public Route(Signal includedEntrySignal, Switch includeSwitch1, Switch includeSwitch2, Switch includeSwitch3, Signal protectedSignal1, Signal protectedSignal2, Signal protectedSignal3, Derail protectedDerail, Signal V1Fsi, Signal V1) {
				includedSignals.Add(includedEntrySignal);
				includedSwitches.Add(includeSwitch1);
				includedSwitches.Add(includeSwitch2);
				includedSwitches.Add(includeSwitch3);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedSignals.Add(protectedSignal3);
				protectedDerails.Add(protectedDerail);
				includedSignals.Add(V1Fsi);
				includedSignals.Add(V1);
			}
			//Overload for c1/c2. 1 entry signal, 2 switches, 2 protected switches, 2 protected signals, 1 protected derail
			public Route(Signal includedEntrySignal, Switch includeSwitch1, Switch includeSwitch2, Switch protectedSwitch1, Switch protectedSwitch2, Signal protectedSignal1, Signal protectedSignal2, Derail protectedDerail) {
				includedSignals.Add(includedEntrySignal);
				includedSwitches.Add(includeSwitch1);
				includedSwitches.Add(includeSwitch2);
				protectedSwitches.Add(protectedSwitch1);
				protectedSwitches.Add(protectedSwitch2);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedDerails.Add(protectedDerail);
			}
			//Overload for a2k/a3k. 1 distant signal, 1 entry signal, 3 switches, 3 protected signals, 1 protected derail
			public Route(Signal includedDistSignal, Signal includedEntrySignal, Switch includeSwitch1, Switch includeSwitch2, Switch includeSwitch3, Signal protectedSignal1, Signal protectedSignal2, Signal protectedSignal3, Derail protectedDerail) {
				includedSignals.Add(includedDistSignal);
				includedSignals.Add(includedEntrySignal);
				includedSwitches.Add(includeSwitch1);
				includedSwitches.Add(includeSwitch2);
				includedSwitches.Add(includeSwitch3);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedSignals.Add(protectedSignal3);
				protectedDerails.Add(protectedDerail);
			}
			//Overload for c1k/c2k. 1 entry signal, 2 switches, 1 protected switch, 1 protected signal, 1 protected derail
			public Route(Signal includedEntrySignal, Switch includeSwitch1, Switch includeSwitch2, Switch protectedSwitch, Signal protectedSignal, Derail protectedDerail) {
				includedSignals.Add(includedEntrySignal);
				includedSwitches.Add(includeSwitch1);
				includedSwitches.Add(includeSwitch2);
				protectedSwitches.Add(protectedSwitch);
				protectedSignals.Add(protectedSignal);
				protectedDerails.Add(protectedDerail);
			}
			//Overload for d1. 1 exit signal, 1 switch, 1 protected switch, 1 protected signal
			public Route(Signal includedExitSignal, Switch includeSwitch, Switch protectedSwitch, Signal protectedSignal) {
				includedSignals.Add(includedExitSignal);
				includedSwitches.Add(includeSwitch);
				protectedSwitches.Add(protectedSwitch);
				protectedSignals.Add(protectedSignal);
			}
			//Overload for d2/d3. 1 exit signal, 3 switches, 3 protected signals
			public Route(Signal includedExitSignal, Switch includeSwitch1, Switch includeSwitch2, Switch includeSwitch3, Signal protectedSignal1, Signal protectedSignal2, Signal protectedSignal3) {
				includedSignals.Add(includedExitSignal);
				includedSwitches.Add(includeSwitch1);
				includedSwitches.Add(includeSwitch2);
				includedSwitches.Add(includeSwitch3);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedSignals.Add(protectedSignal3);
			}
			//Overload for e2/e3. 1 exit signal, 2 switches, 1 protected signal, 1 protected derail, 1 distant road signal, 1 road signal
			public Route(Signal includedExitSignal, Switch includeSwitch1, Switch includeSwitch2, Signal protectedSignal, Derail protectedDerail, Signal V1Fsi, Signal V1) {
				includedSignals.Add(includedExitSignal);
				includedSwitches.Add(includeSwitch1);
				includedSwitches.Add(includeSwitch2);
				protectedSignals.Add(protectedSignal);
				protectedDerails.Add(protectedDerail);
				protectedSignals.Add(V1Fsi);
				protectedSignals.Add(V1);
			}
			//Overload for f1/f2. 1 exit signal, 2 switches, 1 protected switch, 1 protected signal
			public Route(Signal includedExitSignal, Switch includeSwitch1, Switch includeSwitch2, Switch protectedSwitch, Signal protectedSignal) {
				includedSignals.Add(includedExitSignal);
				includedSwitches.Add(includeSwitch1);
				includedSwitches.Add(includeSwitch2);
				protectedSwitches.Add(protectedSwitch);
				protectedSignals.Add(protectedSignal);
			}
			//Overload for o1. 2 entry signals, 2 exit signals, 2 switches, 1 protected switch, 2 protected signals, 1 protected derail, 1 distant road signal, 1 road signal
			public Route(Signal includedEntrySignal1, Signal includedEntrySignal2, Signal includedExitSignal1, Signal includedExitSignal2, Switch includeSwitch1, Switch includeSwitch2, Switch protectedSwitch, Signal protectedSignal1, Signal protectedSignal2, Derail protectedDerail, Signal V1Fsi, Signal V1) {
				includedSignals.Add(includedEntrySignal1);
				includedSignals.Add(includedEntrySignal2);
				includedSignals.Add(includedExitSignal1);
				includedSignals.Add(includedExitSignal2);
				includedSwitches.Add(includeSwitch1);
				includedSwitches.Add(includeSwitch2);
				protectedSwitches.Add(protectedSwitch);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedDerails.Add(protectedDerail);
				includedSignals.Add(V1Fsi);
				includedSignals.Add(V1);
			}

			#endregion

			bool routeLocked = false;
			List<Signal> includedSignals = new List<Signal>(); //Fill with the signals a train will pass in a specific route
			List<Switch> includedSwitches = new List<Switch>(); //Fill with the switches and signals a train will pass in a specific route
			List<Signal> protectedSignals = new List<Signal>(); //Fill with the signals that need to be protected/monitored in a specific route, but will not be passed by a train
			List<Switch> protectedSwitches = new List<Switch>(); //Fill with the switches that need to be locked but are not passed by a train
			List<Derail> protectedDerails = new List<Derail>(); //Fill with the derails that need to be locked in a specific route
		}
		
		
	}
}