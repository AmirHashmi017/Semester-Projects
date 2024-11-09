using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitair_Game
{
    //Queue Class implementing queue using Linked List.
    public class Queue
    {
        public Node Front;
        public Node Rear;
        public Queue()
        {
            Front = null;
            Rear= null;
        }

        //Function for making Deep Copy of Queue.
        public Queue DeepCopy()
        {
            Queue copy = new Queue();
            if (Front == null) {
                return copy;
            }
            Queue tempQueue = new Queue();
            Node current = Front;
            while(current!=null)
            {
                Card copycard = new Card(current.CurrentCard);
                tempQueue.Enqueue(copycard);
                current = current.Next;
            }
            current = tempQueue.Front;
            while(current!=null)
            {
                copy.Enqueue(current.CurrentCard);
                current = current.Next;
            }
            return copy;
        }

        //Function for adding card into queue.
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

        //Function for removing card from queue.
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

        //Function for returning front of queue.
        public Card Peek()
        {
            if (IsEmpty())
            {
                return null;
            }
            return Front.CurrentCard;
        }

        //Function for checking queue is empty or not.
        public bool IsEmpty()
        {
            if (Front == null)
            {
                return true;
            }
            return false;
        }

        //Function for counting number of cards in queue.
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
