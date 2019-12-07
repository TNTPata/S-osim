using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Säosim.RouteObjects {
	public class Crossing {

		public string displayName;
		public bool barriersDown = false;
		public bool barriersUp = true;
		public bool signalTowardRoad = false;
		public event EventHandler TrainPass;

		private bool isClear = false;
		private bool isMoving = false;
		private bool isOccupied = false;
		private bool wasOccupied = false;
		private RoadSignal V;

		public Crossing(RoadSignal V, string displayName) {
			this.V = V;
			this.displayName = displayName;
		}

		public async Task Up() {
			if (barriersDown && Down().IsCompleted) {
				Thread.Sleep(1200);
				isClear = false;
				barriersDown = false;
				isMoving = true;
				Debug.WriteLine("[SIM/INFO] " + displayName + ": Lyfter bommar...");
				Thread.Sleep(9000);
				isMoving = false;
				barriersUp = true;
				signalTowardRoad = false;
				Debug.WriteLine("[SIM/INFO] " + displayName + ": Bommar låsta i lyft läge.");
			} else {
				Debug.WriteLine("[SIM/WARN] " + displayName + ": Bomfällning pågår. Försök igen när bommarna är i nedläge.");
			}
		}

		public async Task Down() {
			if (barriersUp && Up().IsCompleted) {
				Thread.Sleep(1500);
				signalTowardRoad = true;
				Debug.WriteLine("[SIM/INFO] " + displayName + ": Vägsignalering... ");
				Thread.Sleep(10000);
				barriersUp = false;
				isMoving = true;
				Debug.WriteLine("[SIM/INFO] " + displayName + ": Bomfällning...");
				Thread.Sleep(8500);
				isMoving = false;
				barriersDown = true;
				isClear = true;
				Debug.WriteLine("[SIM/INFO] " + displayName + ": Intar skyddande läge.");
			} else {
				Debug.WriteLine("[SIM/WARN] " + displayName + ": Bomlyftning pågår. Försök igen när bommarna är i uppläge.");
			}
		}

		public void Update(GameTime gametime) {
			if (barriersDown && isClear && signalTowardRoad && !isMoving) {
				V.SetClear();
			} else {
				V.SetStop();
			}
		}
	}
}
