using Singleton;

var singleton1 = SingletonNonThreadSafe.GetInstance();
singleton1.DoAction();

var singleton2 = SingletonThreadSafe.GetInstance();
singleton2.DoAction();

LazySingleton.Instance.DoAction();
