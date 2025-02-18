![](/banner-pacman.png)

<h1 align="center">🕹️ PAC-MAN</h1>

<br/>

### 📃 Description

__Pacman__ is a replication of the famous Pac-Man game using __MonoGame__ and C#. This project explores the features of the MonoGame engine for creating a 2D game.

#### The game currently includes :

* Pacman movement with wall collision management.
* Display of a playable map.
* Integration of enemies.
  
---

### ⚙️ Technologies Used

* __[C#](https://learn.microsoft.com/fr-fr/dotnet/csharp/)__:  Main programming language.
* __[MonoGame](https://monogame.net/)__: 2D and 3D game development framework.
* __[.NET SDK](https://dotnet.microsoft.com/en-us/)__:  Required to run the project and use .NET commands

---

### 📁 Folder Structure
```
project-root
├── Content           /* Graphics and audio resources */
├── Core              /* Contains game logic */
│ ├── Collision.cs    /* Collision management */
│ ├── Enemies.cs      /* Enemy behavior management */
│ ├── GameObject.cs   /* Game's objects management */
│ ├── Player.cs       /* Pac-Man behaviour management */
│ └── World.cs        /* Map management */
├── Game1.cs          /* Game main class */
└──  Program.cs       /* Application entry point */
```
---

### 🛠️ Prerequisites

You will need  __[.NET SDK](https://dotnet.microsoft.com/en-us/)__  `v6.0` or higher installed on your system.

You will also need __MonoGame__: To install it, run the following command:  
```
dotnet new install MonoGame.Templates.CSharp
```
__Rider / VSCode__ (or another IDE compatible with C# and .NET)

---

### 💻 Installation and running


#### 1. __Clone the projet:__
   
```
git clone https://github.com/PaulineFranck98/Pacman.git
```


#### 2. __Check dependencies:__

Make sure `.NET SDK` is installed by running:
```
dotnet --version
```

<br/>

Make sure `MonoGame` is installed by running:
```
dotnet new --list | grep MonoGame
```

#### 3. __Starting the project:__

Normal run: 
```
dotnet run
```
<br/>

Run with automatic reload: 
```
dotnet watch run
```

### 🔜 Upcoming features:

* Score system.

* Advanced ghost behavior.

* Sounds and animations.

* Improved map and interaction.


