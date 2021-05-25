using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : Utensil
{
    public override void leave(Vector3 pos)
    {
        transform.position = pos;
    }

    public override bool put(GameObject o)
    {
        if(go != null) return false;
        go = o;
        ((Food)go.GetComponent(typeof(Food))).leave(transform.position + new Vector3(0.0f, 0.05f, 0.0f));
        return true;
    }


    public override bool action()
    {
        if (go == null) return false;
        GameObject obj = ((Food)go.GetComponent(typeof(Food))).cut();
        if (obj == null) return false;

        Destroy(go);
        go = null;
        go = obj;
        return true;
    }
}
