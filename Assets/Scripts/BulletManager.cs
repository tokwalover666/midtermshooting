using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Rigidbody rigidBody;
    public MeshRenderer meshRenderer;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        var player = GameObject.FindGameObjectWithTag("Player");
        var colorManager = player.GetComponent<ColorManager>();
        var currentColor = colorManager.color[colorManager.CurrentColor];

        rend.material = currentColor;
    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("bullet"))
        {
            EnemyColorManager enemyColorManager = collision.GetComponent<EnemyColorManager>();

            if (enemyColorManager != null)
            {
                Color enemyColor = enemyColorManager.GetCurrentColor();

                // Compare the colors of the bullet and enemy
                if (rend.material.color.Equals(enemyColor))
                {
                    Debug.Log("correct color");
                    Destroy(collision.gameObject);
                    Destroy(gameObject); // Destroy the bullet
                }
                else
                {
                    Debug.Log("wrong color");
                    Destroy(gameObject); // Destroy only the bullet
                }
            }
        }
    }

    // Update is called once per frame


}
