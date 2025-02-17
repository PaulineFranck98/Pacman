using Microsoft.Xna.Framework;

namespace Pacman.Core;

public class World : GameObject
{
    public Color[] colorTab;
    
    private Color _collisionColor;
    public Color collisionColor => _collisionColor;
    
    public World(Color collisionColor)
    {
        _collisionColor = collisionColor;
    }
}