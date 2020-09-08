using System;

namespace JB262.ObserverExample.Model
{
    /// <summary>
    /// Abstract base class of a student's activity,
    /// </summary>
    public abstract class StudentActivity : IStudentActivity
    {
        /// <summary>
        /// Student who is to execute the activity.
        /// </summary>
        protected Student _student;

        /// <summary>
        /// Indicates if the activity is currently being executed.
        /// </summary>
        public bool IsActive { get; protected set; }

        /// <summary>
        /// Constructor of the student's activity.
        /// </summary>
        /// <param name="student">Student who is to execute the activity.</param>
        protected StudentActivity(Student student)
        {
            _student = student;
        }

        /// <summary>
        /// Starts the activity.
        /// </summary>
        public virtual void Begin()
        {
            IsActive = true;
        }

        /// <summary>
        /// Resumes a paused activity.
        /// </summary>
        public virtual void Resume()
        {
            IsActive = true;
        }

        /// <summary>
        /// Pauses an active activity.
        /// </summary>
        public virtual void Pause()
        {
            IsActive = false;
        }

        /// <summary>
        /// Static factory method to create a new activity for a student from a given activity type.
        /// </summary>
        /// <param name="student">Student who is to execute the activity.</param>
        /// <param name="activityType">Type of the activity to be created.</param>
        /// <returns>Concrete object of an activity.</returns>
        public static StudentActivity CreateActivity(Student student, StudentActivityType activityType)
        {
            return activityType switch
            {
                StudentActivityType.AttendClass => new AttendClassActivity(student),
                StudentActivityType.GoHome => new GoHomeActivity(student),
                StudentActivityType.WorkOut => new WorkOutActivity(student),
                _ => throw new ArgumentException("Invalid activity type given.", nameof(activityType)),
            };
        }
    }
}
