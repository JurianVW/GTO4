using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    public Grid grid;
    public Unit prefab;
    private List<Unit> units;
    public List<ResourceCost> resourceCost;

    void Start()
    {
        units = new List<Unit>();
    }

    public void BuyUnit()
    {
        bool enoughRecourses = true;

        foreach (ResourceCost rc in resourceCost)
        {
            if (rc.resource.amount < rc.cost) enoughRecourses = false;
        }
        if (enoughRecourses)
        {
            Tile tile = grid.getEmptyTile();
            if (tile != null)
            {
                tile.occupied = true;
                Unit unit = Instantiate(prefab, new Vector3(tile.transform.position.x, 0.5f, tile.transform.position.z), Quaternion.identity);
                unit.transform.SetParent(tile.transform);
                foreach (ResourceCost rc in resourceCost)
                {
					rc.resource.RemoveAmount(rc.cost);
                }
            }

        }
    }

    [System.Serializable]
    public struct ResourceCost
    {
        public Resource resource;
        public int cost;
    }
}
