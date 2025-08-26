using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3AdventOfCode.Refactor;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Rftim3AdventOfCode
{
    public partial class _16_TicketTranslation : I_16_TicketTranslation
    {
        #region Static
        private readonly List<string>? data;

        public _16_TicketTranslation()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_16_TicketTranslation));
        }

        /// <summary>
        /// As you're walking to yet another connecting flight, you realize that one of the legs of your re-routed trip coming up is on a high-speed train.
        /// However, the train ticket you were given is in a language you don't understand. 
        /// You should probably figure out what it says before you get to the train station after the next flight.
        /// 
        /// Unfortunately, you can't actually read the words on the ticket. 
        /// You can, however, read the numbers, and so you figure out the fields these tickets must have and the valid ranges for values in those fields.
        /// 
        /// You collect the rules for ticket fields, the numbers on your ticket, and the numbers on other nearby tickets for the same train 
        /// service(via the airport security cameras) together into a single document you can reference(your puzzle input).
        /// 
        /// The rules for ticket fields specify a list of fields that exist somewhere on the ticket and the valid ranges of values for each field.
        /// For example, a rule like class: 1-3 or 5-7 means that one of the fields in every ticket is named class and can be any value in the ranges 1-3 or 5-7 (inclusive, such that 3 and 5 are both valid in this field, but 4 is not).
        /// 
        /// Each ticket is represented by a single line of comma-separated values.The values are the numbers on the ticket in the order they appear;
        /// every ticket has the same format.For example, consider this ticket:
        /// 
        /// .--------------------------------------------------------.
        /// | ????: 101    ?????: 102   ??????????: 103     ???: 104 |
        /// |                                                        |
        /// | ??: 301  ??: 302             ???????: 303      ??????? |
        /// | ??: 401  ??: 402           ???? ????: 403    ????????? |
        /// '--------------------------------------------------------'
        /// Here, ? represents text in a language you don't understand. This ticket might be represented as 101,102,103,104,301,302,303,401,402,403;
        /// of course, the actual train tickets you're looking at are much more complicated.
        /// In any case, you've extracted just the numbers in such a way that the first number is always the same specific field,
        /// the second number is always a different specific field, and so on - you just don't know what each position actually means!
        /// 
        /// Start by determining which tickets are completely invalid; these are tickets that contain values which aren't valid for any field.
        /// Ignore your ticket for now.
        /// 
        /// For example, suppose you have the following notes:
        /// 
        /// class: 1-3 or 5-7
        /// row: 6-11 or 33-44
        /// seat: 13-40 or 45-50
        /// 
        /// your ticket:
        /// 7,1,14
        /// 
        /// nearby tickets:
        /// 7,3,47
        /// 40,4,50
        /// 55,2,20
        /// 38,6,12
        /// It doesn't matter which position corresponds to which field; you can identify invalid nearby tickets by considering only whether tickets
        /// contain values that are not valid for any field. In this example, the values on the first nearby ticket are all valid for at least one field.
        /// This is not true of the other three nearby tickets: the values 4, 55, and 12 are are not valid for any field.
        /// Adding together all of the invalid values produces your ticket scanning error rate: 4 + 55 + 12 = 71.
        /// 
        /// Consider the validity of the nearby tickets you scanned.What is your ticket scanning error rate?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            Regex r = MyRegex();
            List<(string fieldName, Func<int, bool> fieldPredicate)> ranges = input[0].Split("\r\n")
                .Select(l =>
                {
                    Match matches = r.Match(l);
                    bool predicate(int input) =>
                        input >= int.Parse(matches.Groups[2].Value) &&
                        input <= int.Parse(matches.Groups[3].Value) ||
                        input >= int.Parse(matches.Groups[4].Value) &&
                        input <= int.Parse(matches.Groups[5].Value);
                    return (fieldName: matches.Groups[1].Value, fieldPredicate: (Func<int, bool>)predicate);
                }).ToList();

            ImmutableList<ImmutableList<int>> neighborTickets = input[2]
                .Split("\r\n")
                .Skip(1)
                .Select(line => line.Split(",").Select(stringValue => int.Parse(stringValue)).ToImmutableList()
            ).ToImmutableList();

            IEnumerable<int> invalidTicketsValues = neighborTickets
                .SelectMany(ticketValues => ticketValues.Where(fieldValue => !ranges.Any(rangePredicate => rangePredicate.fieldPredicate(fieldValue)))
            );

            return invalidTicketsValues.Sum();
        }

        /// <summary>
        /// Now that you've identified which tickets contain invalid values, discard those tickets entirely. 
        /// Use the remaining valid tickets to determine which field is which.
        /// 
        /// Using the valid ranges for each field, determine what order the fields appear on the tickets.
        /// The order is consistent between all tickets: if seat is the third field, it is the third field on every ticket, including your ticket.
        /// 
        /// For example, suppose you have the following notes:
        /// 
        /// class: 0-1 or 4-19
        /// row: 0-5 or 8-19
        /// seat: 0-13 or 16-19
        /// 
        /// your ticket:
        /// 11,12,13
        /// 
        /// nearby tickets:
        /// 3,9,18
        /// 15,1,5
        /// 5,14,9
        /// Based on the nearby tickets in the above example, the first position must be row, the second position must be class, and the third position must be seat;
        /// you can conclude that in your ticket, class is 12, row is 11, and seat is 13.
        /// 
        /// Once you work out which field is which, look for the six fields on your ticket that start with the word departure.
        /// What do you get if you multiply those six values together?
        /// </summary>        
        [Benchmark]
        public ulong PartTwo() => PartTwo0(data!);

        private static ulong PartTwo0(List<string> input)
        {
            Regex r = MyRegex();
            List<(string fieldName, Func<int, bool> fieldPredicate)> ranges = input[0].Split("\r\n")
                .Select(l =>
                {
                    Match matches = r.Match(l);
                    bool predicate(int input) =>
                        input >= int.Parse(matches.Groups[2].Value) &&
                        input <= int.Parse(matches.Groups[3].Value) ||
                        input >= int.Parse(matches.Groups[4].Value) &&
                        input <= int.Parse(matches.Groups[5].Value);
                    return (fieldName: matches.Groups[1].Value, fieldPredicate: (Func<int, bool>)predicate);
                }).ToList();

            ImmutableList<ImmutableList<int>> neighborTickets = input[2]
                .Split("\r\n")
                .Skip(1)
                .Select(line => line.Split(",").Select(stringValue => int.Parse(stringValue)).ToImmutableList()
            ).ToImmutableList();

            IEnumerable<int> invalidTicketsValues = neighborTickets
                .SelectMany(ticketValues => ticketValues.Where(fieldValue => !ranges.Any(rangePredicate => rangePredicate.fieldPredicate(fieldValue)))
            );

            ImmutableList<ImmutableList<int>> validNeighborTickets = neighborTickets
                .Where(ticketValues => ticketValues.All(fieldValue => ranges.Any(r => r.fieldPredicate(fieldValue)))
            ).ToImmutableList();

            ImmutableList<(int position, IEnumerable<int> posValues)> ticketFieldValues = ranges
                .Select((_, position) => (position, posValues: validNeighborTickets.Select(validTicketFields => validTicketFields[position])))
                .ToImmutableList();

            ImmutableList<(int field, ImmutableList<int> positions)> fieldValidPositions =
            [
                .. ranges
                .Select((rangePredicate, field) =>
                    (
                        field,
                        positions:
                            ticketFieldValues
                            .Where(tfv => tfv.posValues.All(fv => rangePredicate.fieldPredicate(fv)))
                            .Select(tfv => tfv.position)
                            .ToImmutableList()
                    )
                )
                .OrderBy(fvc => fvc.positions.Count)
            ];

            int[] fieldToPosMapping = Enumerable.Repeat(-1, ranges.Count).ToArray();
            foreach ((int field, ImmutableList<int> positions) in fieldValidPositions)
            {
                fieldToPosMapping[field] = positions.First(position => !fieldToPosMapping.Contains(position));
            }

            List<int> ticket = input[1].Split("\r\n").Skip(1).SelectMany(ticketLine => ticketLine.Split(",").Select(f => int.Parse(f))).ToList();

            IEnumerable<int> fieldIds = ranges
                .Select((r, ix) => (id: ix, range: r))
                .Where(riv => riv.range.fieldName.StartsWith("departure"))
                .Select(riv => riv.id);

            ulong prod = fieldIds
                .Select(fieldPos => ticket[fieldToPosMapping[fieldPos]])
                .Aggregate((ulong)1, (product, ticketField) => product *= (ulong)ticketField);

            return prod;
        }

        [GeneratedRegex(@"^([\w+,\s]+):\s(\d+)-(\d+)\sor\s(\d+)-(\d+)$")]

        private static partial Regex MyRegex();
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static ulong PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _16_TicketTranslation(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_16_TicketTranslation));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}