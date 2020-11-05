using System;
using Data;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public MapData settings;

    private void Awake()
    {
        settings.Help();
        
    }
}
