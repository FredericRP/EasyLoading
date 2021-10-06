using TMPro;
using UnityEngine;

namespace FredericRP.EasyLoading
{
  public class TextDisplayGaugeProgress : MonitorGaugeProgress
  {
    [SerializeField]
    TextMeshProUGUI text = null;

    protected override void DisplayGaugeProgress(float progress)
    {
      // P0 format displays wrong char, must investigate
      text.text = Mathf.RoundToInt(100 * (progress * ratio + offset)).ToString("F0") + " %";
    }
  }
}