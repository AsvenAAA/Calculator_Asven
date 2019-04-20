using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Asven
{
    class ReversePolishEntry
    {
        private const string numbersSubstring = "0123456789,";
        private const string operatorsSubstring = "+-*/";

        private string sExpression;
        public string Expression
        {
            get { return sExpression; }
            set
            {
                sExpression = value;
            }
        }

        public ReversePolishEntry(string Expression)
        {
            this.Expression = Expression;
        }

        public string RPEformer(string expression)
        {
            StringBuilder sRPE = new StringBuilder();
            Stack<string> operandsStack = new Stack<string>(Expression.Length);
            byte zeroLength = 0;

            for (int substringNumb = 0; substringNumb < expression.Length; substringNumb++)
            {
                if (numbersSubstring.Contains(expression[substringNumb]))
                {
                    sRPE.Append(expression[substringNumb]);
                }
                else
                {
                    if (operatorsSubstring.Contains(expression[substringNumb])) sRPE.Append(" ");
                    if (operandsStack.Count == zeroLength) operandsStack.Push(expression[substringNumb].ToString());
                    else
                    {
                        if (PriorityChecker(expression[substringNumb]) > PriorityChecker(char.Parse(operandsStack.Peek())))
                        {
                            while(operandsStack.Count != zeroLength && PriorityChecker(expression[substringNumb]) > PriorityChecker(char.Parse(operandsStack.Peek())))
                            {
                                if(expression[substringNumb].ToString() == ")")
                                {
                                    while (operandsStack.Count != zeroLength && operandsStack.Peek().ToString() != "(")
                                    {
                                        sRPE.Append(operandsStack.Pop());
                                    }
                                    if (operandsStack.Count != zeroLength && operandsStack.Peek() == "(")
                                    {
                                        operandsStack.Pop();
                                        break;
                                    }
                                }
                                else operandsStack.Push(expression[substringNumb].ToString());
                            }
                        }
                        else if (PriorityChecker(expression[substringNumb]) <= PriorityChecker(char.Parse(operandsStack.Peek())))
                        {
                            while (operandsStack.Count != zeroLength && PriorityChecker(expression[substringNumb]) <= PriorityChecker(char.Parse(operandsStack.Peek())) & expression[substringNumb].ToString() != "(")
                            {
                                sRPE.Append(operandsStack.Pop());
                            }
                            operandsStack.Push(expression[substringNumb].ToString());
                        }
                    }
                }
                if(substringNumb == expression.Length - 1)
                {
                    while(operandsStack.Count != zeroLength)
                    {
                        if (operandsStack.Peek() == ")") operandsStack.Pop();
                        else sRPE.Append(operandsStack.Pop());
                    }
                }
            }
            return sRPE.ToString();
        }

        public byte PriorityChecker(char symbol)
        {
             switch (symbol)
             {
                 case '+': return 1;
                 case '-': return 1;
                 case '*': return 2;
                 case '/': return 2;
                 case '(': return 0;
                 case ')': return 3;
                 default: throw new Exception("There is no such operation in the program!");
             }
        }

        public double Add(double x, double y) {return y + x;}
        public double Sub(double x, double y) { return y - x;}
        public double Mult(double x, double y) {return y * x;}
        public double Div(double x, double y) {return y / x;}

        public double Calculate(string reversePolishEntry)
        {
            StringBuilder expressionOperator = new StringBuilder();
            Stack<string> operands = new Stack<string>();
            byte zeroLength = 0;

            for (int symbolNumb = 0; symbolNumb < reversePolishEntry.Length; symbolNumb++)
            {
                if (numbersSubstring.Contains(reversePolishEntry[symbolNumb]))
                {
                    expressionOperator.Append(reversePolishEntry[symbolNumb]);
                    if (symbolNumb < reversePolishEntry.Length & operatorsSubstring.Contains(reversePolishEntry[symbolNumb + 1]))
                    {
                        operands.Push(expressionOperator.ToString());
                        expressionOperator.Clear();
                    }
                }
                else if (expressionOperator.Length > zeroLength & reversePolishEntry[symbolNumb] == ' ')
                {
                    operands.Push(expressionOperator.ToString());
                    expressionOperator.Clear();
                }
                else if (operatorsSubstring.Contains(reversePolishEntry[symbolNumb]))
                {
                    switch (reversePolishEntry[symbolNumb])
                    {
                        case '+':
                            operands.Push(Add(double.Parse(operands.Pop()), double.Parse(operands.Pop())).ToString());
                            break;
                        case '-':
                            operands.Push(Sub(double.Parse(operands.Pop()), double.Parse(operands.Pop())).ToString());
                            break;
                        case '*':
                            operands.Push(Mult(double.Parse(operands.Pop()), double.Parse(operands.Pop())).ToString());
                            break;
                        case '/':
                            operands.Push(Div(double.Parse(operands.Pop()), double.Parse(operands.Pop())).ToString());
                            break;//
                    }
                }
            }
            return double.Parse(operands.Pop());
        }
    }
}
