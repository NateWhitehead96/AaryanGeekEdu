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
        
        Vector3 gunRotation = transform.rotation.eulerAngles; // store the guns rotations
        gunRotation.x -= xRotation; // set the rotations
        gunRotation.x = (gunRotation.x > 180) ? gunRotation.x - 360 : gunRotation.x; // determine if the angle is going up or down
        gunRotation.x = Mathf.Clamp(gunRotation.x, -80, 80); // hopefully clamp rotation before applying rotation
        transform.rotation = Quaternion.Euler(gunRotation); // apply to our gun
        //LimitRotation();
    }

    private void LimitRotation() // use this to limit the rotations on our x-axis (up and down looking)
    {
        Vector3 gunRotation = transform.rotation.eulerAngles; // store our rotation
        gunRotation.x = (gunRotation.x > 180) ? gunRotation.x - 360 : gunRotation.x; // determine if the angle is going up or down
        gunRotation.x = Mathf.Clamp(gunRotation.x, -80, 80); // clamp the rotation
        transform.rotation = Quaternion.Euler(gunRotation); // apply rotation
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
