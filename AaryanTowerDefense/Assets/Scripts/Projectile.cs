using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjType
{
    Arrow,
    Cannon
}

public class Projectile : MonoBehaviour
{
    public Transform target; // the thing it's moving towards
    public float speed; // how fast it goes
    public ProjType type; // what type this projectile is
    public LayerMask layer; // to help with aoe damage
    public int damage; // how much damage the thing does
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (type == ProjType.Arrow) // if we're colliding with an enemy and we're an arrow do this
        {
            if (collision.gameObject.GetComponent<Enemy>())
            {
                collision.gameObject.GetComponent<Enemy>().health -= damage; // subtract damage
                Destroy(gameObject);
            }
        }
        if(type == ProjType.Cannon)
        {
            if (collision.gameObject.GetComponent<Enemy>())
            {
                // creating a small blast radius around the enemy we collide with. We add all those enemies to this temp arry
                Collider2D[] enemiesInBlast = Physics2D.OverlapCircleAll(collision.transform.position, 1, layer);
                for(int i = 0; i < enemiesInBlast.Length; i++) // loop through enemies in blast
                {
                    enemiesInBlast[i].GetComponent<Enemy>().health -= damage; // subtract 1 damage from all enemies
                    Destroy(gameObject); 
                }
            }
        }
    }
}
