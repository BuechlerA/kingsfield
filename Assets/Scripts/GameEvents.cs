using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<string, string> OnZoneEntry = delegate { };
    public void ZoneEntry(string name, string sub)
    {
        OnZoneEntry?.Invoke(name, sub);
    }
}
