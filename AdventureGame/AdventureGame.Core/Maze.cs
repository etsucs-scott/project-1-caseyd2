using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    // creates and manages the grid
    public class Maze
    {
        public int Width;
        public int Height;

        private char[,] grid;
// creates the maze and fills it with empty spaces, adds walls and places the exit.
        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            grid = new char[height, width];

        Random rand= new Random();

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                { 
                    grid[r, c] = ' ';
                }
            }

            for (int c = 0; c < width; c++)
            {
                grid[0, c] = '#';
                grid[Height - 1, c] = '#';
            }

            for (int r = 0; r < Height; r++)
            {
                grid[r, 0] = '#';
                grid[r, Width - 1] = '#';
            }

            for (int r = 1; r < Height - 1; r++)
            {
                for (int c = 1; c < Width - 1; c++)
                {
                    if (rand.Next(100) < 20)
                    {
                        grid[r, c] = '#';
                    }
                }
            }
            SetTile(Height - 2, Width - 2, 'E');

        }

        // checks if a position is inside the maze or not
        public bool InBounds(int row, int col)
        {
            return row >= 0 && row < Height && col >= 0 && col < Width;
        }

        public char GetTile(int row, int col)
        {
            return grid[row, col]; 
        }

        // returns the tile at a specific row and column
        public void SetTile(int row, int col, char tile)
        {
            grid[row, col] = tile;
        }

        // returns true if tile is a wall
        public bool IsWall(int row, int col)
        {
            return GetTile(row, col) == '#';
        }

        // returns true if tile is the exit 
        public bool IsExit(int row, int col)
        {
            return GetTile(row, col) == 'E';
        }
    }
}
