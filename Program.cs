// Program.cs
// Chad Wallace
// March 2021
// This program is the game "Sticks".

using System;
//using System.Collections.Generic;   // for List

namespace SticksGame
{
    class Program
    {
        // This is a function to ask which game we want to play (player vs. player or AI vs. player)
        static int AskWhichGame()
        {
            string gameToPlayString = "";       // This is the string input on which game to play.
            int gameToPlay = 0;                 // This is the int input for which game to play.

            // Let's find out which game we are playing.
            // Ask if this is a player vs. player (1) or a player vs. AI (2) game.
            Console.Write("Options:\nPlay against a friend(1)\nPlay against the computer(2)\nPlay against a trained AI(3)\nWhich option do you take(1 - 3)? ");
            gameToPlayString = Console.ReadLine();
            int.TryParse(gameToPlayString, out gameToPlay);
            while (gameToPlay != 1 && gameToPlay != 2 && gameToPlay != 3)
            {
                Console.Write("You must enter 1, 2, or 3: ");
                gameToPlayString = Console.ReadLine();
                int.TryParse(gameToPlayString, out gameToPlay);
            }
            return gameToPlay;
        } // end AskWhichGame function

        // This is a function to get the number of sticks initially on the table for the game.
        static int GetTotalNumSticks()
        {
            string numSticksString = "";            // For the input of the number of sticks. This is a string.
            int totalNumSticks = 0;                 // This is the number of sticks in the game.

            // Get the number of sticks the game has initially and the player names from the user.
            // First, get the number of sticks from the user.
            Console.WriteLine("Welcome to the game of sticks!");
            Console.Write("How many sticks are there on the table initially (10-100)?: ");
            numSticksString = Console.ReadLine();
            int.TryParse(numSticksString, out totalNumSticks);
            // Make sure the number of sticks for the game is between 10 and 100.
            while (totalNumSticks < 10 || totalNumSticks > 100)
            {
                Console.WriteLine("Please enter a number between 10 and 100. ");
                numSticksString = Console.ReadLine();
                int.TryParse(numSticksString, out totalNumSticks);
            }
            return totalNumSticks;
        } // end GetTotalNumSticks function

        // This is a function to declare how many sticks are on the board
        static void StickStatus(int currentNumSticks)
        {
            if (currentNumSticks == 1)
            {
                Console.WriteLine("There is 1 stick left on the board. ");
            }
            else
            {
                Console.WriteLine("There are " + currentNumSticks + " sticks on the board.");
            }
        } // end StickStatus function

        //This is a function to ask the player how many sticks they want to take (betwen 1-3)
        static int HowMany(string currentPlayer, int currentNumSticks)
        {
            string numDeleteString = "";    // initialize variable for input for how many sticks are chosen.
            int numDelete = 0;              // initialize variable to put the input into an int variable.

            if (currentNumSticks > 3)
            {
                Console.Write(currentPlayer + ": How many sticks do you take? (1-3): ");
            }
            else if (currentNumSticks == 3)
            {
                Console.Write(currentPlayer + ": How many sticks do you take? Remember, there are only 3 left.: ");
            }
            else if (currentNumSticks == 2)
            {
                Console.Write(currentPlayer + ": How many sticks do you take? Remember, there are only 2 left.: ");
            }
            else if (currentNumSticks == 1)
            {
                Console.Write(currentPlayer + ": How many sticks do you take? Remember, there is only 1 left.: ");
            }
            numDeleteString = Console.ReadLine();
            int.TryParse(numDeleteString, out numDelete);

            if (currentNumSticks > 3) // a normal situation. They cannot grab them all.
            {
                // Make sure the number of sticks chosen is valid (1-3).
                while (numDelete < 1 || numDelete > 3)
                {
                    Console.Write("Please enter a number between 1 and 3. ");
                    numDeleteString = Console.ReadLine();
                    int.TryParse(numDeleteString, out numDelete);
                }
            } // end if currentNumSticks > 3
            else if (currentNumSticks == 3) // they could grab them all. . .
            {
                while ((numDelete != 1) && (numDelete != 2))
                {
                    if (numDelete > 3) // They can't take that many.
                    {
                        Console.Write("There aren't that many sticks on the board. Enter '1' or '2'. ");
                        numDeleteString = Console.ReadLine();
                        int.TryParse(numDeleteString, out numDelete);
                    } // end if numDelete > 3
                    else if (numDelete == 3) // They must leave one.
                    {
                        Console.Write("There are only 3 sticks left. You must leave one for your opponent or you will lose. Enter '1' or '2'. ");
                        numDeleteString = Console.ReadLine();
                        int.TryParse(numDeleteString, out numDelete);
                    } // end else if numDelete = 3
                    else if (numDelete < 1) // They must take one.
                    {
                        Console.Write("Nice try, but you must choose at least one stick. Enter '1' or '2'. ");
                        numDeleteString = Console.ReadLine();
                        int.TryParse(numDeleteString, out numDelete);

                    } // end else numDelete < 1
                } // end while numDelete not 1 or 2
            } // end else if currentNumSticks = 3
            else if (currentNumSticks == 2)
            {
                while (numDelete != 1) // One is the only valid response for 2 sticks left.
                {
                    if (numDelete > 2) // Not that many sticks available.
                    {
                        Console.Write("There aren't that many sticks on the board. Enter '1'. ");
                        numDeleteString = Console.ReadLine();
                        int.TryParse(numDeleteString, out numDelete);
                    } // end if for not that many sticks
                    else if (numDelete == 2)// must leave one stick.
                    {
                        Console.Write("There are only 2 sticks left. You must leave one for your opponent or you will lose. Enter '1'. ");
                        numDeleteString = Console.ReadLine();
                        int.TryParse(numDeleteString, out numDelete);
                    } // end else if must leave one stick.
                    else if (numDelete < 1) // They must take one.
                    {
                        Console.Write("Nice try, but you must choose at least one stick. Enter '1' or '2'. ");
                        numDeleteString = Console.ReadLine();
                        int.TryParse(numDeleteString, out numDelete);
                    }// end else if theuy must take one.
                } // end while numDelete not equal to 1
            } // end else if currentNumSticks = 2
            else // currentNumSticks = 1, the user must take 1 and will lose.
            {
                while (numDelete != 1) // one is the only valid response
                {
                    if (numDelete > 1) // There is only one stick left. Not more than one.
                    {
                        Console.Write("There is only one stick left. Please enter '1'. \nYou must pick up this last stick. You will lose. ");
                        numDeleteString = Console.ReadLine();
                        int.TryParse(numDeleteString, out numDelete);
                    } // end if grabbed too many sticks.
                    else if (numDelete < 1) // They must grab one.
                    {
                        Console.Write("Nice try, but you must grab the stick. Enter '1'. \nYou must pick up this last stick. You will lose. ");
                        numDeleteString = Console.ReadLine();
                        int.TryParse(numDeleteString, out numDelete);
                    } // end if they grab less than one
                } // end while loop for numDelete not equal to one.
            } // end else
            return numDelete;
        }  // end HowMany function

        static string GetPlayerInfo(int whichGame, int whichPlayer)
        {
            string playerOne = "human";      // This is a string variable that holds player 1's name.
            string playerTwo = "human or AI";      // This is a string variable that holds player 2's (Player or AI) name.
            string playerThree = "trained AI";    // This is a string variable that holds player 3's (AI) name.

            if (whichGame == 1) // we ae in player vs. player game
            {
                if (whichPlayer == 1)
                {
                    // Get player one's name.
                    Console.Write("Enter name for player 1: ");
                    playerOne = Console.ReadLine();

                    return playerOne;
                } // end if whichPlayer == 1
                else // (whichPlayer == 2)
                {
                    // Get player two's name.
                    Console.Write("Enter name for player 2: ");
                    playerTwo = Console.ReadLine();

                    return playerTwo;
                } // end else whichPlayer == 2
            } // end if whichGame == 1
            else if (whichGame == 2)
            {
                if (whichPlayer == 1)
                {
                    // Get player one's name.
                    Console.Write("Enter name for player 1: ");
                    playerOne = Console.ReadLine();

                    return playerOne;
                } // end if
                else //(whichPlayer == 2)
                {
                    Console.WriteLine("Player 2 will be the AI.");
                    playerTwo = "AI";
                    return playerTwo;
                } // end else
            } // end else if whichGame == 2
            else // whichGame == 3
            {
                if (whichPlayer == 1)
                {
                    // Get player one's name.
                    Console.Write("Enter name for player 1: ");
                    playerOne = Console.ReadLine();

                    return playerOne;
                } // end if 
                else if (whichPlayer == 2)
                {
                    Console.WriteLine("Player 2 will be the trained AI.");
                    playerTwo = "trained AI";
                    return playerTwo;
                } // end else if
                else // whichPlayer == 3
                {
                    playerThree = "helping AI";
                    return playerThree;
                } // end else whichPlayer == 3
            }  // end else whichGame == 3
        } // end getPlayerInfo function

        // This method greets our players.
        static void GreetPlayers(string playerOne, string playerTwo)
        {

            Console.WriteLine("\nWelcome " + playerOne + "(P1) and " + playerTwo + "(P2)!\n");
            Console.WriteLine("Let's begin! \n");

        } // end GreetPlayer function

        // This method declares the winner and loser of the game.
        static void DeclareWinner(string winner, string loser)
        {
            //Console.WriteLine("There are no sticks remaining on the board.");
            //Console.WriteLine("Congratulations " + winner + ". You won!");
            Console.WriteLine("Sorry " + loser + ". You lost.");

        } // end DeclarWinner function

        // This method asks if we want to play again.
        static bool WannaQuit()
        {
            string answer = ""; // initialize a string for user input.

            Console.Write("\nDo you want to quit playing this game? Enter 'q'. ");
            answer = Console.ReadLine();
            if (answer == "q")
            {
                return true;
            }
            else
            {
                return false;
            }
        } // end function wannaQuit


        static void Main(string[] args)
        {
            // Declare some variables.
            int totalNumSticks = 0;             // This is the initial number of sticks in the game.
            string playerOne = "human";         // This is a string variable that holds player 1's name (player)
            string playerTwo = "AI";            // This is a string variable that holds player 2's name (player or main AI)
            string playerThree = "Trained AI";  // This is a string variable that holds player 3's name (training AI)
            int howManyToDelete = 0;            // This is an int variable that holds how many sticks a player chooses to grab.
            int gameToPlay = 0;                 // This is the int input for which game to play.
            string winner = "";                 // This is a string variable to hold the winner's name.
            string loser = "";                  // This is a string variable to hold the loser's name.
            bool wannaQuit = false;             // This is a string declaring if we want to quit or not.

            // Get the number of sticks for the game and tell the sticks game instance using the setter.
            totalNumSticks = GetTotalNumSticks();

            // Make a new sticks game
            Game sticks = new Game(totalNumSticks);

            // Make the AI bot called bot1. This is player 2 - trained AI. Pass to it the number of sticks in our game.
            AI bot1 = new AI(totalNumSticks);

            // Make a training AI bot called bot2. This is the helping AI, player 3. Pass to it the number of sticks in our game.
            AI bot2 = new AI(totalNumSticks);

            // Ask which game we want to play.
            gameToPlay = AskWhichGame();
            if (gameToPlay == 1) // player vs. player
            {
                sticks.SetWhichGame(1); // playing player vs. player.
                                        // get player info for this game

                // Get all of the player information needed for this game.
                playerOne = GetPlayerInfo(1, 1);
                playerTwo = GetPlayerInfo(1, 2);
                // Store this info in the sticks.game
                sticks.SetPlayerOne(playerOne);
                sticks.SetPlayerTwo(playerTwo);
            }
            else if (gameToPlay == 2) // must have entered 2 to play the AI.
            {
                sticks.SetWhichGame(2); // playing player vs. AI

                // Get all of the player information needed for this game.
                playerOne = GetPlayerInfo(2, 1);
                playerTwo = GetPlayerInfo(2, 2);
                // Store this info in the sticks.game
                sticks.SetPlayerOne(playerOne);
                sticks.SetPlayerTwo(playerTwo);
            }
            else
            {
                sticks.SetWhichGame(3); // playing player vs. trained AI

                // Get all of the player information needed for this game.
                playerOne = GetPlayerInfo(3, 1);
                playerTwo = GetPlayerInfo(3, 2);
                playerThree = GetPlayerInfo(3, 3);
                // Store this info in the sticks.game
                sticks.SetPlayerOne(playerOne);
                sticks.SetPlayerTwo(playerTwo);
                sticks.SetPlayerThree(playerThree);
            }

            GreetPlayers(playerOne, playerTwo);

            // Let's repeat the game until we say we want to quit.
            while (wannaQuit == false)
            {
                // Get the player information.
                if (sticks.GetWhichGame() == 1) // We are in player v. player game
                {
                    // Set the current player as player one. That's who begins our game.
                    sticks.SetCurrentPlayer(sticks.GetPlayerOne());

                    // We need a loop to run this game until we get a winner.
                    // We'll use a while loop because we don't know how long the game will last.
                    // But, we keep playing until there are no sticks remaining.
                    while (sticks.GetCurrentNumSticks() > 0) // While there are still sticks available to take, we will ask the next player to take a turn.
                    {
                        // Update how many sticks are on the board.
                        StickStatus(sticks.GetCurrentNumSticks());

                        // Ask the current player how many sticks they want to choose.
                        howManyToDelete = HowMany(sticks.GetCurrentPlayer(), sticks.GetCurrentNumSticks());

                        // Take those sticks away.
                        sticks.SubtractSticks(howManyToDelete);

                        // It's the other player's turn.
                        sticks.NewTurn(1);

                    } // end while loop

                    // A player had to grab the last stick and lost the game. 
                    winner = sticks.GetCurrentPlayer(); // We did a newTurn at the end, so the current player is the winner.
                    sticks.NewTurn(1);  // We have to switch the current player back to who took the last stick.
                    loser = sticks.GetCurrentPlayer();  // This is the loser.
                    DeclareWinner(winner, loser);

                    // ask if we want to quit the player vs. player game (#1).
                    wannaQuit = WannaQuit();

                } // end if gameToPlay is player v. player
                else if (sticks.GetWhichGame() == 2) // We are doing a player vs. AI game
                {
                    // Set the current player as player one. That's who begins our game.
                    sticks.SetCurrentPlayer(sticks.GetPlayerOne());

                    // We need a loop to run this game until we get a winner.
                    // We'll use a while loop because we don't know how long the game will last.
                    // But, we keep playing until there are no sticks remaining.
                    while (sticks.GetCurrentNumSticks() > 0) // While there are still sticks available to take, we will ask the next player to take a turn.
                    {
                        // Update how many sticks are on the board.
                        StickStatus(sticks.GetCurrentNumSticks());

                        // We need to determine if a human player or the AI need to select sticks.
                        if (sticks.GetCurrentPlayer() == sticks.GetPlayerOne()) // it is a human player's turn.
                        {
                            // Ask the current player how many sticks they want to playingAI.
                            howManyToDelete = HowMany(sticks.GetCurrentPlayer(), sticks.GetCurrentNumSticks());
                        } // end if
                        else // it is the AI's turn
                        {
                            // We choose a ball from whose hat number = the number of sticks on the board.
                            // It returns a ball number of sticks to subtract back to main.
                            howManyToDelete = bot1.ChooseRandomBall(sticks.GetCurrentNumSticks());
                            if (howManyToDelete == 1)
                            {
                                Console.WriteLine(playerTwo + " takes " + howManyToDelete + " stick.");
                            } // end if
                            else
                            {
                                Console.WriteLine(playerTwo + " takes " + howManyToDelete + " sticks.");
                            } // end else
                        } // end else it is AI's turn

                        // Take those sticks away.
                        sticks.SubtractSticks(howManyToDelete);

                        // It's the other player's turn.
                        sticks.NewTurn(2);

                    } // end while loop for having sticks this round of the game

                    // A player had to grab the last stick and lost the game.
                    winner = sticks.GetCurrentPlayer(); // We did a newTurn at the end, so the current player is the winner.
                    sticks.NewTurn(2);  // We have to switch the current player back to who took the last stick.
                    loser = sticks.GetCurrentPlayer(); // This is the loser.
                    //DeclareWinner(winner, loser);

                    // Fix the hats (help the AI learn) and reset the besideHat array.
                    playerOne = sticks.GetPlayerOne();
                    if (winner == playerOne) // winner is the player, AI loses, so keep the besides balls out.
                    {
                        sticks.SetDidP2Win(false); // Set did player 1 win to true because player one won.
                                                   // reset the besideHat array to all 0's
                        bot1.ResetBesideHat();
                        bot1.CheckOneEachBallInHat();
                    } // end if
                    else // the winner is player 2, the AI.
                    {
                        sticks.SetDidP2Win(true); // The AI won.
                                                  // take besideHat array and add two of that digit back into the hats[index] for that hat. (double that ball)
                        bot1.PutBesideInHats();

                        // reset the besideHat array to all 0's
                        bot1.ResetBesideHat();
                        bot1.CheckOneEachBallInHat();
                    } // end else

                    // Reset the game.
                    // Reset the current number of sticks to the total number of sticks.
                    sticks.SetCurrentNumSticks(totalNumSticks);
                    // Reset the current player so player 1 goes first.
                    sticks.SetP2Turn(false);
                    sticks.SetCurrentPlayer(sticks.GetPlayerOne());

                    // ask if we want to quit the player vs. AI game (#2).
                    wannaQuit = WannaQuit();

                } // end else if gameToPlay = 2 Player vs. AI
                else if (sticks.GetWhichGame() == 3) // we have the player vs. trained AI game.  We need to let a bot play a bot
                {
                    int numGames = 0; // Initializing the variable that will hold the number of training AI games.

                    Console.Write("How many games do you want the AI bots to play to train? ");
                    string numGamesString = Console.ReadLine();
                    while (!int.TryParse(numGamesString, out numGames))
                    {
                        Console.Write("Please enter a number: ");
                        numGamesString = Console.ReadLine();
                    }

                    // Tell the user that training is happening.
                    Console.WriteLine("Please wait....training the AI.");

                    // play the game numGames times
                    for (int i = 0; i < numGames; i++)
                    {
                        // Let's have training AI(P2) play the helping AI(P3)
                        // Set the current player as player three. That's who begins our game.
                        sticks.SetCurrentPlayer(sticks.GetPlayerThree());
                        sticks.SetP2Turn(false);

                        //Console.WriteLine("Playing Game " + (i + 1));
                        // We need a loop to run this game until we get a winner.
                        // We'll use a while loop because we don't know how long the game will last.
                        // But, we keep playing until there are no sticks remaining.
                        while (sticks.GetCurrentNumSticks() > 0) // While there are still sticks available to take, we will ask the next player to take a turn.
                        {
                            // We need to determine if a AI(P2) (bot1) or the Trained AI(P3) (bot2) need to select sticks.
                            if (sticks.GetCurrentPlayer() == sticks.GetPlayerTwo()) // it is the AI(P2) turn.
                            {
                                // We choose a ball from whose hat number = the number of sticks on the board.
                                // It returns a ball number of sticks to subtract back to main.
                                howManyToDelete = bot1.ChooseRandomBall(sticks.GetCurrentNumSticks());

                            } // end if current player is p2 (bot2)
                            else // it is Trained AI(P3) turn (bot3)
                            {
                                // We choose a ball from whose hat number = the number of sticks on the board.
                                // It returns a ball number of sticks to subtract back to main.
                                howManyToDelete = bot2.ChooseRandomBall(sticks.GetCurrentNumSticks());

                            } // end else it is trained AI(p3) turn

                            // Take those sticks away.
                            sticks.SubtractSticks(howManyToDelete);

                            // It's the other player's turn.
                            sticks.NewTurn(3);
                        } // end while there are sticks loop for this round of the game

                        // A player had to grab the last stick and lost the game.
                        winner = sticks.GetCurrentPlayer(); // We did a newTurn at the end, so the current player is the winner.
                        sticks.NewTurn(3);  // We have to switch the current player back to who took the last stick.
                        loser = sticks.GetCurrentPlayer(); // This is the loser.

                        if (winner == sticks.GetPlayerTwo()) // winner is player 2=bot1. bot2 lost, so keep the bot2 besides balls out.
                        {
                            //sticks.setDidP2Win(true);       // Set did player 2 win to true because player one won.
                            bot2.ResetBesideHat();          // reset the besideHat array to all 0's
                            bot2.CheckOneEachBallInHat();   // Double check we have 1 of each type of ball in bot2
                            bot1.PutBesideInHats();         // put bot1 balls back in hat and double winner balls
                            bot1.ResetBesideHat();          // reset the beside array for bot 1
                            bot1.CheckOneEachBallInHat();   // Double check we have 1 of each type of ball in bot1
                        } // end if
                        else // the winner is bot2. bot1 lost. Keep bot1 beside balls out.
                        {
                            //sticks.setDidP2Win(false);      // Player 3 won. Set did player 2 win boolean to false.
                            bot1.ResetBesideHat();          // reset the besideHat array to all 0's for bot1
                            bot1.CheckOneEachBallInHat();   // Double check we have 1 of each type of ball in bot1 
                            bot2.PutBesideInHats();         // put bot2 balls back in hat and double winner balls
                            bot2.ResetBesideHat();          // reset the beside array for bot 2
                            bot2.CheckOneEachBallInHat();   // Double check we have 1 of each type of ball in bot1
                        } // end else

                        // Reset the game.
                        // Reset the current number of sticks to the total number of sticks.
                        sticks.SetCurrentNumSticks(totalNumSticks);

                    } // end for loop of numGames plays

                    // Let the user know the training is over.
                    Console.WriteLine(numGames + " games completed.");

                    // We need to have the player vs. the trained AI play.
                    // Player 1 is already set to a player
                    // Player 2 is already our trained AI.
                    // whichGame now = 2 - player vs. AI.
                    sticks.SetWhichGame(2);

                    // wannaQuit is still false, so it will loop back to the beginning and play player vs. AI (our trained AI)
                } // end else we are playing Game 3.
            } // end while wannaQuit
        } // end main
    } // end class
} // end namespace
