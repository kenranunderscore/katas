namespace Tests
{
    using Logic;
    using NUnit.Framework;
    using Tests.Inputs;

    [TestFixture]
    public class Day6_Test
    {
        [Test]
        public void Day6_Part1()
        {
            var day6 = new Day6(Utils.ReadLines("day6_data.txt"));
            Assert.That(day6.DecipherMessage(), Is.EqualTo("ygjzvzib"));
        }

        [Test]
        public void Day6_Part2()
        {
        }
    }
}