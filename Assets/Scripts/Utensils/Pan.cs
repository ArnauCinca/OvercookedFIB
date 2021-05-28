using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : Utensil
{
    public override bool action()
    {
        return true;
    }

    public override GameObject cookFood() {
        return ((Food)go.GetComponent(typeof(Food))).cook_stove();
    }

    public override void action_aux(bool isWorking)
    {
        base.action_aux(isWorking);
    }

}
