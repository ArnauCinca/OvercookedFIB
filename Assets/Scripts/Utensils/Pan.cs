using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : Utensil
{
    public override bool action()
    {
        if (go == null) return false;
        if (go.GetComponent(typeof(Food)) == null) return false;
        initCooking();
        return true;
        /*if (go == null) return false;
        GameObject obj = ((Food)go.GetComponent(typeof(Food))).cook_stove();
        if (obj == null) return false;

        Destroy(go);
        go = null;
        go = obj;
        return true;*/
    }

    //AIXO TAMPOC VA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public override bool cookFood() {
        GameObject obj = ((Food)go.GetComponent(typeof(Food))).cook_stove();
        if (obj == null) return false;
        Destroy(go);
        go = null;
        go = obj;
        return true;
    }
}
