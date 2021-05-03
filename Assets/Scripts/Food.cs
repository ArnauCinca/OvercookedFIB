
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Food : Object
{


    public abstract override GameObject pick();
    public abstract override void leave(Vector3 pos);

    public abstract override bool cut();
    public abstract override bool cook_oven();
    public abstract override bool cook_stove();
}
