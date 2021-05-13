using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : Utensil
{


    public override GameObject pick()
    {
        return gameObject;
    }
    public override void leave(Vector3 pos)
    {
        transform.position = pos + new Vector3(0.0f, 0.05f, 0.0f);
    }


    public override GameObject get() 
    {
        if (go == null) return null;
        GameObject ret = ((Food)go.GetComponent(typeof(Food))).pick();
        go = null;
        return ret;
    }


    public override bool put(GameObject o)
    {
        if(go != null) return false;
        go = o;
        ((Food)go.GetComponent(typeof(Food))).leave(transform.position);
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
