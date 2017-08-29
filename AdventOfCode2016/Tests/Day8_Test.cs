﻿namespace Tests
{
    using Logic;
    using NUnit.Framework;
    using Tests.Inputs;

    [TestFixture]
    public class Day8_Test
    {
        [Test]
        public void Day8_Part1()
        {
            var day8 = new Day8(Utils.ReadLines("day8_data.txt"));
            Assert.That(day8.NumberOfLitPixels, Is.EqualTo(106));
        }

        [Test]
        public void Rect_Lights_Correct_Pixels()
        {
            var screen = new Day8.Screen(5, 2);
            screen.Rect(2, 1);
            Assert.That(screen.ToString(), Is.EqualTo("##...\n.....\n"));
        }

        [Test]
        public void Rows_Are_Rotated_Correctly()
        {
            var screen = new Day8.Screen(5, 2);
            screen.Rect(2, 1);
            screen.RotateRow(0, 2);
            Assert.That(screen.ToString(), Is.EqualTo("..##.\n.....\n"));
        }

        [Test]
        public void Columns_Are_Rotated_Correctly()
        {
            var screen = new Day8.Screen(4, 3);
            screen.Rect(2, 1);
            screen.RotateColumn(1, 1);
            Assert.That(screen.ToString(), Is.EqualTo("#...\n.#..\n....\n"));
        }

        [Test]
        public void Sample_Scenario_Is_Handled_Correctly()
        {
            var screen = new Day8.Screen(7, 3);
            screen.Rect(3, 2);
            screen.RotateColumn(1, 1);
            screen.RotateRow(0, 4);
            screen.RotateColumn(1, 1);
            Assert.That(screen.ToString(), Is.EqualTo(".#..#.#\n#.#....\n.#.....\n"));
        }

        [Test]
        public void Lit_Pixels_Are_Counted_Correctly_In_Sample_Scenario()
        {
            var screen = new Day8.Screen(7, 3);
            screen.Rect(3, 2);
            screen.RotateColumn(1, 1);
            screen.RotateRow(0, 4);
            screen.RotateColumn(1, 1);
            Assert.That(screen.NumberOfLitPixels, Is.EqualTo(6));
        }

        [Test]
        public void Lit_Pixels_Are_Counted_Correctly_For_Full_Rect()
        {
            var screen = new Day8.Screen();
            screen.Rect(50, 6);
            Assert.That(screen.NumberOfLitPixels, Is.EqualTo(50 * 6));
        }
    }
}