using Raylib_cs;

class Food
{
    int size = 20;
    const int CELL_SIZE = 40;
    public int x = 40;
    public int y = 40;

    // Update functions


    public void SpawnFood()
    {
        x = Raylib.GetRandomValue(0, 31) * CELL_SIZE;
        y = Raylib.GetRandomValue(0, 17) * CELL_SIZE;
    }

    // Draw functions
    public void Draw()
    {
        Raylib.DrawCircle(x + (CELL_SIZE / 2), y + (size / 2), size, Color.Red);
    } 
}