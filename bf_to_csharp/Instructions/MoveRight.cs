﻿namespace bf.Instructions;

internal class MoveRight : IInstruction
{
    public MoveRight(Location location)
    {
        Location = location;
    }

    public Location Location { get; }
}