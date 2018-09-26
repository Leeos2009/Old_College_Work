using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTrigger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Renderer>().material.color = Color.cyan;
    }
    public int remember = 0,pieces = 0;
    public bool valid;
    public UnityEngine.UI.Button MyButton = null;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        valid = false;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (this.transform.position.z < 8)
                this.transform.position += new Vector3(0, 0, 1f);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (this.transform.position.z > 0)
                this.transform.position += new Vector3(0, 0, -1f);

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (this.transform.position.x > 0)
                this.transform.position += new Vector3(-1f, 0, 0);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (this.transform.position.x < 8)
                this.transform.position += new Vector3(1f, 0, 0);

        }

    }

    public void OnTriggerEnter(Collider other)
    {

            print("Trigger Detected");
            valid = true;
            remember = 1;

            if (valid == true && remember != 0 && pieces == 0)
            {
                if (valid == true)
                {
                    pieces++;
                    other.transform.parent = this.transform;
                    if (this.transform.position.x > 1)
                    {
                    transform.parent = null;
                    //pieces--;
                    // Destroy(this.gameObject);
                }

                }
                




                other.GetComponent<Renderer>().material.color = Color.red;
            }
    }
        
    

    

    public void OnTriggerExit(Collider other)
    {

        if (other.name == "CheckerFront4" || other.name == "CheckerFront5" || other.name == "CheckerFront6" || other.name == "CheckerFront7" || other.name == "Checker9" || other.name == "Checker8" || other.name == "Checker7" || other.name == "Checker6" || other.name == "Checker5")
        {
            other.GetComponent<Renderer>().material.color = Color.white;
            remember = 0;
        }
        else
        {
            other.GetComponent<Renderer>().material.color = Color.black;
            remember = 0;
        }
    }


    public void SetParent(GameObject newParent)
    {
     //   this.transform = newParent.transform;
        player.transform.parent = newParent.transform;
        
        Debug.Log("Player's Parent: " + player.transform.parent.name);

        if (newParent.transform.parent != null)
        {
            Debug.Log("Player's Grand parent: " + player.transform.parent.parent.name);
        }
    }

    public void DetachFromParent()
    {
        transform.parent = null;
    }
}

