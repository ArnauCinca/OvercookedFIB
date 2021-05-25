using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Furniture
{
    public override bool action()
    {
        if(o == null || o.GetComponent(typeof(Cutter)) == null) return false; //for now... (if there are a utensil attach to it)
        return ((Utensil)o.GetComponent(typeof(Cutter))).action();
    }
}
