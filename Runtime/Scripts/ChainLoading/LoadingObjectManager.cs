using FredericRP.EasyLoading;
using FredericRP.EventManagement;
using System;
using System.Collections;
using UnityEngine;

namespace FredericRP.EasyLoading
{
  public class LoadingObjectManager : MonoBehaviour
  {
    [System.Serializable]
    public struct ShouldWaitObject
    {
      public MonoBehaviour component;
      public IShouldWait waiter;
    }
    [SerializeField]
    ShouldWaitObject[] objectList;
    [SerializeField]
    LoadScene loadScene;
    enum Phase { awake, enabled, activating, done };

    Phase currentPhase;

    private IEnumerator Start()
    {
      for (int i = 0; i < objectList.Length; i++)
      {
        if (!objectList[i].component.gameObject.activeInHierarchy)
          objectList[i].component.gameObject.SetActive(true);
        objectList[i].waiter = objectList[i].component.GetComponent<IShouldWait>();
        if (objectList[i].waiter != null)
        {
          Debug.Log($"Wait for {objectList[i].component.GetType()} to be initialized");
          yield return new WaitUntil(() => objectList[i].waiter.isInitialized());
        } else
        {
          // No specific component, just wait for one frame, for object initialisation
          yield return new WaitForEndOfFrame();
        }
      }
      Debug.Log($"{gameObject.name} Waiter, last frame");
      // Wait for one more frame
      yield return new WaitForEndOfFrame();
      // Then start loading the next scene
      loadScene.StartLoading();
    }
  }
}
