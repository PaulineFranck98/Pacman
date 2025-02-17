using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman.Core;

public class PacDot
{
    public Vector2 Position;
    public bool IsEaten;
    private Texture2D _texture;
    public int _size;

    public PacDot(Vector2 position, Texture2D texture, int size)
    {
        Position = position;
        _texture = texture;
        _size = size;
        IsEaten = false;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (!IsEaten)
        {
            spriteBatch.Draw(_texture, new Rectangle((int)Position.X, (int)Position.Y, _size, _size), Color.White);
        }
    }
}