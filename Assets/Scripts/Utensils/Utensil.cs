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
        transform.position = pos;
        if (go != null) ((Food)go.GetComponent(typeof(Food))).leave(pos + new Vector3(0.0f, 0.05f, 0.0f));
    }

    public GameObject get()
    {
        if (go == null) return null;
        GameObject ret = go;
        go = null;
        return ret;
    }

    public virtual bool put(GameObject o)
    {
        if (go != null) return false;
        go = o;
        ((Food)go.GetComponent(typeof(Food))).leave(transform.position + new Vector3(0.0f, 0.05f, 0.0f));
        return true;
    }
    public bool hasFood()
    {
        return go != null;
    }

    public abstract bool action();

}