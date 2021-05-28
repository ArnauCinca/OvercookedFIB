using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Furniture
{
    public override bool action()
    {
        isWorking = !isWorking;
        if (o != null && o.GetComponent(typeof(Pan)) != null)
        {
            ((Utensil)o.GetComponent(typeof(Pan))).action_aux(isWorking);
        }
        return true;
    }

}
