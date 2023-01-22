namespace bf.Instructions;

internal class ReadFromConsole : IInstruction
{
    public ReadFromConsole(Location location)
    {
        Location = location;
    }

    public Location Location { get; }
}