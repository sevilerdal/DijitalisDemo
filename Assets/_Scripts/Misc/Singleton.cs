using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<T>();
            if (Instance == null)
            {
                GameObject singleton = new GameObject();
                Instance = singleton.AddComponent<T>();
                singleton.name = typeof(T).ToString();
            }
        }
    }

    protected virtual void OnDisable()
    {
        Instance = null;
    }

}

public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        base.Awake();

    }

    protected override void OnDisable()
    {
        DontDestroyOnLoad(gameObject);
        base.OnDisable();
    }
}




