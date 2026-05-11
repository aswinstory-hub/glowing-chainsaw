using Raylib_cs;
using System.Numerics;

class Game
{

    Player player;
    Food food;
    public bool gameOver = false; 
    Color bg = new Color(120, 180, 90, 255);
    Color soft_black = new Color(20, 20, 20, 255);

    public Game()
    {
        Raylib.InitWindow(720, 822, "Snake");
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

    Camera2D camera;

    void StartCamera()
    {
        camera = new Camera2D();

        camera.Target = Vector2.Zero;

        camera.Offset = new Vector2(0, 100);

        camera.Zoom = 1f;

        camera.Rotation = 0f;
    }

    void Draw()
    {
        StartCamera();

        Raylib.BeginDrawing();

        Raylib.ClearBackground(bg);

        Raylib.BeginMode2D(camera);

        DrawGrid();

        food.Draw();

        player.Draw();

        Raylib.EndMode2D();

        DrawScore();

        Raylib.EndDrawing();
    }


    void DrawGrid()
    {
        for (int x = 0; x <= 720; x += 40)
        {
            Raylib.DrawLine(x, 0, x, 720, soft_black);
        }

        for (int y = 0; y <= 720; y += 40)
        {
            Raylib.DrawLine(0, y, 720, y, soft_black);
        }
    }

    void DrawScore()
    {
        string scoreText = "Score: " + player.score;

        int textWidth = Raylib.MeasureText(scoreText, 30);

        Raylib.DrawText(
            scoreText,
            720 - textWidth - 20,
            20,
            30,
            Color.Black
        );
    }
    void GameOverScreen()
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(bg);

        DrawRestartMenu();

        Raylib.EndDrawing();

        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            RestartGame();
        }
    }

    void DrawRestartMenu()
    {
        string gameOverText = "GAME OVER";
        int gameOverWidth = Raylib.MeasureText(gameOverText, 30);

        Raylib.DrawText(
            gameOverText,
            720 - gameOverWidth - 320,
            330,
            50,
            Color.Red     
        );

        string RestartText = "Press Enter to Restart";
        int RestartWidth = Raylib.MeasureText(RestartText, 30);
        Raylib.DrawText(
            "Press Enter to Restart",
            720 - RestartWidth - 160,
            440,
            30,
            soft_black 
        );
    }

    void RestartGame()
    {
        Raylib.ClearBackground(bg);
        player = new Player();
        food = new Food();
        gameOver = false;
    }
}