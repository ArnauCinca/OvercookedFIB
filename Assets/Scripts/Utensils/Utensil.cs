using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Utensil : Object
{
    Coroutine co = null;

    protected GameObject go;
    bool burnActive = true;




    public override GameObject pick()
    {
        //StopCooking
        return gameObject;
    }

    
    public override void move(Vector3 pos) {
        transform.position = pos;
        if (go != null) ((Food)go.GetComponent(typeof(Food))).move(pos + new Vector3(0.0f, 0.05f, 0.0f));
    }

    public override void leave(Vector3 pos)
    {
        //StartCooking?

        transform.position = pos;
        if (go != null) ((Food)go.GetComponent(typeof(Food))).leave(pos + new Vector3(0.0f, 0.05f, 0.0f));
    }

    public GameObject get()
    {
        if (go == null) return null;
        //StopCooking

        GameObject ret = go;
        go = null;
        return ret;
    }

    public virtual bool put(GameObject o)
    {
        if (go != null) return false;
        go = o;
        
        ((Food)go.GetComponent(typeof(Food))).leave(transform.position + new Vector3(0.0f, 0.05f, 0.0f));
        //StartCooking?


        return true;
    }
    public bool hasFood()
    {
        return go != null;
    }

    public GameObject getFoodInfo()
    {
        return go;
    }

    public abstract bool action();

    public virtual void action_aux(bool isWorking)
    {
        if (go == null || go.GetComponent(typeof(Food)) == null) return;

        if (isWorking)
        {
            bool b = ((Food)go.GetComponent(typeof(Food))).startCooking();
            if (b)
            {
                float t = ((Food)go.GetComponent(typeof(Food))).getCookingTime();
                co = StartCoroutine(Cook(t));
            }

        }
        else
        {
            bool b = ((Food)go.GetComponent(typeof(Food))).stopCooking();
            if (b && co != null)
            {
                StopCoroutine(co);
                co = null;
            }
        }
    }

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown("n"))
        {
            burnActive = !burnActive;
        }
        if (Input.GetKeyDown("b"))
        {
            if(co != null)
            {
                StopCoroutine(co);
                co = null;
            }

            co = StartCoroutine(Cook(0.1f));

        }
    }

    public virtual GameObject cookFood() {
        return null;
    }



    protected IEnumerator Cook(float delay)
    {
        yield return new WaitForSeconds(delay);
        if(go != null)
        {
            ((Food)go.GetComponent(typeof(Food))).stopCooking();
            if (((Food)go.GetComponent(typeof(Food))).getCookingTime() <= 0.0)
            {

                GameObject obj = cookFood();
                if (obj != null)
                {
                    if (((Food)obj.GetComponent(typeof(Food))).getType().Equals("burned_food") && !burnActive)
                    {
                        Destroy(obj);
                    }
                    else
                    {
                        Destroy(go);
                        go = null;
                        go = obj;

                        co = null;
                        //burn  //TODO: FIRE
                        bool b = ((Food)go.GetComponent(typeof(Food))).startCooking();
                        if (b)
                        {
                            float t = ((Food)go.GetComponent(typeof(Food))).getCookingTime();
                            co = StartCoroutine(Cook(t));
                        }

                    }

                }

            }
        }
        

    }

}