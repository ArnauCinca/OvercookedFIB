using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Object : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

    }

    public abstract GameObject pick();
    public abstract void leave(Vector3 pos);

}