using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiletManager : Spawner
{
    private static BuiletManager instance;
    public static BuiletManager Instance => instance;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

}
