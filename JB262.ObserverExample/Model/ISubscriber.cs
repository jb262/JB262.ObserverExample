using System;

namespace JB262.ObserverExample.Model
{
    /// <summary>
    /// Extends the IObserver interface with methods to subscribe and unsubscribe itself from an IObservable.
    /// </summary>
    /// <typeparam name="T">Type of the push-based notification.</typeparam>
    public interface ISubscriber<T> : IObserver<T>
    {
        /// <summary>
        /// Subscribes the object to a notification provider.
        /// </summary>
        /// <param name="observable"></param>
        void SubscribeTo(IObservable<T> observable);

        /// <summary>
        /// Unsubscribes the object from its notification provider,
        /// </summary>
        void Unsubscribe();
    }
}
