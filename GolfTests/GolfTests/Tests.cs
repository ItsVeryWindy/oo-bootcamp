using System.Collections.Generic;
using NUnit.Framework;

namespace GolfTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ShouldAddGroupsToTheGroupListAndPutThemOutInTheOrderTheyCameIn()
        {
            var gateKeeper = new GateKeeper();

            gateKeeper.RegisterGroup(4);
            gateKeeper.RegisterGroup(4);
            gateKeeper.RegisterGroup(1);

            Queue<Group> groups = gateKeeper.CreateGroupQueue();

            Assert.That(groups.Dequeue().Members, Is.EqualTo(4));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(4));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(1));
        }

        [Test]
        public void ShouldJoinGroupsTogetherThatAreNextToEachOtherAndHaveLessThan4Members()
        {
            var gateKeeper = new GateKeeper();

            gateKeeper.RegisterGroup(2);
            gateKeeper.RegisterGroup(2);
            gateKeeper.RegisterGroup(4);

            Queue<Group> groups = gateKeeper.CreateGroupQueue();

            Assert.That(groups.Count, Is.EqualTo(2));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(4));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(4));
        }

        [Test]
        public void ShouldSplitUpGroupsThatAreTooLargeWhenTheLargeGroupIsFirst()
        {
            var gateKeeper = new GateKeeper();

            gateKeeper.RegisterGroup(10);
            gateKeeper.RegisterGroup(2);

            Queue<Group> groups = gateKeeper.CreateGroupQueue();

            Assert.That(groups.Count, Is.EqualTo(3));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(4));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(4));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(4));
        }

        [Test]
        public void ShouldSplitUpGroupsThatAreTooLargeWhenTheLargeGroupIsLast()
        {
            var gateKeeper = new GateKeeper();

            gateKeeper.RegisterGroup(10);
            gateKeeper.RegisterGroup(10);

            Queue<Group> groups = gateKeeper.CreateGroupQueue();

            Assert.That(groups.Count, Is.EqualTo(5));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(4));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(4));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(4));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(4));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(4));
        }

        [Test]
        public void ShouldGroupGroupsWhenTheyContainLessThanTheMaxNumberOfMembers()
        {
            var gateKeeper = new GateKeeper();

            gateKeeper.RegisterGroup(1);
            gateKeeper.RegisterGroup(4);
            gateKeeper.RegisterGroup(2);

            Queue<Group> groups = gateKeeper.CreateGroupQueue();

            Assert.That(groups.Count, Is.EqualTo(2));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(3));
            Assert.That(groups.Dequeue().Members, Is.EqualTo(4));
        }

        [Test]
        public void returns_the_number_of_groups_of_less_than_4()
        {
            var gateKeeper = new GateKeeper();
            gateKeeper.RegisterGroup(4);
            gateKeeper.RegisterGroup(4);
            gateKeeper.RegisterGroup(3);
            
            var x = gateKeeper.GroupsLessThanMaximum();

            Assert.That(x.Equals(1));
        }
    }
}
