using Calculate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UnitTestCalculate;

namespace UnitTestCalculate
{
    [TestClass]
    public class ExpEvalTest
    {
        [TestMethod]
        public void Check_If_Valid_Instructions_With_add_multiply_Works()
        {
             /*********
             * add 2
             * multiply 3
             * apply 3
             * 
             **********/

            //Arrange 
            List<string> listOfInstructions = new List<string>();
            listOfInstructions.Add("add 2");
            listOfInstructions.Add("multiply 3");
            listOfInstructions.Add("apply 3");
            int expectedResult = 15;

            //Act
            IExpressionEvaluator expressionEvaluator = new ExpressionEvaluator();
            double actualResult = expressionEvaluator.CalculateExpression(listOfInstructions);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Check_If_Valid_Instructions_With_multiply_Works()
        {
            /*********
            * multiply 9
            * apply 5
            * 
            **********/

            //Arrange 
            List<string> listOfInstructions = new List<string>();
            listOfInstructions.Add("multiply 9");
            listOfInstructions.Add("apply 5");
            int expectedResult = 45;

            //Act
            IExpressionEvaluator expressionEvaluator = new ExpressionEvaluator();
            double actualResult = expressionEvaluator.CalculateExpression(listOfInstructions);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Check_If_Valid_Instructions_With_multiply_add_divide_Works()
        {
            /*********
            * multiply 9
            * add 3
            * divide 2
            * apply 5
            * 
            **********/

            //Arrange 
            List<string> listOfInstructions = new List<string>();
            listOfInstructions.Add("multiply 9");
            listOfInstructions.Add("add 3");
            listOfInstructions.Add("divide 2");
            listOfInstructions.Add("apply 5");
            int expectedResult = 24;

            //Act
            IExpressionEvaluator expressionEvaluator = new ExpressionEvaluator();
            double actualResult = expressionEvaluator.CalculateExpression(listOfInstructions);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Check_If_Valid_Instructions_With_divide_add_divide_Works_with()
        {
            /*********
            * divide 2
            * add 3
            * divide 2
            * apply 6
            * 
            **********/

            //Arrange 
            List<string> listOfInstructions = new List<string>();
            listOfInstructions.Add("divide 2");
            listOfInstructions.Add("add 3");
            listOfInstructions.Add("divide 2");
            listOfInstructions.Add("apply 6");
            int expectedResult = 3;

            //Act
            IExpressionEvaluator expressionEvaluator = new ExpressionEvaluator();
            double actualResult = expressionEvaluator.CalculateExpression(listOfInstructions);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Check_If_Valid_Instructions_With_substract_add_multiply_divide_works()
        {
            /*********
            * 
            * substract 3
            * divide 3
            * add 20            
            * apply 6
            * 
            **********/

            //Arrange 
            List<string> listOfInstructions = new List<string>();
            listOfInstructions.Add("substract 3");
            listOfInstructions.Add("divide 3");
            listOfInstructions.Add("add 20");
            listOfInstructions.Add("apply 6");
            int expectedResult = 21;

            //Act
            IExpressionEvaluator expressionEvaluator = new ExpressionEvaluator();
            double actualResult = expressionEvaluator.CalculateExpression(listOfInstructions);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Check_If_InValid_Instruction_Throws_Exception()
        {
            /*********
            * invalid 9
            * apply 5
            * 
            **********/

            //Arrange 
            List<string> listOfInstructions = new List<string>();
            listOfInstructions.Add("invalid 9");
            listOfInstructions.Add("apply 5");
            string expectedResult = "Invalid Operation";
            string actulResult = string.Empty;

            //Act
            IExpressionEvaluator expressionEvaluator = new ExpressionEvaluator();
            try
            {
                expressionEvaluator.CalculateExpression(listOfInstructions);
            }
            catch(Exception ex)
            {
                actulResult = ex.Message;
            }

            //Assert
            Assert.AreEqual(expectedResult, actulResult);
        }
    }
}
