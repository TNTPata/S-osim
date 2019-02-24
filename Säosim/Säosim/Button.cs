using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Säosim {
	class Button {
		public enum State {
			None,
			Pressed,
			Hover,
			Released
		}

		private Rectangle _rectangle;
		private State _state;
		public State State {
			get { return _state; }
			set { _state = value; } // you can throw some events here if you'd like
		}

		private Dictionary<State, Texture2D> _textures;

		public Button(Rectangle rectangle, Texture2D noneTexture, Texture2D hoverTexture, Texture2D pressedTexture) {
			_rectangle = rectangle;
			_textures = new Dictionary<State, Texture2D>
			{
			{ State.None, noneTexture },
			{ State.Hover, hoverTexture },
			{ State.Pressed, pressedTexture }
		}
	
	}

		/*public void Update(MouseState mouseState) {
			if (rectangle.Contains(mouseState.X, mouseState.Y)) {
				if (mouseState.LeftButton == ButtonState.Pressed)
					State = State.Pressed;
				else
					State = State == State.Pressed ? State.Released : State.Hover;
			}
			else {
				State = State.None
	
		}
		}

		// Make sure Begin is called on s before you call this function
		public void Draw(SpriteBatch s) {
			s.Draw(_textures[State], _rectangle);
		}*/
	}
}
