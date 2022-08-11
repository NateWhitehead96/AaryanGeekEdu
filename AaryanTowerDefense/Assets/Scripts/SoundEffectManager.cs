using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager instance; // saved instance of this script

    private void Awake() // singleton design pattern to make sure there is only 1 sound manager
    {
        if(instance != null) // if there is already a sound effect manager in the scene
        {
            Destroy(gameObject); // get rid of this one
        }
        else // we dont have a sound manager yet
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // dont destroy this sound manager
        }
    }

    public AudioSource ArrowShoot;
    public AudioSource CannonShoot;
    public AudioSource ArcaneShoot;
    public AudioSource EnemyDie;
    public AudioSource NextWave;

    public float volume; // help with volume
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // updates the volume of our sound effects
        ArrowShoot.volume = volume;
        CannonShoot.volume = volume;
        ArcaneShoot.volume = volume;
        EnemyDie.volume = volume;
        NextWave.volume = volume;
    }
}
