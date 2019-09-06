using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Säosim.UI
{
	public class InvertedSwitchIndicator : Component
	{
		//This class is only used where the negative state of an object needs to be shown, i.e. for a reversed switch.
		//Works exactly as the normal indicator class, but the "setting" of indicatorState is inverted. 

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
		public InvertedSwitchIndicator(Texture2D onTexture, Texture2D offTexture, object referenceObject) {
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
			//spriteBatch.Draw(texture, position: Position.X, null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
			//spriteBatch.Draw()
		}

		public override object GetReferenceObject() {
			return referenceObject;
		}

		public override void Update(GameTime gametime, object referenceObject) {
			switch (referenceObject) {
				case Switch sw: {
						//Lights up the indicator when the switch is curved and not moving
						if (sw.IsCurvedTrack == true && !sw.isMoving) {
							indicatorState = true;
						} else {
							indicatorState = false;
						}
						break;
					}
				case Derail de: {
						//Lights up the indicator if the derail is lowered and not moving
						if (de.IsLowered == true) {
							indicatorState = true;
						} else {
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
