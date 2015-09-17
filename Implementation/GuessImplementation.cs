using System;
using System.Threading.Tasks;
using Orleans;
using GuessInterfaces;
using System.Collections.Generic;

namespace Implementation
{
    /// <summary>
    /// Grain implementation of the game interface
    /// </summary>
    public class GuessGame : Grain, IGuessGame
    {
        /// <summary>
        /// The number which is the correct guess will be stored in this.
        /// </summary>
        private int correctGuess;

        /// <summary>
        /// Creates a game for a user to play.
        /// </summary>
        /// <param name="min">The minimum number for the guessing range</param>
        /// <param name="max">The maximum number for guessing range.</param>
        /// <returns></returns>
        public Task<Guid> CreateGame(int min, int max)
        {

            correctGuess = new System.Random().Next(min, max);
            //we return the GUID of the task created so users can refer to the game by the GUID later on.
            return Task.FromResult(this.GetPrimaryKey());
        }

        /// <summary>
        /// Tries to guess a number
        /// </summary>
        /// <param name="number">user's guess</param>
        /// <returns>if correct guess: 0, if user's number is larger than the correct number: 1 and if smaller -1</returns>
        public Task<int> Guess(int number)
        {
            int result = 0;
            if (number > correctGuess)
                result = 1;
            else if (number < correctGuess)
                result = -1;
            return Task.FromResult(result);
        }
    }
}
