using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    UnitFactory factory;
    bool isBuilding = false;
    void Update()
    {
        if (isBuilding)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Tile tile = hit.collider.GetComponentInParent<Tile>();
                    if (tile != null)
                    {
                        factory.BuyUnit(tile);
                        ExitSpawnMode();
                    }
                }
            }
        }
    }

    void OnDisable()
    {
        ExitSpawnMode();
    }

    public void EnterSpawnMode(UnitFactory factory)
    {
        this.factory = factory;
        isBuilding = true;
    }

    public void ExitSpawnMode()
    {
        factory = null;
        isBuilding = false;
    }
}
