using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : Utensil
{
    public override bool action()
    {
        if (go == null) return false;
        GameObject obj = ((Food)go.GetComponent(typeof(Food))).cook_stove();
        if (obj == null) return false;

        Destroy(go);
        go = null;
        go = obj;
        return true;
    }
}
