using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Furniture : MonoBehaviour
{
    protected GameObject o;
    public abstract GameObject pick();
    public abstract bool leave(GameObject o);
    public abstract bool action();

}
