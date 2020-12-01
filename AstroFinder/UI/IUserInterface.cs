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
        public string GetInput();

        /// <summary>
        /// Prints a message asking for a file path
        /// </summary>
        public void AskForAFilePath();

        /// <summary>
        /// Prints an invalid path message
        /// </summary>
        public void InvalidPath();

        /// <summary>
        /// Prints a message if the file opened successfully
        /// </summary>
        public void FileOpened();

        /// <summary>
        /// Prints a message if the file didn't open
        /// </summary>
        public void ChooseAnOptionNoFile();

        /// <summary>
        /// Prints initial inputs
        /// </summary>
        public void ChooseAnOption();

        /// <summary>
        /// Prints a message when the player inputs
        /// </summary>
        /// <param name="str">Message to print</param>
        public void NotValid(string str);

        /// <summary>
        /// Prints possible criteria of an ISearchField
        /// </summary>
        /// <param name="searchCriteria">ISearchField variable</param>
        void PossibleCriteria(ISearchField searchCriteria);

        /// <summary>
        /// Prints a goodbye message
        /// </summary>
        public void Goodbye();
    }
}
