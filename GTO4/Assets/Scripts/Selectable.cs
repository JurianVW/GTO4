using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public Material deselectedMaterial, selectedMaterial;

    public void Select()
    {
        this.GetComponent<Renderer>().material = selectedMaterial;
    }

    public void Deselect()
    {
        this.GetComponent<Renderer>().material = deselectedMaterial;
    }
}
