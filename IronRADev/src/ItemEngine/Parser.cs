using System;
using ItemEngine;
namespace ItemEngine
{
    public class Parser
    {
        public int ParseToInt(string input)
        {
            LexerTypes.Items returnEnum = (LexerTypes.Items)Enum.Parse(typeof(LexerTypes.Items), input);

            return (int)returnEnum;

        }
    }
}
