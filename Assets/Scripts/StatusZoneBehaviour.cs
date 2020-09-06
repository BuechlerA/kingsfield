using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusZoneBehaviour : MonoBehaviour
{
    [SerializeField]
    private ZoneTypes zoneType;
    public float changeAmount;
    public float changeRate;
    private Coroutine changeRoutine;

    private void OnTriggerEnter(Collider other)
    {
        changeRoutine = StartCoroutine(Changer(changeAmount, other));
    }
    
    private void OnTriggerExit()
    {
        StopCoroutine(changeRoutine);
    }

    private IEnumerator Changer(float val, Collider collider)
    {
        while (true)
        { 
            yield return new WaitForSeconds(changeRate);
            if (zoneType == ZoneTypes.Damage)
            {
                collider.GetComponent<EntityBehaviour>().TakeDamage(val);
            }
            if (zoneType == ZoneTypes.Heal)
            {
                collider.GetComponent<EntityBehaviour>().Heal(val);
            }
            yield return null;
        }
    }

    enum ZoneTypes
    {
        Heal,
        Damage
    }
}
