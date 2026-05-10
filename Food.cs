using Raylib_cs;

class Food
{
    int size = 40;
    const int CELL_SIZE = 40;
    int foodX = 40;
    int foodY = 40;

    // Update functions

    public void UpdateFood(Player player)
    {
        if (player.x == foodX & player.y == foodY)
        {
            player.score ++;
            Console.WriteLine("Score: " + player.score);       
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