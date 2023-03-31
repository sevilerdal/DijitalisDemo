using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowFilter : PersistentSingleton<GlowFilter>
{
    private List<Renderer> renderers = new List<Renderer>();
    private MaterialPropertyBlock matBlock;
    private bool isGlowing;
    public bool expFilOn, conFilOn, wghtFilOn;
    protected override void Awake()
    {
        base.Awake();
    }
    private void SetReferences(List<GameObject> obj)
    {
        // Clearing list to prevent overriding previous filters
        renderers.Clear();
        // Get renderer of objects to change color of
        for (int i = 0; i < obj.Count; i++)
        {
            renderers.Add(obj[i].GetComponent<Renderer>());
        }
    }

    public void GlowOn(Color color, List<GameObject> obj)
    {
        // Creating new material block
        matBlock = new MaterialPropertyBlock();
        SetReferences(obj);
        for (int i = 0; i < renderers.Count; i++)
        {
            renderers[i].GetPropertyBlock(matBlock);
            // Set color to glow
            matBlock.SetColor("_GlowColor", color);
            // Set glow value to turn on glow
            matBlock.SetFloat("_GlowStrength", 0.5f);
            // Apply block values to material
            renderers[i].SetPropertyBlock(matBlock);
        }
    }

    public void GlowOff(List<GameObject> obj)
    {
        // Creating new material block
        matBlock = new MaterialPropertyBlock();
        SetReferences(obj);

        for (int i = 0; i < renderers.Count; i++)
        {
            renderers[i].GetPropertyBlock(matBlock);
            // Set glow value to turn on glow
            matBlock.SetFloat("_GlowStrength", 0f);
            // Apply block values to material
            renderers[i].SetPropertyBlock(matBlock);
        }

    }
}
