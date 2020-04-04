using System;
using System.Collections.Generic;
using System.Text;

namespace CSD.Utility
{
    public class TransResult<T>
    {
        public T Object { get; set; }
        public bool IsSuccess { get; set; }
    }
}
