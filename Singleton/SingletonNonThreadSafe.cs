namespace Singleton;

public sealed class SingletonNonThreadSafe
{
    private static SingletonNonThreadSafe _instance;

    private SingletonNonThreadSafe() { }

    public static SingletonNonThreadSafe GetInstance()
    {
        if (_instance is null)
        {
            _instance = new SingletonNonThreadSafe();
        }

        return _instance;
    }

    public void DoAction()
    {
        // some business-logic
    }
}