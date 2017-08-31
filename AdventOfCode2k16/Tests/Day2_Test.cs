namespace Tests
{
    using Logic;
    using NUnit.Framework;
    using Tests.Inputs;

    [TestFixture]
    public class Day2_Test
    {
        [Test]
        public void Day2_Part1()
        {
            var input = Utils.ReadLines("day2_data.txt");
            Day2 day2 = new Day2(input);
            Assert.That(day2.DecipherCode(Day2.NumpadMapping), Is.EqualTo("92435"));
        }

        [Test]
        public void Day2_Part2()
        {
            var input = Utils.ReadLines("day2_data.txt");
            Day2 day2 = new Day2(input);
            Assert.That(day2.DecipherCode(Day2.Part2Mapping), Is.EqualTo("C1A88"));
        }
    }
}