using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using AdventureGame.Core;
using AdventureGame.Core.Characters;
namespace AdventureGame.Core.Engine
{
    // controls movement, battles, and items
    public class Game
    {
        private Maze maze;
        private Player player;

        private int playerRow;
        private int playerCol;

        private int bestWeaaponModifier;
        private Random rng;

        private const char EMPTY = ' ';
        private const char WALL = '#';
        private const char EXIT = 'E';
        private const char MONSTER = 'M';
        private const char WEAPON = 'W';
        private const char POTION = 'P';

        private const int BASE_DAMAGE = 10;
        private const int POTION_HEAL = 20;

        // gets the players current row in the maze
        public int PlayerRow => playerRow;

        // gets the players current column in the maze
        public int PlayerCol => playerCol;


        // Sets up the game with maze and player
        public Game(Maze maze, Player player)
        {
            this.maze = maze;
            this.player = player;

            rng = new Random();
            bestWeaaponModifier = 0;

            playerRow = 1;
            playerCol = 1;

            if (maze.InBounds(playerRow, playerCol))
                maze.SetTile(playerRow, playerCol, EMPTY);

            PlaceStuff();
        }

        // handles player movement and interactions after each move
        public MoveResult Move(string input)
        {
            // makes sure input was valid
            if (string.IsNullOrWhiteSpace(input))
            {
                return new MoveResult 
                { 
                    Moved = false, 
                    Message = "Enter W, A, S, D" 
                };
            }
      

            input = input.Trim().ToUpper();

            int newRow = playerRow;
            int newCol = playerCol;


            // Changes the target row or column based on input
            if (input == "W") newRow--;
            else if (input == "S") newRow++;
            else if (input == "A") newCol--;
            else if (input == "D") newCol++;
            else
            {
                return new MoveResult { Moved = false, Message = "Invalid entry" };
            }

            // prevents moving outside of the maze
            if (!maze.InBounds(newRow, newCol))
            {
                return new MoveResult { Moved = false, Message = "You can't go that way" };
            }

            char tile = maze.GetTile(newRow, newCol);

            // stops the player if they hit a wall
            if (tile == WALL)
            {
                return new MoveResult { Moved = false, Message = "You hit a wall" };
            }

            playerRow = newRow;
            playerCol = newCol;


            // player wins if they reach the exit
            if (tile == EXIT)
            {
                return new MoveResult
                {
                    Moved = true,
                    Won = true,
                    Message = "You found the exit. You Win"
                };
            }

            // starts a battle if they find monster
            if (tile == MONSTER)
            {
                MoveResult result = DoBattle();

                if (!result.Died)
                    maze.SetTile(playerRow, playerCol, EMPTY);
                return result;
            }


            // Gives a player a better weapon
            if (tile == WEAPON)
            {
                int modifier = rng.Next(1, 11);
                if (modifier > bestWeaaponModifier)
                    bestWeaaponModifier = modifier;
                maze.SetTile(playerRow, playerCol, EMPTY);

                return new MoveResult
                {
                    Moved = true,
                    Message = "You picked a weapon. Best weapon is now +" + bestWeaaponModifier + "."
                };
            }

            // heals the player when they pick up a potion
            if (tile == POTION)
            {
                player.TakeDamage(-POTION_HEAL);

                if (player.Health > player.MaxHealth)
                {
                    player.TakeDamage(player.Health - player.MaxHealth);
                }

                maze.SetTile(playerRow, PlayerCol, EMPTY);


                // Returns a default success message when move does not trigger something else
                return new MoveResult
                {
                    Moved = true,
                    Message = "You drank a potion (+20 HP). HP" + player.Health + "/" + player.MaxHealth
                };

            }

            return new MoveResult { Moved = true, Message = "You Moved" };
        }


        // randomly places items 
        private void PlaceStuff()
        {
            PlaceRandom(MONSTER, 6);
            PlaceRandom(WEAPON, 4);
            PlaceRandom(POTION, 4);
        }


        // Randomly places a specific tile in empty space
        private void PlaceRandom(char thing, int count)
        {
            int placed = 0;
            int tries = 0;

            // Keeps trying random positions until requested number of tiles is placed
            while (placed < count && tries < 5000)
            {
                tries++;

                int r = rng.Next(1, maze.Height - 1);
                int c = rng.Next(1, maze.Width - 1);

                // Skips the starting postion
                if (r == 1 && c == 1) continue;
                // Skips the exit tile
                if (maze.IsExit(r, c)) continue;
                // Only places tile in an empty space
                if (maze.GetTile(r, c) == EMPTY)
                {
                    maze.SetTile(r, c, thing);
                    placed++;
                }

            }
        }

        // handles fight between player and monster
        private MoveResult DoBattle()
        {
            int monsterHp = rng.Next(30, 51);
            Monster monster = new Monster("Monster", monsterHp);
            while (monster.Health > 0 && player.Health > 0)
            {

                // Player attacks first using their base attack plus the best weapon modifier
                int playerDamage = BASE_DAMAGE + bestWeaaponModifier;
                monster.TakeDamage(playerDamage);

                if (monster.Health <= 0)
                {
                    return new MoveResult
                    {
                        Moved = true,
                        Message = "You defeated the monster"
                    };
                }
                // Monster counterattacks if it survives
                int monsterDamage = monster.Attack(player);
                player.TakeDamage(BASE_DAMAGE);
                if (player.Health <= 0)
                {
                    return new MoveResult
                    {
                        Moved = true,
                        Died = true,
                        Message = "The monster defeated you. Game is over"
                    };
                }
            }
            // Fallback result if the loop exits unexpectedly 
            return new MoveResult { Moved = true, Message = "Battle ended" };

        }
    }
}

       
