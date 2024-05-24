using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    public GameObject Box;
    public PlayerController playerC;

    public GameObject Message;

    public Animator Anim;

    public bool Activate;

    public bool showingMessage;

    public bool isIn;

    void Update(){
        Activate = Input.GetButton("Jump");
          if(showingMessage){
             if(Activate == false){
                Message.SetActive(true);
            }
            if(Activate){
                Message.SetActive(false);
                ShowDialog();
                showingMessage = false;
            }
    }
        
    }


    public void ShowDialog(){
        Box.SetActive(true);
        Anim.SetBool("Talk", true);
        playerC.IsPaused = true;
    }

    public void CloseDialog(){
        Box.SetActive(false);
        Anim.SetBool("Talk", false);
        playerC.IsPaused = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            Message.SetActive(true);
            showingMessage = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player"){
            showingMessage = false;
            Message.SetActive(false);
        }
    }
}
