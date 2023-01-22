namespace bf
{
    internal class Decrease : IInstruction
    {
        public Decrease(Location location)
        {
            Location = location;
        }

        public Location Location { get; }
    }
}