namespace Tests
{
    using Logic;
    using NUnit.Framework;
    using Tests.Inputs;

    [TestFixture]
    public class Day4_Test
    {
        [Test]
        public void Day4_Part1()
        {
            Day4 day4 = new Day4(Utils.ReadLines("day4_data.txt"));
            Assert.That(day4.SumOfSectorIdsOfRealRooms, Is.EqualTo(137896));
        }

        [Test]
        public void Day4_Part2()
        {
            Day4 day4 = new Day4(Utils.ReadLines("day4_data.txt"));
            Assert.That(day4.NorthPoleStorageSectorId, Is.EqualTo(501));
        }

        [Test]
        public void Detects_Real_Rooms()
        {
            Assert.That(Day4.IsRoomReal("aaaaa-bbb-z-y-x-123[abxyz]"), Is.True);
            Assert.That(Day4.IsRoomReal("a-b-c-d-e-f-g-h-987[abcde]"), Is.True);
            Assert.That(Day4.IsRoomReal("not-a-real-room-404[oarel]"), Is.True);
        }

        [Test]
        public void Rotate_Works_In_Simple_Case()
        {
            Assert.That(Day4.Rotate('a', 10), Is.EqualTo('k'));
        }

        [Test]
        public void Rotate_Works_With_Overflow()
        {
            Assert.That(Day4.Rotate('x', 5), Is.EqualTo('c'));
        }
    }
}