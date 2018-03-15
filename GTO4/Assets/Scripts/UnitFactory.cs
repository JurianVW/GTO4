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
                unit.setPlayer(player);
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
