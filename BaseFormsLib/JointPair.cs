using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseFormsLib
{
    [Serializable]
    public class JointPair : IEquatable<object>
    {
        public object Key { get; set; }
        public string Value { get; set; }

        public JointPair(object key, string value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is JointPair)
            {
                JointPair jp = obj as JointPair;
                return Key.Equals(jp.Key) && Value == jp.Value;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Value.Length;
        }

        bool IEquatable<object>.Equals(object other)
        {
            return this.Equals(other);
        }
        
    }
}
