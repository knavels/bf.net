namespace bf.Instructions;

internal class Decrease : IInstruction
{
    public Decrease(Location location)
    {
        Location = location;
    }

    public Location Location { get; }
}