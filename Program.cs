using Raylib_cs;

Raylib.InitWindow(1280, 720, "My First Raylib Game");

Raylib.SetTargetFPS(60);

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.Black);

    Raylib.DrawText("HELLO RAYLIB", 250, 200, 30, Color.Green);

    Raylib.EndDrawing();
}

Raylib.CloseWindow();