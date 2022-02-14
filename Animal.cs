using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour {
    public int curHp;
    public int maxHp;
    public int moneyToGive;
    public Image healthBarFill;

    public void Damage() {
        curHp--;
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;

        if(curHp <= 0) {
            Caught();
        }
    }

    public void Caught() {
        //Add Money

        // Remove Animal
    }
}
