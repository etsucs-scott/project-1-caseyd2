# Adventure Game


## How to run:

Open AdventureGame.sln in VS. Make sure AdventureGame.Cli is selected as the startup project. Press Run



## Controls:

W = Up
S = Down
A = Left
D = Right


## Display Format:
 
The maze redraws after every move. They game shows the maze, your HP, and a message after each turn.


## Symbols:

# = Wall
@ = Player
M = Monster
P = Potion (+20 points)
W = Weapon (increases attack)
E = Exit


## Win and Lose:

You win by reaching the exit. You lose if your HP reaches 0.

## Battles:

If you move onto a monster, a battle begins. Both the player and the monster lose HP.
If the monster reaches 0 HP, it dies. If the player reaches 0 HP, the game is over.


## UML Diagram:
UML FILE: 'Dawson Casey UML Project 1(2).pdf'
The UNL diagram shows the required classes, inheritance, interface implementation, and relationships used in the project.


## Git Clone: 
https://github.com/etsucs-scott/project-1-caseyd2.git

## Build:
dotnet build

## Run:
dotnet run --project src/AdventureGame.Cli
