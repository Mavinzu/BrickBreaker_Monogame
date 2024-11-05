using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Scene;

namespace Entity;

public class Ball
{
    Texture2D sprite;
    Vector2 position, direction;
    Rectangle boxCollider2D;
    public Ball(Texture2D Sprite, Rectangle Position)
    {
        sprite = Sprite;
        position = new Vector2(Position.X, Position.Y);
        boxCollider2D = Position;
        direction = new Vector2(0, -1);
    }

    public void Update(GameTime gameTime)
    {
        // position += direction * 2;
        boxCollider2D.Location = new Point((int)position.X, (int)position.Y);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(sprite, position, null, Color.White);
        spriteBatch.Draw(sprite, boxCollider2D, Color.Blue * 0.5f);
    }
}