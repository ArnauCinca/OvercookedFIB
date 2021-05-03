using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : Food
{


    public override GameObject pick()
    {
        return gameObject;
    }
    public override void leave(Vector3 pos)
    {
        transform.position = pos;
    }
    public override void cut()
    {

    }
    public override void cook_oven()
    {

    }

    public override void cook_stove()
    {

    }

}

