namespace Tests
{
    using Logic;
    using NUnit.Framework;
    using Tests.Inputs;

    [TestFixture]
    public class Day10_Test
    {
        [Test]
        public void Day10_Part1()
        {
            var day10 = new Day10(Utils.ReadLines("day10_data.txt"));
            Assert.That(day10.FindBotHandlingNumbers(17, 61), Is.EqualTo(113));
        }

        [Test]
        public void Day10_Part2()
        {
            var day10 = new Day10(Utils.ReadLines("day10_data.txt"));
            day10.FindBotHandlingNumbers(17, 61);
            Assert.That(day10.Part2, Is.EqualTo(12803));
        }
    }
}