using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GenAI
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        private Texture2D texture;
        private Rectangle testRect;
        private int count;
        Player player;
        PipeManager pipeManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
           
            count = 0;
            testRect = new Rectangle(900,200,50,50);
            

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            
            // TODO: use this.Content to load your game content here
            texture = Content.Load<Texture2D>("purple");

            player = new Player(testRect, texture);
            pipeManager = new PipeManager();
            pipeManager.loadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //KeyboardState kbstate = Keyboard.GetState();

            testRect.X -= 3;

            if (testRect.Right < 0)
            {
                testRect.X = 900;
            }

            player.update();
            pipeManager.update(player,Content);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            //_spriteBatch.Draw(texture, testRect,Color.White);

            player.draw(_spriteBatch);
            pipeManager.draw(_spriteBatch);

            //_spriteBatch.Draw(texture,new Rectangle(300,0,40,200),Color.White); // toprect
            //_spriteBatch.Draw(texture, new Rectangle(300, 400, 40, 400), Color.White); // bot rect

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}