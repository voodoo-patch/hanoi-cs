using System;
using System.Collections.Generic;
using System.Linq;
using Hanoi.Models;

namespace Hanoi
{
    public class HanoiSolver
    {
        private readonly GameConfig config;
        private readonly Board board;
        public HanoiSolver(GameConfig config)
        {
            this.config = config;
            this.board = new Board(config.Rods, config.SourceTowerIndex, config.DestTowerIndex);
            this.Init();
        }

        private void Init()
        {
            this.board
                .Rod(config.SourceTowerIndex)
                .Fill(config.Disks);
        }

        public void Solve() => this.Solve(
            config.Disks,
            this.board.SourceRod(),
            this.board.DestRod(),
            this.board.GetSupport()
            );

        private void Solve(uint disks, Rod source, Rod destination, Rod support)
        {
            if (disks == 0)
            {
                return;
            }

            Solve(disks - 1, source, support, destination);

            destination.Push(source.Pop());

            Solve(disks - 1, support, destination, source);
        }

        private void SwapHead(Rod source, Rod destination)
        {
            if (!this.EnsureMove(source, destination))
                throw new InvalidOperationException("Attempted illegal move");

            uint disk = source.Pop();
            destination.Push(disk);
        }

        private bool EnsureMove(Rod source, Rod destination)
        {
            return !destination.Any() || source.Peek() < destination.Peek();
        }

        public void Print()
        {
            int height = (int)this.config.Disks + 2;
            for (var rodIndex = 0; rodIndex < this.config.Rods; rodIndex++)
            {
                Console.Write($"\t{rodIndex}");
            }
            Console.Write("\n");

            while (height >= 0)
            {
                for (uint rodIndex = 0; rodIndex < this.config.Rods; rodIndex++)
                {
                    IEnumerable<uint> rod = this.board.Rod(rodIndex).Reverse();
                    uint val = rod.ElementAtOrDefault((int)height);
                    Console.Write("\t" + (val != default(uint) ? val.ToString() : "|"));
                }
                Console.Write("\n");
                height--;
            }
        }
    }
}