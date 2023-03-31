using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    // Instead of calling camera.main numerous times, this method calls it once 
    // Can be called everywhere in project
    private static Camera _camera;
    public static Camera Camera
    {
        get
        {
            if (_camera == null) _camera = Camera.main;
            return _camera;
        }
    }

    // To increase performance and decrease allocation
    // this method does not create a yield new wait if it already exists
    // reuses already existing ones instead
    private static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new Dictionary<float, WaitForSeconds>();
    public static WaitForSeconds GetWait(float time)
    {
        if (WaitDictionary.TryGetValue(time, out var wait)) return wait;

        WaitDictionary[time] = new WaitForSeconds(time);
        return WaitDictionary[time];
    }
}
