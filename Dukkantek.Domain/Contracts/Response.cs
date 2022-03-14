using System.Collections.Generic;

namespace Dukkantek.Domain.Contracts
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
