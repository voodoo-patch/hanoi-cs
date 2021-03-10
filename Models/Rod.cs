using System;
using System.Collections.Generic;
using System.Linq;

namespace Hanoi.Models
{
    public class Rod : Stack<uint>
    {
        public Rod() : base()
        {
        }
        public Rod(IEnumerable<uint> stack) : base(stack)
        {
        }

        public Rod Over()
        {
            return new Rod(this.TakeLast(this.Count));
        }

        public void Fill(uint disks)
        {
            while (disks > 0)
            {
                this.Push(disks);
                disks--;
            }
        }
    }
}