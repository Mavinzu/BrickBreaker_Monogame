using BrickBreaker;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Scene;

namespace Entity;

public class Ball
{
    Texture2D sprite;
    Vector2 position, direction, spawnPoint;
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
    public Ball(Texture2D Sprite, Rectangle Position)
    {
        sprite = Sprite;
        position = new Vector2(Position.X, Position.Y);
        spawnPoint = position;
        boxCollider2D = Position;
        direction = new Vector2(0, -1);
        movementSpeed = 3;
    }

    public void Update(GameTime gameTime)
    {
        KeepInScreen();
        CheckElementCollider();
        CheckPaddleCollider();
        position += direction * movementSpeed;
        boxCollider2D.Location = new Point((int)position.X, (int)position.Y);
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(sprite, position, null, Color.White);
        spriteBatch.Draw(sprite, boxCollider2D, Color.Blue * 0.5f);
    }

    private void CheckElementCollider()
    {
        for(int i = 0; i < MainScene.elements.Count; i++)
        {
            if(boxCollider2D.Intersects(MainScene.elements[i].GetCollider))
            {
                direction = boxCollider2D.X + sprite.Width / 2 < MainScene.elements[i].GetCollider.X + MainScene.elements[i].GetCollider.Width / 2 ? new Vector2( -1, 1) : new Vector2( 1, 1);
                MainScene.elements.RemoveAt(i);
            }
        }
    }

    private void CheckPaddleCollider()
    {
        if(boxCollider2D.Intersects(MainScene.player.GetCollider))
        {
            direction = boxCollider2D.X + sprite.Width / 2 < MainScene.player.GetCollider.X + MainScene.player.GetCollider.Width / 2 ? new Vector2( -1, -1) : new Vector2( 1, -1);
        }
    }

    private void KeepInScreen()
    {
        if(position.X < 0)
        {
            direction.X = 1;
        }
        else if(position.X + sprite.Width > Game1.RESOLUTION_WIDTH)
        {
            direction.X = -1;
        }
    }
}