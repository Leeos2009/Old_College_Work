using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        this.GetComponent<Renderer>().material.color = Color.green;

        other.GetComponent<Renderer>().material.color = Color.red;
        if (other.gameObject.tag == "Black")
            if (Input.GetKeyDown(KeyCode.X))
            {
                other.transform.position += new Vector3(1, 0, -1);
            }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            other.transform.position += new Vector3(1, 0, 1);
        }
        else if (other.gameObject.tag == "White")
            if (Input.GetKeyDown(KeyCode.V))
            {
                other.transform.position += new Vector3(-1, 0, -1);
            }
        if (Input.GetKeyDown(KeyCode.C))
        {
            other.transform.position += new Vector3(-1, 0, 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Black")
            other.GetComponent<Renderer>().material.color = Color.black;
        else
            other.GetComponent<Renderer>().material.color = Color.white;

    }
}