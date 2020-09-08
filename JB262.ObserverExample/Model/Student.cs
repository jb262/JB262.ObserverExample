using System;
using System.Collections.Generic;

namespace JB262.ObserverExample.Model
{
    /// <summary>
    /// Basic student.
    /// </summary>
    public class Student : ISubscriber<int>
    {
        /// <summary>
        /// A Collection of the student's activities mapped to hours of the day.
        /// </summary>
        private IDictionary<int, IStudentActivity> _activities;

        /// <summary>
        /// Disposable object to handle the student's unsubscription from its provider.
        /// </summary>
        private IDisposable _unsubscriber;

        /// <summary>
        /// Activity currently being executed.
        /// </summary>
        private IStudentActivity _currentActivity;

        /// <summary>
        /// Integer ID of the student.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of the student.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Basic constructor of the student object.
        /// </summary>
        /// <param name="id">ID of the student.</param>
        /// <param name="name">Name of the student.</param>
        public Student(int id, string name)
        {
            ID = id;
            Name = name;

            _activities = new Dictionary<int, IStudentActivity>();
            _unsubscriber = null;
            _currentActivity = null;
        }

        /// <summary>
        /// Subscribes the student to a provider that notifies them of the current time.
        /// </summary>
        /// <param name="observable">Provider that notifies the student of the current time</param>
        public void SubscribeTo(IObservable<int> observable)
        {
            _unsubscriber = observable.Subscribe(this);
        }

        /// <summary>
        /// Unsubscribes the student from the provider that notifies them of the current time.
        /// </summary>
        public void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }

        /// <summary>
        /// Adds an activity to the student's activities.
        /// </summary>
        /// <param name="time">Hour ofg the day the activity is to be executed.</param>
        /// <param name="activityType">Type of activity that is to be executed at the given time.</param>
        public void AddActivity(int time, StudentActivityType activityType)
        {
            _activities[time] = StudentActivity.CreateActivity(this, activityType);
        }

        /// <summary>
        /// Removes an activity from the student's activities at a given time.
        /// </summary>
        /// <param name="time">Time of the activity that is to be removed.</param>
        public void RemoveActivity(int time)
        {
            if (_activities.ContainsKey(time))
            {
                _activities.Remove(time);
            }
        }

        /// <summary>
        /// Pauses an active activity when the provider that notifies the student of the current time is stopped.
        /// </summary>
        public void OnCompleted()
        {
            if (_currentActivity != null && _currentActivity.IsActive)
            {
                _currentActivity.Pause();
            }
        }

        /// <summary>
        /// Method that handles an error of the provider that notifies the student of the current time.
        /// </summary>
        /// <param name="error">Exception thrown by the provider.</param>
        /// <remarks>Deliberately left empty as the provider a student is subscribed to is very basic and will not throw exceptions.</remarks>
        public void OnError(Exception error) { }

        /// <summary>
        /// Either starts or resumes an activity based on the given hour of the day.
        /// </summary>
        /// <param name="time">Current hour of the day.</param>
        public void OnNext(int time)
        {
            if (_activities.ContainsKey(time))
            {
                _currentActivity = _activities[time];
                _currentActivity.Begin();
            }
            else if (!(_currentActivity == null || _currentActivity.IsActive))
            {
                _currentActivity.Resume();
            }
        }
    }
}
