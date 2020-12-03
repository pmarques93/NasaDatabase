using System.Collections.Generic;
namespace AstroFinder
{
    /// <summary>
    /// Interface responsible for userinterface
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Asks for input
        /// </summary>
        /// <returns>Returns a string with the input</returns>
        string GetInput();

        /// <summary>
        /// Prints a message asking for a file path
        /// </summary>
        void AskForAFilePath();

        /// <summary>
        /// Prints an invalid path message
        /// </summary>
        void InvalidPath();

        /// <summary>
        /// Prints a message if the file opened successfully
        /// </summary>
        void FileOpened();

        /// <summary>
        /// Prints a message if the file didn't open
        /// </summary>
        void ChooseAnOptionNoFile();

        /// <summary>
        /// Prints initial inputs
        /// </summary>
        void ChooseAnOption();

        /// <summary>
        /// Prints a message when the player inputs
        /// </summary>
        /// <param name="str">Message to print</param>
        void Message(string str);

        /// <summary>
        /// Prints possible criteria of an ISearchField
        /// </summary>
        /// <param name="searchCriteria">ISearchField variable</param>
        void PossibleCriteria(ISearchField searchCriteria);

        /// <summary>
        /// Prints elements of an IAstromicalObject ienumerable
        /// </summary>
        /// <param name="">IEnumerable of IAstronomicalObjects</param>
        void PrintCriteria(IEnumerable<IAstronomicalObject> listOfObjects);

        /// <summary>
        /// Prints detailed information of an IAstronomicalObject
        /// </summary>
        /// <param name="astroObject">IAstronomicalObject to print</param>
        void PrintDetailedCriteria(IEnumerable<IAstronomicalObject> astroObject);

        /// <summary>
        /// Prints possible options while inside the criteria loop
        /// </summary>
        /// <param name="time">Number of times the result was shown</param>
        void OptionsOnSearchCriteria(byte time);

        /// <summary>
        /// Prints possible options while inside the detailed information loop
        /// </summary>
        void OptionsOnDetailedInformation();

        /// <summary>
        /// Prints a goodbye message
        /// </summary>
        void Goodbye();
    }
}
