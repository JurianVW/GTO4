using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int startAmount;
    public int amount;

    public delegate void amountChange();
    public static event amountChange ResourceAmountChanged;

    void Start()
    {
        amount = startAmount;
    }

    public void AddAmount(int amount)
    {
        this.amount += amount;
        AmountChanged();
    }

    public void RemoveAmount(int amount)
    {
        this.amount -= amount;
        AmountChanged();
    }

    private void AmountChanged()
    {
        if (ResourceAmountChanged != null)
        {
            ResourceAmountChanged();
        }
    }
}
