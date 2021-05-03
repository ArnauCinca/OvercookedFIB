using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Furniture
{
    public GameObject s;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(0.1f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override GameObject pick() {
        GameObject ret = o;
        o = null;
        StartCoroutine(Spawn(3.0f));
        return ret;
    }

    public override bool leave(GameObject o) {
        return false;
    }


    protected IEnumerator Spawn(float delay)
    {
        Debug.Log("Spawn");
        yield return new WaitForSeconds(delay);
        o = Instantiate(s, new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), Quaternion.identity);
    }

}
