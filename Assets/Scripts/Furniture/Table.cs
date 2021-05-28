using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Furniture
{
    // Start is called before the first frame update
    public void Start()
    {
        fire = null;
        if (spawnObject != null)
            o = Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z), Quaternion.identity);
    }
    public override bool action(GameObject go)
    {
        if(o == null || o.GetComponent(typeof(Cutter)) == null) return false; //for now... (if there are a utensil attach to it)
        return ((Utensil)o.GetComponent(typeof(Cutter))).action();
    }
}
