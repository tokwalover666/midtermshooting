using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    private Renderer rend;
    private Material playerColor;
    public MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {               //color bullet
        rend = GetComponent<Renderer>();

        var player = GameObject.FindGameObjectWithTag("Player");
        var colorManager = player.GetComponent<ColorManager>();
        //var currentColor = colorManager.color[colorManager.CurrentColor];

        playerColor = colorManager.GetCurrentColorMaterial();



        rend.material = playerColor;

    }

/*    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("enemy"))
        {

            Renderer enemyRenderer = collision.GetComponent<Renderer>();
            Debug.Log("Enemy Material: " + enemyRenderer.material.name);
            Debug.Log("Bullet Material: " + playerColor.name);
            if (enemyRenderer != null)
            {
                Material enemyMaterial = enemyRenderer.material;

                Debug.Log("22222Enemy Material: " + enemyRenderer.material.name);
                Debug.Log("22222222222Bullet Material: " + playerColor.name);
                if (enemyMaterial == playerColor)
                {
                    Destroy(collision.gameObject);
                    Debug.Log("Enemy Destroyed");
                }
            }
        }

        Destroy(gameObject);
        Debug.Log("BOULET Destroyed");
    }*/




    // Update is called once per frame


}
