namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Day8 : DayWithInput<IEnumerable<string>>
    {
        private static readonly Regex rectMatcher = new Regex(@"rect (\d+)x(\d+)");
        private static readonly Regex rotateColumnMatcher = new Regex(@"rotate column x=(\d+) by (\d+)");
        private static readonly Regex rotateRowMatcher = new Regex(@"rotate row y=(\d+) by (\d+)");

        public Day8(IEnumerable<string> input) : base(input) { }

        public int NumberOfLitPixels
        {
            get
            {
                var screen = new Screen();
                foreach (string s in input)
                {
                    var match = rectMatcher.Match(s);
                    if (match.Success)
                    {
                        screen.Rect(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
                        continue;
                    }

                    match = rotateColumnMatcher.Match(s);
                    if (match.Success)
                    {
                        screen.RotateColumn(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
                        continue;
                    }

                    match = rotateRowMatcher.Match(s);
                    if (match.Success)
                    {
                        screen.RotateRow(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
                    }
                }

                return screen.NumberOfLitPixels;
            }
        }

        internal class Screen
        {
            private byte[,] screen;

            public int NumberOfLitPixels => screen.Cast<byte>().Count(b => b == 1);

            public int Width { get; }

            public int Height { get; }

            public Screen() : this(50, 6) { }

            internal Screen(int width, int height)
            {
                Width = width;
                Height = height;
                screen = new byte[width, height];
            }

            public void Rect(int x, int y)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        screen[i, j] = 1;
                    }
                }
            }

            public void RotateColumn(int index, int shift)
            {
                var col = new byte[Height];
                for (int j = 0; j < Height; j++)
                {
                    col[j] = screen[index, j];
                }
                var result = Rotate(col, shift);
                for (int j = 0; j < Height; j++)
                {
                    screen[index, j] = result[j];
                }
            }

            public void RotateRow(int index, int shift)
            {
                var row = new byte[Width];
                for (int i = 0; i < Width; i++)
                {
                    row[i] = screen[i, index];
                }
                var result = Rotate(row, shift);
                for (int i = 0; i < Width; i++)
                {
                    screen[i, index] = result[i];
                }
            }

            private static T[] Rotate<T>(T[] source, int shift)
            {
                int l = source.Length;
                T[] target = new T[source.Length];
                Array.Copy(source, 0, target, shift, l - shift);
                Array.Copy(source, l - shift, target, 0, shift);
                return target;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder(Width * Height + 6);
                for (int j = 0; j < Height; j++)
                {
                    for (int i = 0; i < Width; i++)
                    {
                        sb.Append(screen[i, j] == 1 ? "#" : ".");
                    }
                    sb.Append("\n");
                }

                return sb.ToString();
            }
        }
    }
}