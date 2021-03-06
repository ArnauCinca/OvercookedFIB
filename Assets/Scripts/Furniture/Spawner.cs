using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Furniture
{
    // Start is called before the first frame update
    public void Start()
    {
        fire = null;
        if (spawnObject != null)
            o = Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z), Quaternion.identity);
    }
    public override GameObject pick() {
        GameObject ret = base.pick();
        if(ret != null) StartCoroutine(Spawn(3.0f));
        return ret;
    }
    public override GameObject interact(GameObject go)
    {
        if(o != null)
        {
            if (o.GetComponent(typeof(Food)) != null)
            {
                if (!((Utensil)go.GetComponent(typeof(Utensil))).hasFood())
                {
                    ((Utensil)go.GetComponent(typeof(Utensil))).put(o);
                    o = null;
                    StartCoroutine(Spawn(3.0f));
                }
            }
        }
        return go;
    }

    public override bool action(GameObject go)
    {
        return false;
    }

    protected IEnumerator Spawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        o = Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z), Quaternion.identity);
    }

}
