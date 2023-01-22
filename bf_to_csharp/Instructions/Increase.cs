﻿namespace bf.Instructions;

internal class Increase : IInstruction
{
    public Increase(Location location)
    {
        Location = location;
    }

    public Location Location { get; }
}