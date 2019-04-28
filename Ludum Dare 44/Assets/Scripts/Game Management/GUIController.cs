using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIController : MonoBehaviour
{
    public static GUIController instance;

    private GameObject gameplayUI, storeUI;

    private TextMeshProUGUI lungAmount, liverAmount, kidneyAmount, heartAmount;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        findGameUI();
    }

    public void findGameUI()
    {
        gameplayUI = GameObject.FindGameObjectWithTag("Gameplay Screen");

        storeUI = GameObject.FindGameObjectWithTag("Merchant Screen");

        findOrganUIElements();

        toggleStoreUI(false);
    }

    public void findOrganUIElements()
    {
        lungAmount = GameObject.FindGameObjectWithTag("Lung Amount").GetComponent<TextMeshProUGUI>();
        liverAmount = GameObject.FindGameObjectWithTag("Liver Amount").GetComponent<TextMeshProUGUI>();
        kidneyAmount = GameObject.FindGameObjectWithTag("Kidney Amount").GetComponent<TextMeshProUGUI>();
        heartAmount = GameObject.FindGameObjectWithTag("Heart Amount").GetComponent<TextMeshProUGUI>();

        updateAllAmounts();
    }

    public void toggleGameplayUI(bool _on)
    {
        gameplayUI.SetActive(_on);
    }

    public void toggleStoreUI(bool _on)
    {
        storeUI.SetActive(_on);
        GameController.instance.isPaused = _on;
    }

    public void updateAllAmounts()
    {
        updateLungAmount();
        updateLiverAmount();
        updateKidneyAmount();
        updateHeartAmount();
    }

    public void updateLungAmount()
    {
        lungAmount.text = GameController.instance.getLungAmount().ToString();
    }

    public void updateLiverAmount()
    {
        liverAmount.text = GameController.instance.getLiverAmount().ToString();
    }

    public void updateKidneyAmount()
    {
        kidneyAmount.text = GameController.instance.getKidneyAmount().ToString();
    }

    public void updateHeartAmount()
    {
        heartAmount.text = GameController.instance.getHeartAmount().ToString();
    }

    public GameObject getStoreUI()
    {
        return storeUI;
    }
}
