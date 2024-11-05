using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Entity;

public class Element
{
    Texture2D sprite;
    Vector2 position;
    Rectangle boxCollider2D;

    public Rectangle GetCollider{
        get{
            return boxCollider2D;
        }
        private set{
            boxCollider2D = value;
        }
    }
    public Element(Texture2D Sprite, Rectangle Position)
    {
        sprite = Sprite;
        position = new Vector2(Position.X, Position.Y);
        boxCollider2D = Position;
    }

    public void Update(GameTime gameTime)
    {
        
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(sprite, position, null, Color.White);
        spriteBatch.Draw(sprite, boxCollider2D, Color.Blue * 0.5f);
    }
}