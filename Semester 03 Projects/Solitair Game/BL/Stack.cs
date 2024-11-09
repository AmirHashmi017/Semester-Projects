using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitair_Game
{
    //Node Class Containing a Card and it's next node object.
    public class Node
    {
        public Card CurrentCard;
        public Node Next;
    }

    //Stack Class implementing stack using Linked List.
    public class Stack
    {
        public Node Top;
        public Stack()
        {
            Top = null;
        }


        //Function for adding card into stack.
        public void Push(Card newcard)
        {
            Node newNode = new Node();
            newNode.CurrentCard = newcard;
            newNode.Next = Top;
            Top = newNode;

        }
        //Function for removing card from stack.
        public Card Pop()
        {
            if (IsEmpty())
            {
                return null;
            }
            Node next = Top.Next;
            Card CardToDelete = Top.CurrentCard;
            Top = next;
            return CardToDelete;
        }
        //Function for returning top of stack.
        public Card Peek()
        {
            if (IsEmpty())
            {
                return null;
            }
            return Top.CurrentCard;
        }
        //Function for checking stack is empty or not.
        public bool IsEmpty()
        {
            if(Top == null)
            {
                return true;
            }
            return false;
        }
        //Function for counting number of cards in stack.
        public int GetTotalNumberOfCards()
        {
            int count = 0;
            Node current = Top;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
        //Function for making Deep Copy of Stack.
        public Stack DeepCopy()
        {
            Stack copy = new Stack();
            if (Top == null) 
             return copy;

            Node current = Top;
            Stack tempStack = new Stack();

            while (current != null)
            {
                if (current.CurrentCard == null)
                    break;
                Card copycard = new Card(current.CurrentCard);
                tempStack.Push(copycard);
                current = current.Next;
            }

            current = tempStack.Top;
            while (current != null)
            {
                copy.Push(current.CurrentCard);
                current = current.Next;
            }

            return copy;
        }

    }

}
