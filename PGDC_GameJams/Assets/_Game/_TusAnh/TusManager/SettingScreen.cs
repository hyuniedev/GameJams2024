using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScreen : GenericSingleton<SettingScreen>
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
