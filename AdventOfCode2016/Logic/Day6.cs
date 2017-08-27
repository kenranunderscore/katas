namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Day6 : DayWithInput<IEnumerable<string>>
    {
        public Day6(IEnumerable<string> input) : base(input) { }

        public string DeciperMessagePart1() => DecipherMessage(MostFrequentCharacter);

        public string DeciperMessagePart2() => DecipherMessage(LeastFrequentCharacter);

        private string DecipherMessage(Func<IEnumerable<char>, char> columnCharacterSelector)
        {
            int columnCount = input.First().Length;
            StringBuilder sb = new StringBuilder(columnCount);
            for (int i = 0; i < columnCount; i++)
            {
                var column = input.Select(s => s[i]);
                var mostFrequentCharacter = columnCharacterSelector(column);
                sb.Append(mostFrequentCharacter);
            }

            return sb.ToString();
        }

        private static char MostFrequentCharacter(IEnumerable<char> column) =>
            column
                .GroupBy(c => c, (c, g) => (c, g.Count()))
                .OrderByDescending(c => c.Item2)
                .First()
                .c;

        private static char LeastFrequentCharacter(IEnumerable<char> column) =>
            column
                .GroupBy(c => c, (c, g) => (c, g.Count()))
                .OrderBy(c => c.Item2)
                .First()
                .c;
    }
}