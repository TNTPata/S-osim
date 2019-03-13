using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.OpenGL;
using MonoGame.Utilities;
using MonoGame.Utilities.Png;
using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace Säosim
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
		Texture2D textureLampLit;
		Texture2D textureLampUnlit;

		GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

		private Color _backgroundColour = Color.CornflowerBlue;

		private List<Component> _gameComponents;

		//Create interlocking object (The interlocking plant for all intents and purposes)
		Interlocking interlocking;

		#region buttonCreation
		//Create buttons here, switch "Växel 3" is not remote controlled, therefore no button for it is created
		Button switch1Straight;
		Button switch1Curved;
		Button switch2Straight;
		Button switch2Curved;
		Button switch4Straight;
		Button switch4Curved;
		Button switch5Straight;
		Button switch5Curved;
		Button switch6Straight;
		Button switch6Curved;
		Button raiseDerail2;
		Button lowerDerail2;

		//Create buttons for locking/unlocking routes to/from a certain signal
		//Short routes are automaticly used if derails are raised, therefore those buttons will not be used
		//Knapparna nedan är tågvägslås som ställer respektive signal i kör 
		Button routeLock_a1_2_3;
		Button routeLock_b1_2_3;
		Button routeLock_c1_2;
		Button routeLock_d1_2_3;
		Button routeLock_e1_2_3;
		Button routeLock_f1_2;
		Button routeLock_o1;

		//Create buttons for manuevering road protection
		Button V1Raise;
		Button V1Lower;

		//Emergency Stop all signals
		Button emergencyStop;
		#endregion

		public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

			interlocking = new Interlocking();
			Debug.WriteLine("Created interlocking");
			
		}
		
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
			IsMouseVisible = true;
			// TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			textureLampLit = Content.Load<Texture2D>("Textures/lampLit");
			textureLampUnlit = Content.Load<Texture2D>("Textures/lampUnlit");

			var randomButton = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(350, 200),
				Text = "Random",
			};

			randomButton.Click += RandomButton_Click;

			_gameComponents = new List<Component>()
			{
				randomButton
			};
		}

		private void RandomButton_Click(object sender, EventArgs e) {
			var random = new Random();

			_backgroundColour = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent() {
			// TODO: Unload any non ContentManager content here
		}

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			foreach (var component in _gameComponents) {
				component.Update(gameTime);
			}

			// TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(_backgroundColour);

			// TODO: Add your drawing code here
			spriteBatch.Begin();
			spriteBatch.Draw(textureLampLit, new Vector2(0, 0), Color.White);
			spriteBatch.Draw(textureLampUnlit, new Vector2(128, 128), Color.White);
			
			foreach (var component in _gameComponents) {
				component.Draw(gameTime, spriteBatch);
			}
			spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
