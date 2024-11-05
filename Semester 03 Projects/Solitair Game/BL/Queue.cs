using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitair_Game
{
    public class Queue
    {
        public Node Front;
        public Node Rear;
        public Queue()
        {
            Front = null;
            Rear= null;
        }
        public void Enqueue(Card newcard)
        {
            Node newNode = new Node();
            newNode.CurrentCard = newcard;
            newNode.Next = null;
            if (Front == null)
            {
                Front = newNode;
                Rear= newNode;
            }
            else
            {
                Rear.Next = newNode;
                Rear = newNode;
            }
        }
        public Card Dequeue()
        {
            if (IsEmpty())
            {
                return null;
            }
            Node next = Front.Next;
            Card CardToDelete = Front.CurrentCard;
            Front = next;
            if (Front == null)
            {
                Rear = null;
            }
            return CardToDelete;
        }
        public Card Peek()
        {
            if (IsEmpty())
            {
                return null;
            }
            return Front.CurrentCard;
        }
        public bool IsEmpty()
        {
            if (Front == null)
            {
                return true;
            }
            return false;
        }
        public int GetTotalNumberOfCards()
        {
            int count = 0;
            Node current = Front;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}
