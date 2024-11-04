using BrickBreaker;
using Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Scene;

public static class MainScene
{
    static Paddle player;
    public static void Init()
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
    public static void Update(GameTime gameTime)
    {
        player.Update(gameTime);
    }
    public static void Draw(SpriteBatch spriteBatch)
    {
        player.Draw(spriteBatch);
    }
}