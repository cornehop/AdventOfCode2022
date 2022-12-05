using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day05
{
    public static class Program
    {
        public enum CraneType
        {
            CrateMover9000,
            CrateMover9001
        };

        private static Dictionary<int, Stack<char>> _stacks;

        public static void Initialize(IStacks stacks)
        {
            _stacks = stacks.GetStacks();
        }

        public static Task Main()
        {
            var stacks = new Stacks();
            Initialize(stacks);

            var actions = File.ReadLines(@"Day05/input.txt");
            
            RearrangeCrates(actions.Skip(10).ToArray(), CraneType.CrateMover9000);
            var result = GetTopCrates();
            Console.WriteLine($"The result of the 9000 is: {result}");

            // Reset our stacks!
            stacks = new Stacks();
            Initialize(stacks);

            RearrangeCrates(actions.Skip(10).ToArray(), CraneType.CrateMover9001);
            var secondResult = GetTopCrates();
            Console.WriteLine($"The result of the 9001 is: {secondResult}");

            return Task.CompletedTask;
        }

        public static string GetTopCrates()
        {
            var result = string.Empty;

            foreach (var stack in _stacks)
            {
                if (stack.Value.Count > 0)
                {
                    result += stack.Value.Pop();
                }
            }

            return result;
        }

        public static void RearrangeCrates(string[] lines, CraneType craneType)
        {
            foreach (var line in lines)
            {
                switch (craneType)
                {
                    case CraneType.CrateMover9000:
                        MoveItemsOneByOne(line);
                        break;
                    case CraneType.CrateMover9001:
                        MoveMultipleItems(line);
                        break;
                    default:
                        throw new ArgumentException($"Crane type {craneType} doesn't exit!");
                }
            }
        }

        public static void MoveItemsOneByOne(string line)
        {
            var move = GetMoveFromLine(line);

            for (var i = 0; i < move.Amount; i++)
            {
                var item = _stacks[move.From].Pop();
                _stacks[move.To].Push(item);
            }
        }

        public static void MoveMultipleItems(string line)
        {
            var move = GetMoveFromLine(line);
            var temporaryStack = new Stack<char>();

            for (var i = 0; i < move.Amount; i++)
            {
                temporaryStack.Push(_stacks[move.From].Pop());
            }

            while (temporaryStack.TryPeek(out _))
            {
                _stacks[move.To].Push(temporaryStack.Pop());
            }
        }

        public static Move GetMoveFromLine(string line)
        {
            var items = line.Split(' ');
            return new Move
            {
                Amount = int.Parse(items[1]),
                From = int.Parse(items[3]),
                To = int.Parse(items[5]),
            };
        }
    }
}
