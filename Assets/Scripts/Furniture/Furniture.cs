using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Furniture : MonoBehaviour
{
    public GameObject spawnObject;
    protected GameObject o;
    public GameObject spawnFire;
    protected GameObject fire;
    public bool isWorking = false;

    // Start is called before the first frame update
    void Start()
    {
        fire = null;
        if (spawnObject != null)
            o = Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (isWorking) {
            if (o != null && o.GetComponent(typeof(Utensil)) != null) {
                GameObject foodP = ((Utensil)o.GetComponent(typeof(Utensil))).getFoodInfo();
                if (foodP != null) {
                    if (((Food)foodP.GetComponent(typeof(Food))).getType().Equals("burned_food")) {
                        StartFire();
                    }
                }
            }
        }

    }

    public bool hasFire() {
        return fire != null;
    }

    public GameObject getObject() {
        return o;
    }

    public virtual GameObject pick()
    {
        if (hasFire()) return null;
        if(o != null && o.GetComponent(typeof(Utensil)) != null) {
            ((Utensil)o.GetComponent(typeof(Utensil))).action_aux(false);
            GameObject ret = o;
            o = null;
            return ret;
        }
        if(o != null && o.GetComponent(typeof(Fire_Extinguisher)) != null) {
            GameObject ret = o;
            o = null;
            return ret;
        }
        return null;
    }

    public virtual GameObject interact(GameObject go)
    {
        if (hasFire()) return go;
        if (o != null)
        {
            if (o.GetComponent(typeof(Utensil)) != null)
            {
                bool hasFoodP = false;
                if (go.GetComponent(typeof(Utensil)) != null) hasFoodP = ((Utensil)go.GetComponent(typeof(Utensil))).hasFood();
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
                        if (b)
                        {
                            Debug.Log("A");

                            ((Utensil)o.GetComponent(typeof(Utensil))).action_aux(isWorking);

                        }
                    }
                }
                else
                {
                    if (hasFoodF)                                                   //utensil - uteensil & food
                    {
                        ((Utensil)o.GetComponent(typeof(Utensil))).action_aux(false);
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

            return leave(go);
        }

        return go;

    }

    public void StartFire() {
        if (spawnFire != null && !hasFire())
            fire = Instantiate(spawnFire, new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z), Quaternion.identity);
    }

    public void StopFire() {
        Destroy(fire);
        fire = null;
    }

    public virtual GameObject leave(GameObject go)
    {
        o = go;
        ((Object)o.GetComponent(typeof(Object))).leave(transform.position + new Vector3(0.0f, 2.0f, 0.0f));
        Debug.Log("A");
        if (o.GetComponent(typeof(Utensil)) != null) ((Utensil)o.GetComponent(typeof(Utensil))).action_aux(isWorking);

        return null;
    }
 
    public abstract bool action(GameObject go);

    
}
