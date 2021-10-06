using FredericRP.EventManagement;
using UnityEngine;

namespace FredericRP.EasyLoading
{
  public abstract class MonitorGaugeProgress : MonoBehaviour
  {
    [SerializeField]
    GameEvent progressEvent = null;
    [SerializeField]
    protected float ratio = 1;
    [SerializeField]
    protected float offset = 0;
    [SerializeField]
    string gaugeId = null;

    public string GaugeId { get => gaugeId; set => gaugeId = value; }

    private void OnEnable()
    {
      progressEvent.Listen<float, string>(UpdateProgress);
    }

    private void OnDisable()
    {
      progressEvent.Delete<float, string>(UpdateProgress);
    }

    /// <summary>
    /// Update the gauge from parameter progress.
    /// GaugeId can be specified, or null for all existing gauges
    /// </summary>
    /// <param name="gaugeId"></param>
    /// <param name="progress"></param>
    public void UpdateProgress(float progress, string gaugeId = null)
    {
      if (gaugeId != null && !this.gaugeId.Equals(gaugeId))
        return;
      DisplayGaugeProgress(progress);
    }
    protected abstract void DisplayGaugeProgress(float progress);
  }
}