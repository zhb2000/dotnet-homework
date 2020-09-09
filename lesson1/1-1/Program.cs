using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input an expression:");
            string input = Console.ReadLine();
            var (operand1, operand2, op) = ParseInput(input);
            Console.WriteLine("Result: {0}", Calculate(operand1, operand2, op));
        }

        static (int, int, char) ParseInput(string input)
        {
            int opPos = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]) && input[i] != ' ')
                {
                    opPos = i;
                    break;
                }
            }
            int operand1 = int.Parse(input.Substring(0, opPos));
            int operand2 = int.Parse(input.Substring(opPos + 1, input.Length - opPos - 1));
            return (operand1, operand2, input[opPos]);
        }

        static int Calculate(int operand1, int operand2, char op)
        {
            if (op == '+')
                return operand1 + operand2;
            else if (op == '-')
                return operand1 - operand2;
            else if (op == '*')
                return operand1 * operand2;
            else //op == '/'
                return operand1 / operand2;
        }
    }
}
