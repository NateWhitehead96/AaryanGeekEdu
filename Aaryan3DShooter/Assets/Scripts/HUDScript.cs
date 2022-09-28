using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public Text healthText;
    public Text ammoText;
    public Text moneyText;
    public Text waveText;

    public PlayerStats player; // access to our stats
    public EnemySpawner spawner; // access to the wave number
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.health; // display player health
        ammoText.text = "Ammo: " + player.currentGun.currentClip + " / " + player.currentGun.totalAmmo; // display ammo
        moneyText.text = "Cash: $" + player.money; // display money
        waveText.text = "Wave: " + spawner.wave; // display the current wave
    }
}
