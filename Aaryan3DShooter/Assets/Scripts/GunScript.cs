using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float xRotation; // rotation on x axis
    public float rotationSpeed; // how fast we look up and down
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // keep our cursor in the middle of our screen
        Cursor.visible = false; // hides the cursor
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun(); // rotate up and down
    }

    public void RotateGun()
    {
        float mouseY = Input.GetAxisRaw("Mouse Y"); // get the mouse y position
        xRotation = mouseY * rotationSpeed * Time.deltaTime; // set our x rotation
        Vector3 gunRotation = transform.rotation.eulerAngles; // store the guns rotations
        gunRotation.x -= xRotation; // set the rotations
        transform.rotation = Quaternion.Euler(gunRotation); // apply to our gun
    }
}
