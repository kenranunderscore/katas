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
            Assert.That(day7.NumberOfIPsThatSupportTLS, Is.EqualTo(115));
        }

        [Test]
        public void Day7_Part2()
        {
            var day7 = new Day7(Utils.ReadLines("day7_data.txt"));
            Assert.That(day7.NumberOfIPsThatSupportSSL, Is.EqualTo(231));
        }

        [Test]
        public void Sample_String_That_Supports_TLS_Is_Judged_Correctly()
        {
            Assert.That(Day7.SupportsTLS("abba[mnop]qrst"));
        }

        [Test]
        public void Sample_String_That_Supports_SLS_Is_Judged_Correctly()
        {
            Assert.That(Day7.SupportsSSL("zazbz[bzb]cdb"));
        }

        [Test]
        public void Sample_String_That_Does_Not_Support_SLS_Is_Judged_Correctly()
        {
            Assert.That(Day7.SupportsSSL("xyx[xyx]xyx"), Is.False);
        }
    }
}