using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int cost; // how much it costs
    public Tile tile; // what tile the tower/building is on

    public UpgradeSellCanvas canvas; // every tower knows and has access to this canvas
    public int damage; // this will be the towers damage, will help with upgrading

    public ProjType type; // helping us know what type of tower is on the tile
    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<UpgradeSellCanvas>(); // assign it automatically
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(canvas.selectedTower == null)
        {
            canvas.selectedTower = this; // assign this tower to the selected tower
            canvas.transform.position = transform.position + new Vector3(0, 1, 0); // move the canvas to our tower, with an offset to be up
        }
    }
}
