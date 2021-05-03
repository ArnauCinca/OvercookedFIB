
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Food : Object
{


    public abstract override GameObject pick();
    public abstract override void leave(Vector3 pos);

    public abstract void cut();
    public abstract void cook_oven();
    public abstract void cook_stove();
}
