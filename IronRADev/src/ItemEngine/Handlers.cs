using System;
namespace ItemEngine
{
    public class Handlers
    {
            public class Operations
        { 
            public string Add(string num1, string num2)
            {
                return num1 + "+" + num2;
            }
            public string Sub(string num1, string num2)
            {
                return num1 + " - " + num2;

            }
            public string Mul(string num1, string num2)
            {
                return num1 + " * " + num2;
            }
            public string Div(string num1, string num2)
            {
                return num1 + " / " + num2;
            }
            public string Mod(string num1, string num2)
            {
                return num1 + " % " + num2;
            }
        }
        public class Variables
        {
            public string Implicit(string name, string value)
            {
                var line = "var ##name = ##value;";
                var returnData = line.Replace("##name", name);
                returnData = returnData.Replace("##value", value);
                return returnData;
            }
            public string Numbers(bool isInt, string name, string value)
            {
                var returnData = "";
                var intLine = "int ##varname = ##varvalue;";
                var numLine = "double ##varname = ##varvalue;";
                if (isInt)
                {
                    returnData = intLine.Replace("##varname", name);
                    returnData = returnData.Replace("##varvalue", value);
                }
                else
                {
                    returnData = numLine.Replace("##varname", name);
                    returnData = returnData.Replace("##varvalue", value);
                }
                return returnData;
            }
            public string Strings(string name, string value)
            {
                var line = "string ##name = ##value;";
                var returnData = line.Replace("##name", name);
                returnData = returnData.Replace("##value", value);
                return returnData;
            }
        }
        public class Printers
        {
            public string Printer(bool newLine, string varName)
            {
                var lineReturn = "";
                var line = "System.Console.WriteLine(varName);";
                var noLine = "System.Console.Write(varName);";
                lineReturn = newLine ? line.Replace("varName", varName) : noLine.Replace("varName", varName);
                return lineReturn;
            }
        }
    }
}