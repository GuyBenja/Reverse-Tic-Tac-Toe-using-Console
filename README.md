## Overview

The "Reversed Tic Tac Toe" is a console-based game developed in the .NET environment using C#. The game involves two players taking turns to place their symbols on a square game board. The objective is to create a sequence of their symbols (either "X" or "O") along the board, either horizontally, vertically, or diagonally. The game provides the option to play against another human player or against the computer, with a bonus for implementing artificial intelligence for the computer's moves.

## Goals

The goals of this exercise are:

1. Implement object-oriented programming principles in a .NET environment using C#.
2. Utilize the `string` class and working with arrays/collections.
3. Work with external DLLs (Assemblies) to clear the console screen and provide a better user experience.
4. Develop a console-based game with a simple user interface to interact with the players.
5. Provide an option to play against the computer, which randomly selects its moves or implements artificial intelligence for more challenging gameplay.

## Functionality

The functionality of the "Reversed X-Mix Dricks" game includes:

1. Setting the size of the game board (a square matrix) between 3x3 and 9x9.
2. Selecting the game mode: two-player or against the computer.
3. Displaying the game board as an empty matrix.
4. Allowing players to take turns and choose a cell to place their symbols ("X" or "O") on the board.
5. Validating user input and displaying appropriate messages for invalid moves or already occupied cells.
6. Clearing the console screen before displaying the updated game board.
7. Determining the winner or announcing a draw when no sequence is formed.
8. Allowing players to choose to play another round with the same settings.
9. Implementing random moves for the computer or providing AI for more challenging gameplay.

## Project Structure

The project consists of the following components:

1. `Main` class: The entry point of the application, responsible for initializing the game and managing user interaction.
2. `GameBoard` class: Represents the game board matrix and handles the logic for placing symbols, checking for winning sequences, and validating moves.
3. `Player` class: Represents a player in the game, keeping track of their chosen symbol ("X" or "O") and managing their moves.
4. `ComputerPlayer` class (optional): Represents the computer player, responsible for making random moves or implementing AI for the computer's moves.
5. External DLL (`dll.ConsoleUtils02.Ex`): Contains the `Screen.ConsoleUtils02.Ex` class with the `Clear` method used to clear the console screen.

## Installation and Usage

To run the Reversed Tic-Tac-Toe game:

Clone the repository to your local machine using the following command:

```
git clone https://github.com/GuyBenja/Reverse-Tic-Tac-Toe-using-Console.git
```

Open the solution file in Microsoft Visual Studio or your preferred C# development environment.

Build the solution to ensure all dependencies are resolved and the projects are compiled.

Run the project to interact with the Reversed Tic-Tac-Toe game. The application will display the game board and prompt you to set the board size and choose the game mode.

Follow the on-screen instructions to play the game, and take turns making your moves on the board.

If you chose to play against the computer, the computer will either make random moves or use artificial intelligence for more challenging gameplay.

After the game ends, the winner will be announced, or a draw will be declared if there is no winning sequence.

To play another round with the same settings, follow the prompts at the end of the game.

## Contribution and Support

Contributions to the project, such as bug fixes or improvements, are welcome. To contribute, follow these steps:

1. Fork the project on the GitHub repository.
2. Make your changes in a new branch.
3. Create a pull request with a clear description of your changes.
4. Your contribution will be reviewed and merged if it meets the project's standards.

For support or questions regarding the exercise, you can reach out to the course community or the instructor. However, avoid sharing complete solutions or copying code from others, as this is against the course's principles and may result in penalties.
