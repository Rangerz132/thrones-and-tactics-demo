using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsHolder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI entityName;
    [field: SerializeField] public Image HealthBarGauge { get; private set; }

    /// <summary>
    /// Set entity properties
    /// </summary>
    /// <param name="level"></param>
    /// <param name="entityName"></param>
    public void SetStats(string entityName, string level)
    {
        this.entityName.text = entityName;
    }
}
