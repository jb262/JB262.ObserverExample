namespace JB262.ObserverExample.Model
{
    /// <summary>
    /// An activity executed by a student.
    /// </summary>
    public interface IStudentActivity
    {
        /// <summary>
        /// Indicates if the activity is currently being executed.
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        /// Starts the activity.
        /// </summary>
        void Begin();

        /// <summary>
        /// Resumes a paused activity.
        /// </summary>
        void Resume();

        /// <summary>
        /// Pauses an active activity.
        /// </summary>
        void Pause();
    }
}
