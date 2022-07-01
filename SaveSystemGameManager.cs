using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    [SerializeField]
    public int money;
    public TextMeshProUGUI moneyText;

    public static GameManager instance;

    void Awake() {
        instance = this;
    }

    void Start() {
        money = PlayerPrefs.GetInt("money");
        moneyText.text = "$" + money.ToString();
    }

    void Update() {
        PlayerPrefs.SetInt("money", money);
        moneyText.text = "$" + money.ToString();
    }

    public void AddMoney(int amount) {
        money += amount;
        moneyText.text = "$" + money.ToString();
    }

    public void TakeMoney(int amount) {
        money -= amount;
        moneyText.text = "$" + money.ToString();
    }

    void OnApplicationQuit() {
        PlayerPrefs.SetInt("money", money);
    }
}