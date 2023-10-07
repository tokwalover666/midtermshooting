using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColorManager : MonoBehaviour
{
    public Color[] enemyColors;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        // Assign a random color from the possibleColors array
        var player = GameObject.FindGameObjectWithTag("Player");
        var colorManager = player.GetComponent<ColorManager>();
        var currentColor = colorManager.color[colorManager.CurrentColor];

        rend.material.color = enemyColors[Random.Range(0, enemyColors.Length)];
    }

    public Color GetCurrentColor()
    {
        return rend.material.color;
    }
}