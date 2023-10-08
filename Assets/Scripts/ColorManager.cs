using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public Renderer rend;
    public MeshRenderer meshRenderer;
    public Material[] color;

    public int CurrentColor = 0;

    public static Color[] availableColors;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
 //       meshRenderer = GetComponentInChildren<MeshRenderer>();
       meshRenderer = GetComponentInChildren<MeshRenderer>();


        
    }
    public Material GetCurrentColorMaterial()
    {
        return color[CurrentColor];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ChangeColor();
            Debug.Log("change");
        }
    }


    void ChangeColor()
    {
        CurrentColor = (CurrentColor + 1) % color.Length;
        rend.material = color[CurrentColor];
    }

 
}
