using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculate
{
    public class ReadInput:IReadInput
    {
        public List<string> ReadInputFile(string fullPathFileName, out string message)
        {
            List<string> listOfInstructions = new List<string>();
            message = string.Empty;
            try
            {
                var lines = File.ReadAllLines(fullPathFileName);
                for (var i = 0; i < lines.Length; i += 1)
                {
                    if (string.IsNullOrEmpty(lines[i]))
                        continue;

                    if (!Validate(lines[i], out string errorMessage))
                    {
                        message = errorMessage;
                        break;
                    }
                        
                    listOfInstructions.Add(lines[i]);
                }

                if (string.IsNullOrEmpty(message) && listOfInstructions.Count <= 0 )
                    message = "File can not be empty";
            }
            catch(Exception ex)
            {
                message = "File does not exist or does have permission to read";
            }
           

            return listOfInstructions;
        }

        private bool Validate(string line, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool retVal = false;
            string[] opeartors = line.Split(" ");
            if (opeartors.Length != 2)
            {
                errorMessage = "Line does not have instruction followed by number";
               
            }
            else 
            {
                //Check if the 2nd part is number or decimal 
                var isValidNumber = Regex.IsMatch(opeartors[1], @"^[0-9]+(\.[0-9]+)?$");
                if (isValidNumber)
                    retVal = true;
                else
                    errorMessage = "Line does not have valid number";
            }

            return retVal;
        }
    }
}
