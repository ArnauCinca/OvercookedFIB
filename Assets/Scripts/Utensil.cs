using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Utensil : Object
{

    protected GameObject go;

    public abstract override GameObject pick();
    public abstract override void leave(Vector3 pos);

    public abstract GameObject get();
    public abstract bool put(GameObject o);
    public abstract bool action();

}