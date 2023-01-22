using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using bf.Instructions;

namespace bf;

internal static class Program
{
    private static void Main(string[] args)
    {
        if (!args.Any())
        {
            Console.WriteLine("Please supply folder,  target and reference parameters");
            return;
        }

        var fileToCreate = "Unnamed";
        var references = new List<string>();
        var projectFolder = string.Empty;
        var releaseMode = false;

        for (var argumentNumber = 0; argumentNumber < args.Length; argumentNumber++)
            switch (args[argumentNumber])
            {
                case "/o":
                    argumentNumber++;
                    fileToCreate = args[argumentNumber];
                    break;
                case "/r":
                    argumentNumber++;
                    references.Add(args[argumentNumber]);
                    break;
                case "-c":
                case "--configuration":
                    argumentNumber++;
                    releaseMode = args[argumentNumber].Equals("release", StringComparison.InvariantCultureIgnoreCase);
                    break;
                default:
                    projectFolder = args[argumentNumber];
                    break;
            }


        var sourceCodeFile = Path.Combine(projectFolder, "main.bf");


        if (!File.Exists(sourceCodeFile))
        {
            Console.WriteLine($"The source code file {sourceCodeFile} does not exist.");
            return;
        }

        Console.WriteLine(releaseMode ? "Building in release mode" : "Building in debug mode");

        var projectName = Path.GetFileNameWithoutExtension(fileToCreate);

        var sourceCode = File.ReadAllText(sourceCodeFile);

        var errors = new List<Error>();
        var rootBlock = ParseSourceCode(sourceCode, errors);

        if (errors.Any())
        {
            DisplayErrors(errors);
            return;
        }

        var optimisedCode = Optimiser.Optimise(rootBlock, null);

        CheckForEmptyLoops(optimisedCode, errors);
        if (errors.Any())
        {
            DisplayErrors(errors);
            return;
        }

        rootBlock = releaseMode switch
        {
            true => Lower(optimisedCode),
            false => Lower(rootBlock)
        };

        references.Add(SystemHelper.GetLibraryPath("System.Console.dll"));
        references.Add(SystemHelper.GetLibraryPath("System.Runtime.dll"));

        IlGenerator.Emit(projectName, fileToCreate, rootBlock, releaseMode, references, sourceCodeFile);
    }

    private static Block Lower(Block originalBlock)
    {
        var newBlock = new Block(originalBlock.Location);
        var nextLabelNumber = 0;

        LowerBlock(originalBlock, newBlock);

        return newBlock;

        void LowerBlock(Block theOriginalBlock, Block theNewBlock)
        {
            foreach (var instruction in theOriginalBlock.Instructions)
            {
                if (instruction is Block block)
                {
                    /* while (tape[dataPointer] != 0)
                     * {
                     *  do stuff
                     * }
                     * 
                     * topOfLoop1:
                     * if (tape[dataPointer] == 0) goto endOfLoop1
                     * do stuff
                     * goto topOfLoop1
                     * endOfLoop1:
                     */
                    var labelNumber = nextLabelNumber;
                    nextLabelNumber++;

                    theNewBlock.Add(new Label(instruction.Location, $"topOfLoop{labelNumber.ToString()}"));
                    theNewBlock.Add(new ConditionalJump(instruction.Location,
                        $"endOfLoop{labelNumber.ToString()}"));
                    LowerBlock(block, theNewBlock);
                    theNewBlock.Add(new Jump(instruction.Location, $"topOfLoop{labelNumber.ToString()}"));
                    theNewBlock.Add(new Label(instruction.Location, $"endOfLoop{labelNumber.ToString()}"));
                }

                theNewBlock.Add(instruction);
            }
        }
    }

    private static void CheckForEmptyLoops(Block rootBlock, ICollection<Error> errors)
    {
        foreach (var loop in rootBlock.Instructions.OfType<Block>())
            if (loop.Instructions.Any())
                CheckForEmptyLoops(loop, errors);
            else
                errors.Add(new Error(loop.Location, "Empty loop - either will do nothing or loop infinitely"));
    }

    private static void DisplayErrors(IEnumerable<Error> errors)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (var error in errors.OrderBy(e => e.Location))
            Console.WriteLine($"Error at position {error.Location.StartColumn.ToString()} - {error.Description}");
        Console.ResetColor();
    }

    private static Block ParseSourceCode(string sourceCode, ICollection<Error> errors)
    {
        var rootBlock = new Block(new Location(0));
        var currentBlock = rootBlock;
        var location = 1;
        foreach (var instruction in sourceCode)
        {
            switch (instruction)
            {
                case '>':
                    currentBlock.Add(new MoveRight(new Location(location)));
                    break;
                case '<':
                    currentBlock.Add(new MoveLeft(new Location(location)));
                    break;
                case '+':
                    currentBlock.Add(new Increase(new Location(location)));
                    break;
                case '-':
                    currentBlock.Add(new Decrease(new Location(location)));
                    break;
                case '.':
                    currentBlock.Add(new WriteToConsole(new Location(location)));
                    break;
                case ',':
                    currentBlock.Add(new ReadFromConsole(new Location(location)));
                    break;
                case '[':
                    var newBlock = new Block(new Location(location), currentBlock);
                    currentBlock.Add(newBlock);
                    currentBlock = newBlock;
                    break;
                case ']':
                    if (currentBlock.Parent is null)
                        errors.Add(new Error(new Location(location), "] does not have a matching ["));
                    else
                        currentBlock = currentBlock.Parent;
                    break;
            }

            location++;
        }

        while (currentBlock.Parent != null)
        {
            errors.Add(new Error(currentBlock.Location, "[ does not have a matching ]"));
            currentBlock = currentBlock.Parent;
        }

        return rootBlock;
    }
}