namespace bf
{
    internal class Error
    {
        public Error(Location location, string description)
        {
            Location = location;
            Description = description;
        }

        public Location Location { get; }
        public string Description { get; }
    }
}