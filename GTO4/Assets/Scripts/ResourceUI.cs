using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{

    public Resource resource;
    [Space(10)]
    public Text goldValue;
    public Text silverValue;
    public Text bronzeValue;

    void Start()
    {
        Resource.ResourceValueChanged += UpdateUI;
    }

    private void UpdateUI()
    {
        goldValue.text = resource.gold.ToString();
        silverValue.text = resource.silver.ToString();
        bronzeValue.text = resource.bronze.ToString();
    }
}
