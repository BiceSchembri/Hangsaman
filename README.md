# Hangsaman

A simple hangman game built in C#.

It follows Shaun Halverson's [tutorial](https://www.youtube.com/watch?v=Bg3rMMuQ6Oo) (see [here](https://github.com/ShaunHalverson/CsharpHangman) for his Github repo).

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [Customization](#customization)
- [Tools](#tools)
- [Credits](#credits)

## Installation

1. Clone the repository onto your machine:
   `git clone https://github.com/your-username/project.git`
   or copy the contents of the `Program.cs` file into a new `.cs` file.
2. Navigate to the correct folder: `cd your-path-here/Hangsaman`
3. Run the project: `dotnet run`

## Usage

The player can use the terminal to play the game. The goal is to guess the word (randomly chosen from a list) in six attempts or less.

The player can enter a letter at a time to complete the word. The terminal will display the letters already guessed, the hangman drawing, and the secret word updated with the letters that have been guessed correctly plus underscores for letters still to guess.

For each incorrect guess, the hangman drawing is updated.

After six incorrect attempts or when the word is completed, the game is over and a message is displayed to the user.

## Features

- **foreach** loops to iterate over the characters in the random word and check for correct/incorrect guesses
- **if ... else if** conditions to determine the different outcomes after the player's guesses.

## Customization

- You can add, remove or update the words in the word list:

```cs
List<string> wordDictionary = new List<string> { "button", "cookie", "internship", "nick", "mushroom", "ghost" };
```

- You can update the drawing and add or reduce the number of guesses allowed.
- You can customize the messages displayed to the user (Play, Guess already entered, End of game).

```cs
Console.WriteLine("\r\nGame is over! Thank you for playing.");
```

## Tools

To write the app, I used Microsoft's [Visual Studio](https://visualstudio.microsoft.com/) IDE.

You can chose another C# compatible IDE - for example, [Visual Studio Code](https://code.visualstudio.com/).

## Credits

Credits to [Shaun Halverson](https://github.com/ShaunHalverson/).
