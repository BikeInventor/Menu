using System;

namespace Menu.Data.Core
{
    public abstract class DomainObject<TId> where TId : IComparable
    {
        public TId Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastEdited { get; set; }
    }
}
