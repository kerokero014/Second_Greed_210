using Raylib_cs;
using Greed.Game.Casting;


namespace Greed.Game.Services
{
    public class KeyboardService
    {
        private int cellSize = 15;

        public KeyboardService(int cellSize)
        {
            this.cellSize = cellSize;
        }

        public Point GetDirection()
        {
            int dx = 0;
            int dy = 0;

            if ( Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                dx = -1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                dx = 1;
            }

            Point direction = new Point(dx, dy);
            direction = direction.Scale(cellSize);

            return direction;
        }
        
        public Point MoveArtifact()
        {
            int dx = 0;
            int dy = 1;

            Point direction = new Point(dx, dy);
            direction = direction.Scale(cellSize);

            return direction;
        }
    }
}