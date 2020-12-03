using System;
using System.Collections.Generic;
using System.Text;

namespace Calculate
{
    public interface IExpressionEvaluator
    {
        public double CalculateExpression(List<string> listOfInstructions);
    }
}
