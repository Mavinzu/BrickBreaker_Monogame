﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Scene;

namespace BrickBreaker;

public class Game1 : Game
{
    public const int RESOLUTION_WIDTH = 800;
    public const int RESOLUTION_HEIGHT = 600;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;


    public static Texture2D paddleSprite;
    public static Texture2D ballSprite;

    public static Texture2D[] elementSprite = new Texture2D[6];

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = RESOLUTION_WIDTH;
        _graphics.PreferredBackBufferHeight = RESOLUTION_HEIGHT;
        _graphics.ApplyChanges();
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

        paddleSprite = LoadSprite("Assets/paddleRed");
        ballSprite = LoadSprite("Assets/ballGrey");
        elementSprite[0] = LoadSprite("Assets/element_blue_rectangle_glossy");
        elementSprite[1] = LoadSprite("Assets/element_green_rectangle_glossy");
        elementSprite[2] = LoadSprite("Assets/element_grey_rectangle_glossy");
        elementSprite[3] = LoadSprite("Assets/element_purple_rectangle_glossy");
        elementSprite[4] = LoadSprite("Assets/element_red_rectangle_glossy");
        elementSprite[5] = LoadSprite("Assets/element_yellow_rectangle_glossy");
        MainScene.Init();
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        MainScene.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        MainScene.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }

    private Texture2D LoadSprite(string Path)
    {
        return Content.Load<Texture2D>(Path);
    }
}
