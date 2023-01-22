namespace bf
{
    internal class MoveLeft : IInstruction
    {
        public MoveLeft(Location location)
        {
            Location = location;
        }

        public Location Location { get; }
    }
}