namespace Rftim3LeetCode.Temp
{
    public class _02402_MeetingRoomsIII
    {
        /// <summary>
        /// You are given an integer n. 
        /// There are n rooms numbered from 0 to n - 1.
        /// 
        /// You are given a 2D integer array meetings where meetings[i] = [starti, endi] means that
        /// a meeting will be held during the half-closed time interval[starti, endi). 
        /// All the values of starti are unique.
        /// 
        /// Meetings are allocated to rooms in the following manner:
        /// 
        /// Each meeting will take place in the unused room with the lowest number.
        /// If there are no available rooms, the meeting will be delayed until a room becomes free.
        /// The delayed meeting should have the same duration as the original meeting.
        /// When a room becomes unused, meetings that have an earlier original start time 
        /// should be given the room.
        /// Return the number of the room that held the most meetings.
        /// If there are multiple rooms, return the room with the lowest number.
        /// 
        /// A half - closed interval[a, b) is the interval between a and b including a 
        /// and not including b.
        /// </summary>
        public _02402_MeetingRoomsIII()
        {
            Console.WriteLine(MeetingRoomsIII1(2, [[0, 10], [1, 5], [2, 7], [3, 4]]));
            Console.WriteLine(MeetingRoomsIII1(3, [[1, 20], [2, 10], [3, 5], [4, 9], [6, 8]]));
        }

        public static int MeetingRoomsIII0(int a0, int[][] a1) => RftMeetingRoomsIII0(a0, a1);

        // Sorting and Counting
        public static int MeetingRoomsIII1(int a0, int[][] a1) => RftMeetingRoomsIII1(a0, a1);

        private static int RftMeetingRoomsIII0(int n, int[][] meetings)
        {
            long[] roomAvailabilityTime = new long[n];
            int[] meetingCount = new int[n];
            Array.Sort(meetings, (a, b) => { return a[0] - b[0]; });

            foreach (int[] meeting in meetings)
            {
                int start = meeting[0], end = meeting[1];
                long minRoomAvailabilityTime = long.MaxValue;
                int minAvailableTimeRoom = 0;
                bool foundUnusedRoom = false;

                for (int i = 0; i < n; i++)
                {
                    if (roomAvailabilityTime[i] <= start)
                    {
                        foundUnusedRoom = true;
                        meetingCount[i]++;
                        roomAvailabilityTime[i] = end;
                        break;
                    }

                    if (minRoomAvailabilityTime > roomAvailabilityTime[i])
                    {
                        minRoomAvailabilityTime = roomAvailabilityTime[i];
                        minAvailableTimeRoom = i;
                    }
                }

                if (!foundUnusedRoom)
                {
                    roomAvailabilityTime[minAvailableTimeRoom] += end - start;
                    meetingCount[minAvailableTimeRoom]++;
                }
            }

            int maxMeetingCount = 0, maxMeetingCountRoom = 0;
            for (int i = 0; i < n; i++)
            {
                if (meetingCount[i] > maxMeetingCount)
                {
                    maxMeetingCount = meetingCount[i];
                    maxMeetingCountRoom = i;
                }
            }

            return maxMeetingCountRoom;
        }

        // Sorting and Counting, Priority Queues
        private static int RftMeetingRoomsIII1(int n, int[][] meetings)
        {
            int[] meetingCount = new int[n];
            PriorityQueue<long[], long[]> usedRooms = new(Comparer<long[]>.Create((a, b) =>
            {
                return (int)(a[0] - b[0]);
            }
            ));
            PriorityQueue<int, int> unusedRooms = new();

            for (int i = 0; i < n; i++)
            {
                unusedRooms.Enqueue(i, i);
            }

            Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

            foreach (int[] meeting in meetings)
            {
                int start = meeting[0], end = meeting[1];

                while (usedRooms.Count != 0 && usedRooms.Peek()[0] <= start)
                {
                    int room = (int)usedRooms.Dequeue()[1];
                    unusedRooms.Enqueue(room, room);
                }

                if (unusedRooms.Count != 0)
                {
                    int room = unusedRooms.Dequeue();
                    usedRooms.Enqueue([end, room], [end, room]);
                    meetingCount[room]++;
                }
                else
                {
                    long roomAvailabilityTime = usedRooms.Peek()[0];
                    int room = (int)usedRooms.Dequeue()[1];
                    usedRooms.Enqueue([roomAvailabilityTime + end - start, room], [roomAvailabilityTime + end - start, room]);
                    meetingCount[room]++;
                }
            }

            int maxMeetingCount = 0, maxMeetingCountRoom = 0;
            for (int i = 0; i < n; i++)
            {
                if (meetingCount[i] > maxMeetingCount)
                {
                    maxMeetingCount = meetingCount[i];
                    maxMeetingCountRoom = i;
                }
            }

            return maxMeetingCountRoom;
        }
    }
}
