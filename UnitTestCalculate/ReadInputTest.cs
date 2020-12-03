using Calculate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnitTestCalculate
{
    [TestClass]
    public class ReadInputTest
    {
        [TestMethod]
        public void validate_If_file_does_not_exist_returns_error_message()
        {
            //Arrange 
            List<string> listOfInstructions = new List<string>();
            string fileName = "input_test_does_not_exist.txt";
            string expectedMessage = "File does not exist or does have permission to read";
            //Act
            IReadInput readInput = new ReadInput();
            listOfInstructions = readInput.ReadInputFile(Path.GetFullPath(fileName), out string actualMessage);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void validate_If_input_text_file_has_empty_lines_then_list_should_be_zero_with_error_message()
        {
            //Arrange 
            string fileName = "input_test.txt";
            List<string> listOfInstruction = null;
            int expectedInstruction = 0;
            string expectedMessage = "File can not be empty";
            using (var fileCreated = File.CreateText(fileName))
            {
                fileCreated.WriteLine("");
            }

            //Act
            IReadInput readInput = new ReadInput();
            listOfInstruction = readInput.ReadInputFile(Path.GetFullPath(fileName), out string actualMessage);

            //Assert
            Assert.AreEqual(expectedInstruction, listOfInstruction.Count);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void validate_If_input_text_file_has_any_line_without_instruction_or_nummber()
        {
            //Arrange 
            string fileName = "input_test.txt";
            List<string> listOfInstruction = null;
           
            string expectedMessage = "Line does not have instruction followed by number";
            using (var fileCreated = File.CreateText(fileName))
            {
                fileCreated.WriteLine("add 2");
                fileCreated.WriteLine("multiply"); // No number
                fileCreated.WriteLine("apply 3");
            }

            //Act
            IReadInput readInput = new ReadInput();
            listOfInstruction = readInput.ReadInputFile(Path.GetFullPath(fileName), out string actualMessage);

            //Assert           
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        
            [TestMethod]
        public void validate_If_input_text_file_has_any_line_wit_instruction_but_not_nummber()
        {
            //Arrange 
            string fileName = "input_test.txt";
            List<string> listOfInstruction = null;

            string expectedMessage = "Line does not have valid number";
            using (var fileCreated = File.CreateText(fileName))
            {
                fileCreated.WriteLine("add 2");
                fileCreated.WriteLine("multiply str23"); //  invalid number as second part of line
                fileCreated.WriteLine("apply 3");
            }

            //Act
            IReadInput readInput = new ReadInput();
            listOfInstruction = readInput.ReadInputFile(Path.GetFullPath(fileName), out string actualMessage);

            //Assert           
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
