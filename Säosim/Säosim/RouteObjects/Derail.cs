﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	public class Derail {

		//Takes in a name to display for debugging/user experience purposes
		public Derail(string displayName) {
			this.displayName = displayName;
			IsRaised = true;
			IsLowered = false;
			IsLocked = false;
		}

		#region Fields
		public string displayName;
		private bool isMoving = false;
		#endregion

		#region Properties
		public bool IsLowered { get; private set; }
		public bool IsRaised { get; private set; }
		public bool IsLocked { get; private set; }
		#endregion

		#region Methods
		public bool Lower() {
			if (IsLocked == false) {
				isMoving = true;
				IsRaised = false;
				Thread.Sleep(2500);
				IsLowered = true;
				isMoving = false;
				Debug.WriteLine(displayName + " i avlagt läge.");
				return true;
			}
			else { Debug.WriteLine(displayName + " är förreglad i en tågväg"); return false; }
		}

		public bool Raise() {
			if (IsLocked == false) {
				isMoving = true;
				IsLowered = false;
				Thread.Sleep(2500);
				IsRaised = true;
				isMoving = false;
				Debug.WriteLine(displayName + " i pålagt läge.");
				return true;
			}
			else { Debug.WriteLine(displayName + " är förreglad i en tågväg"); return false; }
		}

		public bool LockDerail() {
			if ((IsLocked == false) && (isMoving == false)) {
				IsLocked = true;
				Debug.WriteLine(displayName + " låst");
				return true;
			}
			else { return false; }
		}

		public void UnlockDerail() {
			IsLocked = false;
			Debug.WriteLine(displayName + " upplåst");
		}

		#region Saving
		public string SavePos() {
			if (IsLocked) {
				if (IsRaised) {
					return "LR";
				}
				else {
					return "LL";
				}
			}
			else {
				if (IsRaised) {
					return "UR";
				}
				else {
					return "UL";
				}
			}
		}

		public void ReadPos(string savedPosition) {
			switch (savedPosition) {
				case "LR": {
						IsLocked = true;
						IsRaised = true;
						IsLowered = false;
						break;
					}
				case "LL": {
						IsLocked = true;
						IsRaised = false;
						IsLowered = true;
						break;
					}
				case "UR": {
						IsLocked = false;
						IsRaised = true;
						IsLowered = false;
						break;
					}
				case "UL": {
						IsLocked = false;
						IsRaised = false;
						IsLowered = true;
						break;
					}
				default: {
						Console.WriteLine("Error for " + displayName + ". Tried to inject " + savedPosition + " in ReadPos().");
						break;
					}
			}
		}
		#endregion

		#endregion
	}
}
