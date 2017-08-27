namespace Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Day6 : DayWithInput<IEnumerable<string>>
    {
        public Day6(IEnumerable<string> input)
            : base(input)
        {
        }

        public string DecipherMessage()
        {
            int columnCount = input.First().Length;
            StringBuilder sb = new StringBuilder(columnCount);
            for (int i = 0; i < columnCount; i++)
            {
                var column = input.Select(s => s[i]);
                var mostFrequentCharacter = column
                    .GroupBy(c => c, (c, g) => (c, g.Count()))
                    .OrderByDescending(c => c.Item2)
                    .First()
                    .c;
                sb.Append(mostFrequentCharacter);
            }

            return sb.ToString();
        }
    }
}