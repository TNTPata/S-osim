using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Säosim.RouteObjects;

namespace Säosim.UI {
	public class Indicator : Component {

		#region Fields
		private Texture2D _onTexture;
		private Texture2D _offTexture;
		private bool indicatorState = false;
		public object referenceObject;
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
		public Indicator(Texture2D onTexture, Texture2D offTexture, object referenceObject) {
			_onTexture = onTexture;
			_offTexture = offTexture;
			this.referenceObject = referenceObject;
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
			var color = Color.White;
			var texture = _offTexture;

			if (indicatorState) {
				texture = _onTexture;
			}

			spriteBatch.Draw(texture, Rectangle, color);
		}

		public override object GetReferenceObject() {
			return referenceObject;
		}

		public override void Update(GameTime gametime, object referenceObject) {
			switch (referenceObject) {
				//Light is on if signal is showing any aspect that isn't red
				//Light is off is signal is showing a red aspect
				case Signal si: {
						if (si.signalState > 0) {
							indicatorState = true;
						} else {
							indicatorState = false;
						}
						break;
					}
				case Switch sw: {
						//Lights up indicator when switch is straight and not moving
						if (sw.IsStraightTrack == true && !sw.isMoving) {
							indicatorState = true;
						} else {
							indicatorState = false;
						}
						break;
					}
				case Derail de: {
						//Lights up indicator when derail is raised and not moving
						if (de.IsRaised == true && !de.isMoving) {
							indicatorState = true;
						} else {
							indicatorState = false;
						}
						break;
					}
				case Route ro: {
						//Light is on for a locked route
						//Light if off for an unlocked route
						if (ro.isLocked == true) {
							indicatorState = true;
						} else  {
							indicatorState = false;
						}
						break;
					}
				default: {
						break;
					}
			}
		}

		#region Unused Update-methods
		public override void Update(GameTime gametime) {

		}

		#endregion
		#endregion
	}
}
