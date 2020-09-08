using System;
using System.Collections.Generic;
using System.Timers;

namespace JB262.ObserverExample.Model
{
    /// <summary>
    /// A clock that tells its subscribers the current time.
    /// </summary>
    public class Clock : IObservable<int>
    {
        /// <summary>
        /// Number of hours per day.
        /// </summary>
        private const int _hoursPerDay = 24;

        /// <summary>
        /// Number of milliseconds the simulated hour consists of.
        /// </summary>
        private const int _msPerHour = 1000;

        /// <summary>
        /// Lazy singleton instance of the clock object.
        /// </summary>
        private static Lazy<Clock> _instance;

        /// <summary>
        /// Timer object to simulate the passing time.
        /// </summary>
        private Timer _timer;

        /// <summary>
        /// Observers that are subscribed to the clock.
        /// </summary>
        private ICollection<IObserver<int>> _observers;

        /// <summary>
        /// Accessible instance of the singleton clock object.
        /// </summary>
        public static Clock Instance { get => _instance.Value; }

        /// <summary>
        /// Current integer time.
        /// </summary>
        public int CurrentTime { get; private set; }

        /// <summary>
        /// Static constructor that initializes the lazy instance of the object.
        /// </summary>
        static Clock()
        {
            _instance = new Lazy<Clock>(() => new Clock());
        }

        /// <summary>
        /// Private constructor that initializes the fields of the clock object.
        /// </summary>
        private Clock()
        {
            CurrentTime = 0;
            _observers = new HashSet<IObserver<int>>();

            _timer = new Timer(_msPerHour)
            {
                Enabled = false,
                AutoReset = true
            };
            _timer.Elapsed += OnHourPassed;
        }

        /// <summary>
        /// Event handler when a simulated hour has passed.
        /// </summary>
        /// <param name="sender">Sender of the data.</param>
        /// <param name="args">Data for the Timer.Elapsed event.</param>
        private static void OnHourPassed(object sender, ElapsedEventArgs args)
        {
            if (Instance.CurrentTime < _hoursPerDay - 1)
            {
                Instance.CurrentTime++;
            }
            else
            {
                Instance.CurrentTime = 0;
            }

            foreach (IObserver<int> observer in Instance._observers)
            {
                observer.OnNext(Instance.CurrentTime);
            }
        }

        /// <summary>
        /// Registers an observer to observe the clock.
        /// </summary>
        /// <param name="observer">Observer to be registered.</param>
        /// <returns>A disposable object to the handle the unsubscription of the observer.</returns>
        public IDisposable Subscribe(IObserver<int> observer)
        {
            _observers.Add(observer);
            return new Unsubscriber<int>(_observers, observer);
        }

        /// <summary>
        /// Starts the timer and notifies the observers.
        /// </summary>
        public void Start()
        {
            _timer.Enabled = true;

            foreach (IObserver<int> observer in _observers)
            {
                observer.OnNext(CurrentTime);
            }
        }

        /// <summary>
        /// Stops the timer and notifies the observers.
        /// </summary>
        public void Stop()
        {
            _timer.Enabled = false;

            foreach (IObserver<int> observer in _observers)
            {
                observer.OnCompleted();
            }
        }
    }
}
