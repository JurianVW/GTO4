using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Player myPlayer { get; private set; }
    public float maxMovement;
    public float speed;
    private float currentMovement;
    public bool moving = false;

    void Start()
    {
        currentMovement = maxMovement;
    }

    void Update()
    {
        if (moving)
        {
            transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, Vector3.zero, speed * Time.deltaTime);
            if (this.transform.position == Vector3.zero) moving = false;
        }
    }

    public void SetPlayer(Player player)
    {
        this.myPlayer = player;
    }

    public void Move(Tile targetTile)
    {
        Tile currentTile = this.transform.GetComponentInParent<Tile>();
        if (validMovement(currentTile.xy, targetTile.xy))
        {
            Debug.Log("Valid");
            if (currentTile.xy != Vector2.zero)
            {
                currentTile.SetUnit(null);
                targetTile.SetUnit(this);
                this.transform.SetParent(targetTile.transform);
                if (speed != 0)
                {
                    moving = true;
                }
            }
        }
    }

    private bool validMovement(Vector2 current, Vector2 target)
    {
        return Mathf.Abs((target.x + target.y) - (current.x + current.y)) <= currentMovement;
    }
}
