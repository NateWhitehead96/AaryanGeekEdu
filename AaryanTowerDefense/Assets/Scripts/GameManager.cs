using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // grants access to UI classes

public class GameManager : MonoBehaviour
{
    public int gold; // games currancy to buy towers
    public Building towerToPlace; // the tower we want to place
    public CustomCursor customCursor; // access to the custom mouse cursor
    public Tile[] tiles; // grid or array of all of the tiles
    public int lives; // tell us how many lives we have;
    public Text livesDisplay; // show on our screen how many lives we have
    public Text waveDisplay; // show the user what wave they are on
    public Text goldDisplay; // text on how much gold we have
    public GameObject loseScreen; // reference to the lose screen canvas
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // always start the game with normal time
        customCursor.gameObject.SetActive(false); // hiding the custom cursor game object to start
        loseScreen.SetActive(false); // hide the lose screen
    }

    // Update is called once per frame
    void Update()
    {
        PlaceTower(); // placing tower
        goldDisplay.text = "Gold: " + gold; // display "Gold: XXXXX"
        livesDisplay.text = "Lives: " + lives; // display our lives "Lives: X"
        waveDisplay.text = "Wave: " + FindObjectOfType<EnemySpawner>().wave; // this will display "Wave: XX"
        if(lives == 0)
        {
            loseScreen.SetActive(true); // show lose screen
            Time.timeScale = 0; // pause our time
        }
    }

    public void PlaceTower()
    {
        if(Input.GetMouseButtonDown(0) && towerToPlace != null) // left clicking and we have a tower to place
        {
            Tile nearestTile = null; // this will hold our nearest tile to our mouse
            float nearestDistance = float.MaxValue; // this will store the nearest distance to the tile
            foreach(Tile tile in tiles) // loop through all of our tiles
            {
                // find distance between the tile and our mouse position
                float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if(distance < nearestDistance) // check if distance is the new lowest distance
                {
                    nearestDistance = distance; // make the nearest distance this distance
                    nearestTile = tile; // set nearest tile to be that tile that is closest
                }
            }
            if(nearestTile.isOccupied == false) // if the tile is not occupied
            {
                Building newTower = Instantiate(towerToPlace, nearestTile.transform.position, transform.rotation); // spawn the tower
                newTower.tile = nearestTile; // assign that tile
                nearestTile.isOccupied = true; // set that tile to be occupied
                towerToPlace = null; // reset our tower to place, make it nothing
                Cursor.visible = true; // bring back default cursor
                customCursor.gameObject.SetActive(false); // hide the custom cursor
            }
        }
        
    }

    public void BuyTower(Building tower) // function we put on buttons to buy our towers
    {
        if(gold >= tower.cost)
        {
            customCursor.gameObject.SetActive(true); // make the custom cursor visible
            customCursor.GetComponent<SpriteRenderer>().sprite = tower.GetComponent<SpriteRenderer>().sprite; // makes cursor same as tower
            Cursor.visible = false; // hide the defualt cursor

            gold -= tower.cost; // subtract the gold
            towerToPlace = tower; // set the tower we want to place to be this tower
        }
    }
}
