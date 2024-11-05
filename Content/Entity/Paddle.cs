using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Entity;

public class Paddle
{
    Texture2D sprite;
    Vector2 position;
    Rectangle boxCollider2D;

    int movementSpeed;
    public Rectangle GetCollider{
        get{
            return boxCollider2D;
        }
        private set{
            boxCollider2D = value;
        }
    }
    public Paddle(Texture2D Sprite, Rectangle Position)
    {
        sprite = Sprite;
        position = new Vector2(Position.X, Position.Y);
        boxCollider2D = Position;
        movementSpeed = 5;
    }

    public void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();
        if(keyboardState.IsKeyDown(Keys.A))
        {
            position += Vector2.UnitX * -movementSpeed;
        } 
        else if(keyboardState.IsKeyDown(Keys.D))
        {
            position += Vector2.UnitX * movementSpeed;
        }
        boxCollider2D.Location = new Point((int)position.X, (int)position.Y);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(sprite, position, null, Color.White);
        spriteBatch.Draw(sprite, boxCollider2D, Color.Blue * 0.5f);
    }
}