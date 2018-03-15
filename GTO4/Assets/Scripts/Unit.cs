using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private float x, y;
    private Player myPlayer;
    public void setLocation(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public void setPlayer(Player player){
        this.myPlayer = player;
    }
}
