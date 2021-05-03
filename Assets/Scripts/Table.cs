using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Furniture
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override GameObject pick()
    {
        GameObject ret = o;
        o = null;
        return ret;
    }

    public override bool leave(GameObject ob)
    {
        if (o != null) return false;
        o = ob;
        ((Object)o.GetComponent(typeof(Object))).leave(transform.position + new Vector3(0.0f,1.0f,0.0f));
        return true;
    }
}
