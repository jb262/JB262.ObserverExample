using System;

namespace JB262.ObserverExample.Model
{
    /// <summary>
    /// A rudimentary object to tell the current hour of the day.
    /// </summary>
    public class TimeDisplay : ISubscriber<int>
    {
        /// <summary>
        /// Disposable object to handle the student's unsubscription from its provider.
        /// </summary>
        private IDisposable _unsubscriber;

        /// <summary>
        /// Method that handles the notification of the provider after being stopped.
        /// </summary>
        /// <remarks>Deliberately left empty as a basic object to tell the current time does not change it's behaviour when the provider is stopped.</remarks>
        public void OnCompleted() { }

        /// <summary>
        /// Method that handles an error of the provider that notifies the time display of the current time.
        /// </summary>
        /// <param name="error">Exception thrown by the provider.</param>
        /// <remarks>Deliberately left empty as the provider the time display is subscribed to is very basic and will not throw exceptions.</remarks>
        public void OnError(Exception error) { }

        /// <summary>
        /// Notifies the time display of the current hour of the day.
        /// </summary>
        /// <param name="time">Current hour of the day.</param>
        public void OnNext(int time)
        {
            Console.WriteLine($"It's {time} o'clock.");
        }

        /// <summary>
        /// Subscribes the time display to a provider that notifies it of the current time.
        /// </summary>
        /// <param name="observable">Provider that notifies the time display of the current time</param>
        public void SubscribeTo(IObservable<int> observable)
        {
            _unsubscriber = observable.Subscribe(this);
        }

        /// <summary>
        /// Unsubscribes the time display from the provider that notifies them of the current time.
        /// </summary>
        public void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}
