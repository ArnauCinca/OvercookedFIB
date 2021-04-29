using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject o;
    private GameObject s;
    private Vector3 o_pos;
    bool wait = false;
    // Start is called before the first frame update
    void Start()
    {
        o_pos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        s = Instantiate(o, o_pos, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (!wait &&  s.transform.position != o_pos) {
            Debug.Log("Spawn");
            s = null;
            StartCoroutine(Spawn());

        }
    }

    protected IEnumerator Spawn()
    {
        wait = true;
        yield return new WaitForSeconds(5.0f);
        o_pos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        s = Instantiate(o, o_pos, Quaternion.identity);
        wait = false;
    }

}
