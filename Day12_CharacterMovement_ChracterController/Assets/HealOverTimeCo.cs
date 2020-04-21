using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOverTimeCo : MonoBehaviour
{
    public GameObject healFX;

    bool isHealing = false;
    GameObject fx;

    public void Heal()
    {
        if (!isHealing)
        {
            StartCoroutine(Healing());
        }
    }

    IEnumerator Healing()
    {
        fx = Instantiate(healFX, transform.Find("FXPos"));
        isHealing = true;
        yield return new WaitForSeconds(1.9f);
        Destroy(fx);
        isHealing = false;
    }
}
