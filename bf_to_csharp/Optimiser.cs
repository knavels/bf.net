using bf.Instructions;

namespace bf;

internal static class Optimiser
{
    public static Block Optimise(Block originalBlock, Block parentBlock)
    {
        var newBlock = new Block(originalBlock.Location, parentBlock);

        var previous = default(IInstruction);
        foreach (var instruction in originalBlock.Instructions)
            switch (instruction)
            {
                case Block block:
                    if (previous is object && InstructionDoesSomething(previous)) newBlock.Add(previous);
                    newBlock.Add(Optimise(block, newBlock));
                    previous = null;
                    break;

                case WriteToConsole _:
                case ReadFromConsole _:
                    if (previous is object && InstructionDoesSomething(previous)) newBlock.Add(previous);
                    newBlock.Add(instruction);
                    previous = null;
                    break;

                case MoveLeft _:
                    previous = CombineMoves(newBlock, previous, -1);
                    break;

                case MoveRight _:
                    previous = CombineMoves(newBlock, previous, +1);
                    break;

                case Decrease _:
                    previous = CombineIncreases(newBlock, previous, -1);
                    break;

                case Increase _:
                    previous = CombineIncreases(newBlock, previous, +1);
                    break;
            }

        if (previous is object && InstructionDoesSomething(previous)) newBlock.Add(previous);

        return newBlock;
    }

    private static bool InstructionDoesSomething(IInstruction instruction)
    {
        switch (instruction)
        {
            case Move { Quantity: 0 }:
            case IncreaseCell { Quantity: 0 }:
                return false;
            default:
                return true;
        }
    }

    private static IInstruction CombineIncreases(Block newBlock, IInstruction previous, int offset)
    {
        if (previous is IncreaseCell increaseCell)
        {
            previous = new IncreaseCell(increaseCell.Location, increaseCell.Quantity + offset);
        }
        else
        {
            if (previous is object && InstructionDoesSomething(previous)) newBlock.Add(previous);
            previous = new IncreaseCell(newBlock.Location, offset);
        }

        return previous;
    }

    private static IInstruction CombineMoves(Block newBlock, IInstruction previous, int offset)
    {
        if (previous is Move move)
        {
            previous = new Move(previous.Location, move.Quantity + offset);
        }
        else
        {
            if (previous is object && InstructionDoesSomething(previous)) newBlock.Add(previous);
            previous = new Move(newBlock.Location, offset);
        }

        return previous;
    }
}