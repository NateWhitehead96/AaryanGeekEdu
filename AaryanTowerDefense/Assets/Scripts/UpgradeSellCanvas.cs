using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSellCanvas : MonoBehaviour
{
    public Building selectedTower; // help us know what tower was selected
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade()
    {
        if(FindObjectOfType<GameManager>().gold >= selectedTower.cost * 2)
        {
            selectedTower.damage *= 2; // buff the towers damage by 1
            FindObjectOfType<GameManager>().gold -= selectedTower.cost * 2; // payment
        }
        selectedTower = null;
        transform.position = new Vector3(100, 100, 0); // move the canvas off screen
    }

    public void Sell()
    {
        if(selectedTower != null)
        {
            FindObjectOfType<GameManager>().gold += selectedTower.cost; // refund of the tower
            selectedTower.tile.isOccupied = false; // reset tile
            Destroy(selectedTower.gameObject); // destroy the whole tower
            selectedTower = null; // reset our selected tower
        }
        transform.position = new Vector3(100, 100, 0); // move the canvas off screen
    }

    public void CloseUI()
    {
        selectedTower = null;
        transform.position = new Vector3(100, 100, 0); // move the canvas off screen
    }
}
