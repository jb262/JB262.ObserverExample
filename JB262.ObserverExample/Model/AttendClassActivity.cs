using System;

namespace JB262.ObserverExample.Model
{
    /// <summary>
    /// A rudimentary implementation of a student's activity of attending class.
    /// </summary>
    public class AttendClassActivity : StudentActivity
    {
        /// <summary>
        /// Constructor of a student's activity of attending class.
        /// </summary>
        /// <param name="student">Student who is to execute the activity.</param>
        public AttendClassActivity(Student student) : base(student) { }

        /// <summary>
        /// Method to start the activity.
        /// </summary>
        public override void Begin()
        {
            base.Begin();
            Console.WriteLine($"{_student.Name} starts attending class.");
        }

        /// <summary>
        /// Method to resume the stopped activity.
        /// </summary>
        public override void Resume()
        {
            base.Resume();
            Console.WriteLine($"{_student.Name} is attending class and learning something.");
        }

        /// <summary>
        /// Method to pause the currently active activity.
        /// </summary>
        public override void Pause()
        {
            base.Pause();
            Console.WriteLine($"{_student.Name} stops attending class.");
        }
    }
}
