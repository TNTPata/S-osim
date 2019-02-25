using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	class Button {
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
	}
}
