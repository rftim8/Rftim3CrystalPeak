using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00707_DesignLinkedList
    {
        /// <summary>
        /// Design your implementation of the linked list. You can choose to use a singly or doubly linked list.
        /// A node in a singly linked list should have two attributes: val and next.val is the value of the current node, and next is a pointer/reference to the next node.
        /// If you want to use the doubly linked list, you will need one more attribute prev to indicate the previous node in the linked list.
        /// Assume all nodes in the linked list are 0-indexed.
        /// Implement the MyLinkedList class:
        /// MyLinkedList() Initializes the MyLinkedList object.
        /// int get(int index) Get the value of the indexth node in the linked list.If the index is invalid, return -1.
        /// void addAtHead(int val) Add a node of value val before the first element of the linked list.After the insertion, 
        /// the new node will be the first node of the linked list.
        /// void addAtTail(int val) Append a node of value val as the last element of the linked list.
        /// void addAtIndex(int index, int val) Add a node of value val before the indexth node in the linked list.
        /// If index equals the length of the linked list, the node will be appended to the end of the linked list. 
        /// If index is greater than the length, the node will not be inserted.
        /// void deleteAtIndex(int index) Delete the indexth node in the linked list, if the index is valid.
        /// </summary>
        public _00707_DesignLinkedList()
        {
            MyLinkedList obj = new();
            obj.AddAtHead(1);
            obj.AddAtTail(3);
            obj.AddAtIndex(1, 2);
            int param_1 = obj.Get(1);
            Console.WriteLine(param_1);
            obj.DeleteAtIndex(1);
            int param_2 = obj.Get(1);
            Console.WriteLine(param_2);
        }

        private class MyLinkedList
        {
            private Node? head;
            int count = 0;

            public int Get(int index)
            {
                Node? node = GetNode(index);
                return node is null ? -1 : node.val;
            }

            public Node? GetNode(int index)
            {
                if (index >= count) return null;
                Node? crt = head;
                for (int i = 0; i < index; i++)
                {
                    crt = crt?.next;
                }

                return crt;
            }

            public void AddAtHead(int val)
            {
                Node newNode = new(val)
                {
                    next = head
                };
                head = newNode;
                count++;
            }

            public void AddAtTail(int val)
            {
                if (head is null)
                {
                    AddAtHead(val);
                    return;
                }

                Node? node = GetNode(count - 1);
                node!.next = new Node(val);
                count++;
            }

            public void AddAtIndex(int index, int val)
            {
                if (index > count) return;
                if (index == 0)
                {
                    AddAtHead(val);
                    return;
                }
                Node? node = GetNode(index - 1);
                Node newNode = new(val)
                {
                    next = node?.next
                };
                node!.next = newNode;
                count++;
            }

            public void DeleteAtIndex(int index)
            {
                if (count == 0) return;

                if (index < count && index >= 0)
                {
                    if (index == 0) head = head?.next;
                    else
                    {
                        Node? node = GetNode(index - 1);
                        node!.next = node.next?.next;
                    }

                    count--;
                }
            }
        }

        private class MyLinkedList0
        {
            private Node? head;
            private Node? tail;
            private int length;

            public MyLinkedList0()
            {
                head = null;
                tail = null;
                length = 0;
            }

            public int Get(int index)
            {
                if (index < 0 || index >= length) return -1;
                Node? curr = head;
                for (int i = 0; i < index; i++)
                {
                    curr = curr?.next;
                }

                return curr!.val;
            }

            public void AddAtHead(int val)
            {
                Node? newNode = new(val, head);
                head = newNode;
                tail ??= newNode;
                length++;
            }

            public void AddAtTail(int val)
            {
                Node? newNode = new(val, new Node());
                if (tail is null) head = tail = newNode;
                else
                {
                    tail.next = newNode;
                    tail = newNode;
                }
                length++;
            }

            public void AddAtIndex(int index, int val)
            {
                if (index < 0 || index > length) return;
                if (index == 0)
                {
                    AddAtHead(val);
                    return;
                }
                if (index == length)
                {
                    AddAtTail(val);
                    return;
                }
                Node? prev = null;
                Node? curr = head;
                for (int i = 0; i < index; i++)
                {
                    prev = curr;
                    curr = curr?.next;
                }
                Node? newNode = new(val, curr);
                prev!.next = newNode;
                length++;
            }

            public void DeleteAtIndex(int index)
            {
                if (index < 0 || index >= length) return;
                if (index == 0)
                {
                    head = head?.next;
                    if (head is null) tail = null;
                    length--;
                    return;
                }
                Node? prev = null;
                Node? curr = head;
                for (int i = 0; i < index; i++)
                {
                    prev = curr;
                    curr = curr?.next;
                }
                prev!.next = curr?.next;
                if (prev.next is null) tail = prev;
                length--;
            }
        }
    }
}
