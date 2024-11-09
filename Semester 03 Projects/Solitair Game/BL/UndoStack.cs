using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitair_Game
{

    //Node Class Containing a GameState and it's next UndoStackNode object.
    public class UndoStackNode
    {
        public GameState CurrentGameState;
        public UndoStackNode Next;
    }

    //Stack Class implementing stack using Linked List.
    public class UndoStack
    {
            public UndoStackNode Top;
            public UndoStack()
            {
                Top = null;
            }
            public void Push(GameState newGameState)
            {
                UndoStackNode newUndoStackNode = new UndoStackNode();
                newUndoStackNode.CurrentGameState = newGameState;
                newUndoStackNode.Next = Top;
                Top = newUndoStackNode;

            }
            public GameState Pop()
            {
                if (IsEmpty())
                {
                    return null;
                }
                UndoStackNode next = Top.Next;
                GameState GameStateToDelete = Top.CurrentGameState;
                Top = next;
                return GameStateToDelete;
            }
            public GameState Peek()
            {
                if (IsEmpty())
                {
                    return null;
                }
                return Top.CurrentGameState;
            }
            public bool IsEmpty()
            {
                if (Top == null)
                {
                    return true;
                }
                return false;
            }
            public int GetTotalNumberOfGameStates()
            {
                int count = 0;
                UndoStackNode current = Top;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }
    }

