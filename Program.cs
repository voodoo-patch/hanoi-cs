using System;
using Hanoi.Models;

namespace Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new GameConfig(){
                Disks= 3,
                Rods = 3,
                SourceTowerIndex = 0,
                DestTowerIndex = 1
            };
            var solver = new HanoiSolver(config);

            solver.Solve();
            solver.Print();
        }
    }
}
