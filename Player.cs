using Raylib_cs;

class Player
{
    // State Variables
    int x = 630;
    int y = 350;
    int speed = 2;
    int size = 20;
    int x_direction = 0;
    int y_direction = 0;


    static Player()
    {
        Console.WriteLine("Player Has Spawned");
    }

    // Update Functions
    public void HandleInput()
    {
        var key = Raylib.IsKeyPressed;

        if (key(KeyboardKey.Up))
        {
            y_direction = -1;
        }
        if (key(KeyboardKey.Down))
        {
            y_direction = 1;
        }

    }

    public void Move()
    {
        HandleInput();
        x += x_direction;
        y += y_direction;
    }

    // Draw Functions
    public void Draw()
    {
        Raylib.DrawRectangle(x, y, size, size, Color.DarkGreen);
    }

}