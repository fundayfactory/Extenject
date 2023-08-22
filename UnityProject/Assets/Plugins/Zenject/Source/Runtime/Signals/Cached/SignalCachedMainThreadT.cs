namespace Zenject
{
    public abstract class SignalCachedMainThreadT<T> where T : new()
    {
        public static T Cached { get; } = new();
    }
}