using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitair_Game
{
    public class Queue
    {
        public Node head;
        public Queue()
        {
            head = null;
        }
        public void Enqueue(Card newcard)
        {
            Node newNode = new Node();
            newNode.CurrentCard = newcard;
            newNode.Next = null;
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current != null && current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }
        public Card Dequeue()
        {
            if (IsEmpty())
            {
                return null;
            }
            Node next = head.Next;
            Card CardToDelete = head.CurrentCard;
            head = next;
            return CardToDelete;
        }
        public Card Front()
        {
            if (IsEmpty())
            {
                return null;
            }
            return head.CurrentCard;
        }
        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }
            return false;
        }
        public int GetTotalNumberOfCards()
        {
            int count = 0;
            Node current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}
