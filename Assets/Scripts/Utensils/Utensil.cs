using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Utensil : Object
{

    protected GameObject go;

    public override GameObject pick()
    {
        return gameObject;
    }

    
    public override void move(Vector3 pos) {
        transform.position = pos;
        if (go != null) ((Food)go.GetComponent(typeof(Food))).move(pos + new Vector3(0.0f, 0.05f, 0.0f));
    }
    public override void leave(Vector3 pos)
    {
        transform.position = pos + new Vector3(0.0f, 0.05f, 0.0f);
        if (go != null) ((Food)go.GetComponent(typeof(Food))).leave(pos);
    }

    public GameObject getOut()
    {
        if (go == null) return null;
        GameObject ret = ((Food)go.GetComponent(typeof(Food))).pick();
        go = null;
        return ret;
    }

    public GameObject get()
    {
        if (go == null) return null;
        GameObject ret = ((Food)go.GetComponent(typeof(Food))).pick();
        return ret;
    }

    public virtual bool put(GameObject o)
    {
        if (go != null) return false;
        go = o;
        ((Food)go.GetComponent(typeof(Food))).leave(transform.position);
        return true;
    }

    public abstract bool action();

}