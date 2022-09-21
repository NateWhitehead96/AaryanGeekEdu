using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // give access to ai stuff

public class AIEnemy : MonoBehaviour
{
    public NavMeshAgent agent; // thing that controls the AI
    public Transform player; // player will be the target of our AI

    public int health; // how much health does ai man have
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform; // link player to the player in the scene
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position); // make the enemy move towards our player

        if(health <= 0)
        {
            Destroy(gameObject); // destroy the enemy if its health is 0
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>()) // bullet collides with enemy
        {
            health -= 1; // deal damage
            Destroy(collision.gameObject);
        }
    }
}
