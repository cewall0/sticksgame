// Game.cs
// Chad Wallace
// March 2021
// This program is the game class to make the sticks game object.

using System;
using System.Collections.Generic;   // for List

namespace SticksGame
{
    public class Game
    {
        //-------Data Members-------//
        private int totalNumSticks;     // number of sticks for the game
        private int currentNumSticks;   // number of sticks currently remaining in the game.
        private bool p2Turn;            // boolean true = player 2's turn, false = player 1 or 3's turn.
        private string currentPlayer;   // string of the name for who's turn it is.
        private string playerOne;       // string for player 1's name (player)
        private string playerTwo;       // string for player 2's name (player or main AI)
        private string playerThree;     // string for player 3's name (training AI)
        private int whichGame;          // int 1 = player v. player,  2 = player v. AI, 3 = player v. trained AI
        private bool playAIAgain;       // boolean true = continue to play again, set to false if player v. AI user wants to quit.
        private bool didP2Win;          // boolean to true if player one won the game.

        //-------Constructor-------//
        public Game(int totalNumSticks)
        {
            currentNumSticks = totalNumSticks;     // initialize the number of sticks that currently exist on the board.
            p2Turn = false;             // initialize the player 1 turn to true because the game starts with player 1's turn.
            currentPlayer = "";         // initialize current player's name.
            playerOne = "";             // initialize playerOne's name.
            playerTwo = "";             // initialize playerTwo's name.
            whichGame = 1;              // initialize to player v. player game.
            playAIAgain = true;         // initalize the play again variable to true.
            didP2Win = false;           // initialize the did player 2 win boolean to false.
        }

        //------- Getters and Setters -------//
        public int GetTotalNumSticks()
        {
            return totalNumSticks;
        }

        public void SetTotalNumSticks(int newTotalNumSticks)
        {
            totalNumSticks = newTotalNumSticks;
        }

        public int GetCurrentNumSticks()
        {
            return currentNumSticks;
        }
        public void SetCurrentNumSticks(int newCurrentNumSticks)
        {
            currentNumSticks = newCurrentNumSticks;
        }

        public bool GetP2Turn()
        {
            return p2Turn;
        }
        public void SetP2Turn(bool newP2Turn)
        {
            p2Turn = newP2Turn;
        }

        public string GetCurrentPlayer()
        {
            return currentPlayer;
        }
        public void SetCurrentPlayer(string newCurrentPlayer)
        {
            currentPlayer = newCurrentPlayer;
        }

        public string GetPlayerOne()
        {
            return playerOne;
        }
        public void SetPlayerOne(string newPlayerOne)
        {
            playerOne = newPlayerOne + "(P1)";
        }

        public string GetPlayerTwo()
        {
            return playerTwo;
        }
        public void SetPlayerTwo(string newPlayerTwo)
        {
            playerTwo = newPlayerTwo + "(P2)";
        }

        public string GetPlayerThree()
        {
            return playerThree;
        }
        public void SetPlayerThree(string newPlayerThree)
        {
            playerThree = newPlayerThree + "(P3)";
        }

        public int GetWhichGame()
        {
            return whichGame;
        }
        public void SetWhichGame(int newWhichGame)
        {
            whichGame = newWhichGame;
        }

        public bool GetPlayAIAgain()
        {
            return playAIAgain;
        }
        public void SetPlayAIAgain(bool newPlayAIAgain)
        {
            playAIAgain = newPlayAIAgain;
        }

        public bool GetDidP2Win()
        {
            return didP2Win;
        }
        public void SetDidP2Win(bool newDidP2Win)
        {
            didP2Win = newDidP2Win;
        }

        //------- Other Methods -------//


        // This method will substract the number of sticks passed into it (deleteSticks)
        // and will update the number of sticks remaining (numSticks).
        public void SubtractSticks(int deleteSticks)
        {
            SetCurrentNumSticks(currentNumSticks - deleteSticks);
        } // end subtractSticks function


        // This method changes who's turn it is.
        public void NewTurn(int aiTraining)
        {
            // if player v. player or player vs. AI
            if (aiTraining == 1 || aiTraining == 2)
            {
                bool isP2Turn = GetP2Turn(); // get the boolean value of p2Turn
                if (isP2Turn == true) // if it is player 2's turn
                {
                    currentPlayer = playerOne; // make the current player's turn name = player One.
                    SetP2Turn(false); // make p1Turn false so it is player 2's turn.
                } // end if
                else // aiTraining == 3
                {
                    currentPlayer = playerTwo; // make the current player's turn name = player One.
                    SetP2Turn(true); // isP1Turn = false, so we need to make it player 2's turn. (change p1Turn to false).
                } // end else
            } // end if player v. player or player v. ai
            else // it is AI vs. AI training
            {
                bool isP2Turn = GetP2Turn(); // get the boolean value of p1Turn
                if (isP2Turn == true) // if it is player 1's turn
                {
                    currentPlayer = playerThree; // make the current player's turn name = player Two.
                    SetP2Turn(false); // make p1Turn false so it is player 2's turn.
                } // end if
                else
                {
                    currentPlayer = playerTwo; // make the current player's turn name = player One.
                    SetP2Turn(true); // isP1Turn = false, so we need to make it player 2's turn. (change p1Turn to false).
                } // end else
            } //end else ai v. ai
        } // end newTurn function
    } // end public class game
} // end namespace
