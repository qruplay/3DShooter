﻿using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    
    private void Update()
    {
        
    }
}
