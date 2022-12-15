// AI.cs
// Chad Wallace
// March 2021
// This is the AI class.
// The way this AI works:  Imagine a row of hats all numbered. There is one hat for scenario for the number of sticks that remain on the table when a choice is made.
// We place a 1, 2, or 3 ball into each hat. When the AI needs to choose the number of sticks to pull out, he pulls a '1', '2', or '3' ball out of the appropriate hat
// for that turn (the hat that equals the number of sticks on the table). That ball is placed next to the hat. If the game is won by the AI, that ball + another one just like it
// is placed into the hat. Therefore, if the ball helps the AI win, we get one more extra of that ball in the hat. If the AI loses, an extra one does not go back in. We simply
// replace that ball so there is always at least one of each number in the hat. If a hat has a lot of one type of number in it, the AI will more likely draw out that number of sticks.

using System;
using System.Collections.Generic;   // for List

namespace SticksGame
{
    public class AI
    {
        //-------Data Members-------//
        private int totalNumHats;           // number of total hats = the number of sticks.
        private List<string> hats;           // A list of the hats that will hold the balls.
        private char[] besideHat;               // array of integers that holds the balls beside the hat.

        //-------Constructor--------//
        public AI(int totalNumSticks)
        {
            totalNumHats = (totalNumSticks + 1);            // initialize the number of hats to the number of sticks passed into the constructor. We have one extra hat since
                                                            // the index 0 hat we will use as a placeholder. This unused hat is the zeroth hat.
            hats = new List<string>();                      // initialize the hat list. This is a number of hats. Each will hold a string of numbered balls.
            hats.Add("111"); // hat[0] doesn't really matter
            hats.Add("111"); // hat[1] needs all '1' balls
            hats.Add("12"); // hat[2] should only have '1' and '2' balls
            for (int i = 3; i < totalNumHats; i++)          // all other hats initially hold one '1', one '2', and one '3' ball
            {
                    hats.Add("123"); // Always one of each type of ball for each other hat.
            } // end for

            // Let's put a spot next to each hat where we hold the ball we pull out.
            besideHat = new char[totalNumHats];             // initalize the besideHat spots for "next" to each hat.
            for (int i = 0; i < totalNumHats; i++)          // We'll make one extra so we'll have a zeroth hat, but we will store
                                                            // each ball beside the hat of that number
            {
                besideHat[i] = '0';                         // We will put a null (0) ball in each spot initially.
            } // end for

        } // end constructor

        //------- Getters and Setters -------//
        public int GetTotalNumHats()
        {
            return totalNumHats;
        }
        public void SetTotalNumHats(int newTotalNumHats)
        {
            totalNumHats = newTotalNumHats;
        }

        public string GetHatBalls(int hatNumber)
        {
            return hats[hatNumber];
        }
        public void SetHatBalls(int hatNumber, string newBalls)
        {
            hats[hatNumber] = newBalls;
        }

        public char[] GetBesideHat() // this gets the entire beside array
        {
            return besideHat;
        }
        public void SetBesideHat(int hatNumber, char newBall) // This sets a ball (string) next to a hat numbered (index+1).
        {
            besideHat[hatNumber] = newBall;
        }

        //------- Other Methods -------//

        // This function chooses a random ball from the hat (whose # = the turn we are on).
        // It places that ball in the besides array (in the index of the same hat). It returns the int value of that ball to Main.
        public int ChooseRandomBall(int hatNumber)
        {
            // initialize a variable to store the ballNumber. It will hold 1, 2, or 3 when used.
            int ballNumber = 0;

            // initialize a variable that holds an int array of the balls we pull from a hat whose number we passed to this function (hatNum).
            // theseBalls is the array of all of the balls in a hat of hatNumber.
            string theseBalls = GetHatBalls(hatNumber);

            // Get a random number using pesudo-random number generator
            Random rng = new Random();

            // We need the total number of balls in the hat to choose one at random.
            int totalBalls = theseBalls.Length;

            // Let's choose a random number between 0 and totalBalls-1
            // This does that and will give us the index in the string of the ball we will choose.

            int randomBallIndex = (rng.Next(0, totalBalls));

            // turn this ball (at index randomBallIndex in the theseBalls string into a character.
            char thisBall = theseBalls[randomBallIndex];

            // Place it in the beside array next to this hat.
            SetBesideHat(hatNumber, thisBall);

            // Remove the ball from this set of balls we just pulled out of the hat.
            // theseBalls now is a string that does not have this ball in it.
            theseBalls = theseBalls.Remove(randomBallIndex, 1);

            // Put theseBalls back into the hat.
            SetHatBalls(hatNumber, theseBalls);

            // Convert the thisBall char to an int. Return that int value (ballNumber) to main to play the game.
            ballNumber = thisBall - '0';
            return ballNumber;
        } // end chooseRandomBall function

        // This function is called after an AI wins. It's called when we need to put the ball beside the hat back into the hat. 
        // Since the AI won, we also need to put an additional ball of that type into the hat.
        public void PutBesideInHats()
        {
            // Cycle through every hat.
            for (int numHat = 1; numHat < totalNumHats; numHat++)
            {
                char[] besideArray = GetBesideHat();    // We read the ball in the beside array
                char thisBesideBall = besideArray[numHat];   // thisBesideBall is the char of the ball beside the hat
                string theseHatBalls = GetHatBalls(numHat);  // theseHatBalls are the balls in the hat.

                // if there is a non-zero ball beside the hat, we need to act.
                // Otherwise, we will simply move on to the next besideArray ball.
                if (thisBesideBall != '0')
                {
                    // put this ball beside the hat + one more of that number ball so there is an
                    // extra one in the hat to increase the odds we pull it again to help us win
                    theseHatBalls = theseHatBalls + thisBesideBall + thisBesideBall;
                    // Place them all into the hat.
                    SetHatBalls(numHat, theseHatBalls);
                }
            } // end for loop
        } // end resetBeside function

        // This function resets all element of the beside array to 0.
        public void ResetBesideHat()
        {
            // cycle through every element of the beside array and set = 0;
            for (int numHat = 1; numHat <= totalNumHats - 1; numHat++)
            {
                SetBesideHat(numHat, '0');  // We will reset to a null (0) of ball in each spot in index (i).
            } // end for
        } // end resetBeside function

        public void CheckOneEachBallInHat()
        {

            // Make sure hat 1 has a '1' in it.
            string hat1Balls = GetHatBalls(1);
            if (!hat1Balls.Contains('1'))
            {
                hat1Balls = hat1Balls + '1';
            }
            // put hat1Balls back into the hat.
            SetHatBalls(1, hat1Balls);

            string hat2Balls = GetHatBalls(2);
            if (!hat2Balls.Contains('1'))
            {
                hat2Balls = hat2Balls + '1';
            }
            else if (!hat2Balls.Contains('2'))
            {
                hat2Balls = hat2Balls + '2';
            }
            // put theseHatBalls back into the hat.
            SetHatBalls(2, hat2Balls);

            // Cycle through every hat (3 on). We use totalNumHats -1 because totalNumHats includes the zero hat.
            for (int numHat = 3; numHat <= totalNumHats - 1; numHat++)
            {
                string theseHatBalls = GetHatBalls(numHat);  // theseHatBalls are the balls in the hat.

                // Every hat needs at least one '1', one '2', and one '3' in it.

                // Make sure theseHatBalls contains a '1' ball
                if (!theseHatBalls.Contains('1')) // if these HatBalls does not contain a '1'
                {   // put a '1' with it
                    theseHatBalls = theseHatBalls + '1';
                }
                else if (!theseHatBalls.Contains('2')) // if these HatBalls does not contain a '2'
                {   // put a '2' with it
                    theseHatBalls = theseHatBalls + '2';
                }
                else if (!theseHatBalls.Contains('3')) // if these HatBalls does not contain a '3'
                {   // put a one with it
                    theseHatBalls = theseHatBalls + '3';
                }
                // put theseHatBalls back into the hat.
                SetHatBalls(numHat, theseHatBalls);
            } // end for loop
        } // end checkOneEachBallInHat function
    }// end public class AI
} // end namespace
