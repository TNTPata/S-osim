﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	public class Signal {


		public bool isProtected = false;
		public int signalState = 0;
		//0 = Stop, 1 = Clear, 2 = Caution, 3 = Caution - Short route.

		public void SetStop() {
			signalState = 0;
		}

		public bool SetProtected() {
			if (signalState == 0) {
				isProtected = true;
				return true;
			} else { return false; }
		}

		public void SetUnprotected() {
			isProtected = false;
		}
	}

	public class EntrySignal : Signal {

		#region Constructors
		public EntrySignal() { }

		public EntrySignal(ExitSignal nextSignal) {
			switch (nextSignal.signalState) {
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

		public void SetClear() {
			if (isProtected == false) {
				signalState = 1;
			}
		}

		public void SetCaution() {
			if (isProtected == false) {
				signalState = 2;
			}
		}

		public void SetCautionShort() {
			if (isProtected == false) {
				signalState = 3;
			}
		}
	}

	public class ExitSignal : Signal {
		public void SetClear() {
			if (isProtected == false) {
				signalState = 1;
			}
		}
	}

	public class DistSignal : Signal {
		public DistSignal(EntrySignal nextSignal) {
			//nextSignal = ??? Fill with the signal that this signal will refer to when it acts as a distant signal
		}

	}

	public class RoadSignal : Signal {
		public void SetClear() {
			if (/*CrossingIsClear == true*/true) {
				signalState = 1;
			}
		}
	}

	public class DistroadSignal : Signal {
		public DistroadSignal(RoadSignal referenceSignal) {

		}
		//nextSignal = ??? Fill with the signal that this signal will refer to when it acts as a distant signal
	}
}
