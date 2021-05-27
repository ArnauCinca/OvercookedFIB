using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Object : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public abstract GameObject pick();
    public abstract void leave(Vector3 pos);

    public abstract void move(Vector3 pos);
    
}