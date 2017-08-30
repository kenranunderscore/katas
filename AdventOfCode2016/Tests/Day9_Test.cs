namespace Tests
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
        public void Decompress_Yields_Correct_Result_For_Sample_Without_Marker()
        {
            Assert.That(Day9.Decompress("ADVENT"), Is.EqualTo("ADVENT"));
        }

        [Test]
        public void Decompress_Yields_Correct_Result_For_Complex_Sample()
        {
            Assert.That(Day9.Decompress("X(8x2)(3x3)ABCY"), Is.EqualTo("X(3x3)ABC(3x3)ABCY"));
        }
    }
}