using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Furniture : MonoBehaviour
{
    public GameObject spawnObject;
    protected GameObject o;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnObject != null)
            o = Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject getObject() {
        return o;
    }

    public virtual GameObject pick()
    {
        GameObject ret = o;
        o = null;
        return ret;
    }

    public virtual bool leave(GameObject ob)
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
    public abstract bool action();

}
