using Anime_store.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Anime_store.Helpers
{
    /// <summary>
    /// Converts the status code from the enum to an ObjectResult with the status code
    /// </summary>
    /// <returns> New ObjectResult with the status code </returns>
    public static class HttpResponseHelper
    {
        public static ActionResult CustomStatusCode(EHttpStatus status, object? value = null)
        {
            return new ObjectResult(value) { StatusCode = (int)status };
        }
    }

}
