﻿namespace Tests
{
    using Logic;
    using NUnit.Framework;

    [TestFixture]
    public class Day1_Test
    {
        private const string Input = "L2, L3, L3, L4, R1, R2, L3, R3, R3, L1, L3, R2, R3, L3, R4, R3, R3, L1, L4, R4, L2, R5, R1, L5, R1, R3, L5, R2, L2, R2, R1, L1, L3, L3, R4, R5, R4, L1, L189, L2, R2, L5, R5, R45, L3, R4, R77, L1, R1, R194, R2, L5, L3, L2, L1, R5, L3, L3, L5, L5, L5, R2, L1, L2, L3, R2, R5, R4, L2, R3, R5, L2, L2, R3, L3, L2, L1, L3, R5, R4, R3, R2, L1, R2, L5, R4, L5, L4, R4, L2, R5, L3, L2, R4, L1, L2, R2, R3, L2, L5, R1, R1, R3, R4, R1, R2, R4, R5, L3, L5, L3, L3, R5, R4, R1, L3, R1, L3, R3, R3, R3, L1, R3, R4, L5, L3, L1, L5, L4, R4, R1, L4, R3, R3, R5, R4, R3, R3, L1, L2, R1, L4, L4, L3, L4, L3, L5, R2, R4, L2";

        [Test]
        public void Day1_Part1()
        {
            Day1 day1 = new Day1(Input);
            Assert.That(day1.Distance(), Is.EqualTo(301));
        }

        [Test]
        public void Day1_Part2()
        {
            Day1 day1 = new Day1(Input);
            Assert.That(day1.DistanceToFirstDoublyVisitedLocation(), Is.EqualTo(130));
        }
    }
}