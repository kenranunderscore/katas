namespace Tests
{
    using Logic;
    using NUnit.Framework;
    using Tests.Inputs;

    [TestFixture]
    public class Day10_Test
    {
        [Test]
        public void Sample_Bot_2_Values_Are_Found_Correctly()
        {
            var day10 = new Day10(Utils.ReadLines("day10_data.txt"));
            Assert.That(day10.FindBotHandlingNumbers(17, 61), Is.EqualTo(113));
        }
    }
}