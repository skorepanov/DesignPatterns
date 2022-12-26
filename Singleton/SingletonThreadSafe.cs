namespace Singleton;

public sealed class SingletonThreadSafe
{
    private static volatile SingletonThreadSafe _instance;
    private static readonly object _lock = new object();

    private SingletonThreadSafe() { }

    public static SingletonThreadSafe GetInstance()
    {
        if (_instance is null)
        {
            lock (_lock)
            {
                if (_instance is null)
                {
                    _instance = new SingletonThreadSafe();
                }
            }
        }

        return _instance;
    }

    public void DoAction()
    {
        // some business-logic
    }
}