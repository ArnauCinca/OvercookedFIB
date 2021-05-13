using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Furniture
{
    public GameObject Pan;

    // Start is called before the first frame update
    void Start()
    {
        o = Instantiate(Pan, new Vector3(transform.position.x, transform.position.y + 1.05f, transform.position.z), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override GameObject pick()
    {
        GameObject ret = null;
        if (o == null) return null;
        //food
        if (o.GetComponent(typeof(Food)) != null)
        {
            ret = o;
            o = null;
        }
        else if (o.GetComponent(typeof(Utensil)) != null)
        {
            //empty utensil
            ret = ((Utensil)o.GetComponent(typeof(Utensil))).get();

            //full utensil
            if (ret == null)
            {
                ret = o;
                o = null;
            }


        }
        return ret;
    }

    public override bool leave(GameObject ob)
    {
        //nothing
        if (o == null)
        {
            o = ob;
            ((Object)o.GetComponent(typeof(Object))).leave(transform.position + new Vector3(0.0f, 1.0f, 0.0f));
            return true;
        }
        else
        {
            //food
            if (o.GetComponent(typeof(Food)) != null) return false;

            if (o.GetComponent(typeof(Utensil)) != null && ob.GetComponent(typeof(Food)) != null)
            {
                //empty utensil true
                //full utensil false
                return ((Utensil)o.GetComponent(typeof(Utensil))).put(ob);
            }
        }

        return false;
    }

    public override bool action()
    {
        if (o == null || o.GetComponent(typeof(Pan)) == null) return false; //for now... (if there are a utensil attach to it)
        return ((Utensil)o.GetComponent(typeof(Pan))).action();
    }
}
