using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman.Core;

public class GameObject
{
    // Référence au monde / la carte dans lequel l'objet évolue (pour les collisions et interactions)
    public World world;
    
    // Position de l'objet dans le jeu (coordonnées X, Y)
    public Vector2 Position;
    
    // Texture de l'objet (image affichée)
    public Texture2D Texture;
    
    // Délimite la portion de l'image affichée 
    public Rectangle Source;
    
    // Durée écoulée depuis la dernière mise à jour de l'animation
    public float time;
    
    // Temps d'affichage d'une frame d'animation avant de passer à la suivante
    public float frameTime = 0.1f;
    
    // Indice de l'image actuellement affichée dans l'animation
    public framesIndex frameIndex;
    
    // Définition des différentes frames d'animation en fonction de la direction
    public enum framesIndex
    {
        RIGHT_1 = 0,  
        RIGHT_2 = 1,  
        BOTTOM_1 = 2, 
        BOTTOM_2 = 3, 
        LEFT_1 = 4,   
        LEFT_2 = 5,  
        TOP_1 = 6,    
        TOP_2 = 7     
    }

    // Direction actuelle de l'objet
    public Collision.Direction direction;
    
    // Nombre total de frames dans l'animation
    private int _totalFrames;
    public int totalFrames => _totalFrames;

    // Largeur d'une seule frame d'animation (ex: largeur d'un sprite)
    private int _frameWidth;
    public int frameWidth => _frameWidth;
   
    // Hauteur d'une seule frame d'animation (ex: hauteur d'un sprite)
    private int _frameHeight;
    public int frameHeight => _frameHeight;

    // Constructeur par défaut 
    public GameObject()
    {
    }
    
    public GameObject(int totalAnimationFrames, int frameWidth, int frameHeight, World world)
    {
        _totalFrames = totalAnimationFrames; // Nombre total de frames d'animation
        _frameWidth = frameWidth;           // Largeur d'une frame
        _frameHeight = frameHeight;         // Hauteur d'une frame
        this.world = world;                 
    }

    // Méthode pour dessiner une animation 
    public void DrawAnimation(SpriteBatch spriteBatch)
    {
        if (Texture != null) // Vérifie que la texture existe
        {
            spriteBatch.Draw(Texture, Position, Source, Color.White);
        }
    }
    
    // Met à jour l'animation de l'objet en fonction du temps écoulé
    public void UpdateFrame(GameTime gameTime)
    {
        // Ajoute le temps écoulé depuis la dernière mise à jour
        time += (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Si le temps d'affichage de la frame actuelle est écoulé, on change de frame
        if (time > frameTime)
        {
            switch (direction)
            {
                case Collision.Direction.TOP:
                    frameIndex = frameIndex == framesIndex.TOP_1 ? framesIndex.TOP_2 : framesIndex.TOP_1;
                    break;
                case Collision.Direction.LEFT:
                    frameIndex = frameIndex == framesIndex.LEFT_1 ? framesIndex.LEFT_2 : framesIndex.LEFT_1;
                    break;
                case Collision.Direction.BOTTOM:
                    frameIndex = frameIndex == framesIndex.BOTTOM_1 ? framesIndex.BOTTOM_2 : framesIndex.BOTTOM_1;
                    break;
                case Collision.Direction.RIGHT:
                    frameIndex = frameIndex == framesIndex.RIGHT_1 ? framesIndex.RIGHT_2 : framesIndex.RIGHT_1;
                    break;
            }

            // Réinitialise le temps pour la prochaine frame
            time = 0f; 
        }

        // Met à jour le rectangle `Source` pour afficher la bonne frame d'animation
        Source = new Rectangle(
            (int)frameIndex * frameWidth, // Position X de la frame dans l'image du sprite
            0,                            // Position Y (toujours 0, car les frames sont alignées horizontalement)
            frameWidth,                   // Largeur de la frame
            frameHeight                   // Hauteur de la frame
        );
    }

    // Méthode pour dessiner l'objet (statique, sans animation)
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Color.White);
    }
}
