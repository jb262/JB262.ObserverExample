using System;

namespace JB262.ObserverExample.Model
{
    /// <summary>
    /// A rudimentary implementation of a student's activity of working out.
    /// </summary>
    public class WorkOutActivity : StudentActivity
    {
        /// <summary>
        /// Constructor of a student's activity of working out.
        /// </summary>
        /// <param name="student">Student who is to execute the activity.</param>
        public WorkOutActivity(Student student) : base(student) { }

        /// <summary>
        /// Method to start the activity.
        /// </summary>
        public override void Begin()
        {
            base.Begin();
            Console.WriteLine($"{_student.Name} starts working out.");
        }

        /// <summary>
        /// Method to resume the stopped activity.
        /// </summary>
        public override void Resume()
        {
            base.Resume();
            Console.WriteLine($"{_student.Name} is working out at the gym.");
        }

        /// <summary>
        /// Method to pause the currently active activity.
        /// </summary>
        public override void Pause()
        {
            base.Pause();
            Console.WriteLine($"{_student.Name} stops working out.");
        }
    }
}
