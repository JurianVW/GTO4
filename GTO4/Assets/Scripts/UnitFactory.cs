using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    public Player player;
    public Unit prefab;
    public List<ResourceCost> resourceCost;

    private Grid grid;

    void Start()
    {
        grid = player.GetComponent<PlayerConfiguration>().grid;
    }

    public void BuyUnit(Tile tile)
    {
        bool enoughRecourses = true;

        foreach (ResourceCost rc in resourceCost)
        {
            if (rc.resource.amount < rc.cost) enoughRecourses = false;
        }
        if (enoughRecourses)
        {
           if (!tile.occupied)
            {
                tile.SetOccupied(true);
                Unit unit = Instantiate(prefab, new Vector3(tile.transform.position.x, 0.5f, tile.transform.position.z), Quaternion.identity);
                unit.transform.SetParent(tile.transform);
                unit.SetPlayer(player);
                tile.SetUnit(unit);
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
