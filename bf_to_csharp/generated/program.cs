using System;
using System.Collections.Generic;

namespace bfi
{
    class Program
    {
        static void Main(string[] args)
        {
            var tape = new byte[10000];
            var dataPointer = 5000;
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			while (tape[dataPointer] != 0) {
				dataPointer++;
				tape[dataPointer]=(byte)(tape[dataPointer]+1);
				tape[dataPointer]=(byte)(tape[dataPointer]+1);
				tape[dataPointer]=(byte)(tape[dataPointer]+1);
				tape[dataPointer]=(byte)(tape[dataPointer]+1);
				while (tape[dataPointer] != 0) {
					dataPointer++;
					tape[dataPointer]=(byte)(tape[dataPointer]+1);
					tape[dataPointer]=(byte)(tape[dataPointer]+1);
					dataPointer++;
					tape[dataPointer]=(byte)(tape[dataPointer]+1);
					tape[dataPointer]=(byte)(tape[dataPointer]+1);
					tape[dataPointer]=(byte)(tape[dataPointer]+1);
					dataPointer++;
					tape[dataPointer]=(byte)(tape[dataPointer]+1);
					tape[dataPointer]=(byte)(tape[dataPointer]+1);
					tape[dataPointer]=(byte)(tape[dataPointer]+1);
					dataPointer++;
					tape[dataPointer]=(byte)(tape[dataPointer]+1);
					dataPointer--;
					dataPointer--;
					dataPointer--;
					dataPointer--;
					tape[dataPointer]=(byte)(tape[dataPointer]-1);
				}
				dataPointer++;
				tape[dataPointer]=(byte)(tape[dataPointer]+1);
				dataPointer++;
				tape[dataPointer]=(byte)(tape[dataPointer]+1);
				dataPointer++;
				tape[dataPointer]=(byte)(tape[dataPointer]-1);
				dataPointer++;
				dataPointer++;
				tape[dataPointer]=(byte)(tape[dataPointer]+1);
				while (tape[dataPointer] != 0) {
					dataPointer--;
				}
				dataPointer--;
				tape[dataPointer]=(byte)(tape[dataPointer]-1);
			}
			dataPointer++;
			dataPointer++;
			Console.Write((char)tape[dataPointer]);
			dataPointer++;
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			Console.Write((char)tape[dataPointer]);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			Console.Write((char)tape[dataPointer]);
			Console.Write((char)tape[dataPointer]);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			Console.Write((char)tape[dataPointer]);
			dataPointer++;
			dataPointer++;
			Console.Write((char)tape[dataPointer]);
			dataPointer--;
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			Console.Write((char)tape[dataPointer]);
			dataPointer--;
			Console.Write((char)tape[dataPointer]);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			Console.Write((char)tape[dataPointer]);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			Console.Write((char)tape[dataPointer]);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			tape[dataPointer]=(byte)(tape[dataPointer]-1);
			Console.Write((char)tape[dataPointer]);
			dataPointer++;
			dataPointer++;
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			Console.Write((char)tape[dataPointer]);
			dataPointer++;
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			tape[dataPointer]=(byte)(tape[dataPointer]+1);
			Console.Write((char)tape[dataPointer]);
        }
    }
}