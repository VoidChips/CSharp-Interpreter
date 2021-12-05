using System;
using System.Collections.Generic;
using System.Text;

namespace CS_474_Assignment_5
{
    public class Value
    {
        public class IntValue : Value
        {
            public int val;

            public IntValue(int val)
            {
                this.val = val;
            }

            public override String ToString()
            {
                return "IntValue{" + "val=" + val + '}';
            }
        }

        public class BoolValue : Value
        {
            public bool val;

            public BoolValue(bool val)
            {
                this.val = val;
            }
            public override String ToString()
            {
                return "BoolValue{" + "val=" + val + '}';
            }
        }

    }
}
