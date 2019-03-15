using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.OpenGL;
using MonoGame.Utilities;
using MonoGame.Utilities.Png;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	public class Button : Component {

		#region Fields
		private MouseState _currentMouse;
		private SpriteFont _font;
		private bool _isHovering;
		private bool _isLocked;
		private MouseState _previousMouse;
		private Texture2D _ReleasedTexture;
		private Texture2D _PressedTexture;
		#endregion

		#region Properties
		public event EventHandler Click;
		public bool Clicked { get; private set; }
		public Color PenColour { get; set; }
		public Vector2 Position { get; set; }

		public Rectangle Rectangle {
			get {
				return new Rectangle((int)Position.X, (int)Position.Y, _ReleasedTexture.Width, _ReleasedTexture.Height);
			}
		}

		public string Text { get; set; }
		#endregion

		#region Methods
		public Button(Texture2D releasedTexture, Texture2D pressedTexture, SpriteFont font) {
			_ReleasedTexture = releasedTexture;
			_PressedTexture = pressedTexture;

			_font = font;

			PenColour = Color.Black;
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
			var colour = Color.White;
			var texture = _ReleasedTexture;

			if (_isHovering)
				colour = Color.LightGray;

			if (_isLocked)
				texture = _PressedTexture;

			spriteBatch.Draw(texture, Rectangle, colour);

			if (!string.IsNullOrEmpty(Text)) {
				var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
				var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

				spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
			}
		}

		public override void Update(GameTime gameTime) {
			_previousMouse = _currentMouse;
			_currentMouse = Mouse.GetState();

			var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

			_isHovering = false;

			if (mouseRectangle.Intersects(Rectangle)) {
				_isHovering = true;

				if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed) {
					Click?.Invoke(this, new EventArgs());
				}
			}
		}
		#endregion
	}
}
