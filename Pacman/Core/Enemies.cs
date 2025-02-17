using System;
using Microsoft.Xna.Framework;

namespace Pacman.Core;

public class Enemies : GameObject
{
    // Direction dans laquelle l'ennemi a eu une collision
    private Collision.Direction _collidedDirection;

    // Propriété pour obtenir ou modifier la direction de collision
    public Collision.Direction collidedDirection
    {
        get => _collidedDirection;
        set => _collidedDirection = value;
    }

    // Générateur de nombres aléatoires pour changer la direction des ennemis
    private readonly Random _random;
    
    public Enemies(int totalAnimationFrames, int frameWidth, int frameHeight, World world)
        : base(totalAnimationFrames, frameWidth, frameHeight, world)
    {
        _random = new Random(); 
        direction = GetRandomDirection(); // Assigne une direction aléatoire
        frameIndex = framesIndex.RIGHT_1; // Début sur la frame de déplacement vers la droite
        _collidedDirection = Collision.Direction.NONE; // Pas de collision au départ
    }

    // Retourne une direction aléatoire (haut, bas, gauche ou droite)
    private Collision.Direction GetRandomDirection()
    {
        return (Collision.Direction)_random.Next(0, 4); // 4 directions possibles 
    }

    // Déplace l'ennemi et gère les collisions
    public void Move()
    {
        if (!Collision.Collided(this, world))
        {
            // Déplacement de l'ennemi en fonction de sa direction actuelle
            switch (direction)
            {
                case Collision.Direction.TOP:
                    Position.Y -= 1; // Monte
                    break;
                case Collision.Direction.LEFT:
                    Position.X -= 1; // Va à gauche
                    break;
                case Collision.Direction.BOTTOM:
                    Position.Y += 1; // Descend
                    break;
                case Collision.Direction.RIGHT:
                    Position.X += 1; // Va à droite
                    break;
            }
        }
        else
        {
            // Si l'ennemi rencontre un mur, il change de direction
            direction = GetRandomDirection();
        }
    }

    // Met à jour l'animation en fonction de la direction actuelle
    public void UpdateFrame(GameTime gameTime)
    {
        time += (float)gameTime.ElapsedGameTime.TotalSeconds; // Incrémente le temps d'animation

        if (time > frameTime)
        {
            // Alterne les frames d'animation selon la direction actuelle
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

            time = 0f; // Réinitialise le temps d'animation
        }

        // Définit la partie de l'image de l'ennemi à afficher 
        Source = new Rectangle(
            (int)frameIndex * frameWidth, // Sélection de la bonne colonne de sprite
            0, // Toutes les frames sont sur la même ligne
            frameWidth, // Largeur d'un sprite
            frameHeight // Hauteur d'un sprite
        );
    }
}
