using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_monogame;

public class Game1 : Game {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Ball ball;

    Player player0;
    Player player1;

    public Game1() {
        _graphics = new GraphicsDeviceManager(this);

        _graphics.PreferredBackBufferWidth = 800;
        _graphics.PreferredBackBufferHeight = 480;
        _graphics.ApplyChanges();

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        Texture2D ballTexture = Content.Load<Texture2D>("ball");
        int width = _graphics.PreferredBackBufferWidth;
        int height = _graphics.PreferredBackBufferHeight;


        ball = new Ball(width, height, 8f, ballTexture);

        Texture2D player0Texture = Content.Load<Texture2D>("player0");
        Texture2D player1Texture = Content.Load<Texture2D>("player1");

        player0 = new Player(width, height, 0, 4f, player0Texture);
        player1 = new Player(width, height, 1, 4f, player1Texture);
    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        player0.Update();
        player1.Update();
        
        ball.Update(ref player0, ref player1);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        ball.Draw(_spriteBatch);

        player0.Draw(_spriteBatch);
        player1.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
