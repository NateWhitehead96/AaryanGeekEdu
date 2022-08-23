using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAim : MonoBehaviour
{
    public GameObject projectile; // what the tower is firing
    public List<GameObject> enemiesInRange; // list of enemies that come inside our attack radius
    public float reloadTime; // how long it takes to shoot
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesInRange.Count <= 0) return; // if theres no enemies around dont do any other code
        for(int i = 0; i < enemiesInRange.Count; i++) // loop through and remove any dead enemies
        {
            if(enemiesInRange[i] == null)
            {
                enemiesInRange.RemoveAt(i);
            }
        }

        if(timer >= reloadTime) // time to shoot
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation); // spawning projectile
            newProjectile.GetComponent<Projectile>().target = enemiesInRange[0].transform; // set the target for the projectile
            newProjectile.GetComponent<Projectile>().damage = GetComponent<Building>().damage; // assign damage from tower to projectile
            newProjectile.GetComponent<Projectile>().towerThatShot = this; // assign the tower that shot to this gameobject
            timer = 0; // reset timer
        }
        timer += Time.deltaTime; // always count time up

        Vector3 lookDirection = enemiesInRange[0].transform.position - transform.position; // find the vector between us and the enemy
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f; // find the angle to rotate
        transform.rotation = Quaternion.Euler(0, 0, angle); // apply the rotation
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>()) // when an enemy enters our attack radius, add to our enemy list
        {
            enemiesInRange.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>()) // when an enemy leaves the attach radius, remove from list
        {
            enemiesInRange.Remove(collision.gameObject);
        }
    }
}
