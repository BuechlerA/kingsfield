using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDStaminaDotsBehaviour : MonoBehaviour
{
    [SerializeField]
    private Image[] staminaDotFill;
    [SerializeField]
    private int staminaDotcount;

    private void Awake()
    {
        staminaDotFill = GetComponentsInChildren<Image>();
        staminaDotcount = staminaDotFill.Length;
    }

}
