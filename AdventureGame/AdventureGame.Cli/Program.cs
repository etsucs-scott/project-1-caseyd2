using System;
using AdventureGame.Core;
using AdventureGame.Core.Characters;
using AdventureGame.Core.Engine;

namespace AdventureGame.Cli
{

    // This runs the game
    class Program
    {
    // Start of program
        static void Main(string[] args)
        {
            // Created maze, player, and game objects
            Maze maze = new Maze(10, 10);
            Player player = new Player("P");
            Game game = new Game(maze, player);


            string lastMessage = "Welcome to Adventure Game. Use W A S D or arrow keys";

           // Main loop
            
            while (true)

            {

                // Clear the screen before starting the game over
                Console.Clear();

                Console.WriteLine(lastMessage);

                // Shows the players health
                Console.WriteLine($"HP: " + player.Health + "/" + player.MaxHealth);

                Console.WriteLine();


                // Draw the maze and players position
                DrawMaze(maze, game);

                Console.WriteLine();
                Console.Write("Move: ");


                // Read the key the player pressed
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                // Convert the key to the movement direction
                string moveInput = ConvertKeyToMove(keyInfo);

                if (moveInput == null)
                {
                    lastMessage = "Invalid key";
                    continue;
                }


                // Try to move the player and get the result
                MoveResult result = game.Move(moveInput);

                lastMessage = result.Message;

                // If the player died
                if (result.Won)
                {
                    Console.Clear();
                    Console.WriteLine(lastMessage);
                    Console.WriteLine($"HP: " + player.Health + "/" + player.MaxHealth);
                    Console.WriteLine();
                    DrawMaze(maze, game);
                    Console.WriteLine();
                    Console.WriteLine("You Win");
                    break;

                }

                if (result.Died)
                {
                    Console.Clear();
                    Console.WriteLine(lastMessage);
                    Console.WriteLine($"HP: " + player.Health + "/" + player.MaxHealth);
                    Console.WriteLine();
                    DrawMaze(maze, game);
                    Console.WriteLine();
                    Console.Write("Game Over");
                    break;
                }
            }

            // Turns WASD into movement commands
            static string ConvertKeyToMove(ConsoleKeyInfo keyInfo)
            {
                if (keyInfo.Key == ConsoleKey.UpArrow) return "W";
                if (keyInfo.Key == ConsoleKey.DownArrow) return "S";
                if (keyInfo.Key == ConsoleKey.LeftArrow) return "A";
                if (keyInfo.Key == ConsoleKey.RightArrow) return "D";

                char c = char.ToUpper(keyInfo.KeyChar);
                if (c == 'W') return "W";
                if (c == 'A') return "A";
                if (c == 'S') return "S";
                if (c == 'D') return "D";

                return null;
            }

            //  Prints the maze grid on the console

            static void DrawMaze(Maze maze, Game game)
            {
                for (int row = 0; row < maze.Height; row++)
                {
                    for (int col = 0; col < maze.Width; col++)
                    {
                        if (row == game.PlayerRow && col == game.PlayerCol)
                        {
                            Console.Write('@');

                        }

                        else

                        {
                            char tile = maze.GetTile(row, col);

                            if (tile == ' ')
                                Console.Write('.');
                            else
                                Console.Write(tile);

                        }
                    }

                    Console.WriteLine();
                }

            }
        }
    }
}