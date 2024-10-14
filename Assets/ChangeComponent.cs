using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 省略了 "gameObject."
        // GetComponent<Renderer>().material.color = new Color(0, 0, 255);
        // GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 255, 0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(2*Time.deltaTime, 0, 0);
        if (transform.position.x > 2)
        {
            gameObject.AddComponent<Rigidbody>();
            GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 255, 0));
            GetComponent<Collider>().enabled = false;
        }
    }
}
