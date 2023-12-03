using FredericRP.EventManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FredericRP.EasyLoading
{
  public class LoadScene : MonoBehaviour
  {
    /// <summary>
    /// Loading process can be called: by a script, onStart automatically, on specified event
    /// </summary>
    protected enum LoadingTrigger { onCall, onStart, onEvent, onSceneLoaded };

    [SerializeField]
    protected string sceneName = null;

    [SerializeField]
    protected bool async = false;
    /// <summary>
    /// When will be called the loading process ? if onCall, it's explicitly from a script
    /// </summary>
    [SerializeField]
    protected LoadingTrigger loadingTrigger = LoadingTrigger.onStart;
    [SerializeField]
    protected GameEvent loadingEvent;

    private AsyncOperation asyncOperation;

    public AsyncOperation AsyncOperation { get => asyncOperation; }

    // Start is called before the first frame update
    private IEnumerator Start()
    {
      if (loadingTrigger == LoadingTrigger.onStart)
      {
#if UNITY_EDITOR && SLOW_MODE
        yield return new WaitForSeconds(1.5f);
      Debug.Log("Slow mode. Waiting for 1.5sec before launching transition");
#else
        yield return null;
#endif
        StartLoading();
      }
    }

    private void OnEnable()
    {
      SceneManager.sceneLoaded += OnSceneLoaded;
      if (loadingTrigger == LoadingTrigger.onEvent)
        loadingEvent?.Listen(StartLoading);
    }

    void OnDisable()
    {
      SceneManager.sceneLoaded -= OnSceneLoaded;
      if (loadingTrigger == LoadingTrigger.onEvent)
        loadingEvent?.Delete(StartLoading);
    }

    protected virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      if (loadingTrigger == LoadingTrigger.onSceneLoaded)
        StartLoading();
    }

    public virtual void StartLoading()
    {
      //Debug.Log($"{gameObject.name} > Start Loading {async}");
      if (async)
      {
        asyncOperation = SceneManager.LoadSceneAsync(sceneName);
      }
      else
      {
        SceneManager.LoadScene(sceneName);
      }
    }
  }
}