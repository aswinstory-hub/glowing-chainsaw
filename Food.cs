using Raylib_cs;

class Food
{
    int size = 40;
    const int CELL_SIZE = 40;
    int foodX = 40;
    int foodY = 40;

    // Update functions

    public void UpdateFood(int player_x, int player_y)
    {
        if (player_x == foodX & player_y == foodY)
        {
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        foodX = Raylib.GetRandomValue(0, 31) * CELL_SIZE;
        foodY = Raylib.GetRandomValue(0, 17) * CELL_SIZE;
    }

    // Draw functions
    public void Draw()
    {
        Raylib.DrawRectangle(foodX, foodY, size, size, Color.Red);
    } 
}