using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day05
{
    public interface IStacks
    {
        Dictionary<int, Stack<char>> GetStacks();
    }

    public class Stacks : IStacks
    {
        public Dictionary<int, Stack<char>> GetStacks()
        {
            return Items;
        }

        private Dictionary<int, Stack<char>> Items = new Dictionary<int, Stack<char>>()
        {
            { 1, new Stack<char>(new char[] { 'W', 'M', 'L', 'F' }) },
            { 2, new Stack<char>(new char[] { 'B', 'Z', 'V', 'M', 'F' }) },
            { 3, new Stack<char>(new char[] { 'H', 'V', 'R', 'S', 'L', 'Q' }) },
            { 4, new Stack<char>(new char[] { 'F', 'S', 'V', 'Q', 'P', 'M', 'T', 'J' }) },
            { 5, new Stack<char>(new char[] { 'L', 'S', 'W' }) },
            { 6, new Stack<char>(new char[] { 'F', 'V', 'P', 'M', 'R', 'J', 'W' }) },
            { 7, new Stack<char>(new char[] { 'J', 'Q', 'C', 'P', 'N', 'R', 'F' }) },
            { 8, new Stack<char>(new char[] { 'V', 'H', 'P', 'S', 'Z', 'W', 'R', 'B' }) },
            { 9, new Stack<char>(new char[] { 'B', 'M', 'J', 'C', 'G', 'H', 'Z', 'W' }) }
        };
    }
}
