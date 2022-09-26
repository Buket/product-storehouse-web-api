using System;
using System.Collections.Generic;

namespace APP.STOREHOUSE.WEBAPI.Exceptions
{
    public class BaseException: Exception
    {
        public IEnumerable<string> Errors { get; protected set; }
    }
}
