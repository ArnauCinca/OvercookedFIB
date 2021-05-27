using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Utensil : Object
{

    public bool isCooking;
    public bool isCooked;
    public bool isBurned;
    public float cookingStart;
    public float burnTime;
    public float cookingTime;

    protected GameObject go;

    public override GameObject pick()
    {
        return gameObject;
    }

    
    public override void move(Vector3 pos) {
        transform.position = pos;
        if (go != null) ((Food)go.GetComponent(typeof(Food))).move(pos + new Vector3(0.0f, 0.05f, 0.0f));
    }

    public override void leave(Vector3 pos)
    {
        transform.position = pos;
        if (go != null) ((Food)go.GetComponent(typeof(Food))).leave(pos + new Vector3(0.0f, 0.05f, 0.0f));
    }

    public GameObject get()
    {
        if (go == null) return null;
        GameObject ret = go;
        go = null;
        return ret;
    }

    public virtual bool put(GameObject o)
    {
        if (go != null) return false;
        go = o;
        ((Food)go.GetComponent(typeof(Food))).leave(transform.position + new Vector3(0.0f, 0.05f, 0.0f));
        return true;
    }
    public bool hasFood()
    {
        return go != null;
    }

    public abstract bool action();

    // Start is called before the first frame update
    public override void Start()
    {
        isCooking = false;
        cookingTime = 3f;
        burnTime = 10f;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (isCooking) {
            if (!isCooked && !isBurned && Mathf.Abs(playerMovement.timeRemaining - cookingStart) > cookingTime) {
                isCooked = cookFood();
                Debug.Log(isCooked);
            }
            if (isCooked && !isBurned && Mathf.Abs(playerMovement.timeRemaining - cookingStart) > burnTime) {
                Debug.Log("sdfdssd");
                isBurned = true;
            }
            if (isBurned) {
                //Fer que surti foc
            }
        }
    }

    public void initCooking()
    {
        isCooking = true;
        cookingStart = playerMovement.timeRemaining;
        isCooked = false; //Aqui s'ha de mirar si el mejar esta cuinat
        isBurned = false; //Aqui s'ha de mirar si el menjar esta cremat
    }

    public void stopCooking()
    {
        isCooking = false;
    }

    public virtual bool cookFood() {
        return true;
    }

    //AIXO S'HA D'ARREGLAR!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public bool burnedFood() {
        GameObject obj = ((Food)go.GetComponent(typeof(Food))).burn_food();
        if (obj == null) return false;
        Destroy(go);
        go = null;
        go = obj;
        return true;
    }

}