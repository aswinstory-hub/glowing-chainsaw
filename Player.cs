using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

class Player
{
    // State Variables
    List<Vector2> position = new List<Vector2>(); // 600  // 320
    public int x = 600;
    public int y = 320; 
    public int score = 0;
    int speed = 40;
    int size = 40;
    int x_direction = 0;
    int y_direction = 0;
    float timer = 0f;
    float moveDelay = 0.3f;
    int grow = 0;


    public Player()
    {
        Console.WriteLine("Player Has Spawned");
        position.Add(new Vector2(x, y));
    }

    // Update Functions
    public void HandleInput()
    {
        var key = Raylib.IsKeyPressed;

        if (key(KeyboardKey.Up) & y_direction != 1)        {y_direction = -1; x_direction = 0;}
        if (key(KeyboardKey.Down) & y_direction != -1)     {y_direction = 1;  x_direction = 0;}
        if (key(KeyboardKey.Right) & x_direction != -1)    {x_direction = 1;  y_direction = 0;}
        if (key(KeyboardKey.Left) & x_direction != 1)      {x_direction = -1; y_direction = 0;}

    }

    public void Move()
    {
        HandleInput();

        timer += Raylib.GetFrameTime();

        if (timer >= moveDelay)
        {
            x += x_direction * speed;
            y += y_direction * speed;

            Vector2 newHead = new Vector2(x, y);
            position.Insert(0, newHead);
            
            if (grow > 0)
            {
                grow --;
            }   
            else 
            {
                position.RemoveAt(position.Count - 1);
            }

            timer = 0f;
        } 
    }

    public void UpdateBody(Food food)
    {
        if (food.x == x & food.y == y)
        {
            grow ++;
            score ++;
            Console.WriteLine(score);
            food.SpawnFood();
        }
    }

    // Draw Functions
    public void Draw()
    {
        foreach (Vector2 segment in position)
        {
            Raylib.DrawRectangle(Convert.ToInt32(segment.X), Convert.ToInt32(segment.Y), size, size, Color.DarkGreen);
        }
    }

}