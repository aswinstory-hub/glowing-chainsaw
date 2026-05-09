using Raylib_cs;

class Player
{
    // State Variables
    int x = 630;
    int y = 350;
    int speed = 20;
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

        if (key(KeyboardKey.Up))       {y_direction = -1; x_direction = 0;}
        if (key(KeyboardKey.Down))     {y_direction = 1;  x_direction = 0;}
        if (key(KeyboardKey.Right))    {x_direction = 1;  y_direction = 0;}
        if (key(KeyboardKey.Left))     {x_direction = -1; y_direction = 0;}

    }

    public void Move()
    {
        x += x_direction * speed;
        y += y_direction * speed;

    }

    // Draw Functions
    public void Draw()
    {
        Raylib.DrawRectangle(x, y, size, size, Color.DarkGreen);
    }

}