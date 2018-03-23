using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool occupied { get; private set;}
    public Vector2 xy {get; private set;}
    public Unit unit{get; private set;}

    public void SetLocation(float x, float y)
    {
       this.xy = new Vector2(x,y);
    }

    public void SetOccupied(bool occupied){
        this.occupied = occupied;
    }

    public void SetUnit(Unit unit){
        this.unit = unit;
    }
}
