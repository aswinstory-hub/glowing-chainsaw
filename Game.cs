using Raylib_cs;

class Game
{

    Player player;
    float timer = 0f;
    float moveDelay = 0.4f;

    public Game()
    {
        Raylib.InitWindow(1280, 720, "Snake");
        Raylib.SetTargetFPS(60);

        player = new Player();   
    }

    public void Run()
    {
        while (!Raylib.WindowShouldClose())
        {
            Update();
            Draw();
        }

        Raylib.CloseWindow();
    }

    void Update()
    {
        player.HandleInput();

        timer += Raylib.GetFrameTime();

        if (timer >= moveDelay)
        {
            player.Move();

            timer = 0f;
        } 
    }

    void Draw()
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.Black);

        player.Draw();

        Raylib.EndDrawing();

    }
}