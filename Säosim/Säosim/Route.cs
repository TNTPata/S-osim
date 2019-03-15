using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	public class Route {
		#region Constructors
		///The components that go into a route are named in a comment above each constructor. 
		///It is sometimes needed to specify which route to use, this occurs when two routes use exactly 
		///the same components in a route but when the switches are to be locked in different states.
		///Some routes also don't specify the state of a switch when it is entered as an argument into the constructor, 
		///this is because the state can vary depending on which specific route is picked.
		
		//Overload for a1. 1 distant signal, 1 entry signal, 1 switch, 1 protected switch, 2 protected signals
		public Route(DistSignal includedDistSignal, EntrySignal includedEntrySignal, Switch includeStraightSwitch, Switch protectedStraightSwitch, Signal protectedSignal1, Signal protectedSignal2) {
			includedSignals.Add(includedDistSignal);
			includedSignals.Add(includedEntrySignal);
			straightSwitches.Add(includeStraightSwitch);
			straightSwitches.Add(protectedStraightSwitch);
			protectedSignals.Add(protectedSignal1);
			protectedSignals.Add(protectedSignal2);
		}
		//Overload for a2/a3. 1 distant signal, 1 entry signal, 3 switches, 1 protected switch, 4 protected signals, 1 protected derail
		//Because of ambiguity reasons, the specific route needs to be specified to ensure that switches get locked in correct positions
		public Route(int variant, DistSignal includedDistSignal, EntrySignal includedEntrySignal, Switch includeCurveSwitch1, Switch includeCurveSwitch2, Switch includeSwitch3, Switch protectedSwitch, Signal protectedSignal1, Signal protectedSignal2, Signal protectedSignal3, Signal protectedSignal4, Derail protectedLoweredDerail) {
			if (variant == 2) {
				includedSignals.Add(includedDistSignal);
				includedSignals.Add(includedEntrySignal);
				curvedSwitches.Add(includeCurveSwitch1);
				curvedSwitches.Add(includeCurveSwitch2);
				straightSwitches.Add(includeSwitch3);
				straightSwitches.Add(protectedSwitch);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedSignals.Add(protectedSignal3);
				protectedSignals.Add(protectedSignal4);
				loweredDerails.Add(protectedLoweredDerail);
			} else if (variant == 3) {
				includedSignals.Add(includedDistSignal);
				includedSignals.Add(includedEntrySignal);
				curvedSwitches.Add(includeCurveSwitch1);
				curvedSwitches.Add(includeCurveSwitch2);
				curvedSwitches.Add(includeSwitch3);
				curvedSwitches.Add(protectedSwitch);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedSignals.Add(protectedSignal3);
				protectedSignals.Add(protectedSignal4);
				loweredDerails.Add(protectedLoweredDerail);
			}
		}
		//Overload for b1/e1. 1 entry OR exit signal, 1 switch, 1 protected signal, 1 protected derail, 1 distant road signal, 1 road signal
		//Note that the specific route is picked automagically, and there is no need to specify which route that should be used
		public Route(Signal includedSignal, Switch includeStraightSwitch, Signal protectedSignal, Derail protectedRaisedDerail, DistroadSignal V1Fsi, RoadSignal V1) {
			includedSignals.Add(includedSignal);
			straightSwitches.Add(includeStraightSwitch);
			protectedSignals.Add(protectedSignal);
			raisedDerails.Add(protectedRaisedDerail);
			includedSignals.Add(V1Fsi);
			includedSignals.Add(V1);
		}
		//Overload for b2/b3. 1 entry signal, 3 switches, 3 protected signals, 1 protected derail, 1 distant road signal, 1 road signal
		//Because of ambiguity reasons, the specific route needs to be specified to ensure that switches get locked in correct positions
		public Route(int variant, Signal includedEntrySignal, Switch includeCurveSwitch1, Switch includeSwitch2, Switch includeSwitch3, Signal protectedSignal1, Signal protectedSignal2, Signal protectedSignal3, Derail protectedLoweredDerail, DistroadSignal V1Fsi, RoadSignal V1) {
			if (variant == 2) {
				includedSignals.Add(includedEntrySignal);
				curvedSwitches.Add(includeCurveSwitch1);
				straightSwitches.Add(includeSwitch2);
				straightSwitches.Add(includeSwitch3);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedSignals.Add(protectedSignal3);
				loweredDerails.Add(protectedLoweredDerail);
				includedSignals.Add(V1Fsi);
				includedSignals.Add(V1);
			} else if (variant == 3) {
				includedSignals.Add(includedEntrySignal);
				curvedSwitches.Add(includeCurveSwitch1);
				curvedSwitches.Add(includeSwitch2);
				curvedSwitches.Add(includeSwitch3);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedSignals.Add(protectedSignal3);
				loweredDerails.Add(protectedLoweredDerail);
				includedSignals.Add(V1Fsi);
				includedSignals.Add(V1);
			}

		}
		//Overload for c1/c2. 1 entry signal, 2 switches, 2 protected switches, 2 protected signals, 1 protected derail
		//Because of ambiguity reasons, the specific route needs to be specified to ensure that switches get locked in correct positions
		public Route(int variant, EntrySignal includedEntrySignal, Switch includeStraightSwitch1, Switch includeSwitch2, Switch protectedStraightSwitch1, Switch protectedSwitch2, Signal protectedSignal1, Signal protectedSignal2, Derail protectedLoweredDerail) {
			if (variant == 1) {
				includedSignals.Add(includedEntrySignal);
				straightSwitches.Add(includeStraightSwitch1);
				straightSwitches.Add(includeSwitch2);
				straightSwitches.Add(protectedStraightSwitch1);
				straightSwitches.Add(protectedSwitch2);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				loweredDerails.Add(protectedLoweredDerail);
			} else if (variant == 2) {
				includedSignals.Add(includedEntrySignal);
				straightSwitches.Add(includeStraightSwitch1);
				curvedSwitches.Add(includeSwitch2);
				straightSwitches.Add(protectedStraightSwitch1);
				curvedSwitches.Add(protectedSwitch2);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				loweredDerails.Add(protectedLoweredDerail);
			}
		}
		//Overload for a2k/a3k. 1 distant signal, 1 entry signal, 3 switches, 3 protected signals, 1 protected derail
		//Because of ambiguity reasons, the specific route needs to be specified to ensure that switches get locked in correct positions
		public Route(int variant, DistSignal includedDistSignal, EntrySignal includedEntrySignal, Switch includeCurveSwitch1, Switch includeCurveSwitch2, Switch includeSwitch3, Signal protectedSignal1, Signal protectedSignal2, Signal protectedSignal3, Derail protectedRaisedDerail) {
			if (variant == 2) {
				includedSignals.Add(includedDistSignal);
				includedSignals.Add(includedEntrySignal);
				curvedSwitches.Add(includeCurveSwitch1);
				curvedSwitches.Add(includeCurveSwitch2);
				straightSwitches.Add(includeSwitch3);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedSignals.Add(protectedSignal3);
				raisedDerails.Add(protectedRaisedDerail);
			}
			else if (variant == 3) {
				includedSignals.Add(includedDistSignal);
				includedSignals.Add(includedEntrySignal);
				curvedSwitches.Add(includeCurveSwitch1);
				curvedSwitches.Add(includeCurveSwitch2);
				curvedSwitches.Add(includeSwitch3);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedSignals.Add(protectedSignal3);
				raisedDerails.Add(protectedRaisedDerail);
			}
		}
		//Overload for c1k/c2k. 1 entry signal, 2 switches, 1 protected switch, 1 protected signal, 1 protected derail
		//Because of ambiguity reasons, the specific route needs to be specified to ensure that switches get locked in correct positions
		public Route(int variant, EntrySignal includedEntrySignal, Switch includeStraightSwitch1, Switch includeSwitch2, Switch protectedStraightSwitch, Signal protectedSignal, Derail protectedRaisedDerail) {
			if (variant == 1) {
				includedSignals.Add(includedEntrySignal);
				straightSwitches.Add(includeStraightSwitch1);
				straightSwitches.Add(includeSwitch2);
				straightSwitches.Add(protectedStraightSwitch);
				protectedSignals.Add(protectedSignal);
				raisedDerails.Add(protectedRaisedDerail);
			} else if (variant == 2) {
				includedSignals.Add(includedEntrySignal);
				straightSwitches.Add(includeStraightSwitch1);
				curvedSwitches.Add(includeSwitch2);
				straightSwitches.Add(protectedStraightSwitch);
				protectedSignals.Add(protectedSignal);
				raisedDerails.Add(protectedRaisedDerail);
			}
		}
		//Overload for d1. 1 exit signal, 1 switch, 1 protected switch, 1 protected signal
		public Route(ExitSignal includedExitSignal, Switch includeStraightSwitch, Switch protectedStraightSwitch, Signal protectedSignal) {
			includedSignals.Add(includedExitSignal);
			straightSwitches.Add(includeStraightSwitch);
			straightSwitches.Add(protectedStraightSwitch);
			protectedSignals.Add(protectedSignal);
		}
		//Overload for d2/d3. 1 exit signal, 3 switches, 3 protected signals
		//Because of ambiguity reasons, the specific route needs to be specified to ensure that switches get locked in correct positions
		public Route(int variant, ExitSignal includedExitSignal, Switch includeSwitch1, Switch includeCurveSwitch2, Switch includeCurveSwitch3, Signal protectedSignal1, Signal protectedSignal2, Signal protectedSignal3) {
			if (variant == 2) {
				includedSignals.Add(includedExitSignal);
				straightSwitches.Add(includeSwitch1);
				curvedSwitches.Add(includeCurveSwitch2);
				curvedSwitches.Add(includeCurveSwitch3);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedSignals.Add(protectedSignal3);
			} else if (variant == 3) {
				includedSignals.Add(includedExitSignal);
				curvedSwitches.Add(includeSwitch1);
				curvedSwitches.Add(includeCurveSwitch2);
				curvedSwitches.Add(includeCurveSwitch3);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				protectedSignals.Add(protectedSignal3);
			}
		}
		//Overload for e2/e3. 1 exit signal, 2 switches, 1 protected signal, 1 protected derail, 1 distant road signal, 1 road signal
		//Because of ambiguity reasons, the specific route needs to be specified to ensure that switches get locked in correct positions
		public Route(int variant, ExitSignal includedExitSignal, Switch includeSwitch1, Switch includeCurveSwitch2, Signal protectedSignal, Derail protectedLoweredDerail, DistroadSignal V1Fsi, RoadSignal V1) {
			if (variant == 2) {
				includedSignals.Add(includedExitSignal);
				straightSwitches.Add(includeSwitch1);
				curvedSwitches.Add(includeCurveSwitch2);
				protectedSignals.Add(protectedSignal);
				loweredDerails.Add(protectedLoweredDerail);
				protectedSignals.Add(V1Fsi);
				protectedSignals.Add(V1);
			} else if (variant == 3) {
				includedSignals.Add(includedExitSignal);
				curvedSwitches.Add(includeSwitch1);
				curvedSwitches.Add(includeCurveSwitch2);
				protectedSignals.Add(protectedSignal);
				loweredDerails.Add(protectedLoweredDerail);
				protectedSignals.Add(V1Fsi);
				protectedSignals.Add(V1);
			}
		}
		//Overload for f1/f2. 1 exit signal, 2 switches, 1 protected switch, 1 protected signal
		//Because of ambiguity reasons, the specific route needs to be specified to ensure that switches get locked in correct positions
		public Route(int variant, ExitSignal includedExitSignal, Switch includeSwitch1, Switch includeStraightSwitch2, Switch protectedStraightSwitch, Signal protectedSignal) {
			if (variant == 1) {
				includedSignals.Add(includedExitSignal);
				straightSwitches.Add(includeSwitch1);
				straightSwitches.Add(includeStraightSwitch2);
				straightSwitches.Add(protectedStraightSwitch);
				protectedSignals.Add(protectedSignal);
			} else if (variant == 2) {
				includedSignals.Add(includedExitSignal);
				curvedSwitches.Add(includeSwitch1);
				straightSwitches.Add(includeStraightSwitch2);
				straightSwitches.Add(protectedStraightSwitch);
				protectedSignals.Add(protectedSignal);
			}
		}
		//Overload for o1. 2 entry signals, 2 exit signals, 2 switches, 1 protected switch, 2 protected signals, 1 protected derail, 1 distant road signal, 1 road signal
		public Route(EntrySignal includedEntrySignal1, EntrySignal includedEntrySignal2, ExitSignal includedExitSignal1, ExitSignal includedExitSignal2, Switch includeStraightSwitch1, Switch includeStraightSwitch2, Switch protectedStraightSwitch, Signal protectedSignal1, Signal protectedSignal2, Derail protectedRaisedDerail, DistroadSignal V1Fsi, RoadSignal V1) {
			includedSignals.Add(includedEntrySignal1);
			includedSignals.Add(includedEntrySignal2);
			includedSignals.Add(includedExitSignal1);
			includedSignals.Add(includedExitSignal2);
			straightSwitches.Add(includeStraightSwitch1);
			straightSwitches.Add(includeStraightSwitch2);
			straightSwitches.Add(protectedStraightSwitch);
			protectedSignals.Add(protectedSignal1);
			protectedSignals.Add(protectedSignal2);
			raisedDerails.Add(protectedRaisedDerail);
			includedSignals.Add(V1Fsi);
			includedSignals.Add(V1);
		}
		#endregion

		bool isLocked = false;
		private List<Signal> includedSignals = new List<Signal>(); //Fill with the signals a train will pass in a specific route
		private List<Signal> protectedSignals = new List<Signal>(); //Fill with the signals that need to be protected/monitored in a specific route, but will not be passed by a train
		private List<Switch> straightSwitches = new List<Switch>(); //Fill with the switches that need to be locked straight for a route
		private List<Switch> curvedSwitches = new List<Switch>(); //Fill with the switches that need to be locked curved for a route
		private List<Derail> raisedDerails = new List<Derail>(); //Fill with the derails that need to be locked raised for a route
		private List<Derail> loweredDerails = new List<Derail>(); //Fill with the derails that need to be locked lowered for a route

		//Call to lock route
		//REMINDER: THIS METHOD IS ONLY FOR LOCKING OBJECTS, NO "MOVE" METHODS ARE TO BE CALLED FROM HERE
		public bool LockRoute() {
			///First two loops check if all relevant signals and signalstates are correct
			///Second two loops check if all relevant switches are in correct position
			///Last two loops checks if all relevant derails are in correct position
			///
			foreach (Signal includedSignal in includedSignals) {
				//A signal which is to be passed must not be protected and must be set to stop
				if ((includedSignal.isProtected == false) && (includedSignal.signalState == 0)) {
					
				}
				else {
					Debug.WriteLine("Signal som är förreglad i stopp eller står i kör hindrar tågvägslåsning");
					return false;
				}
			}
			foreach (Signal protectedSignal in protectedSignals) {
				//If a signal is showing a green aspect of any kind, it cannot be set to protected, and thus the route cannot be locked
				if (protectedSignal.SetProtected()) {

				}
				else {
					Debug.WriteLine("Signal som inte står i stopp hindrar tågvägslåsning.");
					return false;
				}
			}
			foreach (Switch straightSwitch in straightSwitches) {
				if (straightSwitch.IsStraightTrack) {
					if (straightSwitch.LockSwitch()) {
						//This means that the switch is straight and LockSwitch has been returned successfully
					} else { Debug.WriteLine(straightSwitch.displayName + " ligger rätt men går inte att låsa."); return false; }
				}
				else
				{
					Debug.WriteLine(straightSwitch.displayName + " ligger fel för denna tågväg.");
					return false;
				}
			}
			foreach (Switch curveSwitch in curvedSwitches) {
				if (curveSwitch.IsCurvedTrack) {
					if (curveSwitch.LockSwitch()) {
						//This means that the switch is curved and LockSwitch has been returned successfully
					} else { Debug.WriteLine(curveSwitch.displayName + " ligger rätt men går inte att låsa."); return false; }
				}
				else {
					Debug.WriteLine(curveSwitch.displayName + " ligger fel för denna tågväg.");
					return false;
				}
			}
			foreach (Derail raisedDerail in raisedDerails) {
				if (raisedDerail.IsRaised) {
					if (raisedDerail.LockDerail()) {
						//This means that the derail is raised and LockDerail has been returned successfully
					} else { Debug.WriteLine(raisedDerail.displayName + " ligger rätt men går inte att låsa."); return false; }
				}
				else {
					Debug.WriteLine(raisedDerail.displayName + " ligger fel för denna tågväg.");
					return false;
				}
			}
			foreach (Derail loweredDerail in loweredDerails) {
				if (loweredDerail.IsRaised) {
					if (loweredDerail.LockDerail()) {
						//This means that the derail is lowered and LockDerail has been returned successfully
					} else { Debug.WriteLine(loweredDerail.displayName + " ligger rätt men går inte att låsa."); return false; }
				}
				else {
					Debug.WriteLine(loweredDerail.displayName + " ligger fel för denna tågväg.");
					return false;
				}
			}
			//All objects are locked in their correct positions
			return true;
		}
	}
}