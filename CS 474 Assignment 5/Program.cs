using System;
using System.Collections.Generic;

namespace CS_474_Assignment_5
{
    class Program
    {
        // 474
        public static Object[] p1 = new Object[]
        {
            Expression.INT_CONST,
            474
        };

        // 400 + 74
        public static Object[] p2 = new object[]
        {
            Expression.BIN_OP,
            Operation.PLUS,
            new object[] {Expression.INT_CONST, 400 },
            new object[] {Expression.INT_CONST, 74 }
        };


        // 400 + (70 + 4)
        public static Object[] p3 = new object[]
        {
            Expression.BIN_OP,
            Operation.PLUS,
            new object[] {Expression.INT_CONST, 400 },
            new object[] {
                Expression.BIN_OP,
                Operation.PLUS,
                new object[] {Expression.INT_CONST, 70 },
                new object[] {Expression.INT_CONST, 4 },
            }
        };

        // (let var = (400 + 70) in var + 74)
        public static Object[] p4 = new object[]
        {
            Expression.LET,
            new Name("var"),
            new object[] {
                Expression.BIN_OP,
                Operation.PLUS,
                new object[] {Expression.INT_CONST, 400 },
                new object[] {Expression.INT_CONST, 70 },
            },
            new object[] {
                Expression.BIN_OP,
                Operation.PLUS,
                new object[] {Expression.VARIABLE, new Name("var") },
                new object[] {Expression.INT_CONST, 4 },
            }
        };

        // (let v1 = 400 in
        //    (let v2 = 70 in v2)
        //    +
        //    4 + v1
        public static Object[] p5 = new object[]
        {
            Expression.LET,
            new Name("v1"),
            new object[] {Expression.INT_CONST, 400},
            new object[]
            {
                Expression.BIN_OP,
                Operation.PLUS,
                new object[]
                {
                    Expression.LET,
                    new Name("v2"),
                    new object[] {Expression.INT_CONST, 70},
                    new object[] {Expression.VARIABLE, new Name("v2")}
                },
                new object[]
                {
                    Expression.BIN_OP,
                    Operation.PLUS,
                    new object[] {Expression.INT_CONST, 4},
                    new object[] {Expression.VARIABLE, new Name("v1")}
                }
            }
        };

        // (let var = 400 in
        //    (let var = 70 in var)
        //    +
        //    4 + var
        public static Object[] p6 = new object[]
        {
            Expression.LET,
            new Name("var"),
            new object[] {Expression.INT_CONST, 400},
            new object[]
            {
                Expression.BIN_OP,
                Operation.PLUS,
                new object[]
                {
                    Expression.LET,
                    new Name("var"),
                    new object[] {Expression.INT_CONST, 70},
                    new object[] {Expression.VARIABLE, new Name("var")}
                },
                new object[]
                {
                    Expression.BIN_OP,
                    Operation.PLUS,
                    new object[] {Expression.INT_CONST, 4},
                    new object[] {Expression.VARIABLE, new Name("var")}
                }
            }
        };

        // (let v1 = 400 in
        //    (let v2 = 70 in v1+v2)
        //    +
        //    4
        public static Object[] p7 = new object[]
        {
            Expression.LET,
            new Name("v1"),
            new object[] {Expression.INT_CONST, 400},
            new object[]
            {
                Expression.BIN_OP,
                Operation.PLUS,
                new object[]
                {
                    Expression.LET,
                    new Name("v2"),
                    new object[] {Expression.INT_CONST, 70},
                    new object[]
                    {
                        Expression.BIN_OP,
                        Operation.PLUS,
                        new object[] {Expression.VARIABLE, new Name("v1")},
                        new object[] {Expression.VARIABLE, new Name("v2")}
                    }
                },
                new object[] {Expression.INT_CONST, 4},
            }
        };

        // (let divisor = 1 in (divisor == 0))
        public static Object[] p8 = new object[]
        {
            Expression.LET,
            new Name("divisor"),
            new object[] {Expression.INT_CONST, 1},
            new object[]
            {
                Expression.EQUALITY,
                new object[] {Expression.VARIABLE, new Name("divisor")},
                new object[] {Expression.INT_CONST, 0}
            }
        };

        // (let dividend = 474 in
        //   (let divisor = 2 in
        //      (divisor == 0) 0 : divided / divisor))
        public static Object[] p9 = new object[]
        {
            Expression.LET,
            new Name("dividend"),
            new object[] {Expression.INT_CONST, 474},
            new object[] {
                Expression.LET,
                new Name("divisor"),
                new object[] {Expression.INT_CONST, 2},
                new object[]
                {
                    Expression.IF,
                    new object[]
                    {
                        Expression.EQUALITY,
                        new object[] {Expression.VARIABLE, new Name("divisor")},
                        new object[] {Expression.INT_CONST, 0}
                    },
                    new object[] {Expression.INT_CONST, 0},
                    new object[]
                    {
                        Expression.BIN_OP,
                        Operation.DIV,
                        new object[] {Expression.VARIABLE, new Name("dividend")},
                        new object[] {Expression.VARIABLE, new Name("divisor")}
                    }
                }
            }
        };

        // function safeDivision(dividend, divisor) -> (divisor == 0) 0 : divided / divisor))
        //    safeDivision(474,0) + safeDivision(474,1)
        public static Object[] p10 = new object[]
        {
            Expression.FUNCTION_DECL,
            new Name("safeDivision"),
            new Name[] {new Name("dividend"), new Name("divisor")},
            new object[]
            {
                Expression.IF,
                new object[]
                {
                    Expression.EQUALITY,
                    new object[] {Expression.VARIABLE, new Name("divisor")},
                    new object[] {Expression.INT_CONST, 0}
                },
                new object[] {Expression.INT_CONST, 0},
                new object[]
                {
                    Expression.BIN_OP,
                    Operation.DIV,
                    new object[] {Expression.VARIABLE, new Name("dividend")},
                    new object[] {Expression.VARIABLE, new Name("divisor")}
                }
            },
            new object[]
            {
                Expression.BIN_OP,
                Operation.PLUS,
                new object[]
                {
                    Expression.FUNCTION_CALL,
                    new Name("safeDivision"),
                    new object[]
                    {
                        new object[]
                        {
                            Expression.BIN_OP,
                            Operation.PLUS,
                            new object[] {Expression.INT_CONST, 400},
                            new object[] {Expression.INT_CONST, 70}
                        },
                        new object[] {Expression.INT_CONST, 0}
                    }
                },
                new object[]
                {
                    Expression.FUNCTION_CALL,
                    new Name("safeDivision"),
                    new object[]
                    {
                        new object[] {Expression.INT_CONST, 474},
                        new object[] {Expression.INT_CONST, 1}
                    }
                }
            }
        };

        static void Main(string[] args)
        {
            Environment environment = Environment.EMPTY;
            Console.WriteLine(new Interpreter().eval(p9, environment));
        }
    }
}
