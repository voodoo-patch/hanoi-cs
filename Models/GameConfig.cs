
namespace Hanoi.Models
{
    public class GameConfig
    {
        public uint Disks { get; set; }
        public uint Rods { get; set; }
        public uint SourceTowerIndex { get; set; }
        public uint DestTowerIndex { get; set; }
    }
}