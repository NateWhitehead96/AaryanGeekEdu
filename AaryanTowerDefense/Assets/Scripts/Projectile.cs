using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjType
{
    Arrow,
    Cannon,
    Arcane,
    Lightning
}

public class Projectile : MonoBehaviour
{
    public Transform target; // the thing it's moving towards
    public float speed; // how fast it goes
    public ProjType type; // what type this projectile is
    public LayerMask layer; // to help with aoe damage
    public int damage; // how much damage the thing does

    // Arcane tower variables
    float timer;

    // lightning tower variables
    public TowerAim towerThatShot; // the tower that has shot this projectile
    public List<GameObject> enemies; // all the enemies the projectile can bounce to
    public int currentEnemy; // the current target
    // Start is called before the first frame update
    void Start()
    {
        if(type == ProjType.Arrow)
        {
            SoundEffectManager.instance.ArrowShoot.Play();
        }
        if(type == ProjType.Cannon)
        {
            SoundEffectManager.instance.CannonShoot.Play();
        }
        if (type == ProjType.Arcane)
        {
            SoundEffectManager.instance.ArcaneShoot.Play();
        }
        if(type == ProjType.Lightning)
        {
            // play sound
            enemies = towerThatShot.enemiesInRange; // store all of the enemies near the tower into a list on the projectile
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (type == ProjType.Arcane)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime); // move it forward
            timer += Time.deltaTime;
            if(timer >= 3) // life spawn of the bullet
            {
                Destroy(gameObject);
            }
        }
        else // if the proj is arrow or cannon, it still moves correctly
        {
            if (target == null)
            {
                target = transform; // assign the target to itself
                Destroy(gameObject); // safely destroy the object
            }

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>()) // check to see its hitting an enemy
        {
            if (type == ProjType.Arcane)
            {
                collision.gameObject.GetComponent<Enemy>().health -= damage; // deal dat damage
            }
            if(type == ProjType.Lightning)
            {
                collision.gameObject.GetComponent<Enemy>().health -= damage; // deal dat damage
                currentEnemy++; // target the next enemy
                if(currentEnemy >= enemies.Count) // we've hit the last enemy
                {
                    Destroy(gameObject);
                }
                else
                {
                    target = enemies[currentEnemy].transform; // assign a new target
                }
            }
        }
    }
}
