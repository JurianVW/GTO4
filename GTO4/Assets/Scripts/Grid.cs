﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int gridWidth, gridHeight;
    public Tile prefab;
    private Tile[,] tiles;

    void Start()
    {
        tiles = new Tile[gridWidth, gridHeight];
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                Tile tile = Instantiate(prefab, new Vector3(i * prefab.transform.localScale.x, 0, j* prefab.transform.localScale.z), Quaternion.identity);
                tile.setLocation(i, j);
				 tile.transform.SetParent(this.transform);
                tiles[i, j] = tile;
            }
        }
    }
	public Tile getEmptyTile(){
		List<Tile> emptyTiles = new List<Tile>();
		foreach (Tile tile in tiles)
		{
			if(!tile.occupied){
				return tile;
			}
		}
		return null;
	}
}
