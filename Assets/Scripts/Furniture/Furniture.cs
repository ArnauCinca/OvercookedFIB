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
        if(o != null && o.GetComponent(typeof(Utensil)) != null) {
            GameObject ret = o;
            o = null;
            return ret;
        }
        return null;
    }

    public virtual GameObject interact(GameObject go)
    {
        
        if (o != null)
        {
            if (o.GetComponent(typeof(Utensil)) != null)
            {
                bool hasFoodP = ((Utensil)go.GetComponent(typeof(Utensil))).hasFood();
                bool hasFoodF = ((Utensil)o.GetComponent(typeof(Utensil))).hasFood();

                if (hasFoodP)
                {
                    if (hasFoodF)                                                   //utensil & food - utensil & food
                    {
                        GameObject foodP = ((Utensil)go.GetComponent(typeof(Utensil))).get();
                        bool b = ((Utensil)o.GetComponent(typeof(Utensil))).put(foodP); //Try combine
                        if (b)
                        {
                            Destroy(foodP);
                        }
                        else { 
                            ((Utensil)go.GetComponent(typeof(Utensil))).put(foodP);
                        }

                    }
                    else                                                             //utensil & food - utensli
                    {
                        GameObject foodP = ((Utensil)go.GetComponent(typeof(Utensil))).get();
                        bool b = ((Utensil)o.GetComponent(typeof(Utensil))).put(foodP);
                    }
                }
                else
                {
                    if (hasFoodF)                                                   //utensil - uteensil & food
                    {
                        GameObject foodF = ((Utensil)o.GetComponent(typeof(Utensil))).get();
                        ((Utensil)go.GetComponent(typeof(Utensil))).put(foodF);
                    }
                    else;                                                           //utensil - utensil
                }

            }
            else if (o.GetComponent(typeof(Food)) != null)
            {
                bool hasFoodP = ((Utensil)go.GetComponent(typeof(Utensil))).hasFood();
                if (hasFoodP) { }                                                     //utensil & food - food
                else                                                                //utensil - food
                {
                    bool b = ((Utensil)go.GetComponent(typeof(Utensil))).put(o);
                    if (b)
                    {
                        o = null;
                    }
                }
            }
        }
        else //no food no utensil -> leave
        {
            o = go;
            ((Object)o.GetComponent(typeof(Object))).leave(transform.position + new Vector3(0.0f, 1.0f, 0.0f));
            return null;
        }

        return go;

    }

    /*public virtual bool leave(GameObject ob)
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
    }*/
    public abstract bool action();

}
