using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Furniture : MonoBehaviour
{
    protected GameObject o;
    public abstract Object pick();
    public abstract bool leave(Object o);

}
