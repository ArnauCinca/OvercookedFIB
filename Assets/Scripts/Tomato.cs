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
    public override bool cut()
    {
        return false;
    }
    public override bool cook_oven()
    {
        return false;
    }

    public override bool cook_stove()
    {
        return false;
    }

}

