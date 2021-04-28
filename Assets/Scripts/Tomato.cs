using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : Food
{


    public override Object pick()
    {
        this.gameObject.transform.position = new Vector3(0, -100, 0);
        StartCoroutine(Deactivate());
        return this;
    }
    public override void leave(Object o)
    {

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

