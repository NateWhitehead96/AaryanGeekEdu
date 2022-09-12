using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // how fast we go
    public float jumpForce; // how high we can jump
    public Vector3 moveDirection; // help us know which direction to move in
    public Rigidbody rb; // our physics body

    public float yRotation; // help us rotate around the y axis 
    public float rotationSpeed; // how fast we rotate left and right
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(); // movement
        Rotate(); // rotation
    }

    public void Move() // movement code for the player
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // get any horizontal movements, A, D, Left/Right arrow, etc
        float vertical = Input.GetAxisRaw("Vertical"); // get our veritcal movements, W, S, Up/Down arrows
        moveDirection = (transform.forward * vertical) + (transform.right * horizontal); // calculate our move direction
        Vector3 force = moveDirection * speed * Time.deltaTime; // add speed and time to our move direction
        transform.position += force; // apply all of the stuff to our position
    }

    public void Rotate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X"); // get our x mouse position
        yRotation = mouseX * rotationSpeed * Time.deltaTime; // set our new y rotation
        Vector3 playerRotation = transform.rotation.eulerAngles; // store our current rotation
        playerRotation.y += yRotation; // set our y rotation
        transform.rotation = Quaternion.Euler(playerRotation); // reapply the rotation to our player
    }
}
