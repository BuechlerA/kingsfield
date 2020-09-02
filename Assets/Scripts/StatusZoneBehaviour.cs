using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusZoneBehaviour : MonoBehaviour
{
    public float changeAmount = 0f;
    private Coroutine changeRoutine;

    private void OnTriggerEnter(Collider other)
    {
        changeRoutine = StartCoroutine(Damager(changeAmount, other));
    }
    
    private void OnTriggerExit()
    {
        StopCoroutine(changeRoutine);
    }

    private IEnumerator Damager(float dmg, Collider collider)
    {
        float totalDamage = 0f;
        while (true)
        { 
            yield return new WaitForSeconds(1.3f);
            collider.GetComponent<PlayerStatus>().TakeDamage(dmg);
            yield return null;
            totalDamage += dmg;
            Debug.Log("total damage cause: " + totalDamage);
        }
    }
}
