using System;
using Hanoi.Models;

namespace Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new GameConfig()
            {
                Disks = 9,
                Rods = 3,
                SourceTowerIndex = 0,
                DestTowerIndex = 1
            };
            var solver = new HanoiSolver(config);

            Console.WriteLine("Start");
            solver.Print();
            solver.Solve();
            Console.WriteLine("End");
            solver.Print();
        }
    }
}
