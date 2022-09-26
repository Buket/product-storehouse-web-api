using System;
using System.Resources;

namespace APP.STOREHOUSE.WEBAPI.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string entityname, Guid id)
        {
            var text = StaticContent.ResourceManager.GetString(StaticContent.ErrorResourceNames.NotFound);
            text = text.Replace("{entityname}", entityname);
            text = text.Replace("{id}", id.ToString());
            this.Errors = new string[] { text };
        }
    }
}
