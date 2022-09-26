using System;

namespace APP.STOREHOUSE.WEBAPI.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string entityname, Guid id)
        {
            var text = Properties.ru_RU_Resources.ERROR_EntitiWithIdNotFound.Replace("{entityname}", entityname).Replace("{id}", id.ToString());
            this.Errors = new string[] { text };
        }
    }
}
