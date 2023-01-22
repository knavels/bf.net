namespace bf.Instructions;

internal class WriteToConsole : IInstruction
{
    public WriteToConsole(Location location)
    {
        Location = location;
    }

    public Location Location { get; }
}