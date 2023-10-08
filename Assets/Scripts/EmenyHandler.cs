using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EmenyHandler : MonoBehaviour
{

    public float walkspeed = 0.10f;
    public float RotationSpeed = 0.1f ;


    public Transform TargetPlayer;

    Quaternion rotate;
    Vector3 direction;

    public Rigidbody rigidBody;
    public Renderer rend;
    public MeshRenderer meshRenderer;

    public GameObject GameOver;



    void Start()
    {
/*        meshRenderer = GetComponent<MeshRenderer>();
        var player = GameObject.FindGameObjectWithTag("Player");
        var colorManager = player.GetComponent<ColorManager>();
        var currentColor = colorManager.color[colorManager.CurrentColor];

        meshRenderer.material.color = currentColor;*/
        GameOver.SetActive(false);


    }

    void Update()
    {
        direction = (TargetPlayer.position - transform.position).normalized;
        rotate = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, RotationSpeed);


        transform.position = Vector3.MoveTowards(transform.position, TargetPlayer.position, walkspeed * Time.deltaTime);


    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {

            Debug.Log("Bullet hit enemy");
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameOver.SetActive(true);
        }



    }





}
