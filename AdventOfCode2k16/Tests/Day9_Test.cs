﻿namespace Tests
{
    using Logic;
    using NUnit.Framework;
    using System.Linq;
    using Tests.Inputs;

    [TestFixture]
    public class Day9_Test
    {
        [Test]
        public void Day9_Part1()
        {
            string decompressed = Day9.Decompress(Utils.ReadLines("day9_data.txt").First());
            Assert.That(decompressed.Length, Is.EqualTo(110346));
        }

        [Test]
        public void Day9_Part2()
        {
            long length = Day9.FullyDecompressedLength(Utils.ReadLines("day9_data.txt").First());
            Assert.That(length, Is.EqualTo(10774309173));
        }

        [Test]
        public void Decompress_Yields_Correct_Result_For_Sample_Without_Marker()
        {
            Assert.That(Day9.Decompress("ADVENT"), Is.EqualTo("ADVENT"));
        }

        [Test]
        public void Decompress_Yields_Correct_Result_For_Complex_Sample()
        {
            Assert.That(Day9.Decompress("X(8x2)(3x3)ABCY"), Is.EqualTo("X(3x3)ABC(3x3)ABCY"));
        }

        [Test]
        public void Decompress_Yields_Correct_Result_For_Complex_Sample_Part2()
        {
            Assert.That(Day9.FullyDecompressedLength("X(8x2)(3x3)ABCY"), Is.EqualTo(20));
        }

        [Test]
        public void Fully_Decompressed_Complex_Sample_Input_Has_Correct_Length()
        {
            Assert.That(Day9.FullyDecompressedLength("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN"), Is.EqualTo(445));
        }
    }
}