using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    // Declare the class with a generic type, of T.  The Typr thatthis linked list supports
    // is whatever is passed into this class when it is declared.
    // The type is available in this class at the ' variable' T
    class GenericLinkedList<Type>
    {
        //Node that will 'Point' to the current node we are looking at
        public GenericNode<Type> current
        {
            get;
            set;
        }

        // Node that will point to the beginning of the linked list
        public GenericNode<Type> Head
        {
            get;
            set;
        }

        // Node that will point to the end of the linked list
        private GenericNode<Type> Tail
        {
            get;
            set;
        }

        // Constructor. Just to initialize the properties to null
        public GenericLinkedList()
        {
            Head = null;
            Tail = null;
            current = null;
        }

        // This would be the add method to add a new node to the inked list
        public void add(Type content)
        {
            //Make a new node
            GenericNode<Type> node = new GenericNode<Type>();

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

        public Type Retrive(int position)
        {
            // Used as a temporary pointer to a spot within the linked list
            GenericNode<Type> tempNode = Head;

            // Used to hold the node at the index indicated by the passed in position
            GenericNode<Type> returnNode = null;

            // counter to see where we are in the list
            int counter = 0;

            // while out tempNode is not a the end of the list
            while (tempNode != null)
            {
                // if he count and the position match.  This means that it will be 
                // Zero based.  Ifwe wanted it to be one based, we would need to subtract 1from the positon
                if (counter == position)
                {

                    // Set the returnNode var to the tempNode, which is the one we are looking for
                    returnNode = tempNode;
                }

                // Increment the count so tha we actually move through the linked list
                counter++;

                // Set the temoNode to tempnode's next property, which allows us to go the next node
                tempNode = tempNode.Next;
                
            }

            // We are going to use a ternary operator to do a smaller version of an if.
            // this could easiy be written as an if/else.  essentially the part in the ()
            // is the test, and the part between the ? and the : is what will hapen if true.
            // the part after : is what will happen when false.

            // The default(Type) part is going to determine what the value for
            // Type T is, ad return that.  Most of the time it will robably be null, but in case it isn't
            // this wil handle it.  Putting it in allows the IDE to convert the differnet types
            return (returnNode != null) ? returnNode.Data : default(Type); 
            // wonder if you could do null + " there wasnt anything" in the false part?
        }

        public bool Delete(int position)
        {
            // return value for the method
            bool returnBool = false;

            // set current to head
            current = Head;

            // Check to see if osition is Zero
            // meaning its the first Node
            // then we will need to do things differently
            // tis part is alwas equivelent t always removing from front ( hint hint)
            if (position == 0)
            {
                // set the head to the current.next which will make ead point ot the node
                // at index 1, instead of index 0
                Head = current.Next;

                // Set the Next property to null so that the current
                // ( which was the old head) does not point to any other node.
                // this line is probabl not 'required' but does illustrate how to
                // clean up a node so that it no longer points to anything.
                current.Next = null;

                // Set the current  which was the old head)  to null.  now that node
                // no longer exists, and can be garbae collected
                current = null;

                // chec to see if the head is null, if so, the Tail must become nul as well
                // because it means that we just deleted the last node in the list.
                if (Head == null)
                {
                    Tail = null;
                }

                // Set the return bool to true since the remove was successfull
                returnBool = true;
            }

            else
            {
                // set a Tempnode to the first position in the linked list
                GenericNode<Type> tempNode = Head;

                // Declare a previous temp that will get a value after the tempNode moves
                GenericNode<Type> previousTempnode = null;

                // start a counter to move thorugh the list
                int count = 0;

                // loop until the tempNode is null, which means we are at the end.
                while (tempNode != null)
                {
                    // If we match the position and the count we are on, we found the one we need to delete
                    if (count == position)
                    {
                        // Set the previous nodes next to the tempNode's next
                        // Jumping over the tempNode.  The previous node's next will
                        // now point to the node AFTER the tempNode
                        previousTempnode.Next = tempNode.Next;

                        // chec to see if we are deleting the very last node in the linked list
                        // if so, we need to move the Tail Pointer
                        if (tempNode.Next == null)
                        {
                            // Set Tail to the previousTempNode, which is the new end of list
                            Tail = previousTempnode;
                        }

                        // We found the one to delete, so set the bool to true
                        returnBool = true;
                    }

                    // Increment count so that we move through the linked list.
                    count++;

                    // Here we are setting the previousTempNode to the Tempnode
                    // before we increment it, so we can save its position.
                    previousTempnode = tempNode;

                    // Set the tempnode to temptNode's next property, which will move it down the linked list one position
                    tempNode = tempNode.Next;

                }
            }

            return returnBool;
        }

        public void AddToFront(Type content)
        {
            // Just make another pointer that points to the firstnode in the linked list
            GenericNode<Type> oldFirst = Head;

            // Overwrite head with a new Generic Node
            Head = new GenericNode<Type>();

            // Set the data on the Node
            Head.Data = content;

            // Make Head's next point to the old First
            Head.Next = oldFirst;
        }

        public Type RemoveFromFront()
        {
            // Mae a return Node and set it to Head
            // Which is the first node in the linked list
            GenericNode<Type> returnNode = Head;

            // Move the Head to the next node in the linked list
            Head = Head.Next;
            
            // check to see if Head is null, if so, set Tail to null as well.
            // List is empty
            if (Head == null)
            {
                Tail = null;
            }

            // Return that data
            return returnNode.Data;

        }
    }
}
