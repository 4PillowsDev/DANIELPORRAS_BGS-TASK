using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellDialog : MonoBehaviour
{
    public GameObject Box;
    public PlayerController playerC;

    public GameObject Message;

    public bool Activate;
    public bool m = false;

    public MoneyManager manager;
    public GameObject skinInventory;
    public int price;
    public int skinNumber;
    public Animator Anim;

    public GameObject advice;

    public bool showingMessage;


    void Update(){
        
        Activate = Input.GetButton("Jump");

        if(m == false){
        if(showingMessage){
            if(Activate == false){
                if(m == false){
                Message.SetActive(true);
                }else{
                advice.SetActive(true); 
                }
            }
            if(Activate){
                Message.SetActive(false);
                advice.SetActive(false); 
                ShowDialog();
                showingMessage = false;
            }
        }
        }

    }
    
   public void ShowDialog(){
        Box.SetActive(true);
        playerC.IsPaused = true;
    }

    public void CloseDialog(){
        Box.SetActive(false);
        Anim.SetBool("Sell", false);
        playerC.IsPaused = false;
    }


     public void Buy(){
        Box.SetActive(false);
        playerC.IsPaused = false;
        StartCoroutine(celebrate());
        m = true;
    }

     public void cancelBuy(){
        Box.SetActive(false);
        playerC.IsPaused = false;
    }

    IEnumerator celebrate(){
        Anim.SetBool("Sell", true);
        manager.money -= price;
        playerC.SelectSkin(skinNumber);
        yield return new WaitForSeconds(0.5f);
        skinInventory.SetActive(true);
        Anim.SetBool("Sell", false);
        yield break;
    }

    
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            if(m == false){
            Message.SetActive(true);
            }else{
            advice.SetActive(true); 
            }
            showingMessage = true;
        }
    }

      void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player"){
            showingMessage = false;
            Message.SetActive(false);
            advice.SetActive(false);
        }
    }

}
