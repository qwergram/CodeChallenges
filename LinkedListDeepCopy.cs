using System.Collections.Generic;
using System.Diagnostics;

namespace InterviewRemake
{

    // Create a public Node with simple properties and constructor
    public class Node
    {
        public char Value { get; set; }
        public Node Next { get; set; }
        public Node Random { get; set; }

        public Node(char value, Node next, Node random)
        {
            this.Value = value;
            this.Next = next;
            this.Random = random;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var C = new Node('C', null, null);
            var B = new Node('B', C, null);
            B.Random = B;
            var A = new Node('A', B, C);

            //            
            // Looks like A->B->C
            // A has a random pointer to C
            // B has a random pointer to itself

            var aCopy = Copy(A);
            
            // assert values are correct
            Debug.Assert(aCopy.Value == 'A');
            Debug.Assert(aCopy.Next.Value == 'B');
            Debug.Assert(aCopy.Next.Next.Value == 'C');

            // assert random values are correct
            Debug.Assert(aCopy.Random.Value == 'C');
            Debug.Assert(aCopy.Next.Random.Value == 'B');
            Debug.Assert(aCopy.Next.Next.Random == null);

            // assert the actual items are correct
            Debug.Assert(aCopy.Random == aCopy.Next.Next);
            Debug.Assert(aCopy.Next.Random == aCopy.Next);
            Debug.Assert(aCopy.Next.Next.Random == null);

            // assert it's a deep copy
            Debug.Assert(aCopy != A);
            Debug.Assert(aCopy.Next != B);
            Debug.Assert(aCopy.Next.Next != C);
            Debug.Assert(aCopy.Random != C);
            Debug.Assert(aCopy.Next.Random != B);


            // changing value should have no effect on copy
            A.Value = 'D';
            Debug.Assert(aCopy.Value != 'D');
            // and vice versa
            aCopy.Value = 'E';
            Debug.Assert(A.Value != 'E');

            var D = new Node('D', null, A);
            A.Random = D;
            C.Next = D;

            Debug.Assert(aCopy.Next.Next.Next == null);
            Debug.Assert(aCopy.Random == aCopy.Next.Next);

        }

        // main copying function
        static Node Copy(Node head)
        {
            // set cursor to head
            var cursor = head;
            // create a new Node with head value and head old pointer
            var copy = new Node(head.Value, null, head.Random);
            // Create a cursor for copy
            var copyCursor = copy;

            // Create a "Memory Pointer" map. Although it's more of a "reference" map. 
            var memoryMap = new Dictionary<Node, Node> { };
            // Add cursor head and cursor copy to it
            memoryMap.Add(cursor, copy);

            // Iterate through all cursors
            while (cursor != null)
            {
                // Add the cursor and copyCursor to memoryMap if it isn't in there already
                if (!memoryMap.ContainsKey(cursor))
                {
                    memoryMap.Add(cursor, copyCursor);
                }

                // Move the cursor to be ahead of the copyCursor
                cursor = cursor.Next;
                // set the copyCursor.Next to be a new node containing cursor data
                if (cursor != null)
                {
                    copyCursor.Next = new Node(cursor.Value, null, cursor.Random);
                } else
                {
                    copyCursor.Next = null;
                }
                // move the copy cursor forward one step
                copyCursor = copyCursor.Next;
            }


            // Start over and iterate through the copy cursors now
            copyCursor = copy;

            while (copyCursor != null) {
                // if there is a random pointer, look up the copy equiv and set it to that
                if (copyCursor.Random != null) {
                    copyCursor.Random = memoryMap[copyCursor.Random];
                }
                // move onto the next step
                copyCursor = copyCursor.Next; 
            }
            
            // return reference to copy head
            return copy;
        }
    }

}
