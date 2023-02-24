using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public Equipment armour = null;
    public Equipment weapon = null;
    public List<Equipment> unequipped = new List<Equipment>(0);
    public bool invState = false;
    public GameObject foundInv = null;
    public GameObject invPanel = null;
    public List<GameObject> panels = new List<GameObject>(6);
    
    private void Start(){
        GameObject inv = GameObject.FindGameObjectWithTag("inv");
        GameObject invpan = GameObject.FindGameObjectWithTag("invpan");
        foundInv = inv;
        invPanel = invpan;

        inv.SetActive(false);
        
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.I)){
            if(invState){
                foundInv.SetActive(false);
                invState = false;
                print(unequipped[1].type);
            }
            else{
                foundInv.SetActive(true);
                invState = true;
                if(armour){
                    panels[1].gameObject.GetComponent<Image>().sprite = armour.icon;
                }
                if(weapon){
                    panels[3].gameObject.GetComponent<Image>().sprite = weapon.icon;
                }
                if(unequipped[0]){
                    panels[5].gameObject.GetComponent<Image>().sprite = unequipped[0].icon;
                }
                if(unequipped[1]){
                    panels[0].gameObject.GetComponent<Image>().sprite = unequipped[1].icon;
                }
                if(unequipped[2]){
                    panels[4].gameObject.GetComponent<Image>().sprite = unequipped[2].icon;
                }
                if(unequipped[3]){
                    panels[2].gameObject.GetComponent<Image>().sprite = unequipped[3].icon;
                }

            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other) {

        unequipped.Add(other.gameObject.GetComponent<Equipment>());

    }
}
