using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField]public AudioSource sound; // sound this gameobject makes aka music
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>(); // links the component to the variable
    }

    // Update is called once per frame
    void Update()
    {
        sound.volume = SoundEffectManager.instance.volume;
    }
}
