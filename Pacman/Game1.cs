using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pacman.Core;

namespace Pacman;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    // Définition des dimensions de la fenêtre du jeu
    public const int WINDOW_WIDTH = 224;
    public const int WINDOW_HEIGHT = 248;

  
    World world;    // La carte du jeu 
    Player player;  // Pacman

    // Liste des ennemis présents dans le jeu
    private List<Enemies> enemies = new();

    // Constructeur de la classe 
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);  // Création du gestionnaire graphique
        Content.RootDirectory = "Content";             // Définition du dossier où sont stockés les images, sons, etc
        IsMouseVisible = true;                         // Rend le curseur visible pendant l'exécution du jeu
    }

    // Appelée au démarrage du jeu pour initialiser les objets et paramètres du jeu
    protected override void Initialize()
    {
        // Initialisation de l'environnement avec une couleur de collision (bleu : la couleur des murs)
        world = new World(new Color(0, 128, 248));

        // Initialisation de Pacman (image divisée en 8 parties de 13x13 pixels)
        player = new Player(8, 13, 13, world);

        // Création de 4 ennemis et ajout à la liste des ennemis
        for (int i = 0; i < 4; i++)
        {
            Enemies enemy = new Enemies(8, 14, 14, world); // Création d'un ennemi (image divisée en 8 parties de 14x14 pixels)
            enemy.Position = new Vector2(100 + (i * 20), 100); // Placement initial des ennemis sur la carte
            enemies.Add(enemy); // Ajout de l'ennemi à la liste des ennemis
        }

        // Configuration de la taille de la fenêtre du jeu
        _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
        _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
        _graphics.ApplyChanges(); // Application des changements de taille de la fenêtre (à ne pas oublier)

        base.Initialize(); 
    }

    // Chargement des contenus 
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice); // Création du gestionnaire de 'dessin'

        // Chargement de l'image de l'image de fond et définition de sa position à 0,0 (en haut à gauche)
        world.Texture = Content.Load<Texture2D>("world"); // Chaque image doit avoir un nom unique
        world.Position = new Vector2(0, 0);

        // Initialisation du tableau contenant les couleurs des pixels des murs pour la détection des collisions
        world.colorTab = new Color[world.Texture.Width * world.Texture.Height];
        world.Texture.GetData(world.colorTab); 

        // Chargement et positionnement de Pacman sur la carte
        player.Texture = Content.Load<Texture2D>("pacman");
        player.Position = new Vector2(0, 109); // Position initiale

        // Chargement de la texture des ennemis
        foreach (var enemy in enemies)
        {
            enemy.Texture = Content.Load<Texture2D>("fantom-red"); // Chargement de l'image du fantôme rouge
        }
    }

    // Mise à jour (exécutée à chaque frame)
    protected override void Update(GameTime gameTime)
    {
        // Vérifie si la touche "Échap" ou "Retour" est appuyée pour quitter le jeu
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // Déplace Pacman en fonction des touches du clavier : récupère l'état avec GetState()
        player.Move(Keyboard.GetState());

        // Met à jour l'animation de Pacman
        player.UpdateFrame(gameTime);

        // Mise à jour du mouvement et de l'animation des ennemis
        foreach (var enemy in enemies)
        {
            enemy.Move();                 // Déplacement automatique des ennemis
            enemy.UpdateFrame(gameTime);   // Animation des ennemis
        }

        // Vérifie si Pacman entre en collision avec un ennemi
        if (Collision.CollidedWithEnemy(player, enemies))
        {
            // Si Pacman est touché, il revient à sa position initiale
            player.Position = new Vector2(0, 109);
        }

        base.Update(gameTime); 
    }

    // Dessine les éléments du jeu (aussi exécuté à chaque frame après l'Update)
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue); // Efface l'écran et met un fond bleu

        // Début du 'dessin' des éléments
        _spriteBatch.Begin();

        world.Draw(_spriteBatch); // Dessine le fond (carte)

        player.DrawAnimation(_spriteBatch); // Dessine Pacman (qui est animé)

        // Dessine tous les ennemis (qui sont animés)
        foreach (var enemy in enemies)
        {
            enemy.DrawAnimation(_spriteBatch);
        }

        _spriteBatch.End(); // Le rendu de l’image est effectif à l’appel de la méthode End 

        base.Draw(gameTime); 
    }
}
