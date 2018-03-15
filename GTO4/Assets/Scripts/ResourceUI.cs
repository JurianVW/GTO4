using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{

    public Player player;
    public List<ResourceText> resources;

    void OnEnable()
    {
        Resource.ResourceAmountChanged += UpdateUI;
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
