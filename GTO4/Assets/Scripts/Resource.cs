using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{

    public float gold;
    public float silver;
    public float bronze;

    public delegate void FloatChange();
    public static event FloatChange ResourceValueChanged;
    void Start()
    {
        SetGold(25);
        SetSilver(45);
        SetBronze(10);
    }

    public void SetGold(int amount)
    {
        gold += amount;
        ResourceChanged();
    }

    public void SetSilver(int amount)
    {
        silver += amount;
        ResourceChanged();
    }

    public void SetBronze(int amount)
    {
        bronze += amount;
        ResourceChanged();
    }

    private void ResourceChanged()
    {
        if (ResourceValueChanged != null)
        {
            ResourceValueChanged();
        }
    }
}
