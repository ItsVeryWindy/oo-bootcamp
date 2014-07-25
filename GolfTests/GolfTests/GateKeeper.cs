using System;
using System.Collections.Generic;
using System.Linq;

namespace GolfTests
{
    class GateKeeper
    {
        readonly LinkedList<Group> _groups = new LinkedList<Group>();

        public void RegisterGroup(int numOfMembers)
        {
            _groups.AddLast(new Group(numOfMembers));
        }

        private Group DequeueFromGroups(Group? current)
        {
            Group? next = null;

            if (current.HasValue)
            {
                foreach (var group in _groups)
                {
                    if (!group.CanBeMergedWith(current.Value))
                        continue;
                    
                    next = group;
                    
                    break;
                }
            }

            if (!next.HasValue)
            {
                next = _groups.First.Value;
            }

            _groups.Remove(next.Value);

            next = HandleLargeGroups(current, next.Value);

            return next.Value;
        }

        public Queue<Group> CreateGroupQueue()
        {
            var queue = new Queue<Group>();

            if (_groups.Count == 0)
                return queue;

            var current = DequeueFromGroups(null);

            while (_groups.Count > 0)
            {
                var next = DequeueFromGroups(current);

                if (current.CanBeMergedWith(next))
                {
                    current = current.Merge(next);
                }
                else
                {
                    queue.Enqueue(current);

                    current = next;
                }
            }

            queue.Enqueue(current);

            return queue;
        }

        private Group HandleLargeGroups(Group? current, Group next)
        {
            var groups = next.Split(current);

            for (int i = groups.Length - 1; i > 0; i--)
            {
                _groups.AddFirst(groups[i]);
            }

            return groups[0];
        }

        public int GroupsLessThanMaximum()
        {
            var blah = CreateGroupQueue();
           
            return blah.Count(p => p.Members < 4);
        }
    }
}
