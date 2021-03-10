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
            this.board.SourceRod(),
            this.board.DestRod(),
            this.board.GetSupport()
            );

        private void Solve(Rod source, Rod destination, Rod support)
        {
            if (!source.Over().Any())
            {
                this.SwapHead(source, destination);
            }
            else
            {
                this.Solve(source.Over(), support, destination);
                this.SwapHead(source, destination);
                this.Solve(support, destination.Over(), source);
            }
        }

        private void SwapHead(Rod source, Rod destination)
        {
            uint disk = source.Pop();
            destination.Push(disk);
        }

        public void Print()
        {
            var height = this.config.Disks + 2;
            for (var rodIndex = 0; rodIndex < this.config.Rods; rodIndex++)
            {
                Console.Write($"\t{rodIndex}");
            }
            Console.Write("\n");

            while (height > 0)
            {
                for (uint rodIndex = 0; rodIndex < this.config.Rods; rodIndex++)
                {
                    Rod rod = this.board.Rod(rodIndex);
                    int? val = ((IEnumerable<int?>)rod).ElementAtOrDefault((int)height);
                    Console.Write("\t" + (val != null ? val.ToString() : "|"));
                }
                Console.Write("\n");
                height--;
            }
        }
    }
}