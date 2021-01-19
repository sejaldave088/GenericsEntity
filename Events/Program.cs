using System;

namespace Events
{
    public class Program
    {

       
            static void Main(string[] args)
            {
                additinoftwo a = new additinoftwo();
                //Event gets binded with delegates
                a.evnumber += new additinoftwo.oddNumber(EventMessage);
                a.Add();
                Console.Read();
            }
            //Delegates calls this method when event raised.  
            static void EventMessage()
            {
                Console.WriteLine("** This is Odd Number**");
            }
        }

        class additinoftwo
        {
            public delegate void oddNumber(); // Delegate   Declared  
        public event oddNumber evnumber; // EventsDeclared

        public void Add()
            {
                int result;
                result = 1 + 2;
                Console.WriteLine(result.ToString());
              
                if ((result % 2 != 0))
                {
                    evnumber(); //event raise
                }
            }

        }
    }