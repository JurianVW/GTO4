using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [Range(1,6)]
    public int playerAmount;
    public Player prefab;

    [Space(10)]
    public Grid grid;

    [Space(10)]
    public Image colorImage;


    private List<Player> players;
    private Player currentPlayer;

    private int startNumber = 1;
    private int currentPlayerNumber;

    private List<Color> availableColors;


    void Start()
    {
        players = new List<Player>();
        availableColors = new List<Color>(){Color.blue, Color.cyan,Color.green, Color.magenta, Color.red, Color.yellow};

        prefab.gameObject.SetActive(false);
        currentPlayerNumber = startNumber;

        for (int i = 0; i < playerAmount; i++)
        {
            Player player = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            player.transform.SetParent(this.transform);  
            players.Add(player);

            int randomColorIndex = Random.Range(0,availableColors.Count);
            player.color = availableColors[randomColorIndex];
            availableColors.RemoveAt(randomColorIndex);

            player.name = "Player" + (i + 1);

            player.GetComponent<PlayerConfiguration>().grid = grid;
        }

        if (players.Count != 0)
        {
            currentPlayer = players[currentPlayerNumber - startNumber];
            currentPlayer.gameObject.SetActive(true);
            colorImage.color = currentPlayer.color;
        }
    }

    public void endTurn()
    {
        currentPlayerNumber++;
        if (currentPlayerNumber > players.Count)
        {
            currentPlayerNumber = startNumber;
        }
        currentPlayer.gameObject.SetActive(false);
        currentPlayer = players[currentPlayerNumber - startNumber];
        currentPlayer.gameObject.SetActive(true);

        colorImage.color = currentPlayer.color;
    }
}
