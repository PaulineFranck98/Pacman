![](/banner-pacman.png)

<h1 align="center">PAC-MAN</h1>

<br/>

### 📃 Description

__Pacman__ is a recreation of the famous Pacman game using __MonoGame__ and C#. This project explores the features of the MonoGame engine for creating a 2D game.

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

### 💻 Running locally in development mode


#### 1. __Clone the projet:__
   
```
git clone https://github.com/PaulineFranck98/next-recipe-project-cda.git
```


#### 2. __Install dependencies:__

```
npm install
```


#### 3. __Configure environment variables:__

Create a `.env` file in the root directory and add your MongoDB URL: 
```
DATABASE_URL="<Your MongoDB URL>"
```
<br/>

Create a `.env.local` file in the root directory and paste your [Clerk API Credentials](https://clerk.com/docs/deployments/clerk-environment-variables?_gl=1*124mxpw*_gcl_au*ODIyNjQ3MjAxLjE3MzEwNzU0MjMuNTI4NTEzNDQ5LjE3MzMyNDAzNjQuMTczMzI0MDM2NA..*_ga*MTQ2MDg4MDU0MS4xNzMxMDc1NDIz*_ga_1WMF5X234K*MTczMzQxMTIzNy45LjEuMTczMzQxMTMwNi4wLjAuMA..#clerk-publishable-and-secret-keys):
```
NEXT_PUBLIC_CLERK_PUBLISHABLE_KEY="<Your Publishable Key>"
CLERK_SECRET_KEY="<Your Clerk Secret Key>"
```
You can find those credential in the section "API keys" on your Clerk dashboard. 
<br/>
#### 4. __Set up Prisma:__

Generate the Prisma client:
```
npx prisma generate
```

Apply Prisma migrations:
```
npx prisma db push
```

You can also access a visual editor for the data in your database by running:
```
npx prisma studio
```


#### 5. __Start the application:__
```
npm run dev
```

The application should now be running at http://localhost:3000 🎉

<br/>

---

### 🎨 Design Overview

#### Home Page
![](/public/homepage-recipes.png)
*The main page showcasing recipes in a carousel.*

#### Recipe Details
![](/public/recipe-detail.png)
*Detailed view of a recipe, including ingredients, tools and options to add the recipe to favorites or download it as a PDF.*

#### Blog section
![](/public/blog-recipe.png)
*Users can read, post and respond to articles.*


