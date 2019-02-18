using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
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

		//The goal is to make all of these private, and only have public methods that are used to manipulate/interate through these lists
		bool isLocked = false;
		List<Signal> includedSignals = new List<Signal>(); //Fill with the signals a train will pass in a specific route
		List<Switch> includedSwitches = new List<Switch>(); //Fill with the switches a train will pass in a specific route
		List<Signal> protectedSignals = new List<Signal>(); //Fill with the signals that need to be protected/monitored in a specific route, but will not be passed by a train
		List<Switch> protectedSwitches = new List<Switch>(); //Fill with the switches that need to be locked but are not passed by a train
		List<Derail> protectedDerails = new List<Derail>(); //Fill with the derails that need to be locked in a specific route

		//Call to lock route
		public bool LockRoute(string route) {
			//===============IMPORTANT===============
			//THESE LOOPS SHOULD NOT BE NESTED, THIS IS PROABLY RETARDED, FIX LATER
			//===============IMPORTANT===============
			foreach (Signal includedSignal in includedSignals) {
				//A signal which is to be passed must not be protected and must be set to stop
				if ((includedSignal.isProtected == false) && (includedSignal.signalState == 0)) {
					foreach (Signal protectedSignal in protectedSignals) {
						//If a signal is showing a green aspect of any kind, it cannot be set to protected, and thus the route cannot be locked
						if (protectedSignal.SetProtected()) {
							foreach (Switch includedSwitch in includedSwitches) {
								foreach (Switch protectedSwitch in protectedSwitches) {
									foreach (Derail protectedDerail in protectedDerails) {

									}
								}
							}
						} else {
							//Err: Signal som inte står i stopp hindrar tågvägslåsning
							return false;
						}


					}
				} else {
					//Route could not be set
					//Err: Signal som är låst i stopp hindrar tågvägslåsning
				}
			}
			return false;
		}

	}
}