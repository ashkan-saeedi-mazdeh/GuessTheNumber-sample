using System.Threading.Tasks;
using Orleans;

namespace GuessInterfaces
{
    /// <summary>
    /// Game interface with all required messages
    /// </summary>
	public interface IGuessGame : IGrainWithGuidKey
    {
        /// <summary>
        /// should guess a number and return 0 for correct guess, 1 for numbers larger than correct guess and -1 for
        /// guesses smaller than the correct number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        Task<int> Guess(int number);

        /// <summary>
        /// Creates a new game.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        Task<System.Guid> CreateGame(int min, int max);
    }
}
