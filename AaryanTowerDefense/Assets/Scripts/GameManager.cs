using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gold; // games currancy to buy towers
    public Building towerToPlace; // the tower we want to place
    public CustomCursor customCursor; // access to the custom mouse cursor
    public Tile[] tiles; // grid or array of all of the tiles
    // Start is called before the first frame update
    void Start()
    {
        customCursor.gameObject.SetActive(false); // hiding the custom cursor game object to start
    }

    // Update is called once per frame
    void Update()
    {
        
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
