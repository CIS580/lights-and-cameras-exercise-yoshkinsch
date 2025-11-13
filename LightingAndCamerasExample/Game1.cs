using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LightingAndCamerasExample
{
    /// <summary>
    /// The type of crate to create
    /// </summary>
    public enum CrateType
    {
        Slats = 0,
        Cross,
        DarkCross
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        // A collection of crates
        Crate[] crates;
        // The camera - Circling Camera
        //private CirclingCamera camera;
        // The game camera
        private FPSCamera camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Make some crates
            crates = new Crate[] {
                new Crate(this, CrateType.DarkCross, Matrix.Identity),
                new Crate(this, CrateType.Slats, Matrix.CreateTranslation(4, 0, 5)),
                new Crate(this, CrateType.Cross, Matrix.CreateTranslation(-8, 0, 3)),
                new Crate(this, CrateType.DarkCross, Matrix.CreateRotationY(MathHelper.PiOver4) * Matrix.CreateTranslation(1, 0, 7)),
                new Crate(this, CrateType.Slats, Matrix.CreateTranslation(3, 0, -3)),
                new Crate(this, CrateType.Cross, Matrix.CreateRotationY(3) * Matrix.CreateTranslation(3, 2, -3))
            };

            // Initialize the camera - Circling Camera
            //camera = new CirclingCamera(this, new Vector3(0, 5, 10), 0.5f);
            // Initialize the camera 
            camera = new FPSCamera(this, new Vector3(0, 3, 10));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Update the camera 
            camera.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            // Draw some crates
            foreach (Crate crate in crates)
            {
                crate.Draw(camera);
            }

            base.Draw(gameTime);
        }
    }
}
