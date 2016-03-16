using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make a new linked list
            MyLinkedList iMadeALinkedList = new MyLinkedList();

            // Add a few things to the linked list
            iMadeALinkedList.add("First");
            iMadeALinkedList.add("Second");
            iMadeALinkedList.add("Third");
            iMadeALinkedList.add("Fourth");
            iMadeALinkedList.add("Fifth");

            // Loop through this differently looking for loop to output.
            // In here, the first part is initialization: setting x to the Head
            // the second part is the test: if x !+ null, keep going
            // the last part is: set the current x to x's next pointer. (the next in the list)
            for (Node x = iMadeALinkedList.Head; x != null; x = x.Next)
            {
                Console.WriteLine(x.Data);
            }

            // Use the retrieve method to start at the Head of the lined list,
            Console.WriteLine(iMadeALinkedList.Retrive(2));
            
            // retreive doesnt seem to work?

            // Do some deletion of the linked list

            // Creating a GenericLinkedList that is now able to be of ANY type (in this case strings)
            GenericLinkedList<string> myGenericLinkedList = new GenericLinkedList<string>();
            // Now as about poymorphism within the methods themselves?


            
        }
    }
}
