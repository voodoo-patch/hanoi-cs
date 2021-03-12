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
            return new Rod(this.SkipLast(1).Reverse().ToList());
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