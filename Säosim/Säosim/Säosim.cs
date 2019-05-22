﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.OpenGL;
using MonoGame.Utilities;
using MonoGame.Utilities.Png;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using Säosim.UI;

namespace Säosim {
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Säosim : Game {

		GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

		private Color _backgroundColour = Color.CornflowerBlue;

		private List<Component> gameButtons;
		private List<Component> gameIndicators;

		IO filehandler;

		//Create interlocking object (The interlocking plant for all intents and purposes)
		Interlocking interlocking;


		public Säosim() {
			/*---------FRONT END CONSTRUCTION---------*/
			Window.Title = "Säosim"; //Doesn't work for some bastard reason
			Window.AllowUserResizing = true;

			graphics = new GraphicsDeviceManager(this);

			//graphics.IsFullScreen = true;
			graphics.ApplyChanges();

			/*-----END OF FRONT END CONSTRUCTION-----*/

			/*---------BACK END CONSTRUCTION---------*/
			Content.RootDirectory = "Content";

			filehandler = new IO();
			interlocking = new Interlocking();
			Debug.WriteLine("Created interlocking");
			/*------END OF BACK END CONSTRUCTION------*/
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

			#region Create buttons
			// TODO: use this.Content to load your game content here
			var switch1Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(10, 10),
				Text = "Vx 1 (+)",
			};
			var switch1Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(10, 60),
				Text = "Vx 1 (-)",
			};
			var switch2Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(60, 10),
				Text = "Vx 2 (+)",
			};
			var switch2Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(60, 60),
				Text = "Vx 2 (-)",
			};
			var switch4Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(110, 10),
				Text = "Vx 4 (+)",
			};
			var switch4Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(110, 60),
				Text = "Vx 4 (-)",
			};
			var switch5Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(160, 10),
				Text = "Vx 5 (+)",
			};
			var switch5Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(160, 60),
				Text = "Vx 5 (-)",
			};
			var switch6Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(210, 10),
				Text = "Vx 6 (+)",
			};
			var switch6Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(210, 60),
				Text = "Vx 6 (-)",
			};
			var derail2Raise = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(260, 10),
				Text = "SpII (+)",
			};
			var derail2Lower = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(260, 60),
				Text = "SpII (-)",
			};
			var a1lock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(10, 120),
				Text = "a1",
			};
			#endregion
			#region Create indicators
			var switch1Indicator = new Indicator(Content.Load<Texture2D>("Textures/lampLit48px"), Content.Load<Texture2D>("Textures/lampUnlit48px"), interlocking.switch1) {
				Position = new Vector2(310, 60)
			};

			#endregion

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
			derail2Raise.Click += Derail2Raise_Click;
			derail2Lower.Click += Derail2Lower_Click;
			a1lock.Click += a1Lock_Click;

			gameButtons = new List<Component>() {
				//Switch buttons
				switch1Straight,
				switch1Curved,
				switch2Straight,
				switch2Curved,
				switch4Straight,
				switch4Curved,
				switch5Straight,
				switch5Curved, 
				switch6Straight,
				switch6Curved,

				//Derail buttons
				derail2Raise,
				derail2Lower,

				//Route locking
				a1lock,
			};

			gameIndicators = new List<Component>() {
				switch1Indicator,
			};

			filehandler.ReadPositions(ref interlocking, "Positions.txt");
		}

		#region ButtonEvents
		private void a1Lock_Click(object sender, EventArgs e) {
			if (interlocking.route_a1.LockRoute()) {
				Debug.WriteLine("Tågväg a1 låst");
			}
		}

		private void Derail2Lower_Click(object sender, EventArgs e) {
			if (interlocking.derail2.IsLowered) {
				Debug.WriteLine(interlocking.derail2.displayName + " ligger redan i avlagt läge.");
			}
			else if (interlocking.derail2.IsRaised) {
				interlocking.derail2.Lower();
			}
		}

		private void Derail2Raise_Click(object sender, EventArgs e) {
			if (interlocking.derail2.IsRaised) {
				Debug.WriteLine(interlocking.derail2.displayName + " ligger redan i pålagt läge.");
			}
			else if (interlocking.derail2.IsLowered) {
				interlocking.derail2.Raise();
			}
		}

		private void Switch6Curved_Click(object sender, EventArgs e) {
			if (interlocking.switch6.IsCurvedTrack) {
				Debug.WriteLine(interlocking.switch6.displayName + " ligger redan i (-).");
			}
			else if (interlocking.switch6.IsStraightTrack) {
				interlocking.switch6.CurveSwitch();
			}
		}

		private void Switch6Straight_Click(object sender, EventArgs e) {
			if (interlocking.switch6.IsStraightTrack) {
				Debug.WriteLine(interlocking.switch6.displayName + " ligger redan i (+).");
			}
			else if (interlocking.switch6.IsCurvedTrack) {
				interlocking.switch6.StraightSwitch();
			}
		}

		private void Switch5Curved_Click(object sender, EventArgs e) {
			if (interlocking.switch5.IsCurvedTrack) {
				Debug.WriteLine(interlocking.switch5.displayName + " ligger redan i (-).");
			}
			else if (interlocking.switch5.IsStraightTrack) {
				interlocking.switch5.CurveSwitch();
			}
		}

		private void Switch5Straight_Click(object sender, EventArgs e) {
			if (interlocking.switch5.IsStraightTrack) {
				Debug.WriteLine(interlocking.switch5.displayName + " ligger redan i (+).");
			}
			else if (interlocking.switch5.IsCurvedTrack) {
				interlocking.switch5.StraightSwitch();
			}
		}

		private void Switch4Curved_Click(object sender, EventArgs e) {
			if (interlocking.switch4.IsCurvedTrack) {
				Debug.WriteLine(interlocking.switch4.displayName + " ligger redan i (-).");
			}
			else if (interlocking.switch4.IsStraightTrack) {
				interlocking.switch4.CurveSwitch();
			}
		}

		private void Switch4Straight_Click(object sender, EventArgs e) {
			if (interlocking.switch4.IsStraightTrack) {
				Debug.WriteLine(interlocking.switch4.displayName + " ligger redan i (+).");
			}
			else if (interlocking.switch4.IsCurvedTrack) {
				interlocking.switch4.StraightSwitch();
			}
		}

		private void Switch2Curved_Click(object sender, EventArgs e) {
			if (interlocking.switch2.IsCurvedTrack) {
				Debug.WriteLine(interlocking.switch2.displayName + " ligger redan i (-).");
			}
			else if (interlocking.switch2.IsStraightTrack) {
				interlocking.switch2.CurveSwitch();
			}
		}

		private void Switch2Straight_Click(object sender, EventArgs e) {
			if (interlocking.switch2.IsStraightTrack) {
				Debug.WriteLine(interlocking.switch2.displayName + " ligger redan i (+).");
			}
			else if (interlocking.switch2.IsCurvedTrack) {
				interlocking.switch2.StraightSwitch();
			}
		}

		private void Switch1Curved_Click(object sender, EventArgs e) {
			if (interlocking.switch1.IsCurvedTrack) {
				Debug.WriteLine(interlocking.switch1.displayName + " ligger redan i (-).");
			}
			else if (interlocking.switch1.IsStraightTrack) {
				interlocking.switch1.CurveSwitch();
			}
		}

		private void Switch1Straight_Click(object sender, EventArgs e) {
			if (interlocking.switch1.IsStraightTrack) {
				Debug.WriteLine(interlocking.switch1.displayName + " ligger redan i (+).");
			}
			else if (interlocking.switch1.IsCurvedTrack) {
				interlocking.switch1.StraightSwitch();
			}
		}
		#endregion

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent() {

			filehandler.SavePositions(ref interlocking, "Positions.txt");

			// TODO: Unload any non ContentManager content here
			Content.Dispose();
			Content.Unload();
		}

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			foreach (var button in gameButtons) {
				button.Update(gameTime);
			}

			foreach (var indicator in gameIndicators) {
				//Get the signal, switch, derail, route, whatever that determines the state of the indicator. 
				object refObject = indicator.GetReferenceObject();
				indicator.Update(gameTime, refObject);
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

			foreach (var button in gameButtons) {
				button.Draw(gameTime, spriteBatch);
			}

			foreach (var indicator in gameIndicators) {
				indicator.Draw(gameTime, spriteBatch);
			}

			spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
