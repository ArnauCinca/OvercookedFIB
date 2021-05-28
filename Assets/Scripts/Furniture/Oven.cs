using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : Furniture
{
    private AudioSource source;
    private bool r=false;

    public void Start()
    {
        source = GetComponent<AudioSource>();

        fire = null;
        if (spawnObject != null)
            o = Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        gameObject.transform.GetChild(1).gameObject.SetActive(isWorking);

        if (isWorking && !r)
        {
            Debug.Log("Play");
            source.Play();
            r = true;
        }
        else if (!isWorking && r)
        {
            source.Stop();
            r = false;
        }
    }

    public override bool action(GameObject go)
    {
        if (hasFire() && go != null && go.GetComponent(typeof(Fire_Extinguisher)) != null) StopFire();
        isWorking = !isWorking;
        if (o != null && o.GetComponent(typeof(Oven_Tray)) != null) {
            ((Utensil)o.GetComponent(typeof(Oven_Tray))).action_aux(isWorking);
        }
        return true;
    }

    public override GameObject leave(GameObject go)
    {
        o = go;
        ((Object)o.GetComponent(typeof(Object))).leave(transform.position + new Vector3(0.0f, 1.0f, 0.0f));
        Debug.Log("A");
        ((Utensil)o.GetComponent(typeof(Utensil))).action_aux(isWorking);

        return null;
    }

}
