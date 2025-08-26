using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _08_TwoFactorAuthentication : I_08_TwoFactorAuthentication
    {
        #region Static
        private readonly List<string>? data;

        public _08_TwoFactorAuthentication()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_08_TwoFactorAuthentication));
        }

        /// <summary>
        /// You come across a door implementing what you can only assume is an implementation of two-factor authentication after a long game of requirements telephone.
        /// 
        /// To get past the door, you first swipe a keycard(no problem; there was one on a nearby desk). 
        /// Then, it displays a code on a little screen, and you type that code on a keypad.Then, presumably, the door unlocks.
        /// 
        /// Unfortunately, the screen has been smashed.After a few minutes, you've taken everything apart and figured out how it works.
        /// Now you just have to work out what the screen would have displayed.
        /// 
        /// The magnetic strip on the card you swiped encodes a series of instructions for the screen; these instructions are your puzzle input.
        /// The screen is 50 pixels wide and 6 pixels tall, all of which start off, and is capable of three somewhat peculiar operations:
        /// 
        /// rect AxB turns on all of the pixels in a rectangle at the top-left of the screen which is A wide and B tall.
        /// rotate row y= A by B shifts all of the pixels in row A (0 is the top row) right by B pixels.Pixels that would fall off the right end appear at the left end of the row.
        /// rotate column x= A by B shifts all of the pixels in column A (0 is the left column) down by B pixels.Pixels that would fall off the bottom appear at the top of the column.
        /// For example, here is a simple sequence on a smaller screen:
        /// 
        /// rect 3x2 creates a small rectangle in the top-left corner:
        /// 
        /// ###....
        /// ###....
        /// .......
        /// rotate column x= 1 by 1 rotates the second column down by one pixel:
        /// 
        /// #.#....
        /// ###....
        /// .#.....
        /// rotate row y= 0 by 4 rotates the top row right by four pixels:
        /// 
        /// ....#.#
        /// ###....
        /// .#.....
        /// rotate column x= 1 by 1 again rotates the second column down by one pixel, causing the bottom pixel to wrap back to the top:
        /// 
        /// .#..#.#
        /// #.#....
        /// .#.....
        /// As you can see, this display technology is extremely powerful, and will soon dominate the tiny-code-displaying-screen market. 
        /// That's what the advertisement on the back of the display tries to convince you, anyway.
        /// 
        /// There seems to be an intermediate check of the voltage used by the display: after you swipe your card, if the screen did work, how many pixels should be lit?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            lcd = new string[lcd_height, lcd_width];
            //InitDisplay();
            //DisplayScreen();

            foreach (string line in input)
            {
                ParseLine(line);
            }

            return CountLights();
        }

        /// <summary>
        /// You notice that the screen is only capable of displaying capital letters; in the font it uses, each letter is 5 pixels wide and 6 tall.
        /// 
        /// After you swipe your card, what code is the screen trying to display?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            lcd = new string[lcd_height, lcd_width];
            //InitDisplay();
            //DisplayScreen();

            foreach (string line in input)
            {
                ParseLine(line);
            }

            return CountLights();
        }

        private const int lcd_width = 50;
        private const int lcd_height = 6;
        private static string[,]? lcd;

        private static void ParseLine(string param)
        {
            string instruction = param.Split(' ')[0];

            switch (instruction)
            {
                case "rect":
                    string rec_width = param.Split(' ')[1].Split('x')[0];
                    string rec_height = param.Split(' ')[1].Split('x')[1];
                    DrawRect(Convert.ToInt32(rec_width), Convert.ToInt32(rec_height));
                    break;

                case "rotate":
                    string inst = param.Split(' ')[1];
                    string coord = param.Split(' ')[2].Split('=')[0];
                    int coordVal = Convert.ToInt32(param.Split(' ')[2].Split('=')[1]);
                    int byVal = Convert.ToInt32(param.Split(' ')[4]);
                    DrawRotate(inst, coord, coordVal, byVal);
                    break;
            }

            //DisplayScreen();
        }

        private static void DrawRotate(string inst, string coord, int coordVal, int byVal)
        {
            if (inst == "column")
            {
                for (int cnt = 0; cnt < byVal; cnt++)
                {
                    string tmp = lcd![lcd_height - 1, coordVal];

                    for (int i = lcd_height - 1; i > 0; i--)
                    {
                        lcd[i, coordVal] = lcd[i - 1, coordVal];
                    }
                    lcd[0, coordVal] = tmp;
                }
            }

            ArgumentNullException.ThrowIfNull(coord);

            if (inst == "row")
            {
                for (int cnt = 0; cnt < byVal; cnt++)
                {
                    string tmp = lcd![coordVal, lcd_width - 1];

                    for (int i = lcd_width - 1; i > 0; i--)
                    {
                        lcd[coordVal, i] = lcd[coordVal, i - 1];
                    }
                    lcd[coordVal, 0] = tmp;
                }
            }
        }

        private static void DrawRect(int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    lcd![i, j] = "#";
                }
            }
        }

        private static int CountLights()
        {
            int sum = 0;

            for (int i = 0; i < lcd_height; i++)
            {
                for (int j = 0; j < lcd_width; j++)
                {
                    if (lcd![i, j] == "#") sum++;
                }
            }

            return sum;
        }

        private static void DisplayScreen()
        {
            Console.Clear();

            for (int i = 0; i < lcd_height; i++)
            {
                for (int j = 0; j < lcd_width; j++)
                {
                    Console.Write($" {lcd![i, j]}");
                }
                Console.WriteLine();
            }
        }

        private static void InitDisplay()
        {
            for (int i = 0; i < lcd_height; i++)
            {
                for (int j = 0; j < lcd_width; j++)
                {
                    lcd![i, j] = ".";
                }
            }
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _08_TwoFactorAuthentication(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_08_TwoFactorAuthentication));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}