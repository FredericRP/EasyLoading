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
    [SerializeField]
    bool leftToRight = true;

    protected override void DisplayGaugeProgress(float progress)
    {
      Vector2 anchorPos = leftToRight ? gaugeRect.anchorMax : gaugeRect.anchorMin;
      float anchorX = progress * ratio + offset;
      // At least some pixels width
      if (anchorX < anchorMin)
      {
        if (hideBelowMin)
          gaugeRect.gameObject.SetActive(false);
        else
          anchorPos.x = anchorMin;
      }
      else
      {
        anchorPos.x = anchorX;
        if (!gaugeRect.gameObject.activeInHierarchy)
          gaugeRect.gameObject.SetActive(true);
      }
      if (leftToRight)
        gaugeRect.anchorMax = anchorPos;
      else
        gaugeRect.anchorMin = anchorPos;
    }
  }
}