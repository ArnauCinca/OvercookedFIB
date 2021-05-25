using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Furniture
{

    public override GameObject pick() {
        GameObject ret = base.pick();
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
        o = Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), Quaternion.identity);
    }

}
