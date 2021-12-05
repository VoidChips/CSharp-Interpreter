using System;
using System.Collections.Generic;
using System.Text;

namespace CS_474_Assignment_5
{
    public class Binding
    {
        public Name name;
        public Value value;

        public Binding(Name name, Value value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
