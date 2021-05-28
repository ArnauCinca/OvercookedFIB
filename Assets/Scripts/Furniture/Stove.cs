using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Furniture
{
    // Start is called before the first frame update
    void Start()
    {
        if (spawnObject != null)
            o = Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(!isWorking);
        gameObject.transform.GetChild(1).gameObject.SetActive(isWorking);
    }
    public override bool action()
    {
        isWorking = !isWorking;
        if (o != null && o.GetComponent(typeof(Pan)) != null)
        {
            ((Utensil)o.GetComponent(typeof(Pan))).action_aux(isWorking);
        }
        return true;
    }

}
