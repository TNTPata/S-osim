﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.OpenGL;
using MonoGame.Utilities;
using MonoGame.Utilities.Png;
using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace Säosim {
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
			//textureLampLit = Content.Load<Texture2D>("Textures/lampLit");
			//textureLampUnlit = Content.Load<Texture2D>("Textures/lampUnlit");

			var switch1Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(10, 10),
				Text = "Vx 1 (+)",
			};
			var switch1Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(10, 60),
				Text = "Vx 1 (-)",
			};
			var switch2Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(60, 10),
				Text = "Vx 2 (+)",
			};
			var switch2Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(60, 60),
				Text = "Vx 2 (-)",
			};
			var switch4Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(110, 10),
				Text = "Vx 4 (+)",
			};
			var switch4Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(110, 60),
				Text = "Vx 4 (-)",
			};
			var switch5Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(160, 10),
				Text = "Vx 5 (+)",
			};
			var switch5Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(160, 60),
				Text = "Vx 5 (-)",
			};
			var switch6Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(210, 10),
				Text = "Vx 6 (+)",
			};
			var switch6Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(210, 60),
				Text = "Vx 6 (-)",
			};
			var derail2On = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(260, 10),
				Text = "SpII (+)",
			};
			var derail2Off = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(260, 60),
				Text = "SpII (-)",
			};


			switch1Straight.Click += Switch1Straight_Click;
			switch1Curved.Click += Switch1Curved_Click;
			switch2Straight.Click += Switch2Straight_Click;
			switch2Curved.Click += Switch2Curved_Click;
			switch4Straight.Click += Switch4Straight_Click;
			switch4Curved.Click += Switch4Curved_Click;
			switch5Straight.Click += Switch5Straight_Click;
			switch5Curved.Click += Switch5Curved_Click;
			switch6Straight.Click += Switch6Straight_Click;
			switch6Curved.Click += Switch6Curved_Click;
			derail2On.Click += Derail2On_Click;
			derail2Off.Click += Derail2Off_Click;

			_gameComponents = new List<Component>()
			{
				switch1Straight,
				switch1Curved,
				switch2Straight,
				switch2Curved,
				switch4Straight,
				switch4Curved,
				switch5Straight,
				switch5Curved, 
				switch6Straight,
				switch5Curved,
				derail2On,
				derail2Off,
			};
		}

		#region ButtonEvents
		private void Derail2Off_Click(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void Derail2On_Click(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void Switch6Curved_Click(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void Switch6Straight_Click(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void Switch5Curved_Click(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void Switch5Straight_Click(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void Switch4Curved_Click(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void Switch4Straight_Click(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void Switch2Curved_Click(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void Switch2Straight_Click(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void Switch1Curved_Click(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void Switch1Straight_Click(object sender, EventArgs e) {
			throw new NotImplementedException();
		}
		#endregion

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
			GraphicsDevice.Clear(Color.LightGray);

			// TODO: Add your drawing code here
			spriteBatch.Begin();
			//spriteBatch.Draw(textureLampLit, new Vector2(0, 0), Color.White);
			//spriteBatch.Draw(textureLampUnlit, new Vector2(128, 128), Color.White);
			
			foreach (var component in _gameComponents) {
				component.Draw(gameTime, spriteBatch);
			}
			spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
