using System.Collections.Generic;

namespace IUP.Toolkits.SerializableCollections
{
    public interface ISerailizableHashSetBase<T>
    {
        public HashSet<T> Value { get; }
    }
}
