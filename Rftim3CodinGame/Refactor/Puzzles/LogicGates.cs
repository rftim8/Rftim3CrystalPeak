namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class LogicGates
    {
        /// <summary>
        /// A logic gate is an electronic device implementing a boolean function, performing a logical operation on one or more binary inputs and producing a single binary output.
        /// Given n input signal names and their respective data, and m output signal names with their respective type of gate and two input signal names, 
        /// provide m output signal names and their respective data, in the same order as provided in input description.
        /// 
        /// All type of gates will always have two inputs and one output.
        /// All input signal data always have the same length.
        /// 
        /// The type of gates are :
        /// AND : performs a logical AND operation.
        /// OR : performs a logical OR operation.
        /// XOR : performs a logical exclusive OR operation.
        /// NAND : performs a logical inverted AND operation.
        /// NOR : performs a logical inverted OR operation.
        /// NXOR : performs a logical inverted exclusive OR operation.
        /// 
        /// Signals are represented with underscore and minus characters, an undescore matching a low level (0, or false) and a minus matching a high level(1, or true).
        /// </summary>
        public LogicGates()
        {
            Dictionary<string, string> ops = new();
            List<Operation> operations = new();

            List<(string, string)> inputs = new()
            {
                ("A", "__---___---___---___---___"),
                ("B", "____---___---___---___---_")
            };

            List<(string, string, string, string)> inputs1 = new()
            {
                ("C", "AND", "A", "B"),
                ("D", "OR", "A", "B"),
                ("E", "XOR", "A", "B")
            };

            int n = 2;
            int m = 3;
            for (int i = 0; i < n; i++)
            {
                string inputName = inputs[i].Item1;
                string inputSignal = inputs[i].Item2;
                ops.Add(inputName, inputSignal);
            }
            for (int i = 0; i < m; i++)
            {
                string outputName = inputs1[i].Item1;
                string type = inputs1[i].Item2;
                string inputName1 = inputs1[i].Item3;
                string inputName2 = inputs1[i].Item4;
                Operation x = new(outputName, type, "", "", "");
                foreach (KeyValuePair<string, string> kvp in ops)
                {
                    if (kvp.Key == inputName1) x.op0 = kvp.Value.Replace("_", "0").Replace("-", "1");
                    if (kvp.Key == inputName2) x.op1 = kvp.Value.Replace("_", "0").Replace("-", "1");
                }
                operations.Add(x);
            }

            Solve(operations);
        }

        private static void Solve(List<Operation> operations)
        {
            foreach (Operation item in operations)
            {
                string x = "";
                int y = item.op0.Length;
                switch (item.op)
                {
                    case "AND":
                        for (int i = 0; i < y; i++) x += (int.Parse(item.op0[i].ToString()) & int.Parse(item.op1[i].ToString())).ToString();
                        break;
                    case "OR":
                        for (int i = 0; i < y; i++) x += (int.Parse(item.op0[i].ToString()) | int.Parse(item.op1[i].ToString())).ToString();
                        break;
                    case "XOR":
                        for (int i = 0; i < y; i++) x += (int.Parse(item.op0[i].ToString()) ^ int.Parse(item.op1[i].ToString())).ToString();
                        break;
                    case "NAND":
                        for (int i = 0; i < y; i++) x += (int.Parse(item.op0[i].ToString()) & int.Parse(item.op1[i].ToString())).ToString();
                        x = Invert(x);
                        break;
                    case "NOR":
                        for (int i = 0; i < y; i++) x += (int.Parse(item.op0[i].ToString()) | int.Parse(item.op1[i].ToString())).ToString();
                        x = Invert(x);
                        break;
                    case "NXOR":
                        for (int i = 0; i < y; i++) x += (int.Parse(item.op0[i].ToString()) ^ int.Parse(item.op1[i].ToString())).ToString();
                        x = Invert(x);
                        break;
                    default:
                        break;
                }
                Console.WriteLine($"{item.name} {x.Replace("0", "_").Replace("1", "-")}");
            }
        }

        private static string Invert(string x)
        {
            x = x.Replace("1", "2");
            x = x.Replace("0", "1");
            x = x.Replace("2", "0");
            return x;
        }

        public class Operation
        {
            public string name, op, op0, op1, result;

            public Operation(string name, string op, string op0, string op1, string result)
            {
                this.name = name;
                this.op = op;
                this.op0 = op0;
                this.op1 = op1;
                this.result = result;
            }
        }
    }
}
