using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager<T> : MonoBehaviour where T : BaseManager<T> // la` bat ky class nao` duoc tao ra
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Object.FindObjectOfType<T>();

                if (instance == null)
                {
                    Debug.LogError($"{typeof(T).Name} Singleton Instance.");
                }
            }
            return instance;
        }
    }

    public static bool HasInstance
    {
        get
        {
            return (instance != null);
        }
    }
    protected virtual void Awake()
    {
        CheckInstance();
    }
    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = (T)this;
            DontDestroyOnLoad(this);
            return true;
        }
        else if (instance == this)
        {
            DontDestroyOnLoad(this);
            return true;
        }
        Object.Destroy(this.gameObject);
        return false;
    }
}
