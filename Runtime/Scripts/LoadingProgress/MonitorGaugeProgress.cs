using FredericRP.EventManagement;
using UnityEngine;

namespace FredericRP.EasyLoading
{
  public abstract class MonitorGaugeProgress : MonoBehaviour
  {
    [SerializeField]
    FloatStringGameEvent progressEvent = null;
    [SerializeField]
    protected float ratio = 1;
    [SerializeField]
    protected float offset = 0;
    [SerializeField]
    string gaugeId = null;

    public string GaugeId { get => gaugeId; set => gaugeId = value; }

    internal void OnEnable()
    {
      progressEvent.Listen(UpdateProgress);
    }

    internal void OnDisable()
    {
      progressEvent.Delete(UpdateProgress);
    }

    /// <summary>
    /// Update the gauge from parameter progress.
    /// GaugeId can be specified, or null for all existing gauges
    /// </summary>
    /// <param name="gaugeId">Specific gauge id, or null for all of them</param>
    /// <param name="progress">Progress of the loading, between 0.0f and 1.0f</param>
    public void UpdateProgress(float progress, string gaugeId = null)
    {
      if (!string.IsNullOrWhiteSpace(gaugeId) && !this.gaugeId.Equals(gaugeId))
        return;
      DisplayGaugeProgress(progress);
    }
    protected abstract void DisplayGaugeProgress(float progress);
  }
}