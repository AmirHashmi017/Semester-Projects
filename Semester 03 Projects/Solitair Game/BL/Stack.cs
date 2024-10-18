using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitair_Game
{
    
    public class Node
    {
        public Card CurrentCard;
        public Node Next;
    }

    public class Stack
    {
        public Node head;
        public Stack()
        {
            head = null;
        }
        public void Push(Card newcard)
        {
            Node newNode = new Node();
            newNode.CurrentCard = newcard;
            newNode.Next = head;
            head = newNode;

        }
        public Card Pop()
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
        public Card Peek()
        {
            if (IsEmpty())
            {
                return null;
            }
            return head.CurrentCard;
        }
        public bool IsEmpty()
        {
            if(head == null)
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
