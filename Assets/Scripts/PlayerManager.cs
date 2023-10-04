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
    public float RotationSpeed = .01f;
    Quaternion rotate;
    Vector3 direction;




    private Renderer rend;
    public Color[] colors;
    public Vector3 position;
    float radius;




    void Start()
    {
        BaseBulletFireRate = BulletFireRate;
        rend = GetComponent<Renderer>();

    }


    void Update()
    {
/*        Vector3 EnemyDirection = Enemy.position - Player.position;
        EnemyDirection.z = 0;

        Quaternion targetRotation = Quaternion.LookRotation(EnemyDirection);
        Player.rotation = Quaternion.Slerp(Player.rotation, targetRotation, Time.deltaTime * RotationSpeed);
*/
        direction = (TargetPlayer.position - transform.position).normalized;
        rotate = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, RotationSpeed);

        BulletFireRate -= Time.deltaTime;
        if (BulletFireRate <= 0)
        {
            Shoot();

        }
/*        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }*/
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
 //       bulletRB.angularVelocity = Vector3.zero;
        bulletRB.AddForce(BulletSpawn.forward * BulletSpeed, ForceMode.Impulse);
        BulletFireRate = BaseBulletFireRate;
    }

    private void OnDrawGizmos()
    {
       // Gizmos.color = Color.green;
       // Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnMouseDown()
    {
        rend.material.color = colors[Random.Range(0,colors.Length)];
    }
}
