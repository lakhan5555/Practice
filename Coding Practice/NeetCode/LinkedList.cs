using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0,ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class LinkedList
    {
        #region Question1 - Reverse Linked List
        //link - https://leetcode.com/problems/reverse-linked-list/
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null, temp = head, next = null;
            while(temp != null)
            {
                next = temp.next;
                temp.next = prev;
                prev = temp;
                temp = next;
            }
            return prev;
        }
        #endregion

        #region Question2 - Merge Two Sorted Lists
        //link - https://leetcode.com/problems/merge-two-sorted-lists/

        #region Approach1
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null)
                return list2;
            if (list2 == null)
                return list1;
            if(list1.val <= list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }
        }
        #endregion

        #region Approach2
        public ListNode MergeTwoLists1(ListNode list1, ListNode list2)
        {
            ListNode temp = new ListNode(-1);
            ListNode temp1 = temp;
            while(list1 != null && list2 != null)
            {
                if(list1.val <= list2.val)
                {
                    temp1.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    temp1.next = list2;
                    list2 = list2.next;
                }
                temp1 = temp1.next;
            }
            if (list1 != null)
                temp1.next = list1;
            if (list2 != null)
                temp1.next = list2;
            return temp.next;
        }
        #endregion
        #endregion

        #region Question3 - Reorder List
        //link - https://leetcode.com/problems/reorder-list/
        public void ReorderList(ListNode head)
        {
            if(head != null && head.next != null && head.next.next != null)
            {
                ListNode temp = head;
                ListNode temp1 = null;
                while (temp.next != null)
                {
                    temp1 = temp;
                    temp = temp.next;
                }
                ListNode temp2 = head.next;
                head.next = temp;
                head.next.next = temp2;
                temp1.next = null;
                ReorderList(temp2);
            }
        }
        #endregion

        #region Question4 - Remove Nth Node From End of List
        //link - https://leetcode.com/problems/remove-nth-node-from-end-of-list/
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int len = 0;
            ListNode temp = head, prev = null;
            while(temp != null)
            {
                len++;
                temp = temp.next;
            }
            if (len == n)
                return head.next;
            temp = head;
            for(int i = 0; i < (len - n); i++)
            {
                prev = temp;
                temp = temp.next;
            }
            prev.next = temp.next;
            temp = null;
            return head;
        }
        #endregion

        #region Question5 - Find the Duplicate Number
        //lnik - https://leetcode.com/problems/find-the-duplicate-number/
        public int FindDuplicate(int[] nums)
        {
            int len = nums.Length;
            int ans = 0;
            for(int i = 0;i < len;)
            {
                int n = nums[i];
                if (n == (i + 1))
                    i++;
                else if (n == nums[n - 1])
                {
                    ans = n;
                    break;
                }
                else
                {
                    int a = n;
                    nums[i] = nums[n - 1];
                    nums[n - 1] = a;
                }
            }
            return ans;
        }
        #endregion
    }
}
