using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    public static T instance;

    private static bool m_applicationIsQuitting = false;

    public static T GetInstance()
    {
        if (m_applicationIsQuitting) { return null; }

        if (instance == null)
        {
            instance = FindObjectOfType<T>();
            if (instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                instance = obj.AddComponent<T>();
            }
        }
        return instance;
    }

    /* IMPORTANT!!! To use Awake in a derived class you need to do it this way
     * protected override void Awake()
     * {
     *     base.Awake();
     *     //Your code goes here
     * }
     * */

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            SetDontDestroyOnLoad();
        }
        else if (instance != this as T)
        {
            Destroy(gameObject);
        }
        else { DontDestroyOnLoad(gameObject); }
    }
    protected virtual void SetDontDestroyOnLoad()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void OnApplicationQuit()
    {
        m_applicationIsQuitting = true;
    }
}
