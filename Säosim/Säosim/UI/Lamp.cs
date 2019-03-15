using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Säosim.UI {
	public class Indicator : Component {

		#region Fields
		private Texture2D _onTexture;
		private Texture2D _offTexture;
		private bool isOn = false;
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
		public Indicator(Texture2D litTexture, Texture2D unlitTexture) {
			_onTexture = litTexture;
			_offTexture = unlitTexture;
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
			var color = Color.White;
			var texture = _offTexture;

			if (isOn) {
				texture = _onTexture;
			}

			spriteBatch.Draw(texture, Rectangle, color);
			 
		}
		public override void Update(GameTime gametime) {
			
		}
		#endregion
	}
}
