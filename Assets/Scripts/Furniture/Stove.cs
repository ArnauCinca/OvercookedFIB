using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Furniture
{

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        gameObject.transform.GetChild(0).gameObject.SetActive(!isWorking);
        gameObject.transform.GetChild(1).gameObject.SetActive(isWorking);
    }
    public override bool action(GameObject go)
    {
        if (hasFire() && go != null && go.GetComponent(typeof(Fire_Extinguisher)) != null) StopFire();
        isWorking = !isWorking;
        if (o != null && o.GetComponent(typeof(Pan)) != null)
        {
            ((Utensil)o.GetComponent(typeof(Pan))).action_aux(isWorking);
        }
        return true;
    }

}
