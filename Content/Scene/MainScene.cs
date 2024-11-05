using System;
using System.Collections.Generic;
using BrickBreaker;
using Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Scene;

public static class MainScene
{
    public static Paddle player;
    public static Ball ball;

    public static List<Element> elements;

    private static Random spriteElement;
    public static void Init()
    {
        SetupPlayer();
        SetupBall();
        SetupElement();
    }
    public static void Update(GameTime gameTime)
    {
        player.Update(gameTime);
        ball.Update(gameTime);
    }
    public static void Draw(SpriteBatch spriteBatch)
    {
        player.Draw(spriteBatch);
        ball.Draw(spriteBatch);
        foreach(Element element in elements)
        {
            element.Draw(spriteBatch);
        }
    }

    private static void SetupPlayer()
    {
        player = new Paddle(
            Game1.paddleSprite,
            new Rectangle(
                Game1.RESOLUTION_WIDTH / 2 - Game1.paddleSprite.Width / 2,
                Game1.RESOLUTION_HEIGHT - 60,
                Game1.paddleSprite.Width,
                Game1.paddleSprite.Height
            ));
    }
    private static void SetupBall()
    {
        ball = new Ball(
            Game1.ballSprite,
            new Rectangle(
                Game1.RESOLUTION_WIDTH / 2,
                Game1.RESOLUTION_HEIGHT - 100,
                Game1.ballSprite.Width,
                Game1.ballSprite.Height
            ));
    }

    private static void SetupElement()
    {
        elements = new List<Element>();
        spriteElement = new Random();
        int xRowElement = 12;
        int xRowOffset = 16;
        
        for(int yRow = 0; yRow < 6; yRow++)
        {
            int spriteIndex = spriteElement.Next(0, 6);
            for(int xRow = 0; xRow < xRowElement; xRow++)
            {
                elements.Add(
                    new Element(
                    Game1.elementSprite[spriteIndex],
                    new Rectangle(
                        xRow * Game1.elementSprite[0].Width + xRowOffset,
                        yRow * Game1.elementSprite[0].Height,
                        Game1.elementSprite[0].Width,
                        Game1.elementSprite[0].Height))
                );
            }
        }
    }
}