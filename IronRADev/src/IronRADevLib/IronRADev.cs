using System;

namespace IronRADev
{
    public class RADEVItems
    {
        public struct Line
        {
            public string item;
            public string arg1;
            public string arg2;
            public bool arg3;
            public bool arg4;
            public bool recognised;
        }
        public string[] itemList = { "write", "writel", "print", "printl", "+", "-", "/", "*", "%", "string", "num", "int", "raw" };
        public string[] ironItemList = { "var" };
        public class IronRADevItems
        {
            public string Var(string name, string value)
            {
                var line = "var ##name = ##val";
                var temp = line.Replace("##name", name);
                return temp.Replace("##val", value);
            }
        }
        public class RADevBaseItems
        {
            public class Operations
            {
                public string Add(string num1, string num2)
                {
                    return num1 +"+"+ num2;
                }
                public string Sub(string num1, string num2)
                {
                    return num1 +" - "+ num2;

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
    public class IronConvert : RADEVItems
    {
        public string StringReturn(string line)
        {
            return DataReturn(Parser(line));
        }
        public string DataReturn(Line line)
        {
            var data = "";
            if (!line.recognised) return "//Invalid Line: "+line.item;
            var print = new RADevBaseItems.Printers();
            var varItems = new RADevBaseItems.Variables();
            var OPSItems = new RADevBaseItems.Operations();
            switch (line.item)
            {
                case "writel":
                case "write":
                    data = print.Printer(line.arg3, line.arg1);
                    break;
                case "printl":
                case "print":
                    data = print.Printer(line.arg3, line.arg1);
                    break;
                case "int":
                    break;
                case "num":
                    data = varItems.Numbers(line.arg3, line.arg1, line.arg2);
                    break;
                case "string":
                    data = varItems.Strings(line.arg1, line.arg2);
                    break;
                case "+":
                    data = OPSItems.Add(line.arg1, line.arg2);
                    break;
                case "-":
                    data = OPSItems.Sub(line.arg1, line.arg2);
                    break;
                case "*":
                    data = OPSItems.Mul(line.arg1, line.arg2);
                    break;
                case "/":
                    data = OPSItems.Div(line.arg1, line.arg2);
                    break;
                case "%":
                    data = OPSItems.Mod(line.arg1, line.arg2);
                    break;
                case "raw":
                    data = line.arg1;
                    break;
            }
            switch (line.item)
            {
                case "var":
                    data = varItems.Implicit(line.arg1, line.arg2);
                    break;
            }
            return data;
        }
        public Line Parser(string lineToParse)
        {
            var lineReturn = new Line();
            var parts = lineToParse.Split(' ');
            foreach (string line in itemList)
            {
                if (parts[0].Contains(line))
                {
                    lineReturn.item = line;
                    lineReturn.recognised = true;
                }
                if (!lineReturn.recognised)
                {
                    foreach (var item in ironItemList)
                    {
                        lineReturn.item = line;
                        lineReturn.recognised = true;
                    }
                }
                if (lineReturn.recognised) {
                    try
                    {
                        switch (lineReturn.item)
                        {
                            case "writel":
                                lineReturn.arg1 = lineToParse.Replace("writel", "");
                                lineReturn.arg3 = true;
                                break;
                            case "write":
                                lineReturn.arg1 = lineToParse.Replace("write", "");
                                lineReturn.arg3 = false;
                                break;
                            case "printl":
                                lineReturn.arg1 = lineToParse.Replace("printl", "");
                                lineReturn.arg3 = true;
                                break;
                            case "print":
                                lineReturn.arg1 = lineToParse.Replace("print", "");
                                lineReturn.arg3 = false;
                                break;
                            case "int":
                                lineReturn.arg1 = lineToParse.Split('=')[0];
                                lineReturn.arg2 = lineToParse.Split('=')[1];
                                lineReturn.arg1 = lineReturn.arg1.Replace("int", "");
                                lineReturn.arg3 = true;
                                break;
                            case "num":
                                lineReturn.arg1 = lineToParse.Split('=')[0];
                                lineReturn.arg2 = lineToParse.Split('=')[1];
                                lineReturn.arg1 = lineReturn.arg1.Replace("num", "");
                                lineReturn.arg3 = false;
                                break;
                            case "string":
                                lineReturn.arg1 = lineToParse.Split('=')[0];
                                lineReturn.arg2 = lineToParse.Split('=')[1];
                                lineReturn.arg1 = lineReturn.arg1.Replace("string", "");
                                break;
                            case "+":
                                lineReturn.arg1 = lineToParse.Split('+')[0];
                                lineReturn.arg2 = lineToParse.Split('+')[1];
                                break;
                            case "-":
                                lineReturn.arg1 = lineToParse.Split('-')[0];
                                lineReturn.arg2 = lineToParse.Split('-')[1];
                                break;
                            case "*":
                                lineReturn.arg1 = lineToParse.Split('*')[0];
                                lineReturn.arg2 = lineToParse.Split('*')[1];
                                break;
                            case "/":
                                lineReturn.arg1 = lineToParse.Split('/')[0];
                                lineReturn.arg2 = lineToParse.Split('/')[1];
                                break;
                            case "%":
                                lineReturn.arg1 = lineToParse.Split('%')[0];
                                lineReturn.arg2 = lineToParse.Split('%')[1];
                                break;
                            case "raw":
                                lineReturn.arg1 = parts[1];
                                break;
                        }
                        switch (lineReturn.item)
                        {
                            case "var":
                                lineReturn.arg1 = lineToParse.Split('=')[0];
                                lineReturn.arg1 = lineReturn.arg1.Replace("var", "");
                                lineReturn.arg2 = lineToParse.Split('=')[1];
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        lineReturn.recognised = false;
                    }
                }
                
                if (!lineReturn.recognised)
                {
                    lineReturn.item = lineToParse;
                }
            }
            return lineReturn;
        }
    }

}
