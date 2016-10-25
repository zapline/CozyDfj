using System;
using System.Reflection;

public abstract class Singleton<T> where T : Singleton<T>
{
    protected static T mInstance = null;

    protected Singleton()
    {
    }

    public static T Instance
    {
        get
        {
            if (mInstance == null)
            {
                ConstructorInfo[] ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                ConstructorInfo ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                if (ctor == null)
                    throw new Exception("Non-public ctor() not found!");
                mInstance = ctor.Invoke(null) as T;
            }
            return mInstance;
        }
    }

    public void Dispose()
    {
        mInstance = null;
    }
}