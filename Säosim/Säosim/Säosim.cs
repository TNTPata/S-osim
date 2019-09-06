using Microsoft.Xna.Framework;
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
		private Texture2D backgroundImage;


		private List<Component> gameButtons;
		private List<Component> gameIndicators;

		IO filehandler;

		//Create interlocking object (The interlocking plant for all intents and purposes)
		Interlocking interlocking;


		public Säosim() {			
			/*---------FRONT END CONSTRUCTION---------*/
			Window.Title = "Säosim"; //Doesn't work for some bastard reason
			Window.AllowUserResizing = false;
			
			graphics = new GraphicsDeviceManager(this);

			//graphics.IsFullScreen = true;
			
			graphics.PreferredBackBufferHeight = 646;
			graphics.PreferredBackBufferWidth = 1163;
			graphics.ApplyChanges();
			/*-----END OF FRONT END CONSTRUCTION-----*/

			/*---------BACK END CONSTRUCTION---------*/
			Content.RootDirectory = "Content";

			filehandler = new IO();

            interlocking = new Interlocking();
			Debug.WriteLine("[PRG/INFO] Created interlocking");
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

			backgroundImage = Content.Load<Texture2D>("Textures/Background");

			#region Create buttons
			// TODO: use this.Content to load your game content here
			var switch1Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(255, 60),
				Text = "1+",
			};
			var switch1Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(255, 110),
				Text = "1-",
			};
			var switch2Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(800, 10),
				Text = "2+",
			};
			var switch2Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(800, 60),
				Text = "2-",
			};
			var switch3Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(375, 60),
				Text = "3+",
			};
			var switch3Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(375, 110),
				Text = "3-",
			};
			var switch4Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(750, 10),
				Text = "4+",
			};
			var switch4Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(750, 60),
				Text = "4-",
			};
			var switch8Straight = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(315, 60),
				Text = "8+",
			};
			var switch8Curved = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(315, 110),
				Text = "8-",
			};
			var derail2Raise = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(840, 355),
				Text = "SpII+",
			};
			var derail2Lower = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(840, 405),
				Text = "SpII-",
			};
			var a1lock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(397, 330),
				Text = "a1",
			};
			var a2lock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(397, 430),
				Text = "a2",
			};
			var a3lock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(397, 530),
				Text = "a3",
			};
			var b1lock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(277, 330),
				Text = "b1",
			};
			var b2lock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(277, 430),
				Text = "b2",
			};
			var c1lock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(1065, 355),
				Text = "c1",
			};
			var c2lock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(1065, 455),
				Text = "c2",
			};
			var c3lock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(1065, 555),
				Text = "c3",
			};
			var d1lock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(945, 355),
				Text = "d1",
			};
			var d2_3lock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(945, 455),
				Text = "d2/3",
			};
			var e1lock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(157, 430),
				Text = "e1",
			};
			var e2lock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(157, 530),
				Text = "e2",
			};
			var Flock = new Button(Content.Load<Texture2D>("Controls/buttonReleased48px"), Content.Load<Texture2D>("Controls/buttonPressed48px"), Content.Load<SpriteFont>("Fonts/Font")) {
				Position = new Vector2(277, 530),
				Text = "F",
			};
			#endregion

			#region Create indicators
			//Textures are "inverted" for every other indicator
			var switch1StraightIndicator = new Indicator(Content.Load<Texture2D>("Textures/lampYellowLit48px"), Content.Load<Texture2D>("Textures/lampYellowUnlit48px"), interlocking.switch1) {
				Position = new Vector2(255, 160)
			};
			var switch1CurveIndicator = new InvertedIndicator(Content.Load<Texture2D>("Textures/lampYellowLit48px"), Content.Load<Texture2D>("Textures/lampYellowUnlit48px"), interlocking.switch1) {
				Position = new Vector2(255, 210)
			};
			var switch2StraightIndicator = new Indicator(Content.Load<Texture2D>("Textures/lampYellowLit48px"), Content.Load<Texture2D>("Textures/lampYellowUnlit48px"), interlocking.switch2) {
				Position = new Vector2(800, 110)
			};
			var switch2CurveIndicator = new InvertedIndicator(Content.Load<Texture2D>("Textures/lampYellowLit48px"), Content.Load<Texture2D>("Textures/lampYellowUnlit48px"), interlocking.switch2)	{
				Position = new Vector2(800, 160)
			};
			var switch3StraightIndicator = new Indicator(Content.Load<Texture2D>("Textures/lampYellowLit48px"), Content.Load<Texture2D>("Textures/lampYellowUnlit48px"), interlocking.switch3) {
				Position = new Vector2(375, 160)
			};
			var switch3CurveIndicator = new InvertedIndicator(Content.Load<Texture2D>("Textures/lampYellowLit48px"), Content.Load<Texture2D>("Textures/lampYellowUnlit48px"), interlocking.switch3)	{
				Position = new Vector2(375, 210)
			};
			var switch4StraightIndicator = new Indicator(Content.Load<Texture2D>("Textures/lampYellowLit48px"), Content.Load<Texture2D>("Textures/lampYellowUnlit48px"), interlocking.switch4) {
				Position = new Vector2(750, 110)
			};
			var switch4CurveIndicator = new InvertedIndicator(Content.Load<Texture2D>("Textures/lampYellowLit48px"), Content.Load<Texture2D>("Textures/lampYellowUnlit48px"), interlocking.switch4)	{
				Position = new Vector2(750, 160)
			};
			var switch8StraightIndicator = new Indicator(Content.Load<Texture2D>("Textures/lampYellowLit48px"), Content.Load<Texture2D>("Textures/lampYellowUnlit48px"), interlocking.switch8) {
				Position = new Vector2(315, 160)
			};
			var switch8CurveIndicator = new InvertedIndicator(Content.Load<Texture2D>("Textures/lampYellowLit48px"), Content.Load<Texture2D>("Textures/lampYellowUnlit48px"), interlocking.switch8)	{
				Position = new Vector2(315, 210)
			};
			var derail2RaisedIndicator = new Indicator(Content.Load<Texture2D>("Textures/lampYellowLit48px"), Content.Load<Texture2D>("Textures/lampYellowUnlit48px"), interlocking.derail2) {
				Position = new Vector2(840, 455)
			};
			var derail2LoweredIndicator = new InvertedIndicator(Content.Load<Texture2D>("Textures/lampYellowLit48px"), Content.Load<Texture2D>("Textures/lampYellowUnlit48px"), interlocking.derail2)	{
				Position = new Vector2(840, 505)
			};

			var routea1Indicator = new Indicator(Content.Load<Texture2D>("Textures/fieldWhite30x90px"), Content.Load<Texture2D>("Textures/fieldRed30x90px"), interlocking.route_a1) {
				Position = new Vector2(375, 385)
			};
			var routea2Indicator = new Indicator(Content.Load<Texture2D>("Textures/fieldWhite30x90px"), Content.Load<Texture2D>("Textures/fieldRed30x90px"), interlocking.route_a2)	{
				Position = new Vector2(375, 485)
			};
			var routea3Indicator = new Indicator(Content.Load<Texture2D>("Textures/fieldWhite30x90px"), Content.Load<Texture2D>("Textures/fieldRed30x90px"), interlocking.route_a3)	{
				Position = new Vector2(375, 585)
			};
			var routeb1Indicator = new Indicator(Content.Load<Texture2D>("Textures/fieldWhite30x90px"), Content.Load<Texture2D>("Textures/fieldRed30x90px"), interlocking.route_b1) {
				Position = new Vector2(255, 385)
			};
			var routeb2Indicator = new Indicator(Content.Load<Texture2D>("Textures/fieldWhite30x90px"), Content.Load<Texture2D>("Textures/fieldRed30x90px"), interlocking.route_b2)	{
				Position = new Vector2(255, 485)
			};
			var routec1Indicator = new Indicator(Content.Load<Texture2D>("Textures/fieldWhite30x90px"), Content.Load<Texture2D>("Textures/fieldRed30x90px"), interlocking.route_c1) {
				Position = new Vector2(1043, 410)
			};
			var routec2Indicator = new Indicator(Content.Load<Texture2D>("Textures/fieldWhite30x90px"), Content.Load<Texture2D>("Textures/fieldRed30x90px"), interlocking.route_c2)	{
				Position = new Vector2(1043, 510)
			};
			var routec3Indicator = new Indicator(Content.Load<Texture2D>("Textures/fieldWhite30x90px"), Content.Load<Texture2D>("Textures/fieldRed30x90px"), interlocking.route_c3)	{
				Position = new Vector2(1043, 610)
			};
			var routed1Indicator = new Indicator(Content.Load<Texture2D>("Textures/fieldWhite30x90px"), Content.Load<Texture2D>("Textures/fieldRed30x90px"), interlocking.route_d1) {
				Position = new Vector2(923, 410)
			};
			var routed2_3Indicator = new Indicator(Content.Load<Texture2D>("Textures/fieldWhite30x90px"), Content.Load<Texture2D>("Textures/fieldRed30x90px"), interlocking.route_d2_3)	{
				Position = new Vector2(923, 510)
			};
			var routee1Indicator = new Indicator(Content.Load<Texture2D>("Textures/fieldWhite30x90px"), Content.Load<Texture2D>("Textures/fieldRed30x90px"), interlocking.route_e1) {
				Position = new Vector2(135, 485)
			};
			var routee2Indicator = new Indicator(Content.Load<Texture2D>("Textures/fieldWhite30x90px"), Content.Load<Texture2D>("Textures/fieldRed30x90px"), interlocking.route_e2)	{
				Position = new Vector2(135, 585)
			};
			var routeFIndicator = new Indicator(Content.Load<Texture2D>("Textures/fieldWhite30x90px"), Content.Load<Texture2D>("Textures/fieldRed30x90px"), interlocking.route_F)	{
				Position = new Vector2(255, 585)
			};
			#endregion

			switch1Straight.Click += Switch1Straight_Click;
			switch1Curved.Click += Switch1Curved_Click;
			switch2Straight.Click += Switch2Straight_Click;
			switch2Curved.Click += Switch2Curved_Click;
			switch3Straight.Click += Switch3Straight_Click;
			switch3Curved.Click += Switch3Curved_Click;
			switch4Straight.Click += Switch4Straight_Click;
			switch4Curved.Click += Switch4Curved_Click;
			switch8Straight.Click += Switch8Straight_Click;
			switch8Curved.Click += Switch8Curved_Click;

			derail2Raise.Click += Derail2Raise_Click;
			derail2Lower.Click += Derail2Lower_Click;

			a1lock.Click += a1Lock_Click;
			a2lock.Click += a2Lock_Click;
			a3lock.Click += a3Lock_Click;
			b1lock.Click += b1Lock_Click;
			b2lock.Click += b2Lock_Click;
			c1lock.Click += c1lock_Click;
			c2lock.Click += c2lock_Click;
			c3lock.Click += c3lock_Click;
			d1lock.Click += d1lock_Click;
			d2_3lock.Click += d2_3lock_Click;
			e1lock.Click += e1Lock_Click;
			e2lock.Click += e2Lock_Click;
			Flock.Click += FLock_Click;

			gameButtons = new List<Component>() {
				//Switch buttons
				switch1Straight,
				switch1Curved,
				switch2Straight,
				switch2Curved,
				switch3Straight,
				switch3Curved, 
				switch4Straight,
				switch4Curved,
				switch8Straight,
				switch8Curved,

				//Derail buttons
				derail2Raise,
				derail2Lower,

				//Route locking
				a1lock,
				a2lock,
				a3lock,
				b1lock,
				b2lock,
				c1lock,
				c2lock,
				c3lock,
				d1lock,
				d2_3lock,
				e1lock,
				e2lock,
				Flock,
			};

			gameIndicators = new List<Component>() {
				switch1StraightIndicator,
				switch1CurveIndicator,
				switch2StraightIndicator,
				switch2CurveIndicator,
				switch3StraightIndicator,
				switch3CurveIndicator,
				switch4StraightIndicator,
				switch4CurveIndicator,
				switch8StraightIndicator,
				switch8CurveIndicator,
				derail2RaisedIndicator,
				derail2LoweredIndicator,

				routea1Indicator,
				routea2Indicator,
				routea3Indicator,
				routeb1Indicator,
				routeb2Indicator,
				routec1Indicator,
				routec2Indicator,
				routec3Indicator,
				routed1Indicator,
				routed2_3Indicator,
				routee1Indicator,
				routee2Indicator,
				routeFIndicator,
			};

			filehandler.ReadPositions(ref interlocking, "Positions.txt");
		}

		private void FLock_Click(object sender, EventArgs e) {
			interlocking.F_toggle();
		}

		#region ButtonEvents
		private void e2Lock_Click(object sender, EventArgs e) {
			interlocking.e2_toggle();
		}

		private void e1Lock_Click(object sender, EventArgs e) {
			interlocking.e1_toggle();
		}

		private void d2_3lock_Click(object sender, EventArgs e)	{
			interlocking.d2_3_toggle();
		}

		private void d1lock_Click(object sender, EventArgs e){
			interlocking.d1_toggle();
		}

		private void c3lock_Click(object sender, EventArgs e) {
			interlocking.c3_toggle();
		}

		private void c2lock_Click(object sender, EventArgs e) {
			interlocking.c2_toggle();
		}

		private void c1lock_Click(object sender, EventArgs e) {
			interlocking.c1_toggle();
		}

		private void b2Lock_Click(object sender, EventArgs e) {
			interlocking.b2_toggle();
		}

		private void b1Lock_Click(object sender, EventArgs e) {
			interlocking.b1_toggle();
		}

		private void a3Lock_Click(object sender, EventArgs e) {
			interlocking.a3_toggle();
		}

		private void a2Lock_Click(object sender, EventArgs e) {
			interlocking.a2_toggle();
		}

		private void a1Lock_Click(object sender, EventArgs e) {
			interlocking.a1_toggle();
		}

		private void Derail2Lower_Click(object sender, EventArgs e) {
			if (interlocking.derail2.IsLowered) {
                Debug.WriteLine("[SIM/WARN] " + interlocking.derail2.displayName + " ligger redan i avlagt läge.");
            }
			else if (interlocking.derail2.IsRaised) {
				Task.Run(async () => await interlocking.derail2.Lower());
			}
		}

		private void Derail2Raise_Click(object sender, EventArgs e) {
			if (interlocking.derail2.IsRaised) {
                Debug.WriteLine("[SIM/WARN] " + interlocking.derail2.displayName + " ligger redan i pålagt läge.");
            }
			else if (interlocking.derail2.IsLowered) {
				Task.Run(async () => await interlocking.derail2.Raise());
			}
		}

		private void Switch8Curved_Click(object sender, EventArgs e) {
			if (interlocking.switch8.IsCurvedTrack) {
                Debug.WriteLine("[SIM/WARN] " + interlocking.switch8.displayName + " ligger redan i (-).");
			}
			else if (interlocking.switch8.IsStraightTrack) {
				Task.Run(async () => await interlocking.switch8.CurveSwitch());
			}
		}

		private void Switch8Straight_Click(object sender, EventArgs e) {
			if (interlocking.switch8.IsStraightTrack) {
                Debug.WriteLine("[SIM/WARN] " + interlocking.switch8.displayName + " ligger redan i (+).");
			}
			else if (interlocking.switch8.IsCurvedTrack) {
				Task.Run(async () => await interlocking.switch8.StraightSwitch());
			}
		}

		private void Switch4Curved_Click(object sender, EventArgs e) {
			if (interlocking.switch4.IsCurvedTrack) {
                Debug.WriteLine("[SIM/WARN] " + interlocking.switch4.displayName + " ligger redan i (-).");
			}
			else if (interlocking.switch4.IsStraightTrack) {
				Task.Run(async () => await interlocking.switch4.CurveSwitch());
			}
		}

		private void Switch4Straight_Click(object sender, EventArgs e) {
			if (interlocking.switch4.IsStraightTrack) {
                Debug.WriteLine("[SIM/WARN] " + interlocking.switch4.displayName + " ligger redan i (+).");
			}
			else if (interlocking.switch4.IsCurvedTrack) {
				Task.Run(async () => await interlocking.switch4.StraightSwitch());
			}
		}
		
		private void Switch3Curved_Click(object sender, EventArgs e) {
			if (interlocking.switch3.IsCurvedTrack) {
                Debug.WriteLine("[SIM/WARN] " + interlocking.switch3.displayName + " ligger redan i (-).");
			}
			else if (interlocking.switch3.IsStraightTrack) {
				Task.Run(async () => await interlocking.switch3.CurveSwitch());
			}
		}

		private void Switch3Straight_Click(object sender, EventArgs e) {
			if (interlocking.switch3.IsStraightTrack) {
                Debug.WriteLine("[SIM/WARN] " + interlocking.switch3.displayName + " ligger redan i (+).");
			}
			else if (interlocking.switch3.IsCurvedTrack) {
				Task.Run(async () => await interlocking.switch3.StraightSwitch());
			}
		}

		private void Switch2Curved_Click(object sender, EventArgs e) {
			if (interlocking.switch2.IsCurvedTrack) {
                Debug.WriteLine("[SIM/WARN] " + interlocking.switch2.displayName + " ligger redan i (-).");
			}
			else if (interlocking.switch2.IsStraightTrack) {
				Task.Run(async () => await interlocking.switch2.CurveSwitch());
			}
		}

		private void Switch2Straight_Click(object sender, EventArgs e) {
			if (interlocking.switch2.IsStraightTrack) {
                Debug.WriteLine("[SIM/WARN] " + interlocking.switch2.displayName + " ligger redan i (+).");
			}
			else if (interlocking.switch2.IsCurvedTrack) {
				Task.Run(async () => await interlocking.switch2.StraightSwitch());
			}
		}

		private void Switch1Curved_Click(object sender, EventArgs e) {
			if (interlocking.switch1.IsCurvedTrack) {
                Debug.WriteLine("[SIM/WARN] " + interlocking.switch1.displayName + " ligger redan i (-).");
			}
			else if (interlocking.switch1.IsStraightTrack) {
				Task.Run(async () => await interlocking.switch1.CurveSwitch());
			}
		}

		private void Switch1Straight_Click(object sender, EventArgs e) {
			if (interlocking.switch1.IsStraightTrack) {
                Debug.WriteLine("[SIM/WARN] " + interlocking.switch1.displayName + " ligger redan i (+).");
			}
			else if (interlocking.switch1.IsCurvedTrack) {
				Task.Run(async () => await interlocking.switch1.StraightSwitch());
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

			spriteBatch.Draw(backgroundImage, Vector2.Zero);

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
