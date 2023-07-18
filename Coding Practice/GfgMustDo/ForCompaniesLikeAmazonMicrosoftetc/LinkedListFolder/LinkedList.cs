using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.GfgMustDo.ForCompaniesLikeAmazonMicrosoftetc.LinkedListFolder
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int a)
        {
            data = a;
            next = null;
        }

    }
    public class LinkedList
    {
        

        #region Question 1 - Finding middle element in a linked list
        // link - https://practice.geeksforgeeks.org/problems/finding-middle-element-in-a-linked-list/1
        public int getMiddle(Node head)
        {
            Node slow = head;
            Node fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow.data;
        }
        #endregion

        #region Question 2  - Reverse a linked list
        // link - https://practice.geeksforgeeks.org/problems/reverse-a-linked-list/1
        public Node reverseList(Node head)
        {
            Node prev = null, curr = null, next = head;
            while(next != null)
            {
                curr = next;
                next = next.next;
                curr.next = prev;
                prev = curr;
            }
            return prev;
        }
        #endregion

        #region Question 3 - Rotate a Linked List
        // link - https://practice.geeksforgeeks.org/problems/rotate-a-linked-list/1
        // sln link - https://www.geeksforgeeks.org/rotate-a-linked-list/
        #region Approach 1 - Time - O(n), Space - O(1)
        public Node rotate(Node head, int k)
        {
            Node kth = null, kthplus1, temp = head;
            for (int i = 1; i <= k; i++)
            {
                kth = temp;
                temp = temp.next;
            }
            kthplus1 = temp;
            if (temp == null)
                return head;
            while (temp.next != null)
                temp = temp.next;
            temp.next = head;
            kth.next = null;
            return kthplus1;
        }
        #endregion

        #region Approach 2 - Time - O(n), SPcae - O(1)
        public Node rotate1(Node head, int k)
        {
            Node temp = head, last = head;
            if (k == 1)
                return head;
            while (last.next != null)
                last = last.next;
            while(k > 0)
            {
                head = head.next;
                last.next = temp;
                temp.next = null;
                last = temp;
                temp = head;
                k--;
            }
            return head;
        }
        #endregion
        #endregion

        #region Question 4 - Reverse a Linked List in groups of given size
        // link - https://practice.geeksforgeeks.org/problems/reverse-a-linked-list-in-groups-of-given-size/1
        public Node reverse(Node head, int k)
        {
            int j = 0;
            Node ans = null, temp = head;
            while(temp != null)
            {
                Node prev = null, curr = null, next = temp;
                for(int i = 1; i <= k && next != null; i++)
                {
                    curr = next;
                    next = next.next;
                    curr.next = prev;
                    prev = curr;
                }
                temp = next;
                if (j == 0)
                    ans = prev;
                else
                {
                    head.next = prev;
                    head = temp;
                }
                j++;
            }
            return ans;
        }
        #endregion

        #region Question 5 - Intersection Point in Y Shaped Linked Lists
        // link - https://practice.geeksforgeeks.org/problems/intersection-point-in-y-shapped-linked-lists/1
        public int intersectPoint(Node head1, Node head2)
        {
            Node temp1 = head1, temp2 = head2;
            bool oneLoop1 = false, oneLoop2 = false;
            while(temp1 != temp2)
            {
                temp1 = temp1.next;
                temp2 = temp2.next;
                if(temp1 == null)
                {
                    if (oneLoop1)
                        return -1;
                    temp1 = head2;
                    oneLoop1= true;
                }
                if (temp2 == null)
                {
                    if(oneLoop2)
                        return -1;
                    temp2 = head1;
                    oneLoop2 = true;
                }
            }
            return temp1.data;
        }
        #endregion

        #region Question 6 - Detect Loop in linked list
        // link - https://practice.geeksforgeeks.org/problems/detect-loop-in-linked-list/1
        public bool detectLoop(Node head)
        {
            Node slow = head, fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    return true;
            }
            return false;
        }
        #endregion

        #region Question 7 - Remove loop in Linked List
        public void removeLoop(Node head)
        {
            Node slow = head, fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    removeLoopUtil(slow, head);
                    return;
                }
            }
        }
        public void removeLoopUtil(Node node, Node head)
        {
            Node ptr1 = node, ptr2 = node;
            int k = 1;
            while(ptr1.next != ptr2)
            {
                ptr1 = ptr1.next;
                k++;
            }
            ptr1 = head;
            ptr2= head;
            for(int i = 0; i < k;i++)
                ptr2 = ptr2.next;
            while(ptr1 != ptr2)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }
            while (ptr2.next != ptr1)
            {
                ptr2 = ptr2.next;
            }
            ptr2.next = null;
        }
        #endregion

        #region Question 8 - Nth node from end of linked list
        #region Approach 1 - by counting total nodes
        public int getNthFromLast(Node head, int k)
        {
            int count = 0;
            Node temp = head;
            while(temp != null)
            {
                temp = temp.next;
                count++;
            }
            if (k > count)
                return -1;
            temp = head;
            for(int i = 1;i < count - k + 1; i++)
            {
                temp = temp.next;
            }
            if(temp == null)
                return-1;
            return temp.data;
        }
        #endregion

        #region Approach 2 - in One traversal using two pointers
        public int getNthFromLast1(Node head, int k)
        {
            Node ptr1 = head, ptr2 = head;
            if (k == 0)
                return -1;
            for(int i = 1; i < k; i++)
            {
                ptr2 = ptr2.next;
                if(ptr2 == null) return-1;
            }
            while(ptr2.next != null)
            {
                ptr2 = ptr2.next;
                ptr1= ptr1.next;
            }
            return ptr1.data;
        }
        #endregion
        #endregion
    }
}
