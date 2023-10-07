using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;
    public Transform EnemySpawnPoint;
    public float SpawnInterval = 2.0f;

    private float NextSpawnTime;


    private EnemyColorManager enemyColorManager;
    // Start is called before the first frame update
    void Start()
    {

        enemyColorManager = GameObject.FindGameObjectWithTag("Player").GetComponent<EnemyColorManager>();
    
}

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= NextSpawnTime)
        {
            Spawn();
            NextSpawnTime = Time.time + SpawnInterval;
        }
    }

    void Spawn()
    {
        GameObject Enemy = Instantiate(enemy, EnemySpawnPoint.position, EnemySpawnPoint.rotation);

   
/*        Renderer enemyRenderer = enemy.GetComponent<Renderer>();

        Color[] availableColors = ColorManager.availableColors;
        int randomColorIndex = Random.Range(0, availableColors.Length);
        Color randomColor = availableColors[randomColorIndex];

        Renderer rend = enemy.GetComponent<Renderer>();
        enemyRenderer.material.color = Color.red;
*/
    }


}
