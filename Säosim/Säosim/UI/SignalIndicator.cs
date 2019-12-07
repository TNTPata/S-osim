using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Säosim.UI
{
	public class SignalIndicator : Component
	{
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
		public SignalIndicator(Texture2D onTexture, Texture2D offTexture, object referenceObject) {
			_onTexture = onTexture;
			_offTexture = offTexture;
			this.referenceObject = referenceObject;
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
			throw new NotImplementedException();
		}

		public override void Update(GameTime gametime, object referenceObject) {
			throw new NotImplementedException();
		}

		public override object GetReferenceObject() {
			return referenceObject;
		}
		#endregion

		#region Unused methods
		public override void Update(GameTime gametime) {
			throw new NotImplementedException();
		}
		#endregion
	}
}
