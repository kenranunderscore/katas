namespace Logic
{
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class Day9
    {
        public static string Decompress(string input)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i < input.Length)
            {
                string marker;
                if (input[i] == '(')
                {
                    int closing = input.IndexOf(')', i);
                    int difference = closing - i - 1;
                    marker = input.Substring(i + 1, closing - i - 1);
                    var markerNumbers = marker.Split('x').Select(int.Parse).ToArray();
                    string target = input.Substring(closing + 1, markerNumbers[0]);
                    sb.Append(Repeat(target, markerNumbers[1]));
                    i = closing + 1 + markerNumbers[0];
                }
                else
                {
                    sb.Append(input[i]);
                    i++;
                }
            }

            return sb.ToString();
        }

        public static long FullyDecompressedLength(string input)
        {
            long length = 0;
            int i = 0;
            while (i < input.Length)
            {
                string marker;
                if (input[i] == '(')
                {
                    int closing = input.IndexOf(')', i);
                    int difference = closing - i - 1;
                    marker = input.Substring(i + 1, closing - i - 1);
                    var markerNumbers = marker.Split('x').Select(int.Parse).ToArray();
                    string target = input.Substring(closing + 1, markerNumbers[0]);
                    length += FullyDecompressedLength(target) * markerNumbers[1];
                    i = closing + 1 + markerNumbers[0];
                }
                else
                {
                    length++;
                    i++;
                }
            }

            return length;
        }

        private static string Repeat(string s, int count)
        {
            StringBuilder sb = new StringBuilder(count * s.Length);
            for (int i = 0; i < count; i++)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }
    }
}