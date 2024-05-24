using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int state;
    float h;
    float v;
    public float speed = 1;

    public GameObject Cam;
    public float CamSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update(){
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        transform.Translate(h*speed*Time.deltaTime, v*speed*Time.deltaTime,0);
    }

    void LateUpdate(){
        Cam.transform.position = Vector3.Slerp(Cam.transform.position, transform.position, CamSpeed);
    }
        
}
