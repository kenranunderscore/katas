namespace Tests
{
    using Logic;
    using NUnit.Framework;
    using Tests.Inputs;

    [TestFixture]
    public class Day7_Test
    {
        [Test]
        public void Day7_Part1()
        {
            var day7 = new Day7(Utils.ReadLines("day7_data.txt"));
            Assert.That(day7.NumberOfIPsThatSupportTLS, Is.EqualTo(0));
        }

        [Test]
        public void Sample_String_That_Support_TLS_Is_Judged_Correctly()
        {
            Assert.That(Day7.SupportsTLS("abba[mnop]qrst"));
        }
    }
}