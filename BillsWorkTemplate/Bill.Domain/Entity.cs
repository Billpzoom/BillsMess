using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Bill.Domain
{
    public class Entity<TId>
    {
        public virtual TId Id { get; set; }

        protected virtual int Version { get; set; }

        public override bool Equals(object obj)
        {
            // ReSharper disable once BaseObjectEqualsIsObjectEquals
            return base.Equals(obj as Entity<TId>);
        }

        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return Equals(Id, default(TId)) ? base.GetHashCode() : Id.GetHashCode();
        }

        private static bool IsTransient(Entity<TId> obj)
        {
            return obj != null && Equals(obj.Id, default(TId));
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        public virtual bool Equals(Entity<TId> other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (IsTransient(this) || IsTransient(other) || !Equals(Id, other.Id)) return false;
            var otherType = other.GetUnproxiedType();
            var thisType = GetUnproxiedType();
            return thisType.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(thisType);
        }

        public virtual Entity<TId> Copy()
        {
            object retval;
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                //序列化成流
                bf.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                //反序列化成对象
                retval = bf.Deserialize(ms);
                ms.Close();
            }
            return (Entity<TId>) retval;
        }
    }

    public class EntityInt32:Entity<int>
    { }

    public class EntityUuidString : Entity<string>
    {
        
    }
}