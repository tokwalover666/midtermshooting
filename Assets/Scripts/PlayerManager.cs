using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject Bullet;
    public Transform BulletSpawn;
    public float BulletSpeed;

    public float BulletFireRate;
    private float BaseBulletFireRate;

    public Transform TargetPlayer;
    public float RotationSpeed = 0.9f;
    Quaternion rotate;
    Vector3 direction;

    public float Range;
    public GameObject GameOver;
    public GameObject Player;

    void Start()
    {
        BaseBulletFireRate = BulletFireRate;
        GameOver.SetActive(false);
        Player.SetActive(true);



    }


    void Update()
    {
/*        Vector3 EnemyDirection = Enemy.position - Player.position;
        EnemyDirection.z = 0;

        Quaternion targetRotation = Quaternion.LookRotation(EnemyDirection);
        Player.rotation = Quaternion.Slerp(Player.rotation, targetRotation, Time.deltaTime * RotationSpeed);

*/

        BulletFireRate -= Time.deltaTime;
    if (BulletFireRate <= 0)
        {
            Shoot();

        }
        /*        if (Input.GetButtonDown("Fire1"))
                {
                    Shoot();
                }*/
        RotateToNearestEnemy();

    }
    private void RotateToNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float closestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);

            if (dist <= Range && dist < closestDistance)
            {
                closestDistance = dist;
                nearestEnemy = enemy.transform;
            }
        }

        if (nearestEnemy != null)
        {
            direction = (nearestEnemy.position - transform.position).normalized;
            rotate = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotate, RotationSpeed * Time.deltaTime);
        }
    }



    void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
 //       bulletRB.angularVelocity = Vector3.zero;
        bulletRB.AddForce(BulletSpawn.forward * BulletSpeed, ForceMode.Impulse);
        BulletFireRate = BaseBulletFireRate;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            GameOver.SetActive(true);
            Player.SetActive(false);
            Debug.Log("enemy reached player");
        }


    }
    private void OnDrawGizmos()
    {
       Gizmos.color = Color.green;
       Gizmos.DrawWireSphere(transform.position, Range);
    }



/*    private void OnMouseDown()
    {
        rend.material.color = colors[Random.Range(0,colors.Length)];
    }*/
}
