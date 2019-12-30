using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public class ObjectValue<T>
    {
        public ObjectValue(T value = default)
        {
            Value = value;
        }

        public T Value { get; }

        public static implicit operator T(ObjectValue<T> o) => o.Value;
        public static explicit operator ObjectValue<T>(T v) => new ObjectValue<T>(v);

        public override string ToString() => $"{Value}";
    }
}
