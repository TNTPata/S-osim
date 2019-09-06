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


		//Overload for a1. 1 entry signal, 1 protected signal, (2 forbidden routes), 1 switch, 1 protected switch
		public Route(EntrySignal includedEntrySignal, Signal protectedSignal, Switch includedStraightSwitch, Switch protectedStraightSwitch, string displayName) {
			this.displayName = displayName;
			includedSignals.Add(includedEntrySignal);
			protectedSignals.Add(protectedSignal);
			straightSwitches.Add(includedStraightSwitch);
			straightSwitches.Add(protectedStraightSwitch);
		}

		//Overload for a2/a3. 1 entry signal, 2 protected signals, (2 forbidden routes), 3 switches
		//Because the routes use the same objects, the specific route needs to be selected to ensure objects are locked in their correct positions 
		public Route(int variant, EntrySignal includedEntrySignal, Signal protectedSignal1, Signal protectedSignal2, Switch includedSwitch1, Switch includedSwitch2, Switch includedSwitch3, string displayName) {
			if (variant == 2) {
				this.displayName = displayName;
				includedSignals.Add(includedEntrySignal);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				curvedSwitches.Add(includedSwitch1);
				straightSwitches.Add(includedSwitch2);
				curvedSwitches.Add(includedSwitch3);
			} else if (variant == 3) {
				this.displayName = displayName;
				includedSignals.Add(includedEntrySignal);
				protectedSignals.Add(protectedSignal1);
				protectedSignals.Add(protectedSignal2);
				curvedSwitches.Add(includedSwitch1);
				curvedSwitches.Add(includedSwitch2);
				curvedSwitches.Add(includedSwitch3);
			}
		}

		//Overload for b1/b2. 1 entry signal, (3 forbidden routes), 3 switches
		//Because the routes use the same objects, the specific route needs to be selected to ensure objects are locked in their correct positions 
		public Route(int variant, EntrySignal includedEntrySignal, Switch includedSwitch1, Switch includedSwitch2, Switch includedSwitch3, string displayName) {
			if (variant == 1) {
				this.displayName = displayName;
				includedSignals.Add(includedEntrySignal);
				straightSwitches.Add(includedSwitch1);
				straightSwitches.Add(includedSwitch2);
				straightSwitches.Add(includedSwitch3);
			} else if (variant == 2) {
				this.displayName = displayName;
				includedSignals.Add(includedEntrySignal);
				straightSwitches.Add(includedSwitch1);
				curvedSwitches.Add(includedSwitch2);
				straightSwitches.Add(includedSwitch3);
			}
		}

		//Overload for c1. 1 entry signal, 1 protected signal, (1 forbidden route), 1 switch, 1 derail, 1 road signal
		public Route(EntrySignal includedEntrySignal, Signal protectedSignal, Switch includedSwitch, Derail includedDerail, RoadSignal includedRoadSignal, string displayName) {
			this.displayName = displayName;
			includedSignals.Add(includedEntrySignal);
			protectedSignals.Add(protectedSignal);
			straightSwitches.Add(includedSwitch);
			raisedDerails.Add(includedDerail);
			includedSignals.Add(includedRoadSignal);
		}

		//Overload for c2/c3. 1 entry signal, 1 protected signal, (2 forbidden routes), 2 switches, 1 derail, 1 road signal
		//Because the routes use the same objects, the specific route needs to be selected to ensure objects are locked in their correct positions 
		public Route(int variant, EntrySignal includedEntrySignal, Signal protectedSignal, Switch includedSwitch1, Switch includedSwitch2, Derail includedDerail, RoadSignal includedRoadSignal, string displayName) {
			if (variant == 2) {
				this.displayName = displayName;
				includedSignals.Add(includedEntrySignal);
				protectedSignals.Add(protectedSignal);
				curvedSwitches.Add(includedSwitch1);
				straightSwitches.Add(includedSwitch2);
				loweredDerails.Add(includedDerail);
				includedSignals.Add(includedRoadSignal);
			} else if (variant == 3) {
				this.displayName = displayName;
				includedSignals.Add(includedEntrySignal);
				protectedSignals.Add(protectedSignal);
				curvedSwitches.Add(includedSwitch1);
				curvedSwitches.Add(includedSwitch2);
				loweredDerails.Add(includedDerail);
				includedSignals.Add(includedRoadSignal);
			}
		}

		//Overload for d1/d2/d3. 1 exit signal, 1 protected signal, 1 switch, 1 derail, 1 road signal
		//Because the routes use the same objects, the specific route needs to be selected to ensure objects are locked in their correct positions
		public Route(int variant, ExitSignal includedExitSignal, Signal protectedSignal, Switch includedSwitch, Derail includedDerail, Signal includedRoadSignal, string displayName) {
			if (variant == 1) {
				this.displayName = displayName;
				includedSignals.Add(includedExitSignal);
				protectedSignals.Add(protectedSignal);
				straightSwitches.Add(includedSwitch);
				raisedDerails.Add(includedDerail);
				includedSignals.Add(includedRoadSignal);
			} else if (variant == 2) {
				this.displayName = displayName;
				includedSignals.Add(includedExitSignal);
				protectedSignals.Add(protectedSignal);
				curvedSwitches.Add(includedSwitch);
				loweredDerails.Add(includedDerail);
				includedSignals.Add(includedRoadSignal);
			}
		}

		//Overload for e1. 1 protected signal, 2 switches
		public Route(Signal protectedSignal, Switch includedSwitch1, Switch includedSwitch2, string displayName) {
			this.displayName = displayName;
			protectedSignals.Add(protectedSignal);
			straightSwitches.Add(includedSwitch1);
			straightSwitches.Add(includedSwitch2);
		}

		//Overload for e2. 1 exit signal, 2 protected signals, (2 forbidden routes), 2 switches
		public Route(ExitSignal includedExitSignal, Signal protectedSignal1, Signal protectedSignal2, Switch includedSwitch1, Switch includedSwitch2, string displayName) {
			this.displayName = displayName;
			includedSignals.Add(includedExitSignal);
			protectedSignals.Add(protectedSignal1);
			protectedSignals.Add(protectedSignal2);
			curvedSwitches.Add(includedSwitch1);
			curvedSwitches.Add(includedSwitch2);
		}

		//Overload for F. 1 exit signal, 1 protected signal
		public Route(ExitSignal includedExitSignal, Signal protectedSignal, string displayName) {
			this.displayName = displayName;
			includedSignals.Add(includedExitSignal);
			protectedSignals.Add(protectedSignal);
		}

		//Overload for o1. 4 signals, 1 protected signal, 3 switches, 1 derail, 1 road signal
		public Route(EntrySignal A, EntrySignal C, ExitSignal D, ExitSignal F, EntrySignal B, Switch includedSwitch1, Switch includedSwitch2, Switch includedSwitch3, Derail includedDerail, RoadSignal includedRoadSignal, string displayName) {
			this.displayName = displayName;
			includedSignals.Add(A);
			includedSignals.Add(C);
			includedSignals.Add(D);
			includedSignals.Add(F);
			straightSwitches.Add(includedSwitch1);
			straightSwitches.Add(includedSwitch2);
			straightSwitches.Add(includedSwitch3);
			raisedDerails.Add(includedDerail);
			includedSignals.Add(includedRoadSignal);
		}
		#endregion

		public bool isLocked { get; private set; } = false;
		public string displayName;

		private List<Signal> includedSignals = new List<Signal>(); //Fill with the signals a train will pass in a specific route
		private List<Signal> protectedSignals = new List<Signal>(); //Fill with the signals that need to be protected/monitored in a specific route, but will not be passed by a train
		private List<Switch> straightSwitches = new List<Switch>(); //Fill with the switches that need to be locked straight for a route
		private List<Switch> curvedSwitches = new List<Switch>(); //Fill with the switches that need to be locked curved for a route
		private List<Derail> raisedDerails = new List<Derail>(); //Fill with the derails that need to be locked raised for a route
		private List<Derail> loweredDerails = new List<Derail>(); //Fill with the derails that need to be locked lowered for a route

		public List<Route> forbiddenRoutes = new List<Route>(); //Fill with the routes that are forbidden for a specific route

		//Call to lock route
		//REMINDER: THIS METHOD IS ONLY FOR LOCKING OBJECTS, NO "MOVE" METHODS ARE TO BE CALLED FROM HERE
		public bool LockRoute() {

			if (isLocked) {
				Debug.WriteLine("[SIM/WARN] Tågväg " + displayName + " är redan låst.");
				return false;
			}

			foreach (Route forbiddenRoute in forbiddenRoutes) {
				if (forbiddenRoute.isLocked) {
					Debug.WriteLine("[SIM/WARN] Tågväg " + forbiddenRoute.displayName + " är redan låst och tillåter inte att tågväg " + displayName + " är låst samtidigt");
					return false;
				}
			}

			

			///Locking of all objects is done in two loops.
			///The first loop makes sure that everything is positioned correctly and that everything is unlocked.
			///The second loop actually completes the locking.
			///If the slightest thing doesn't meet a criteria, the process is aborted and things that are locked are unlocked. 

			//TODO: Write comments on locking of signals
			#region Control signals
			foreach (Signal protectedSignal in protectedSignals) {
				//If a signal is showing a green aspect of any kind, it cannot be set to protected, and thus the route cannot be locked
				if (protectedSignal.signalState == 0) {

				}
				else {
					Debug.WriteLine("[SIM/WARN] Signal " + protectedSignal.displayName + " som inte står i stopp hindrar tågvägslåsning.");
					return false;
				}
			}
			foreach (Signal includedSignal in includedSignals) {
				//A signal which is to be passed must not be protected and must be set to stop
				if ((includedSignal.protectionFactor == 0) && (includedSignal.signalState == 0)) {

				}
				else {
					Debug.WriteLine("[SIM/WARN] Signal " + includedSignal.displayName + " som är förreglad i stopp eller står i kör hindrar tågvägslåsning");
					return false;
				}
			}
			#endregion
			#region Control objects
			//Check if all objects are in their correct position
			foreach (Switch straightSwitch in straightSwitches) {
				if (straightSwitch.IsStraightTrack) {
                    //Switch is in correct position, the process can continue
                }
				else {
					Debug.WriteLine("[SIM/WARN] " + straightSwitch.displayName + " ligger fel för denna tågväg.");
					return false;
				}
			}
			foreach (Switch curveSwitch in curvedSwitches) {
				if (curveSwitch.IsCurvedTrack) {
					//Switch is in correct position, the process can continue
				}
				else {
					Debug.WriteLine("[SIM/WARN] " + curveSwitch.displayName + " ligger fel för denna tågväg.");
					return false;
				}
			}
			foreach (Derail raisedDerail in raisedDerails) {
				if (raisedDerail.IsRaised) {
					//Derail is in correct position, the process can continue
				}
				else {
					Debug.WriteLine("[SIM/WARN] " + raisedDerail.displayName + " ligger fel för denna tågväg.");
					return false;
				}
			}
			foreach (Derail loweredDerail in loweredDerails) {
				if (loweredDerail.IsLowered) {
					//Derail is in correct position, the process can continue
				}
				else {
					Debug.WriteLine("[SIM/WARN] " + loweredDerail.displayName + " ligger fel för denna tågväg.");
					return false;
				}
			}
			#endregion
			
			#region Lock Signals
			foreach (Signal protectedSignal in protectedSignals) {
				//If a signal is showing a green aspect of any kind, it cannot be set to protected, and thus the route cannot be locked
				if (protectedSignal.SetProtected()) {

				}
				else {
					Debug.WriteLine("[SIM/WARN] Signal " + protectedSignal.displayName + " kunde inte förreglas");
					UnlockRoute();
					return false;
				}
			}
			foreach (Signal includedSignal in includedSignals) {
				//A signal which is to be passed must not be protected and must be set to stop
				if ((includedSignal.protectionFactor == 0) && (includedSignal.signalState == 0)) {

				}
				else {
					Debug.WriteLine("[SIM/WARN] Signal " + includedSignal.displayName + " som är förreglad i stopp eller står i kör hindrar tågvägslåsning");
					return false;
				}
			}
			#endregion
			#region Lock Objects
			//Lock objects to positions checked above
			foreach (Switch straightSwitch in straightSwitches)
			{
				if (straightSwitch.LockSwitch())
				{

				}
				else
				{
					Debug.WriteLine("[SIM/WARN] " + straightSwitch.displayName + " kunde inte låsas (Okänd anledning).");
					UnlockRoute();
					return false;
				}
			}
			foreach (Switch curveSwitch in curvedSwitches)
			{
				if (curveSwitch.LockSwitch())
				{

				}
				else
				{
					Debug.WriteLine("[SIM/WARN] " + curveSwitch.displayName + " kunde inte låsas (Okänd anledning).");
					UnlockRoute();
					return false;
				}
			}
			foreach (Derail raisedDerail in raisedDerails)
			{
				if (raisedDerail.LockDerail())
				{

				}
				else
				{
					Debug.WriteLine("[SIM/WARN] " + raisedDerail.displayName + " kunde inte låsas (Okänd anledning).");
					UnlockRoute();
					return false;
				}
			}
			foreach (Derail loweredDerail in loweredDerails)
			{
				if (loweredDerail.LockDerail())
				{

				}
				else
				{
					Debug.WriteLine("[SIM/WARN] " + loweredDerail.displayName + " kunde inte låsas (Okänd anledning).");
					UnlockRoute();
					return false;
				}
			}

			#endregion

			//All objects are locked in their correct positions
			isLocked = true;
			return true;
		}

		//Call to unlock route
		public bool UnlockRoute() {
			///Function similar to LockRoute(), but the only action taken is to unlock the relevant objects
			foreach (Signal protectedSignal in protectedSignals) {
				protectedSignal.SetUnprotected();
			}
			foreach (Switch straightSwitch in straightSwitches) {
				straightSwitch.UnlockSwitch();
			}
			foreach (Switch curveSwitch in curvedSwitches) {
				curveSwitch.UnlockSwitch();
			}
			foreach (Derail raisedDerail in raisedDerails) {
				raisedDerail.UnlockDerail();
			}
			foreach (Derail loweredDerail in loweredDerails) {
				loweredDerail.UnlockDerail();
			}
			//All objects have been unlocked
			isLocked = false;
			return true;
		}

		#region Saving
		public string SavePos() {
			if (isLocked) {
				return "L";
			}
			else {
				return "U";
			}
		}

		public void ReadPos(string savedLockedState) {
			isLocked = savedLockedState == "L" ? true : false;
		}
		#endregion
	}
}