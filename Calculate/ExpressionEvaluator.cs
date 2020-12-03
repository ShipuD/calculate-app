using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Calculate
{
    public class ExpressionEvaluator:IExpressionEvaluator
    {
        public double CalculateExpression(List<string> listOfInstructions)
        {
            double result = 0;
            string expression = "(initialNo)";
            string initialNo = string.Empty;
            foreach (string instruction in listOfInstructions)
            {
                string[] ins = instruction.Split(" ");

                switch(ins[0])
                {
                    case "apply":
                        expression = expression.Replace("initialNo", ins[1]);
                        break;
                    case "add":
                        expression = "(" + expression + ")+" + ins[1];
                        break;
                    case "substract":
                        expression = "(" + expression + ")-" + ins[1];
                        break;
                    case "multiply":
                        expression = "(" + expression + ")*" + ins[1];
                        break;
                    case "divide":
                        expression ="(" + expression + ")/" + ins[1];
                        break;
                    default:
                        throw new Exception("Invalid Operation");
                }
            }           
            result = Convert.ToDouble( new DataTable().Compute(expression,""));

            return result;
        }
    }
    
}
