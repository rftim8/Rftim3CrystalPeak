using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _23_CategorySix : I_23_CategorySix
    {
        #region Static
        private readonly List<string>? data;

        public _23_CategorySix()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_23_CategorySix));
        }

        /// <summary>
        /// The droids have finished repairing as much of the ship as they can. Their report indicates that this was a Category 6 disaster -
        /// not because it was that bad, but because it destroyed the stockpile of Category 6 network cables as well as most of the ship's network infrastructure.
        /// 
        /// You'll need to rebuild the network from scratch.
        /// 
        /// The computers on the network are standard Intcode computers that communicate by sending packets to each other.
        /// There are 50 of them in total, each running a copy of the same Network Interface Controller(NIC) software(your puzzle input). 
        /// The computers have network addresses 0 through 49; when each computer boots up, it will request its network address via a single input instruction.
        /// Be sure to give each computer a unique network address.
        /// 
        /// Once a computer has received its network address, it will begin doing work and communicating over the network by sending 
        /// and receiving packets.All packets contain two values named X and Y.Packets sent to a computer are queued by the recipient and read in the order they are received.
        /// 
        /// To send a packet to another computer, the NIC will use three output instructions that provide the destination address of the packet 
        /// followed by its X and Y values. For example, three output instructions that provide the values 10, 20, 30 would send a packet with X = 20 and Y = 30 
        /// to the computer with address 10.
        /// 
        /// To receive a packet from another computer, the NIC will use an input instruction.If the incoming packet queue is empty, provide -1. 
        /// Otherwise, provide the X value of the next packet; the computer will then use a second input instruction to receive the Y value for the same packet.
        /// Once both values of the packet are read in this way, the packet is removed from the queue.
        /// 
        /// Note that these input and output instructions never block. 
        /// Specifically, output instructions do not wait for the sent packet to be received - the computer might send multiple packets before receiving any.
        /// Similarly, input instructions do not wait for a packet to arrive - if no packet is waiting, input instructions should receive -1.
        /// 
        /// Boot up all 50 computers and attach them to your network.What is the Y value of the first packet sent to address 255?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> data)
        {
            return 0;
        }

        /// <summary>
        /// Packets sent to address 255 are handled by a device called a NAT (Not Always Transmitting). 
        /// The NAT is responsible for managing power consumption of the network by blocking certain packets and watching for idle periods in the computers.
        /// 
        /// If a packet would be sent to address 255, the NAT receives it instead.
        /// The NAT remembers only the last packet it receives; that is, the data in each packet it receives overwrites the NAT's packet memory with the new packet's X and Y values.
        /// The NAT also monitors all computers on the network.If all computers have empty incoming packet queues and are continuously trying 
        /// to receive packets without sending packets, the network is considered idle.
        /// Once the network is idle, the NAT sends only the last packet it received to address 0;
        /// this will cause the computers on the network to resume activity.
        /// In this way, the NAT can throttle power consumption of the network when the ship needs power in other areas.
        /// 
        /// Monitor packets released to the computer at address 0 by the NAT.What is the first Y value delivered by the NAT to the computer at address 0 twice in a row?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> data)
        {
            return 0;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _23_CategorySix(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_23_CategorySix));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}