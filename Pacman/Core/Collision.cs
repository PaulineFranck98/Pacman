using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Pacman.Core;


public static class Collision
{
    // Enumération pour représenter les directions de déplacement
    public enum Direction
    {
        NONE = -1, // Aucune direction (valeur par défaut)
        LEFT = 0,  // Gauche
        RIGHT = 1, // Droite
        TOP = 2,   // Haut
        BOTTOM = 3 // Bas
    }
    
    // Fonction qui récupère la couleur d'un pixel à une position donnée
    private static Color GetColorAt(GameObject gameObject, World world)
    {
        // La couleur est celle des murs (collisions)
        Color color = world.collisionColor;

        // Vérifie que la position du GameObject est bien dans les limites de l'image du monde
        if ((int)gameObject.Position.X >= 0 && (int)gameObject.Position.X < world.Texture.Width
                                            && (int)gameObject.Position.Y >= 0 && (int)gameObject.Position.Y < world.Texture.Height)
        {
            // Selon la direction du GameObject, on récupère la couleur du pixel à l'avant
            switch (gameObject.direction)
            {
                case Direction.RIGHT:
                {
                    // Récupère la couleur du pixel à droite du personnage 
                    color = world.colorTab[((int)gameObject.Position.X + gameObject.frameWidth) +
                                           ((int)gameObject.Position.Y + (gameObject.frameHeight / 2)) * world.Texture.Width];
                }
                    break;
                case Direction.LEFT:
                {
                    // Récupère la couleur du pixel à gauche du personnage 
                    color = world.colorTab[(int)gameObject.Position.X +
                                           ((int)gameObject.Position.Y + (gameObject.frameHeight / 2)) * world.Texture.Width];
                }
                    break;
                case Direction.BOTTOM:
                {
                    // Récupère la couleur du pixel en bas du personnage 
                    color = world.colorTab[((int)gameObject.Position.X + (gameObject.frameWidth / 2)) +
                                           ((int)gameObject.Position.Y + gameObject.frameHeight) * world.Texture.Width];
                }
                    break;
                case Direction.TOP:
                {
                    // Récupère la couleur du pixel en haut du personnage 
                    color = world.colorTab[((int)gameObject.Position.X + (gameObject.frameWidth / 2)) +
                                           (int)gameObject.Position.Y * world.Texture.Width];
                }
                    break;
            }
        }

        // Retourne la couleur détectée à la position du GameObject
        return color;
    }

    // Vérifie si un objet (Pacman ou un ennemi) est en collision avec un mur
    public static bool Collided(GameObject gameObject, World world)
    {
        bool b = false;
        // Récupère la couleur à la position du GameObject
        Color color = GetColorAt(gameObject, world);

        // Si la couleur correspond à la couleur des murs, alors il y a collision
        if (color != world.collisionColor)
            b = false; // Pas de collision
        else
            b = true;  // Collision 

        return b;
    }
    
    // Vérifie si Pacman entre en collision avec un ennemi
    public static bool CollidedWithEnemy(Player player, List<Enemies> enemies)
    {
        // Parcourt tous les ennemis
        foreach (var enemy in enemies)
        {
            // Vérifie si les positions de Pacman et de l'ennemi se superposent
            if (player.Position.X < enemy.Position.X + enemy.frameWidth &&   // Pacman à gauche de l'ennemi
                player.Position.X + player.frameWidth > enemy.Position.X &&   // Pacman à droite de l'ennemi
                player.Position.Y < enemy.Position.Y + enemy.frameHeight &&   // Pacman au-dessus de l'ennemi
                player.Position.Y + player.frameHeight > enemy.Position.Y)    // Pacman en dessous de l'ennemi
            {
                return true; // Collision détectée avec un ennemi
            }
        }

        return false; // Aucune collision détectée avec les ennemis
    }
}

