using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldZonePanelBehaviour : MonoBehaviour
{
    public Text zoneNameText;
    public Text subNameText;

    private void Start()
    {
        GameEvents.current.OnZoneEntry += CurrentZoneEntry;
    }

    private void CurrentZoneEntry(string arg1, string arg2)
    {
        zoneNameText.text = arg1;
        subNameText.text = arg2;
    }
}
