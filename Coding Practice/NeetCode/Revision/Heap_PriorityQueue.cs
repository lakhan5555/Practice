using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class Heap_PriorityQueue
    {
        public void main()
        {
            //int[] nums = { 4, 5, 8, 2 };
            //int k = 3;
            //var a = new KthLargest(k, nums);
            //var b = a.Add(3);
            //b = a.Add(5);
            //b = a.Add(10);
            //b = a.Add(9);
            //b = a.Add(4);

            //int[] stones = { 3,7,8 };
            //int ans = LastStoneWeight(stones);

            //int[][] points = new int[2][];
            //points[0] = new int[2]{ 1,3};
            //points[1] = new int[2] { 2,-2};

            //var ans = KClosest(points, 1);

            //int[] arr = { 3, 2, 1, 5, 6, 4 };
            //var ans = FindKthLargest(arr, 2);

            Twitter twitter = new Twitter();
            twitter.PostTweet(1, 5);
            twitter.PostTweet(1, 3);
            var a = twitter.GetNewsFeed(1);
            //twitter.Follow(1, 2);
            //twitter.PostTweet(2, 6);
            //a = twitter.GetNewsFeed(1);
            //twitter.Unfollow(1, 2);
            //a = twitter.GetNewsFeed(1);
        }

        #region Kth Largest Element in a Stream
        public class KthLargest
        {
            int k;
            int[] pq;
            int size = 0;
            public KthLargest(int k, int[] nums)
            {
                this.k = k;
                pq = new int[this.k];
                foreach (var item in nums)
                    Insert(item);
            }

            public int Add(int val)
            {
                Insert(val);
                return GetMin();
            }
            public void Insert(int item)
            {
                if(size < k)
                {
                    size++;
                    pq[size - 1] = item;
                    ShiftUp(size - 1);
                }
                else
                {
                    int min = GetMin();
                    if(min < item)
                    {
                        pq[0] = item;
                        ShiftDown(0);
                    }
                }
            }
            public void ShiftUp(int i)
            {
                while(i > 0 && pq[i] < pq[Parent(i)])
                {
                    int parent = Parent(i);
                    int temp = pq[i];
                    pq[i] = pq[parent];
                    pq[parent] = temp;

                    i = parent;
                }
            }
            public int Parent(int i)
            {
                return (i - 1) / 2;
            }
            public int LeftChild(int i)
            {
                return 2 * i + 1;
            }
            public int RightChild(int i)
            {
                return 2 * i + 2;
            }
            public int GetMin()
            {
                return pq[0];
            }
            public void ShiftDown(int i)
            {
                int leftChild = LeftChild(i);
                int rightChild = RightChild(i);
                int smallest = i;

                if(leftChild < size && pq[leftChild] < pq[smallest])
                    smallest= leftChild;
                if(rightChild < size && pq[rightChild] < pq[smallest])
                    smallest= rightChild;

                if(i != smallest)
                {
                    int temp = pq[i];
                    pq[i] = pq[smallest];
                    pq[smallest] = temp;
                    ShiftDown(smallest);
                }
            }
        }
        #endregion

        #region Last Stone Weight
        // link - https://leetcode.com/problems/last-stone-weight/
        public int LastStoneWeight(int[] stones)
        {
            int size = 0;
            int[] pq = new int[stones.Length]; 
            foreach(var item in stones)
            {
                size = Insert(item, pq, size);
            }
            LastStoneWeightUtil(pq, ref size);
            if (size == 0)
                return 0;
            else
                return pq[0];
        }
        public int Insert(int item, int[] pq, int size)
        {
            size++;
            pq[size-1] = item;
            ShiftUp(size-1,pq);
            return size;
        }
        public void ShiftUp(int i, int[] pq)
        {
            while(i  > 0 && pq[i] > pq[Parent(i)])
            {
                int parent = Parent(i);
                int temp = pq[i];
                pq[i] = pq[parent];
                pq[parent] = temp;
                i = parent;
            }
        }
        public void ShiftDown(int i, int[] pq, int size)
        {
            int leftChild = LeftChild(i);
            int rightChild = RightChild(i);
            int largest = i;
            if (leftChild < size && pq[leftChild] > pq[largest])
                largest = leftChild;
            if(rightChild < size && pq[rightChild] > pq[largest])
                largest = rightChild;

            if(i != largest)
            {
                int temp = pq[i];
                pq[i] = pq[largest];
                pq[largest] = temp;
                ShiftDown(largest, pq, size);
            }
        }
        public void ExtractMax(int[] pq, int size)
        {
            pq[0] = pq[size - 1];
            ShiftDown(0, pq, size-1);
        }
        public int Parent(int i)
        {
            return (i - 1) / 2;
        }
        public int LeftChild(int i)
        {
            return 2 * i + 1;
        }
        public int RightChild(int i)
        {
            return 2 * i + 2;
        }
        public void LastStoneWeightUtil(int[] pq,ref int size)
        {
            if(size > 1)
            {
                int root = pq[0];
                int largest = 1;
                if(size > 2)
                    if(pq[largest] < pq[2])
                    {
                        largest = 2;
                    }

                int diff = root - pq[largest];
                if(diff > 0)
                {
                    ExtractMax(pq, size);
                    size--;
                    pq[0] = diff;
                    ShiftDown(0, pq, size);
                }
                else
                {
                    ExtractMax(pq, size);
                    size--;
                    ExtractMax(pq, size);
                    size--;
                }
                LastStoneWeightUtil(pq, ref size);
            }
        }
        #endregion

        #region K Closest Points to Origin
        int heapSize = 0;
        public int[][] KClosest(int[][] points, int k)
        {
            int[][] pq = new int[k][];
            foreach (var item in points)
                InsertKClosest(pq, item, k);
            return pq;
        }
        public void InsertKClosest(int[][] pq, int[] item, int k)
        {
            if(heapSize < k)
            {
                heapSize++;
                pq[heapSize-1] = item;
                ShiftUpKClosest(pq, heapSize - 1);
            }
            else
            {
                double distFromOrigin = Math.Sqrt(Math.Pow(item[0], 2) + Math.Pow(item[1], 2));
                double distFromRoot = Math.Sqrt(Math.Pow(pq[0][0], 2) + Math.Pow(pq[0][1], 2));
                
                if (distFromOrigin < distFromRoot)
                {
                    pq[0] = item;
                    ShiftDownKClosest(pq, 0);
                }
            }

        }
        public void ShiftUpKClosest(int[][] pq, int i)
        {
            
            while (i > 0 && distFromOrigin(i,pq) > distFromOrigin(ParentKClosest(i),pq))
            {
                int parent = Parent(i);
                var temp = pq[i];
                pq[i] = pq[parent];
                pq[parent] = temp;

                i = parent;
            }
        }
        public void ShiftDownKClosest(int[][] pq, int i)
        {
            int leftChild = LeftChildKClosest(i);
            int rightChild = RightChildKClosest(i);
            int largest = i;
            if (leftChild < heapSize && distFromOrigin(leftChild,pq) > distFromOrigin(largest,pq))
                largest = leftChild;
            if (rightChild < heapSize && distFromOrigin(rightChild, pq) > distFromOrigin(largest, pq))
                largest = rightChild;
            if(i != largest)
            {
                var temp = pq[i];
                pq[i] = pq[largest];
                pq[largest] = temp;
                ShiftDownKClosest(pq, largest);
            }
        }
        public double distFromOrigin(int i, int[][] pq)
        {
            return Math.Sqrt(Math.Pow(pq[i][0], 2) + Math.Pow(pq[i][1], 2));
        }
        public int ParentKClosest(int i)
        {
            return (i - 1) / 2;
        }
        public int LeftChildKClosest(int i)
        {
            return 2 * i + 1;
        }
        public int RightChildKClosest(int i)
        {
            return 2 * i + 2;
        }
        #endregion

        #region Kth Largest Element in an Array
        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int,int> priorityQueue= new PriorityQueue<int,int>();
            int pqSize = 0;
            foreach(var item in nums)
            {
                pqSize++;
                priorityQueue.Enqueue(item, -1*item);
            }
            for(int i = 0; i< k-1; i++)
            {
                priorityQueue.Dequeue();
            }
            return priorityQueue.Peek();
        }
        #endregion

        #region Design Twitter
        // sln link - https://leetcode.com/problems/design-twitter/solutions/82825/java-oo-design-with-most-efficient-function-getnewsfeed/
        public class Twitter
        {
            private static int timeStamp = 0;
            private Dictionary<int, User> userMap;
            public class Tweet
            {
                public int id;
                public int time;
                public Tweet next;

                public Tweet(int id)
                {
                    this.id = id;
                    this.time = timeStamp++;
                    this.next = null;
                }
            }

            public class User
            {
                public int id;
                public HashSet<int> followed;
                public Tweet tweet_head;
                public User(int id)
                {
                    this.id = id;
                    this.followed = new HashSet<int>();
                    follow(id);
                    this.tweet_head = null;
                }

                public void follow(int id)
                {
                    this.followed.Add(id);
                }
                public void unfollow(int id)
                {
                    this.followed.Remove(id);
                }
                public void post(int id)
                {
                    Tweet t = new Tweet(id);
                    t.next = tweet_head;
                    tweet_head = t;
                }
            }

            public Twitter()
            {
                this.userMap = new Dictionary<int, User>();
            }

            public void PostTweet(int userId, int tweetId)
            {
                User user;
                if (userMap.ContainsKey(userId))
                    user = userMap[userId];
                else
                {
                    user = new User(userId);
                    userMap.Add(userId, user);
                }
                user.post(tweetId);
            }
            public IList<int> GetNewsFeed(int userId)
            {
                IList<int> res = new List<int>();
                User user;
                if (!userMap.ContainsKey(userId))
                    return res;
                user = userMap[userId];
                HashSet<int> followeds = user.followed;

                var reverseComparer = new ReverseComparer<int>(Comparer<int>.Default);
                PriorityQueue<Tweet, int> priorityQueue = new PriorityQueue<Tweet, int>(reverseComparer);
                foreach(var item in followeds)
                {
                    var followee = userMap[item];
                    Tweet t = followee.tweet_head;
                    if (t != null)
                        priorityQueue.Enqueue(followee.tweet_head, followee.tweet_head.time);
                }
                int n = 0;
                while(priorityQueue.Count != 0 && n < 10)
                {
                    Tweet t = priorityQueue.Dequeue();
                    res.Add(t.id);
                    n++;
                    if (t.next != null)
                        priorityQueue.Enqueue(t, t.time);
                }
                return res;
            }
            public void Follow(int followerId, int followeeId)
            {
                User follower;
                if(userMap.ContainsKey(followerId))
                    follower = userMap[followerId];
                else
                {
                    follower = new User(followerId);
                    userMap.Add(followerId, follower);
                }
                User followee;
                if(userMap.ContainsKey(followeeId))
                    followee = userMap[followeeId];
                else
                {
                    followee = new User(followeeId);
                    userMap.Add(followeeId, followee);
                }
                follower.follow(followeeId);
            }

            public void Unfollow(int followerId, int followeeId)
            {
                if (!userMap.ContainsKey(followerId) || !userMap.ContainsKey(followeeId))
                    return;

                User follower = userMap[followerId];
                follower.unfollow(followeeId);
            }

            public class ReverseComparer<T> : IComparer<T>
            {
                private readonly IComparer<T> baseComparer;
                public ReverseComparer(IComparer<T> baseComparer)
                {
                    this.baseComparer = baseComparer;
                }
                public int Compare(T x, T y)
                {
                    return baseComparer.Compare(y, x);
                }
            }

        }
        #endregion

    }
}
