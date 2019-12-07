using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Säosim.RouteObjects;

namespace Säosim.UI {
	public class CrossingIndicator {

		#region Fields
		private Texture2D _onTexture;
		private Texture2D _offTexture;
		private bool indicatorState = false;
		public Crossing referenceCrossing;
		public string target;
		#endregion

		#region Properties
		public Vector2 Position { get; set; }

		public Rectangle Rectangle {
			get {
				return new Rectangle((int)Position.X, (int)Position.Y, _offTexture.Width, _offTexture.Height);
			}
		}
		#endregion

		#region Methods
		public CrossingIndicator(Texture2D onTexture, Texture2D offTexture, Crossing referenceCrossing, string target) {
			_onTexture = onTexture;
			_offTexture = offTexture;
			this.referenceCrossing = referenceCrossing;
			this.target = target;
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
			var color = Color.White;
			var texture = _offTexture;

			if (indicatorState) {
				texture = _onTexture;
			}

			spriteBatch.Draw(texture, Rectangle, color);
		}

		public Crossing GetReferenceCrossing() {
			return referenceCrossing;
		}

		public string GetTarget() {
			return target;
		}

		public void Update(GameTime gametime, Crossing referenceCrossing, string target) {
			switch (target) {
				case "down": {
						indicatorState = referenceCrossing.barriersDown;
						break;
					}
				case "up": {
						indicatorState = referenceCrossing.barriersUp;
						break;
					}
				case "signal": {
						indicatorState = referenceCrossing.signalTowardRoad;
						break;
					}
				default: {
						break;
					}
			}
		}
		#endregion
	}
}