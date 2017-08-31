namespace Tests
{
    using Logic;
    using NUnit.Framework;
    using Tests.Inputs;

    [TestFixture]
    public class Day3_Test
    {
        [Test]
        public void Day3_Part1()
        {
            Day3 day3 = new Day3(Utils.ReadLines("day3_data.txt"));
            Assert.That(day3.NoOfValidTriangles, Is.EqualTo(869));
        }

        [Test]
        public void Day3_Part2()
        {
            Day3 day3 = new Day3(Utils.ReadLines("day3_data.txt"));
            Assert.That(day3.NoOfValidTrianglesInColumns, Is.EqualTo(1544));
        }
    }
}