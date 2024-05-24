using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool IsPaused;
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

        
        if(IsPaused == false){
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        }else{
            h=0;
            v=0;
        }

        
        Animators[0].SetFloat("h", h);
        Animators[0].SetFloat("v", v);
        Animators[1].SetFloat("h", h);
        Animators[1].SetFloat("v", v);
        Animators[2].SetFloat("h", h);
        Animators[2].SetFloat("v", v);
        Animators[3].SetFloat("h", h);
        Animators[3].SetFloat("v", v);

        if(currentSkin == 0){

        Skins[0].GetComponent<SpriteRenderer>().enabled = true;
        Skins[1].GetComponent<SpriteRenderer>().enabled = false;
        Skins[2].GetComponent<SpriteRenderer>().enabled = false;
        Skins[3].GetComponent<SpriteRenderer>().enabled = false;

        }

         if(currentSkin == 1){

        Skins[0].GetComponent<SpriteRenderer>().enabled = false;
        Skins[1].GetComponent<SpriteRenderer>().enabled = true;
        Skins[2].GetComponent<SpriteRenderer>().enabled = false;
        Skins[3].GetComponent<SpriteRenderer>().enabled = false;

        }

         if(currentSkin == 2){

        Skins[0].GetComponent<SpriteRenderer>().enabled = false;
        Skins[1].GetComponent<SpriteRenderer>().enabled = false;
        Skins[2].GetComponent<SpriteRenderer>().enabled = true;
        Skins[3].GetComponent<SpriteRenderer>().enabled = false;

        }

         if(currentSkin == 3){

        Skins[0].GetComponent<SpriteRenderer>().enabled = false;
        Skins[1].GetComponent<SpriteRenderer>().enabled = false;
        Skins[2].GetComponent<SpriteRenderer>().enabled = false;
        Skins[3].GetComponent<SpriteRenderer>().enabled = true;

        }
   

    }

    public void SelectSkin(int skin){
         if(!IsPaused){
        currentSkin = skin;
         }
    }

    void FixedUpdate()
    {
        if(!IsPaused){
        transform.Translate(h*speed*Time.deltaTime, v*speed*Time.deltaTime,0);
        }
    }

    void LateUpdate(){
        Cam.transform.position = Vector3.Slerp(Cam.transform.position, transform.position, CamSpeed);
    }
        
}
