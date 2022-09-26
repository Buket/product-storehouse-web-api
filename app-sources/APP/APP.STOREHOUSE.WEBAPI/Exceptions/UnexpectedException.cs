using System;

namespace APP.STOREHOUSE.WEBAPI.Exceptions
{
    public class UnexpectedException : BaseException
    {
        public UnexpectedException()
        {
            this.Errors = new string[] { Properties.ru_RU_Resources.ERROR_UnexpectedCase };
        }
    }
}
