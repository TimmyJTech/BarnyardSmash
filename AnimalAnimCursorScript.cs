using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour {
    public int curHp;
    public int maxHp;
    public int moneyToGive;
    public Image healthBarFill;
    public Animation anim;

    // Animal Movement

    private float velx;
    private float vely;
    private float speed = 0.02f;
    private bool right;
    private bool left;

    void Awake() {
        if(right == true) {
            velx = speed;
        } else {
            velx = -speed;
        }
    }

    public void FixedUpdate() {

        if(transform.position.x <= -15 || transform.position.x >= 5){
            velx = -velx;
        }
    }

    public void Damage() {
        curHp--;
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;
        
        anim.Stop();
        anim.Play();

        if(curHp <= 0) {
            Caught();
        }
    }
    public void NotDamage() {
        curHp++;
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;

        //if(curHp <= 0) {
        //    Escape();
        //}
    }

    public void Caught() {
        GameManager.instance.AddMoney(moneyToGive);
        AnimalManager.instance.ReplaceAnimal(gameObject);
    }

    public void OnMouseOver() {
        transform.Translate(velx, 0, 0);
        Damage();
        Debug.Log("MouseOver");
    }

    public void OnMouseExit() {
        NotDamage();
        Debug.Log("MouseExit");
    }
}