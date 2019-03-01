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
	/*class Button {
		/// <summary>
		/// Don't touch anything
		/// </summary>
		public enum State {
			None,
			Pressed,
			Hover,
			Released
		}

		private Rectangle _rectangle;

		public State state { get; set; }

		private Dictionary<State, Texture2D> _textures;

		public Button(Rectangle rectangle, Texture2D noneTexture, Texture2D hoverTexture, Texture2D pressedTexture) {
			_rectangle = rectangle;
			_textures = new Dictionary<State, Texture2D>
				{
				{ State.None, noneTexture },
				{ State.Hover, hoverTexture },
				{ State.Pressed, pressedTexture }
				};
		}

		public void Update(MouseState mouseState) {
			if (_rectangle.Contains(mouseState.X, mouseState.Y)) {
				if (mouseState.LeftButton == ButtonState.Pressed) {
					state = State.Pressed;
				}
				else {
					state = state == State.Pressed ? State.Released : State.Hover;
				}
			}
			else {
				state = State.None;
			}
		}

		// Make sure Begin is called on s before you call this function
		public void Draw(SpriteBatch s) {
			s.Draw(_textures[state], _rectangle);
		}
	}*/

	enum State {
		None, 
		Pressed,
		Released
	}
	//I have no idea what any of this does...
	class Button : Component {

		#region Fields
		private MouseState _currentMouse;
		private SpriteFont _font;
		private bool _isHovering;
		private MouseState _previousMouse;
		private Texture2D _texturePressed;
		private Texture2D _textureReleased;
		#endregion
		#region Properties
		public event EventHandler Click;

		public bool Clicked { get; private set; }

		public Color PenColor { get; set; }

		public Vector2 Position { get; set; }

		public Rectangle rectangle {
			get {
				return new Rectangle((int)Position.X, (int)Position.Y, _texturePressed.Width, _texturePressed.Height);
			}
		}

		public string Text { get; set; }

		#endregion
		#region Methods

		//Constuctors
		public Button(Texture2D texturePressed, Texture2D textureReleased) {
			_texturePressed = texturePressed;
			_textureReleased = textureReleased;
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
			
		}

		public override void Update(GameTime gametime) {
			_previousMouse = _currentMouse;
			_currentMouse = Mouse.GetState();

			var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

			_isHovering = false;

			if (mouseRectangle.Intersects(rectangle)) {
				_isHovering = true;

				if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed) {
					Click?.Invoke(this, new EventArgs());

				}
			}
		}
		#endregion
	}
}
