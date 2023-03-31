using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CreationAnimation : MonoBehaviour
{
    public float duration = 1f; // duration of the tween in seconds
    public Renderer _renderer;
    private string propertyName = "_GlowStrength"; // name of the float property in the Material Property Block

    private MaterialPropertyBlock propBlock;
    private float currentValue, startValue, endValue;

    void Start()
    {
        startValue = 0.5f;
        endValue = 0f;


    }
    public void AnimateObj(GameObject obj)
    {
        _renderer = obj.GetComponent<Renderer>();
        propBlock = new MaterialPropertyBlock();
        _renderer.GetPropertyBlock(propBlock);
        currentValue = startValue;

        // create the tween and start it immediately
        DOTween.To(() => startValue, x =>
        {
            currentValue = x;
            propBlock.SetFloat(propertyName, currentValue);
            _renderer.SetPropertyBlock(propBlock);
        }, endValue, duration).SetLoops(3, LoopType.Yoyo);
    }


}
