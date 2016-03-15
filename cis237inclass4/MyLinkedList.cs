using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class MyLinkedList
    {
        //Node that will 'Point' to the current node we are looking at
        public Node current
        {
            get;
            set;
        }

        // Node that will point to the beginning of the linked list
        public Node Head
        {
            get;
            set;
        }

        // Node that will point to the end of the linked list
        private Node Tail
        {
            get;
            set;
        }

        // Constructor. Just to initialize the properties to null
        public MyLinkedList()
        {
            Head = null;
            Tail = null;
            current = null;
        }

        // This would be the add method to add a new node to the inked list
        public void add(string content)
        {
            //Make a new node
            Node node = new Node();

            // Set the data for the nde to the content that was passed in.
            node.Data = content;

            //if head is null then there isnt anthing in the linked list.
            // We are about to add the first node
            if (Head == null)
            {
                // Assign the new head an tail t the new node
                // Tail is assigned because its first and doesnt point to anything else
                Head = node;
                //Tail = node;
            }
            

            // This is the case where this already at least one node already in the linked list
            else
            {
                // Take the tail node, which is the last one in the list, and set its Next property
                // which was null, to the new node we just created
                Tail.Next = node;

                // this is a valid replacement for the Tail = node;  but migh be harder to understand.
                // Tail.next = node;
                // This ot moved blow te if/else line
            }

            // This was duplicated in both the if and the else, so we moved it down here, since it must be done for both of them
            Tail = node;
        }

    }
}
