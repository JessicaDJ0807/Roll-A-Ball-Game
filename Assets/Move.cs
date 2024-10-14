using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Transform>().position = new Vector3(0, 10, 0);
        // transform.position = new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(1*Time.deltaTime, 0, 0);
        // transform.rotation = Quaternion.Euler(0, 30, 0);
        transform.eulerAngles = new Vector3(0, 30, 0);
        // transform.Rotate(0, 30*Time.deltaTime, 0);
    }
}
