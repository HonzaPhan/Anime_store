namespace Anime_store.Exceptions
{
    /// <summary>
    /// A Custom Exception thrown when a record or a list of records are not found in the database
    /// </summary>
    [Serializable]
    public class NoDataFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoDataFoundException"/> class.
        /// </summary>
        public NoDataFoundException()
            : base(string.Format("No record was found")) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoDataFoundException"/> class with the specified id.
        /// </summary>
        /// <param name="id">The id of the record.</param>
        public NoDataFoundException(int id)
            : base(string.Format("No record by id {0} was found", id)) { }
    }
}
