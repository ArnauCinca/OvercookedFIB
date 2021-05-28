using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : Utensil
{
    public override bool action()
    {
        playerMovement.initDelay();
        if (go == null) return false;
        GameObject obj = ((Food)go.GetComponent(typeof(Food))).cut();
        if (obj == null) return false;
        source.Play();
        Destroy(go);
        go = null;
        go = obj;
        return true;
    }
    public override void action_aux(bool isWorking)
    {
        
    }

}
