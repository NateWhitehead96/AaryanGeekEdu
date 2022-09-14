using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float xRotation; // rotation on x axis
    public float rotationSpeed; // how fast we look up and down
    public GameObject bullet; // access to the bullet prefab
    public Transform shootPoint; // where the bullet spawns
    public float shootForce; // how fast the bullet can travel
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
        Shoot(); // pow pow blam blam
    }

    public void RotateGun()
    {
        float mouseY = Input.GetAxisRaw("Mouse Y"); // get the mouse y position
        xRotation = mouseY * rotationSpeed * Time.deltaTime; // set our x rotation
        if(transform.rotation.eulerAngles.x >= 80) // when the gun is at 80 degrees
        {
            //xRotation = 80;
            transform.rotation = Quaternion.Euler(80, 0, 0); // keep it at 80 degrees on the x axis
        }
        if(transform.rotation.eulerAngles.x <= -80)
        {
            //xRotation = -80;
            transform.rotation = Quaternion.Euler(-80, 0, 0); // keep it at 80 degrees on the x axis
        }
        Vector3 gunRotation = transform.rotation.eulerAngles; // store the guns rotations
        gunRotation.x -= xRotation; // set the rotations
        transform.rotation = Quaternion.Euler(gunRotation); // apply to our gun
    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0)) // when we hit the left mouse button
        {
            GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation); // spawn the bullet and store it in newBullet
            newBullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce, ForceMode.Impulse); // add force to bullet
        }
    }
}
