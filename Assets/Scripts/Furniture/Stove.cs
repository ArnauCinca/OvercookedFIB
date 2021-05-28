using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Furniture
{
    public override bool action(GameObject go)
    {
        if (hasFire() && go != null && go.GetComponent(typeof(Fire_Extinguisher)) != null) StopFire();
        isWorking = !isWorking;
        if (o != null && o.GetComponent(typeof(Pan)) != null)
        {
            ((Utensil)o.GetComponent(typeof(Pan))).action_aux(isWorking);
        }
        return true;
    }

}
