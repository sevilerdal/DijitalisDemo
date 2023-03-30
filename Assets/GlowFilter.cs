using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowFilter : MonoBehaviour
{
    private Renderer _renderer;
    private MaterialPropertyBlock matBlock;
    private bool isGlowing;
    private void Awake()
    {
        // Creating new material block
        matBlock = new MaterialPropertyBlock();
    }
    private void SetReferences(GameObject obj)
    {
        // Get renderer of object to change color of
        _renderer = obj.GetComponent<Renderer>();

        // Clearing previous values of block
        matBlock.Clear();
    }

    public void GlowOn(Color color, GameObject obj)
    {
        if (!isGlowing) // Checking if object is glowing
        {
            isGlowing = true;
            //Get renderer of current object and reset prev. values
            SetReferences(obj);
            _renderer.GetPropertyBlock(matBlock);
            // Set color to glow
            matBlock.SetColor("_GlowColor", color);
            // Set glow value to turn on glow
            matBlock.SetFloat("_GlowStrength", 0.5f);
            // Apply block values to material
            _renderer.SetPropertyBlock(matBlock);
        }
    }

    public void GlowOff(GameObject obj)
    {
        if (isGlowing) // Checking if object is glowing
        {
            isGlowing = false;

            //Get renderer of current object and reset prev. values
            SetReferences(obj);
            _renderer.GetPropertyBlock(matBlock);
            // Set glow value to 0
            matBlock.SetFloat("_GlowStrength", 0f);
            // Apply block to material
            _renderer.SetPropertyBlock(matBlock);
        }
    }
}
