using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Säosim {
	public abstract class Signal {

		public string displayName;
		public int protectionFactor = 0; //How many times the signal has been set to protected by different routes
		public int signalState = 0; //0 = Stop, 1 = Clear, 2 = Caution, 3 = Caution - Short route.

		public void SetStop() {
			signalState = 0;
		}

		public bool SetProtected() {
			if (signalState == 0) {
				protectionFactor++;
				return true;
			}
			return false;
		}

		public void SetUnprotected() {
			protectionFactor--;
		}

		#region Saving
		public string SavePos() {
			if (protectionFactor <= 0) {
				return Convert.ToString(signalState);
			}
			return "P" + Convert.ToString(protectionFactor);
		}

		public void ReadPos(string savedSignalState) {
			if (!savedSignalState.Contains("P"))
			{
				signalState = Convert.ToInt32(savedSignalState);
				protectionFactor = 0;
			} else {
				switch (savedSignalState) {
					case "P1":
						{
							signalState = 0;
							protectionFactor = 1;
							break;
						}
					case "P2":
						{
							signalState = 0;
							protectionFactor = 2;
							break;
						}
					case "P3":
						{
							signalState = 0;
							protectionFactor = 3;
							break;
						}
					default:
						{
							throw new ArgumentOutOfRangeException();
							break;
						}
				}
			}
		}
		#endregion
	}

	public class EntrySignal : Signal {

		#region Constructors
		public EntrySignal() { }
		public EntrySignal(string displayName) {
			this.displayName = displayName;
		}

		public EntrySignal(ExitSignal referenceSignal, string displayName) {
			this.displayName = displayName;
			switch (referenceSignal.signalState) {
				case 0: {
						//Grön blink
						break;
					}
				case 1: {
						//Vit blink
						break;
					}
				case 2: {
						//Två gröna blinkar
						break;
					}
				case 3: {
						//Två gröna blinkar
						break;
					}
				default: {
						//Grön blink
						break;
					}
			}
		}
		#endregion

		public bool SetClear() {
			if (protectionFactor == 0) {
				signalState = 1;
				return true;
			}
			return false;
		}

		public bool SetCaution() {
			if (protectionFactor == 0) {
				signalState = 2;
				return true;
			}
			return false;
		}

		public bool SetCautionShort() {
			if (protectionFactor == 0) {
				signalState = 3;
				return true;
			}
			return false;
		}
	}

	public class ExitSignal : Signal {

		public ExitSignal(string displayName) {
			this.displayName = displayName;
		}

		public bool SetClear() {
			if (protectionFactor == 0) {
				signalState = 1;
				return true;
			}
			return false;
		}
	}

	public class DistSignal : Signal {
		public DistSignal(EntrySignal referenceSignal, string displayName) {
			this.displayName = displayName;
		}
		//nextSignal = ??? Fill with the signal that this signal will refer to when it acts as a distant signal
	}

	public class RoadSignal : Signal {

		public RoadSignal(string displayName) {
			this.displayName = displayName;
		}
		public void SetClear() {
			signalState = 1;
		}
	}

	public class DistroadSignal : Signal {
		public DistroadSignal(RoadSignal referenceSignal, string displayName) {
			signalState = referenceSignal.signalState;
			this.displayName = displayName;
		}
		//nextSignal = ??? Fill with the signal that this signal will refer to when it acts as a distant signal
	}
}
