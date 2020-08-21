using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Position_BulletinBoard.Utils
{
    public abstract class ModelBase<T> where T:class,new()
    {

        public abstract bool ValidationModel();

        public new bool Equals(object obj)
        {
            if ((object)this == obj)
                return true;
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            foreach (var pro in this.GetType().GetProperties(BindingFlags.Public|BindingFlags.Instance))
            {
                var thisValue = pro.GetValue(this);
                var compareValue = pro.GetValue(this);
                if (!GetComparer(pro.PropertyType).Equals(thisValue, compareValue))
                    return false;
            }
            return true;
        }

        public dynamic GetComparer(Type DataType)
        {
            var type = typeof(EqualityComparer<>);
            var defaultProp = type.MakeGenericType(new Type[] { DataType }).GetProperty("Default", BindingFlags.Static | BindingFlags.Public);
            return defaultProp.GetValue(null);
        }
        public new int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(ModelBase<T> left, ModelBase<T> right)
        {
            if ((object)left == right)
                return true;
            if (left is null)
                return right.Equals(left);
            else if (right is null)
                return left.Equals(right);
            else
                return true;

        }

        public static bool operator !=(ModelBase<T> left, ModelBase<T> right)
        {
            return !(left == right);
        }
    }
}
