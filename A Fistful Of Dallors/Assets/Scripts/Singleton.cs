﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
                Debug.Log("NULL Exception");
            return instance;
        }

    }
    
}
