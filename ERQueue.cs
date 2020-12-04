using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalQueue_Boyd
{
    class ERQueue
    {
        /* I used a linked list for this project since I thought it would prove the most useful for a short
         * list where I could add patients from the back in an order without a lot of searching
         * the way I added the new patients was from the back so I could keep priority if someone has the same priority
         * I could add them behind the current patient, or infront if they had the highest priority of the highest priority
         * queue.
         * I did not make a patient class becuse I don't think the project called for it becuse I used a nexted Node class
         * making a patient class would only add extra work for little gain the patient info is stored in the node class and can
         * is only read only.
         * 
         * 
         * 
         */
        internal class Node
        {
            internal Node next;
            internal Node last;
            private string name;
            public string Name
            {
                get { return name; }
            }

            private int priority;
            public int Priority
            {
                get { return priority; }
            }
            internal Node(string _Name, int _Priority)
            {
                name = _Name;
                priority = _Priority;
                next = null;
                last = null;

            }    
        }

        int currentQue = 0;
        Node head;
        Node tail;

        public int Enqueue(string Name, int Priority)
        {
            currentQue++;//for knowing how many people are in the list
            Node newNode = new Node(Name, Priority);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                return currentQue;
            }
            Node tempEnd = tail;
            while (tempEnd != null)
            {
                // first person
                if (newNode.Priority < tempEnd.Priority && tempEnd.next == null)
                {
                    tempEnd.next = newNode;
                    newNode.last = tempEnd;
                    head = newNode;
                    return currentQue;
                }
                //end of que
                else if (newNode.Priority >= tempEnd.Priority && tempEnd.last == null)
                {
                    tempEnd.last = newNode;
                    newNode.next = tempEnd;
                    tail = newNode;
                    return currentQue;
                }
                
                else if (newNode.Priority >= tempEnd.Priority)
                {
                    tempEnd.last.next = newNode;
                    newNode.last = tempEnd.last;
                    tempEnd.last = newNode;
                    newNode.next = tempEnd;

                    return currentQue;
                }
                else
                {
                    tempEnd = tempEnd.next;
                }

            }
            
                return -1;
            
        }
        public string Dequeue()
        {
            if (head == null)
            {
                return "no people in que";    
            }
            string removedPerson = head.Name + " " + head.Priority.ToString();
            head = head.last;
            if (currentQue == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                head.next = null;
            }
            currentQue--;
            return removedPerson;
        }
        public override string ToString()
        {
            StringBuilder patientsInfo = new StringBuilder();
            Node ListValue = head;
            int postionInQueue = 0;
            while (ListValue != null)
            {
                postionInQueue++;
                patientsInfo.Append("Patiens name is "+ListValue.Name + " their priority is " + ListValue.Priority +" their postion in the queue is "+ postionInQueue + "\n");
                ListValue = ListValue.last;
            }
            
            //string builder that adds all items in the que both name and priority
            return patientsInfo.ToString();
        }

    }
}
