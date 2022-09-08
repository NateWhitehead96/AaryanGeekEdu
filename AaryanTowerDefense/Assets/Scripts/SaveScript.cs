using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public GameManager manager; // access to all of it's variables
    public GameObject ArrowTower; // variables for what towers to create
    public GameObject CannonTower;
    public GameObject ArcaneTower;
    public GameObject LightningTower;
    private void Start()
    {
        LoadGame(); // when we open up play scene load our data
    }
    public void SaveGame() // save all of our play scene stuff
    {
        PlayerPrefs.SetInt("Gold", manager.gold); // save our gold amount to a tag called gold
        PlayerPrefs.SetInt("Lives", manager.lives); // save lives
        for (int i = 0; i < manager.tiles.Length; i++)
        {
            if(manager.tiles[i].isOccupied == true) // if the tile is occupied
            {
                PlayerPrefs.SetInt("Tile" + i, 1); // save it as a 1 meaning it has tower
                if(manager.tiles[i].type == ProjType.Arrow)
                {
                    PlayerPrefs.SetInt("Type" + i, 0); // save that type is arrow
                }
                if (manager.tiles[i].type == ProjType.Cannon)
                {
                    PlayerPrefs.SetInt("Type" + i, 1); // save that type is Cannon
                }
                if (manager.tiles[i].type == ProjType.Lightning)
                {
                    PlayerPrefs.SetInt("Type" + i, 2); // save that type is Lightning
                }
                if (manager.tiles[i].type == ProjType.Arcane)
                {
                    PlayerPrefs.SetInt("Type" + i, 3); // save that type is Arcane
                }
            }
            else
            {
                PlayerPrefs.SetInt("Tile" + i, 0); // the tile saves as unoccupied
            }
        }
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Gold")) // check to see if we have any save data
        {
            manager.gold = PlayerPrefs.GetInt("Gold"); // apply the saved gold amount to our gold
            manager.lives = PlayerPrefs.GetInt("Lives"); // apply lives
            for (int i = 0; i < manager.tiles.Length; i++)
            {
                if(PlayerPrefs.GetInt("Tile" + i) == 0) // if any tile has a 0 then
                {
                    manager.tiles[i].isOccupied = false; // make it unoccupied
                }
                else
                {
                    manager.tiles[i].isOccupied = true;
                    if(PlayerPrefs.GetInt("Type" + i) == 0)
                    {
                        manager.tiles[i].type = ProjType.Arrow;
                        Instantiate(ArrowTower, manager.tiles[i].transform.position, manager.tiles[i].transform.rotation);
                        // spawn or create the tower thats approriate for this spot
                    }
                    if (PlayerPrefs.GetInt("Type" + i) == 1)
                    {
                        manager.tiles[i].type = ProjType.Cannon;
                        Instantiate(CannonTower, manager.tiles[i].transform.position, manager.tiles[i].transform.rotation);
                        // spawn or create the tower thats approriate for this spot
                    }
                    if (PlayerPrefs.GetInt("Type" + i) == 2)
                    {
                        manager.tiles[i].type = ProjType.Lightning;
                        Instantiate(LightningTower, manager.tiles[i].transform.position, manager.tiles[i].transform.rotation);
                        // spawn or create the tower thats approriate for this spot
                    }
                    if (PlayerPrefs.GetInt("Type" + i) == 3)
                    {
                        manager.tiles[i].type = ProjType.Arcane;
                        Instantiate(ArcaneTower, manager.tiles[i].transform.position, manager.tiles[i].transform.rotation);
                        // spawn or create the tower thats approriate for this spot
                    }
                }
            }
        }
    }
}
