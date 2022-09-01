using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isOccupied; // to know if a tower is occupying this tile
    public Color unoccupiedColor;
    public Color occupiedColor;
    public SpriteRenderer sprite; // access to sprites color
    public ProjType type; // to know the type of tower on this tile
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // auto grabs the sprite renderer
    }

    // Update is called once per frame
    void Update()
    {
        if(isOccupied == true) // when a tower is on it
        {
            sprite.color = occupiedColor;
        }
        if(isOccupied == false) // when a tower is not
        {
            sprite.color = unoccupiedColor;
        }
    }
}
