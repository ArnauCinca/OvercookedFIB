using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Furniture : MonoBehaviour
{
    public GameObject spawnObject;
    protected GameObject o;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnObject != null)
            o = Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y + 1.05f, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public abstract GameObject pick();
    public abstract bool leave(GameObject o);
    public abstract bool action();

}
