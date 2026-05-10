using Raylib_cs;

class Player
{
    // State Variables
    public int x = (1280/2) - 40;
    public int y = (720/2) - 40;
    public int score = 0;
    int speed = 40;
    int size = 40;
    int x_direction = 0;
    int y_direction = 0;
    float timer = 0f;
    float moveDelay = 0.3f;


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
        HandleInput();

        timer += Raylib.GetFrameTime();

        if (timer >= moveDelay)
        {
            x += x_direction * speed;
            y += y_direction * speed;
            
            timer = 0f;
        } 
    }

    // Draw Functions
    public void Draw()
    {
        Raylib.DrawRectangle(x, y, size, size, Color.DarkGreen);
    }

}