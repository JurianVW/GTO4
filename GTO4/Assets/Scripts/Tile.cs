using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool occupied;
    public float x, y;

    public void setLocation(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

}
