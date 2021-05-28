using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Furniture
{
    // Start is called before the first frame update
    void Start()
    {
        if (spawnObject != null)
            o = Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override bool action()
    {
        if(o == null || o.GetComponent(typeof(Cutter)) == null) return false; //for now... (if there are a utensil attach to it)
        return ((Utensil)o.GetComponent(typeof(Cutter))).action();
    }
}
