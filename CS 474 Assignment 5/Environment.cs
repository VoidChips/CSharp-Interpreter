using System;
using System.Collections.Generic;
using System.Text;

namespace CS_474_Assignment_5
{
    public class Environment
    {
        public Binding b;
        public Environment referencingEnvironment;

        public Environment(Binding b, Environment referencingEnvironment)
        {
            this.b = b;
            this.referencingEnvironment = referencingEnvironment;
        }

        public static Environment EMPTY = new Environment(null, null);

        public Environment bind(Name name, Value value)
        {
            Binding b = new Binding(name, value);
            return new Environment(b, this);
        }

        public Value lookup(Name name)
        {
            if (this == EMPTY)
            {
                throw new Exception("No such element.");
            }

            if (name.theName.Equals(b.name.theName))
            {
                return b.value;
            }

            return referencingEnvironment.lookup(name);
        }
    }
}
