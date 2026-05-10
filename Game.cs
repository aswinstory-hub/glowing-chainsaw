using Raylib_cs;

class Game
{

    Player player;
    Food food;
    public bool gameOver = false; 

    public Game()
    {
        Raylib.InitWindow(1280, 720, "Snake");
        Raylib.SetTargetFPS(60);

        player = new Player();   
        food = new Food();
    }

    public void Run()
    {
        while (!Raylib.WindowShouldClose())
        {
            if (!gameOver)
            {
                Update();
                Draw();
            }
            else if (gameOver)
            {
                GameOverScreen();
            }
        }

        Raylib.CloseWindow();
    }

    void Update()
    {
        player.Move();
        player.UpdateBody(food);
        gameOver = player.UpdateGameOver();
    }

    void Draw()
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.Black);

        food.Draw();

        player.Draw();

        Raylib.EndDrawing();

    }

    void GameOverScreen()
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.Black);

        DrawRestartMenu();

        Raylib.EndDrawing();

        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            RestartGame();
        }
    }

    void DrawRestartMenu()
    {
        Raylib.DrawText(
            "GAME OVER",
            430,
            250,
            50,
            Color.Red     
        );

        Raylib.DrawText(
            "Press Enter to Restart",
            390,
            340,
            30,
            Color.White 
        );
    }

    void RestartGame()
    {
        Raylib.ClearBackground(Color.Black);
        player = new Player();
        food = new Food();
        gameOver = false;
    }
}