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

    public GameObject[] Skins;
    public Animator[] Animators;

    public int currentSkin;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update(){

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if(currentSkin == 0){

        Animators[0].SetFloat("h", h);
        Animators[0].SetFloat("v", v);

        }
   

    }

    public void SelectSkin(int skin){
        currentSkin = skin;
    }

    void FixedUpdate()
    {
        transform.Translate(h*speed*Time.deltaTime, v*speed*Time.deltaTime,0);
    }

    void LateUpdate(){
        Cam.transform.position = Vector3.Slerp(Cam.transform.position, transform.position, CamSpeed);
    }
        
}
