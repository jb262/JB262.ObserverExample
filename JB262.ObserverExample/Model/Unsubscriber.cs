using System;
using System.Collections.Generic;

namespace JB262.ObserverExample.Model
{
    /// <summary>
    /// Object to handle the unsubscription of an observer.
    /// </summary>
    /// <typeparam name="T">Type of the provider's notification.</typeparam>
    internal class Unsubscriber<T> : IDisposable
    {
        /// <summary>
        /// Collection of the observers subscribed to the provider.
        /// </summary>
        private ICollection<IObserver<T>> _observers;

        /// <summary>
        /// Observer that is subscribed to the provider whose unsubscription is to be handled.
        /// </summary>
        private IObserver<T> _observer;

        /// <summary>
        /// Construction of the unsubscription object.
        /// </summary>
        /// <param name="observers">Collection of the observers subscribed to the provider.</param>
        /// <param name="observer">Observer that is subscribed to the provider whose unsubscription is to be handled.</param>
        internal Unsubscriber(ICollection<IObserver<T>> observers, IObserver<T> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        /// <summary>
        /// Unsubscribes an observer from the provider.
        /// </summary>
        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
