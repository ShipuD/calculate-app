using System;
using System.Collections.Generic;
using System.IO;

namespace Calculate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program to calculate expression from Input file!");
            
            IReadInput readInput = new ReadInput();
            string fullFilePath = Path.GetFullPath("input.txt");

            try
            {
                List<string> listOfInstruction = readInput.ReadInputFile(fullFilePath, out string message);
                if (!string.IsNullOrEmpty(message))
                {
                    Console.WriteLine(message);
                }
                else
                {
                    IExpressionEvaluator ev = new ExpressionEvaluator();
                    double result = ev.CalculateExpression(listOfInstruction);
                    Console.WriteLine(result.ToString());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
