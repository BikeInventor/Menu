using System;

namespace Menu.Business.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public string Title { get; set; }
        public string Message { get; set; }

    }
}
