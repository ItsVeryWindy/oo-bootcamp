using System;
namespace GolfTests
{
    struct Group
    {
        private const int MaxMembers = 4;

        private readonly int _members;

        public Group(int members)
        {
            if(members <= 0)
                throw new ArgumentException("Group must have members", "members");

            _members = members;
        }

        public int Members
        {
            get { return _members; }
        }

//        public bool HasMembers
//        {
//            get { return _members > 0; }
//        }

        private bool IsTooLarge
        {
            get { return _members > MaxMembers; }
        }

        public bool IsFull
        {
            get { return _members == MaxMembers; }
        }

        public bool CanBeMergedWith(Group group)
        {
            return _members + group._members <= MaxMembers;
        }

        public Group[] Split(Group? previous)
        {
            if (IsTooLarge)
            {
                var remainingMembers = _members;
                var numOfGroups = 0;
                var startIndex = 0;

                if (previous.HasValue)
                {
                    remainingMembers -= MaxMembers - previous.Value._members;
                    numOfGroups++;
                }

                numOfGroups += (int)Math.Ceiling(remainingMembers / 4d);

                var groups = new Group[numOfGroups];

                if (previous.HasValue)
                {
                    groups[0] = new Group(MaxMembers - previous.Value._members);
                    startIndex++;
                }

                for (int i = startIndex; i < groups.Length; i++)
                {
                    var membersInGroup = Math.Min(remainingMembers, MaxMembers);

                    groups[i] = new Group(membersInGroup);

                    remainingMembers -= membersInGroup;
                }

                return groups;
            }

            return new[] { this };
        }

        public Group Merge(Group group)
        {
            if (!CanBeMergedWith(group))
                throw new InvalidOperationException("Combined group would be too large");

            return new Group(_members + group._members);
        }
    }
}
