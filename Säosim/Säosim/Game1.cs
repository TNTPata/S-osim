using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.OpenGL;
using MonoGame.Utilities;
using MonoGame.Utilities.Png;
using System.IO;
using System.Diagnostics;

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

		//Create interlocking object (The interlocking plant for all intents and purposes)
		Interlocking interlocking;

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
			textureLampLit = Content.Load<Texture2D>("lampLit");
			textureLampUnlit = Content.Load<Texture2D>("lampUnlit");
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

			// TODO: Add your update logic here
            base.Update(gameTime);
			
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			spriteBatch.Begin();
			spriteBatch.Draw(textureLampLit, new Vector2(0, 0), Color.White);
			spriteBatch.Draw(textureLampUnlit, new Vector2(128, 128), Color.White);
			spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
