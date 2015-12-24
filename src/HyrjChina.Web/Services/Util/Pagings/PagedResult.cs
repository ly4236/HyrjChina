using System.Collections.Generic;

namespace HyrjChina.Web.Services.Util.Pagings
{
    public sealed class PagedResult<T> : Paged where T : class
    {
        public IList<T> Result { get; set; }

        public PagedResult()
        {
            Result = new List<T>();
        }
    }
}