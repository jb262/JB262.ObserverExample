using System;
using JB262.ObserverExample.Model;

namespace JB262.ObserverExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student alice = new Student(1, "Alice");
            Student bob = new Student(2, "Bob");
            TimeDisplay display = new TimeDisplay();

            Clock clock = Clock.Instance;

            display.SubscribeTo(clock);
            alice.SubscribeTo(clock);
            bob.SubscribeTo(clock);

            alice.AddActivity(6, StudentActivityType.WorkOut);
            alice.AddActivity(8, StudentActivityType.AttendClass);
            alice.AddActivity(16, StudentActivityType.GoHome);

            bob.AddActivity(8, StudentActivityType.AttendClass);
            bob.AddActivity(15, StudentActivityType.WorkOut);
            bob.AddActivity(17, StudentActivityType.GoHome);

            clock.Start();

            Console.ReadKey();
        }
    }
}
