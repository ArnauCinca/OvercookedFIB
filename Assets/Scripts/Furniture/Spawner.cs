using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Furniture
{
    // Start is called before the first frame update
 /*   void Start()
    {
        //Can't be null
        StartCoroutine(Spawn(0.1f));
    }

    // Update is called once per frame
    void Update()
    {

    }*/

    public override GameObject pick() {
        GameObject ret = o;
        o = null;
        StartCoroutine(Spawn(3.0f));
        return ret;
    }

    public override bool leave(GameObject o) {
        return false;
    }

    public override bool action()
    {
        return false;
    }

    protected IEnumerator Spawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        o = Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
    }

}
