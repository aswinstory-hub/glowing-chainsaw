using Raylib_cs;

class Game
{

    Player player;
    Food food;

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
            Update();
            Draw();
        }

        Raylib.CloseWindow();
    }

    void Update()
    {
        player.Move();
        food.UpdateFood(player.x, player.y);
    }

    void Draw()
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.Black);

        food.Draw();

        player.Draw();

        Raylib.EndDrawing();

    }
}