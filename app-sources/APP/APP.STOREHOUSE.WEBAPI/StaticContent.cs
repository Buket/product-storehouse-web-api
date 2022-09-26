using System.Resources;

namespace APP.STOREHOUSE.WEBAPI
{
    public static class StaticContent
    {
        public static ResourceManager ResourceManager;

        static StaticContent()
        {
            ResourceManager = new ResourceManager("TextResources", typeof(StaticContent).Assembly);
        }

        public static class ErrorResourceNames
        {
            public const string NotFound = "Error_EntityWithIdNotFound";
        }
    }
}
