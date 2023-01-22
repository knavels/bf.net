namespace bf
{
    internal class Location
    {
        public Location(int location)
        {
            StartColumn = location;
        }

        public int StartColumn { get; }
    }
}