using Anime_store.Helpers;

namespace Anime_store.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a failed update operation occurs.
    /// </summary>
    /// <typeparam name="T">The type of the object being updated.</typeparam>
    public class FailedToUpdateException<T> : Exception
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailedToUpdateException{T}"/> class.
        /// </summary>
        public FailedToUpdateException()
            : base(CustomResponseMessage.GetFailedToUpdateMessage<T>()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FailedToUpdateException{T}"/> class with the specified ID.
        /// </summary>
        /// <param name="id">The ID associated with the failed update.</param>
        public FailedToUpdateException(int id)
            : base(CustomResponseMessage.GetFailedToUpdateMessage<T>(id)) { }
    }
}
