using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Collections;

namespace Rftim3AdventOfCode.Refactor
{
    public class _20_TrenchMap : I_20_TrenchMap
    {
        #region Static
        private readonly List<string>? data;

        public _20_TrenchMap()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_20_TrenchMap));
        }

        /// <summary>
        /// With the scanners fully deployed, you turn their attention to mapping the floor of the ocean trench.
        /// 
        /// When you get back the image from the scanners, it seems to just be random noise.Perhaps you can combine an image enhancement algorithm 
        /// and the input image(your puzzle input) to clean it up a little.
        /// 
        /// For example:
        /// 
        /// ..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..##
        /// #..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###
        /// .######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#.
        /// .#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#.....
        /// .#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#..
        /// ...####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.....
        /// ..##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#
        /// 
        /// #..#.
        /// #....
        /// ##..#
        /// ..#..
        /// ..###
        /// The first section is the image enhancement algorithm. It is normally given on a single line, but it has been wrapped to multiple lines in this example for legibility.
        /// The second section is the input image, a two-dimensional grid of light pixels (#) and dark pixels (.).
        /// 
        /// The image enhancement algorithm describes how to enhance an image by simultaneously converting all pixels in the input image into an output image.
        /// Each pixel of the output image is determined by looking at a 3x3 square of pixels centered on the corresponding input image pixel.
        /// So, to determine the value of the pixel at (5,10) in the output image, nine pixels from the input image 
        /// need to be considered: (4,9), (4,10), (4,11), (5,9), (5,10), (5,11), (6,9), (6,10), and(6,11). 
        /// These nine input pixels are combined into a single binary number that is used as an index in the image enhancement algorithm string.
        /// 
        /// For example, to determine the output pixel that corresponds to the very middle pixel of the input image, the nine pixels marked by[...] would need to be considered:
        /// 
        /// # . . # .
        /// #[. . .].
        /// #[# . .]#
        /// .[. # .].
        /// . . # # #
        /// Starting from the top-left and reading across each row, these pixels are..., then #.., then .#.; 
        /// combining these forms ...#...#.. By turning dark pixels (.) into 0 and light pixels (#) into 1, the binary number 000100010 can be formed, which is 34 in decimal.
        /// 
        /// The image enhancement algorithm string is exactly 512 characters long, enough to match every possible 9-bit binary number.
        /// The first few characters of the string (numbered starting from zero) are as follows:
        /// 
        /// 0         10        20        30  34    40        50        60        70
        /// |         |         |         |   |     |         |         |         |
        /// ..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..##
        /// In the middle of this first group of characters, the character at index 34 can be found: #.
        /// So, the output pixel in the center of the output image should be #, a light pixel.
        /// 
        /// This process can then be repeated to calculate every pixel of the output image.
        /// Through advances in imaging technology, the images being operated on here are infinite in size.Every pixel of the infinite output image 
        /// needs to be calculated exactly based on the relevant pixels of the input image.
        /// The small input image you have is only a small region of the actual infinite input image; the rest of the input image consists of dark pixels(.).
        /// For the purposes of the example, to save on space, only a portion of the infinite-sized input and output images will be shown.
        /// The starting input image, therefore, looks something like this, with more dark pixels (.) extending forever in every direction not shown here:
        /// 
        /// ...............
        /// ...............
        /// ...............
        /// ...............
        /// ...............
        /// .....#..#......
        /// .....#.........
        /// .....##..#.....
        /// .......#.......
        /// .......###.....
        /// ...............
        /// ...............
        /// ...............
        /// ...............
        /// ...............
        /// By applying the image enhancement algorithm to every pixel simultaneously, the following output image can be obtained:
        /// 
        /// ...............
        /// ...............
        /// ...............
        /// ...............
        /// .....##.##.....
        /// ....#..#.#.....
        /// ....##.#..#....
        /// ....####..#....
        /// .....#..##.....
        /// ......##..#....
        /// .......#.#.....
        /// ...............
        /// ...............
        /// ...............
        /// ...............
        /// Through further advances in imaging technology, the above output image can also be used as an input image! This allows it to be enhanced a second time:
        /// 
        /// ...............
        /// ...............
        /// ...............
        /// ..........#....
        /// ....#..#.#.....
        /// ...#.#...###...
        /// ...#...##.#....
        /// ...#.....#.#...
        /// ....#.#####....
        /// .....#.#####...
        /// ......##.##....
        /// .......###.....
        /// ...............
        /// ...............
        /// ...............
        /// Truly incredible - now the small details are really starting to come through.After enhancing the original input image twice, 35 pixels are lit.
        /// 
        /// Start with the original input image and apply the image enhancement algorithm twice, being careful to account for the infinite size of the images. 
        /// How many pixels are lit in the resulting image?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            BitArray? enhancement = new(input.First().ToCharArray().Select(c => c == '#').ToArray());

            HashSet<(int, int)> inputImage = [];
            for (int row = 2; row < input.Count; row++)
            {
                string line = input[row];
                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] == '#') inputImage.Add((col, row - 2));
                }
            }

            FrameState initialFrame = new()
            {
                MinX = 0,
                MinY = 0,
                MaxX = input[2].Length,
                MaxY = input.Count - 2
            };

            (HashSet<(int, int)> image, FrameState frame) = (inputImage, initialFrame);

            for (int i = 0; i < 2; i++)
            {
                (image, frame) = Step(image, frame, enhancement);
            }

            return image.Count;
        }

        /// <summary>
        /// You still can't quite make out the details in the image. Maybe you just didn't enhance it enough.
        /// 
        /// If you enhance the starting input image in the above example a total of 50 times, 3351 pixels are lit in the final output image.
        /// 
        /// Start again with the original input image and apply the image enhancement algorithm 50 times.
        /// How many pixels are lit in the resulting image?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            BitArray? enhancement = new(input.First().ToCharArray().Select(c => c == '#').ToArray());

            HashSet<(int, int)> inputImage = [];
            for (int row = 2; row < input.Count; row++)
            {
                string line = input[row];
                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] == '#') inputImage.Add((col, row - 2));
                }
            }

            FrameState initialFrame = new()
            {
                MinX = 0,
                MinY = 0,
                MaxX = input[2].Length,
                MaxY = input.Count - 2
            };

            (HashSet<(int, int)> image, FrameState frame) = (inputImage, initialFrame);
            for (int i = 0; i < 50; i++)
            {
                (image, frame) = Step(image, frame, enhancement);
            }
            return image.Count;
        }

        private static (HashSet<(int, int)>, FrameState) Step(HashSet<(int, int)> inputImage, FrameState frame, BitArray? enhancement)
        {
            HashSet<(int, int)> outputImage = [];
            for (int x = frame.MinX - 1; x <= frame.MaxX + 1; x++)
            {
                for (int y = frame.MinY - 1; y <= frame.MaxY + 1; y++)
                {
                    if (!outputImage.Contains((x, y)) && CalculatePixel(inputImage, (x, y), frame, enhancement)) outputImage.Add((x, y));
                }
            }

            FrameState newFrame = new()
            {
                LitOutside = frame.LitOutside ? enhancement![511] : enhancement![0],
                MinX = frame.MinX - 1,
                MinY = frame.MinY - 1,
                MaxX = frame.MaxX + 1,
                MaxY = frame.MaxY + 1,
            };

            return (outputImage, newFrame);
        }

        private static bool CalculatePixel(HashSet<(int, int)> image, (int x, int y) coordinates, FrameState frame, BitArray? enhancement)
        {
            int key = 0;
            for (int row = coordinates.y - 1; row <= coordinates.y + 1; row++)
            {
                for (int col = coordinates.x - 1; col <= coordinates.x + 1; col++)
                {
                    key <<= 1;
                    bool litBecauseOutside = frame.LitOutside && (col < frame.MinX || col > frame.MaxX || row < frame.MinY || row > frame.MaxY);
                    if (litBecauseOutside || image.Contains((col, row))) key += 1;
                }
            }

            return enhancement![key];
        }

        private struct FrameState
        {
            public bool LitOutside = false;
            public int MinX = int.MaxValue;
            public int MinY = int.MaxValue;
            public int MaxX = int.MinValue;
            public int MaxY = int.MinValue;

            public FrameState() { }
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _20_TrenchMap(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_20_TrenchMap));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}