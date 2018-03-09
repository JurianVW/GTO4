using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{

    public List<ResourceText> resources;

    void Start()
    {
        Resource.ResourceAmountChanged += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        foreach (ResourceText rt in resources)
        {
            rt.resourceText.text = rt.resource.amount.ToString();
        }
    }

    [System.Serializable]
    public struct ResourceText
    {
        public Resource resource;
        public Text resourceText;
    }
}
