using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace bf
{
    internal class Block : IInstruction
    {
        private readonly List<IInstruction> _instructions = new List<IInstruction>();

        public Block(Location location, Block parent = null)
        {
            Parent = parent;
            Location = location;
        }

        public Block Parent { get; internal set; }

        public ReadOnlyCollection<IInstruction> Instructions => _instructions.AsReadOnly();
        public Location Location { get; }

        public void Add(IInstruction instruction)
        {
            _instructions.Add(instruction);
        }
    }
}