namespace Singleton;

public sealed class LazySingleton
{
    private static readonly Lazy<LazySingleton> _instance
        = new Lazy<LazySingleton>(() => new LazySingleton());

    private LazySingleton() { }

    public static LazySingleton Instance => _instance.Value;

    public void DoAction()
    {
        // some business-logic
    }
}