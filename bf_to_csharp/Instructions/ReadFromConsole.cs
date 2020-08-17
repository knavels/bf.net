﻿using System.Text;

namespace bf_to_csharp
{
    class ReadFromConsole : IInstruction
    {
        public ReadFromConsole(int location)
        {
            Location = location;
        }
        public int Location { get; }

        public void EmitCSharp(StringBuilder sb, int indents)
        {
            sb.AppendLine(new string('\t', indents) + "tape[dataPointer] = (byte)Console.ReadKey().KeyChar;");
        }
    }

}