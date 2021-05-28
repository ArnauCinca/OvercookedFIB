
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Food : Object
{
    public GameObject Cutted_Food;
    public GameObject Stove_Food;
    public GameObject Oven_Food;
    public string type;

    public GameObject C1;
    public GameObject C1R;
    public GameObject C2;
    public GameObject C2R;

    bool is_cooking;
    public float cookingTime;

    public bool deliverable;


    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (is_cooking) cookingTime -= Time.deltaTime;
        if (Input.GetKeyDown("b"))
        {
            cookingTime = -1;
        }
    }

    public bool startCooking() {
        Debug.Log("Start");
        if (!is_cooking) {
            is_cooking = true;
            return true;
        }
        return false;
    }

    public bool stopCooking()
    {
        Debug.Log("Stop");
        if (is_cooking)
        {
            is_cooking = false;
            return true;
        }
        return false;
    }

    public float getCookingTime()
    {
        return cookingTime;
    }

    public bool isCooking()
    {
        return is_cooking;
    }

    public string getType()
    {
        return type;
    }

    public bool sameFood(GameObject go)
    {
        if(go.GetComponent(typeof(Food))!= null)
        {
            return type.Equals(((Food)go.GetComponent(typeof(Food))).getType());
        }
        return false;
    }

    public override GameObject pick()
    {
        return gameObject;
    }
    public override void leave(Vector3 pos)
    {
        transform.position = pos;
    }
    public override void move(Vector3 pos)
    {
        transform.position = pos;
    }

    public GameObject cut()
    {
        if (Cutted_Food == null) return null;
        return Instantiate(Cutted_Food, transform.position, Quaternion.identity);
    }

    public GameObject cook_oven()
    {
        if (Oven_Food == null) return null;
        return Instantiate(Oven_Food, transform.position, Quaternion.identity);
    }

    public GameObject cook_stove()
    {
        if (Stove_Food == null) return null;
        return Instantiate(Stove_Food, transform.position, Quaternion.identity);
    }


    public GameObject combine(GameObject go)
    {
        Debug.Log("Combine");

        if (C1 != null) {
            if (((Food)go.GetComponent(typeof(Food))).getType().Equals(((Food)C1.GetComponent(typeof(Food))).getType()))
                return Instantiate(C1R, transform.position, Quaternion.identity);
        }

        if (C2 != null)
        {
            if (((Food)go.GetComponent(typeof(Food))).getType().Equals(((Food)C2.GetComponent(typeof(Food))).getType()))
                return Instantiate(C2R, transform.position, Quaternion.identity);
        }
        return null;
    }
    public bool deliver()
    {
        return deliverable;
    }


}

