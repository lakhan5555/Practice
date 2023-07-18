using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision_2
{
    public class HeapPriorityQueue
    {
        #region Question 1 - Kth Largest Element in a Stream
        // link - https://leetcode.com/problems/kth-largest-element-in-a-stream/description/
        public class KthLargest
        {
            public PriorityQueue<int,int> queue;
            public int k;

            public KthLargest(int k, int[] nums)
            {
                queue = new PriorityQueue<int, int>();
                this.k = k;
                foreach(int i in nums)
                {
                    Add(i);
                }
            }

            public int Add(int val)
            {
                if (queue.Count < k)
                    queue.Enqueue(val,val);
                else if(queue.Peek() < val)
                {
                    queue.Dequeue();
                    queue.Enqueue(val,val);
                }
                return queue.Peek();
            }
        }
        #endregion
    }
}
