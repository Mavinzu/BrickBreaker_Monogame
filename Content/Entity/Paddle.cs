using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Entity;

public class Paddle
{
    Texture2D sprite;
    Vector2 position;
    Rectangle boxCollider2D;
    public Paddle(Texture2D Sprite, Rectangle Position)
    {
        sprite = Sprite;
        position = new Vector2(Position.X, Position.Y);
        boxCollider2D = Position;
    }

    public void Update(GameTime gameTime)
    {
        boxCollider2D.Location = new Point((int)position.X, (int)position.Y);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(sprite, position, null, Color.White);
        spriteBatch.Draw(sprite, boxCollider2D, Color.Blue * 0.5f);
    }
}