using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public static GUIController instance;

    private GameObject gameplayUI, storeUI, deathScreen, loadingScreen, pauseMenu;

    private Button restartButton, exitButton, playButton, menuExitButton, pauseExitButton, resumeButton;

    private Transform upgradeIconParent;

    private TextMeshProUGUI lungAmount, liverAmount, kidneyAmount, heartAmount;

    private void Awake()
    {
        instance = this;
    }

    public void findMenuUI()
    {
        playButton = GameObject.FindGameObjectWithTag("Play Button").GetComponent<Button>();
        menuExitButton = GameObject.FindGameObjectWithTag("Menu Exit Button").GetComponent<Button>();

        playButton.onClick.AddListener(delegate { GameController.instance.startGame(); });
        menuExitButton.onClick.AddListener(delegate { GameController.instance.exitGame(); });
    }

    public void findGameUI()
    {
        gameplayUI = GameObject.FindGameObjectWithTag("Gameplay Screen");

        storeUI = GameObject.FindGameObjectWithTag("Merchant Screen");

        deathScreen = GameObject.FindGameObjectWithTag("Death Screen");

        loadingScreen = GameObject.FindGameObjectWithTag("Loading Screen");

        pauseMenu = GameObject.FindGameObjectWithTag("Pause Menu");

        restartButton = GameObject.FindGameObjectWithTag("Restart Button").GetComponent<Button>();

        exitButton = GameObject.FindGameObjectWithTag("Exit Button").GetComponent<Button>();

        resumeButton = GameObject.FindGameObjectWithTag("Resume Button").GetComponent<Button>();

        pauseExitButton = GameObject.FindGameObjectWithTag("Pause Exit Button").GetComponent<Button>();

        upgradeIconParent = GameObject.FindGameObjectWithTag("Upgrade Icons").GetComponent<Transform>();

        restartButton.gameObject.SetActive(false);

        exitButton.onClick.AddListener(delegate { GameController.instance.exitToMenu(); });

        pauseExitButton.onClick.AddListener(delegate { GameController.instance.exitToMenu(); });

        resumeButton.onClick.AddListener(delegate { GameController.instance.resumeGame(); });

        //restartButton.onClick.AddListener(delegate { GameController.instance.createNewRooms(); });

        findOrganUIElements();

        toggleDeathScreen(false);

        togglePauseScreen(false);

        //toggleLoadingScreen(false);

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

    public void toggleDeathScreen(bool _on)
    {
        deathScreen.SetActive(_on);
        GameController.instance.isPaused = _on;
    }
    public void toggleLoadingScreen(bool _on)
    {
        loadingScreen.SetActive(_on);
    }

    public void togglePauseScreen(bool _on)
    {
        pauseMenu.SetActive(_on);
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

    public Transform getUpgradeIconsParent()
    {
        return upgradeIconParent;
    }
}
