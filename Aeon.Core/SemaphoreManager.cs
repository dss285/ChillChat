using NodaTime;
using System.Collections.Concurrent;

namespace Aeon.Core
{
    public class SemaphoreManager<T> where T : notnull
    {
        private readonly ConcurrentDictionary<T, (SemaphoreSlim, Instant)> _storage = new();
        private readonly double _cleanupTime = 3600;

        public SemaphoreSlim this[T key]
        {
            get
            {
                if (_storage.TryGetValue(key, out var val))
                {
                    var (semaphore, _) = val;
                    _storage[key] = (semaphore, SystemClock.Instance.GetCurrentInstant());
                    return semaphore;
                }
                else
                {
                    var semaphore = new SemaphoreSlim(1);
                    _storage[key] = (semaphore, SystemClock.Instance.GetCurrentInstant());
                    return semaphore;
                }
            }
        }
        public void Cleanup()
        {
            var now = SystemClock.Instance.GetCurrentInstant();
            List<T> keysToRemove = new();
            foreach (var entry in _storage)
            {
                var key = entry.Key;
                var (semaphore, instant) = entry.Value;
                var duration = now - instant;
                if (duration.TotalSeconds >= _cleanupTime)
                {
                    keysToRemove.Add(key);
                    semaphore.Dispose();
                }
            }
            foreach(var key in keysToRemove)
            {
                _storage.Remove(key, out var _);
            }
        }
    }

}
