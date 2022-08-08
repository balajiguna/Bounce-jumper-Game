using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_bounce : MonoBehaviour
{

    public Rigidbody rb;
    public float jumpForce;
    public GameObject splashPrefabs;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = new Vector3(0, jumpForce, 0);

        GameObject splash = Instantiate(splashPrefabs, transform.position + new Vector3(0f,-0.2f,0f), Quaternion.Euler(90, 0, 0));
        splash.transform.SetParent(collision.gameObject.transform);

        string materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;
        Debug.Log(materialName);
        if (materialName == "PlatformSafe (Instance)")
        {
            //Continue


        }
        else if (materialName == "PlatformDanger (Instance)")
        {
            //game Over
            gm.RestartGame();

        }
        else if (materialName == "LastRing (Instance)")
        {
            //Level Complete

        }
    }
}
