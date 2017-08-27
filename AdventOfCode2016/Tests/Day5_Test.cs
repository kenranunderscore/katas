namespace Tests
{
    using Logic;
    using NUnit.Framework;

    [TestFixture]
    public class Day5_Test
    {
        [Test]
        public void Day5_Part1()
        {
            Day5 day5 = new Day5("uqwqemis");
            Assert.That(day5.DecodePassword(), Is.EqualTo("1a3099aa"));
        }
    }
}