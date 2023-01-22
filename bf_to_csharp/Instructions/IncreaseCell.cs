namespace bf.Instructions;

internal class IncreaseCell : IInstruction
{
    public IncreaseCell(Location location, int quantity)
    {
        Location = location;
        Quantity = quantity;
    }

    public int Quantity { get; }
    public Location Location { get; }
}