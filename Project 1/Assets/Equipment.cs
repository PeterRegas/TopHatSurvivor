using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Equipment : MonoBehaviour
{
    public string type = "";
    public string description = "";
    public int defense = 0;
    public int attack = 0;
    public Sprite icon = null;
    private void OnTriggerEnter2D(Collider2D other) {
       gameObject.SetActive(false); 
    }
}
