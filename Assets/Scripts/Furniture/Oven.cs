using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : Furniture
{

    public override bool action(GameObject go)
    {
        if (hasFire() && go != null && go.GetComponent(typeof(Fire_Extinguisher)) != null) StopFire();
        isWorking = !isWorking;
        if (o != null && o.GetComponent(typeof(Oven_Tray)) != null) {
            ((Utensil)o.GetComponent(typeof(Oven_Tray))).action_aux(isWorking);
        }
        return true;
    }
}
