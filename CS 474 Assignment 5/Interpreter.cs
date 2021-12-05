using System;
using System.Collections.Generic;
using System.Text;

namespace CS_474_Assignment_5
{
    public enum Expression { INT_CONST, BIN_OP, LET, VARIABLE, EQUALITY, IF, FUNCTION_DECL, FUNCTION_CALL }
    public enum Operation { PLUS, MINUS, TIMES, DIV }
    public class Interpreter
    {
        public Value eval(Object[] c, Environment e)
        {
            Expression expression = (Expression)c[0];

            switch (expression)
            {
                case Expression.INT_CONST:
                    {
                        int value = (int)c[1];
                        return new Value.IntValue(value);
                    }
                case Expression.BIN_OP:
                    {
                        Operation o = (Operation)c[1];
                        Value.IntValue left = (Value.IntValue)eval((Object[])c[2], e);
                        Value.IntValue right = (Value.IntValue)eval((Object[])c[3], e);

                        switch (o)
                        {
                            case Operation.PLUS:
                                return new Value.IntValue(left.val + right.val);
                            case Operation.MINUS:
                                return new Value.IntValue(left.val - right.val);
                            case Operation.TIMES:
                                return new Value.IntValue(left.val * right.val);
                            case Operation.DIV:
                                return new Value.IntValue(left.val / right.val);
                            default:
                                throw new Exception("I don't know the operation: " + o);
                        }
                    }
                case Expression.LET:
                    {
                        Value val = eval((Object[])c[2], e);
                        Name name = (Name)c[1];

                        Environment newE = e.bind(name, val);

                        return eval((Object[])c[3], newE);
                    }
                case Expression.VARIABLE:
                    {
                        Name name = (Name)c[1];

                        return e.lookup(name);

                        throw new Exception("No such element");
                    }
                case Expression.EQUALITY:
                    {
                        Value.IntValue left = (Value.IntValue)eval((Object[])c[1], e);
                        Value.IntValue right = (Value.IntValue)eval((Object[])c[2], e);

                        bool result = (left.val == right.val);

                        return new Value.BoolValue(result);
                    }
                case Expression.IF:
                    {
                        Value.BoolValue cond = (Value.BoolValue)eval((Object[])c[1], e);

                        if (cond.val)
                        {
                            return eval((Object[])c[2], e);
                        } else
                        {
                            return eval((Object[])c[3], e);
                        }
                    }
                //case Expression.FUNCTION_DECL:
                //    {
                //        Func<Value[], Object[], Environment, Value> function = (actualValues, c, e) =>
                //        {
                //            Environment envThatKnowsTheArguments = e;

                //            for (int i = 0; i < actualValues.Length; i++)
                //            {
                //                envThatKnowsTheArguments = envThatKnowsTheArguments.bind(c[2], actualValues[i]);
                //            }

                //            return eval((Object[])c[3], envThatKnowsTheArguments);
                //        };

                //        return eval((Object[])c[4], e);
                //    }
                //case Expression.FUNCTION_CALL:
                //    {
                //        Function<Value[], Value> function;

                //        Value[] actualValues = new Value[((Object[])c[1]).Length];

                //        for (int i = 0; i < actualValues.Length; i++)
                //        {
                //            actualValues[i] = eval((Object)((Object[])c[1])[i], e);
                //        }
                //    }
                default:
                    throw new Exception("I don't know the expression: " + e);
            }
        }


    }
}
