using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    protected static T mInstance = null;

    public static T Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<T>();
                if (FindObjectsOfType<T>().Length > 1)
                {
                    return mInstance;
                }
                if (mInstance == null)
                {
                    string instanceName = typeof(T).Name;
                    GameObject instanceGO = GameObject.Find(instanceName);
                    if (instanceGO == null)
                        instanceGO = new GameObject(instanceName);
                    mInstance = instanceGO.AddComponent<T>();

                    DontDestroyOnLoad(instanceGO);

                }
            }
            return mInstance;
        }
    }

    protected virtual void OnDestroy()
    {
        mInstance = null;
    }
}