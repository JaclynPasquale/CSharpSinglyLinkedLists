using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode firstNode;



        public SinglyLinkedList()
        {
            currentLength = 0;
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        private int currentLength;

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                AddLast(values[i].ToString());
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return ElementAt(i); }
            set { throw new NotImplementedException(); }
        }

        public void AddAfter(string existingValue, string value)
        {
            SinglyLinkedListNode node = this.firstNode;
            while(existingValue != value)
            {
                node = node.Next;  
                if (node == null)
                {
                    throw new System.ArgumentException();
                }
                else
                {
                    SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
                    newNode.Next = node.Next;
                    node.Next = newNode;

                }
                
              
            }
             
        }

        public void AddFirst(string value)
        {
            SinglyLinkedListNode FirstGen = this.firstNode;
            SinglyLinkedListNode SecondGen = new SinglyLinkedListNode(value);
            this.firstNode = SecondGen;
            SecondGen.Next = FirstGen;
        }

        public void AddLast(string value)
        {
            if (firstNode == null)
            {
                firstNode = new SinglyLinkedListNode(value);
                return;
            }else
            {
            SinglyLinkedListNode node = this.firstNode;

            while (true)
            {
                if (node.Next == null)
                {
                    node.Next = new SinglyLinkedListNode(value);
                    break;
                }
                else
                {
                   lastnode.next = new SinglyLinkedListNode(value);
                }
                currentLength++;
            }
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            return currentLength;
        }

        public string ElementAt(int index)
        {
            SinglyLinkedListNode node = this.firstNode;
            if (node == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node.Value;

        }

        public string First()
        {
            if (firstNode == null)
            {
                return null;
            }
            else
            {
                return firstNode.Value;
            }
        }

        public int IndexOf(string value)
        {
            if (currentLength == 0)
            {
                return -1;
            }
            else
            {
                int index = 0;
                for (int i = 0; i < currentLength; i++)
                {
                    if (this[i] == value)
                    {
                        index = i;
                        break;
                    } 
                }
                return index;
            }
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

         

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            if (this.firstNode == null)
            {
                return null;
            }
            SinglyLinkedListNode node = firstNode;
            int counter = 0;

            while (true)
            {
                if (node.Next == null)
                {
                    break;
                }
                node = node.Next;
                counter++;
            }
            return this.ElementAt(counter);
        }

        public void Remove(string value)
        {
            throw new NotImplementedException();
        }
        private void Swap(SinglyLinkedListNode prevPrev, SinglyLinkedListNode prev, SinglyLinkedListNode current)
        {
            var temp = prev;
            prev.Next = current.Next;
            current.Next = temp;
            if(firstNode == temp)
            {
                firstNode = current;
            }
            else
            {
                prevPrev.Next = current;
            }
        }
        private SinglyLinkedListNode NodeAt(int index)
        {
            var result = firstNode;
            for (int i =0; i < index; i++)
            {
                result = result.Next;
            }
            return result;
        }

        public void Sort()
        {
            
            if (firstNode == null || firstNode.Next == null )
            {
                return;
            }
            for (int i = 0; i < this.Count(); i++)
			{
			    SinglyLinkedListNode lowest = NodeAt(i);
                
                for (int j = 0; j < this.Count(); j++)
                {
                    if (lowest > NodeAt(j))
                    {
                        lowest = NodeAt(j);
                    }
                        
                }
                if(lowest != NodeAt(i))
                {
                    Swap(NodeAt(i - 1), NodeAt(i), lowest);
                }
                // either add a setter or swap the nodes
			}
            

        }

        public string[] ToArray()
        {
            string[] StuffWeDontWant = new string [] {",", " ", "{", "}", "\""};
            string list = ToString();
            string[] words = list.Split(StuffWeDontWant, StringSplitOptions.RemoveEmptyEntries);

            return words;

        }
        public override string ToString()
        {
            SinglyLinkedListNode node = this.firstNode;
            if (node == null)
            {
                return "{ }";
            }
            StringBuilder listString = new StringBuilder("{ \"");

            while (true)
            {
                listString.Append(node.ToString()); 
                if (node.Next == null)
                {
                    break;
                }
                listString.Append("\", \"");
                node = node.Next;
            }
            listString.Append("\" }");
            return listString.ToString();
        }


    }
}


