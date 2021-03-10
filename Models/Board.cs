using System.Collections.Generic;
using System.Linq;

namespace Hanoi.Models
{
    public class Board
    {
        private readonly List<Rod> Rods;
        private readonly uint sourceIndex;
        private readonly uint destIndex;
        private readonly List<uint> freeRods;

        public Board(uint rodsLength, uint source, uint dest)
        {
            this.sourceIndex = source;
            this.destIndex = dest;

            this.freeRods = new List<uint>();

            this.Rods = new List<Rod>();
            while (rodsLength > 0)
            {
                this.Rods.Add(new Rod());
                rodsLength--;
                if (rodsLength != source && rodsLength != dest)
                {
                    this.freeRods.Add(rodsLength);
                }
            }
        }

        public Rod Rod(uint index) => this.Rods[(int)index];
        public Rod SourceRod() => this.Rods[(int)sourceIndex];
        public Rod DestRod() => this.Rods[(int)destIndex];
        public Rod GetSupport() => this.Rods[(int)this.freeRods.First()];
    }
}