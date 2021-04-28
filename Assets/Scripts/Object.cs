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

    public abstract Object pick();
    public abstract void leave(Object o);

    protected IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
    }
}