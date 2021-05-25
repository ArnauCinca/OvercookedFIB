using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : Furniture
{
    public override bool action()
    {
        if (o == null || o.GetComponent(typeof(Oven_Tray)) == null) return false; //for now... (if there are a utensil attach to it)
        return ((Utensil)o.GetComponent(typeof(Oven_Tray))).action();
    }
}
