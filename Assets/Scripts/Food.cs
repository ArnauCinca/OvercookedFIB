
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Object
{
    public GameObject Cutted_Food;
    public GameObject Stove_Food;
    public GameObject Oven_Food;
    public bool deliverable;
    //public bool needPlate; TODO

    public override GameObject pick()
    {
        return gameObject;
    }
    public override void leave(Vector3 pos)
    {
        transform.position = pos + new Vector3(0.0f, 0.5f, 0.0f);
    }


    public GameObject cut()
    {
        if (Cutted_Food == null) return null;
        return Instantiate(Cutted_Food, transform.position, Quaternion.identity); ;
    }
    public GameObject cook_oven()
    {
        if (Oven_Food == null) return null;
        return Instantiate(Oven_Food, transform.position, Quaternion.identity); ;
    }

    public GameObject cook_stove()

    {
        if (Stove_Food == null) return null;
        return Instantiate(Stove_Food, transform.position, Quaternion.identity); ;
    }
    public GameObject combine(GameObject go)
    {
        return null; //TODO: Look possible combinations with prefabs tags
    }
    public bool deliver()
    {
        return deliverable;
    }
}

