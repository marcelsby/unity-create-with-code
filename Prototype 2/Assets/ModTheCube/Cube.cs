using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float rotationRangeY;
    private Material material;
    private Color[] colorPalette;
    private float lastColorChange;
    private Color actualColor;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        // Initialize class variables
        colorPalette = GetColorPalette();
        material = Renderer.material;

        ChangeToRandomColor();
    }

    void Update()
    {
        float randomRotationY = Random.Range(-rotationRangeY, rotationRangeY);
        transform.Rotate(20.0f * Time.deltaTime, randomRotationY * Time.deltaTime, 0.0f);

        float timeDifferenceFromLastColorChange = Time.time - lastColorChange;

        if (timeDifferenceFromLastColorChange >= Random.Range(1.0f, 3.0f))
            ChangeToRandomColor();
    }

    private void ChangeToRandomColor()
    {
        Color newColor = GetRandomColor();
        actualColor = newColor;

        material.color = actualColor;

        lastColorChange = Time.time;
    }

    private Color GetRandomColor()
    {
        int randomColorIndex = Random.Range(0, colorPalette.Length);
        return colorPalette[randomColorIndex];
    }

    private Color[] GetColorPalette()
    {
        return new Color[5] {
            // Red
            new Color(0.996f, 0.003f, 0.101f),

            // Aqua
            new Color(0.003f, 0.694f, 0.631f),

            // Yellow
            new Color(1f, 0.772f, 0f),

            // Blue
            new Color(0f, 0.427f, 0.725f),

            // White
            new Color(0.980f, 0.980f, 0.984f),
        };
    }
}
