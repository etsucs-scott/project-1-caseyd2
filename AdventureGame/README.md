Adventure Game


How to run:

Open AdventureGame.sln in VS. Make sure AdventureGame.Cli is selected. Press Run



Controls:

W = Up
S = Down
A = Left
D = Right


Symbols:

# = Wall
@ = Player
M = Monster
P = Potion (+20 points)
W = Weapon (increases attack)
E = Exit



Display:

The game shows the maze, your HP, and a message after each move you make. 



Win and Lose:

You win by reaching the exit. You lose if your HP reaches 0.



Battles:

If you move onto a monster, a battle begins. Both the player and the monster lose HP.
If the monster reaches 0 HP, it dies. If the player reaches 0 HP, the game is over.



UML Diagram:

The UML diagram shows each class and how they link together. 



Clone: 
https://github.com/etsucs-scott/project-1-caseyd2.git


Build:
dotnet build

Run:
dotnet run --project AdventureGame.Cli
