using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Furniture
{
    private AudioSource source;
    private bool r = false;

    // Start is called before the first frame update
    public void Start()
    {
        source = GetComponent<AudioSource>();

        fire = null;
        if (spawnObject != null)
            o = Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z), Quaternion.identity);
    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        gameObject.transform.GetChild(0).gameObject.SetActive(!isWorking);
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
        if (o != null && o.GetComponent(typeof(Pan)) != null)
        {
            ((Utensil)o.GetComponent(typeof(Pan))).action_aux(isWorking);
        }
        return true;
    }

}
