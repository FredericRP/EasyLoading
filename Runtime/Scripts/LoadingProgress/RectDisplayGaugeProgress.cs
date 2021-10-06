using UnityEngine;

namespace FredericRP.EasyLoading
{
  public class RectDisplayGaugeProgress : MonitorGaugeProgress
  {
    [Header("Links")]
    [SerializeField]
    RectTransform gaugeRect = null;
    [Header("Config")]
    [SerializeField]
    float anchorMin = 0.1f;
    [SerializeField]
    bool hideBelowMin = false;

    protected override void DisplayGaugeProgress(float progress)
    {
      Vector2 anchorMax = gaugeRect.anchorMax;
      float anchorX = progress * ratio + offset;
      // At least some pixels width
      if (anchorX < anchorMin)
      {
        if (hideBelowMin)
          gaugeRect.gameObject.SetActive(false);
        else
          anchorMax.x = anchorMin;
      }
      else
      {
        anchorMax.x = anchorX;
        if (!gaugeRect.gameObject.activeInHierarchy)
          gaugeRect.gameObject.SetActive(true);
      }
      gaugeRect.anchorMax = anchorMax;
    }
  }
}