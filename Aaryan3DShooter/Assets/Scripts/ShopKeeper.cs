using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public GameObject shopWindow; // show and hide the shop UI
    public GameObject playerHUD; // in case we want to show and hide this
    public PlayerStats gun; // need access to our "current gun" so it wont shoot while talking to shop
    // Start is called before the first frame update
    void Start()
    {
        shopWindow.SetActive(false); // hide the shop window at start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>()) // if the player touches shop keeper
        {
            shopWindow.SetActive(true); // show shop
            //playerHUD.SetActive(false); // hide playerhud (optional)
            Cursor.lockState = CursorLockMode.None; // unlock our mouse so we can click on buttons
            gun.currentGun.talkingToShop = true; // stop us from shooting
            Cursor.visible = true; // show mouse
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>()) // if the player leaves shop keeper
        {
            shopWindow.SetActive(false); // hide shop
            //playerHUD.SetActive(true); // show playerhud (optional)
            Cursor.lockState = CursorLockMode.Locked; // relock our mouse so we can shoot
            gun.currentGun.talkingToShop = false; // be able to shooty mcShoot
            Cursor.visible = false; // hide mouse
        }
    }

    public void BuyPistolAmmo()
    {
        if(gun.money >= 5) // if we have enough money
        {
            gun.money -= 5; // subtract money
            gun.currentGun.totalAmmo += 10; // add the ammo
        }
    }
}
