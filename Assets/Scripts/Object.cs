using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Object : MonoBehaviour
{


    public abstract GameObject pick();
    public abstract void leave(Vector3 pos);

    public abstract void move(Vector3 pos);
    
}