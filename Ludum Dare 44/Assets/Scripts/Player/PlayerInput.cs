using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController pController;
    private PlayerMotor pMotor;

    public bool debugMode = false;

    private void Awake()
    {
        pMotor = GetComponent<PlayerMotor>();
        pController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!pController.getIsDead() && !GameController.instance.isPaused)
        {
            float _horDir = Input.GetAxisRaw("Horizontal");
            float _vertDir = Input.GetAxisRaw("Vertical");

            pMotor.playerMove(_horDir, _vertDir);

            if (Input.GetButtonDown("Shoot Blood"))
            {
                Vector3 _dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                pController.spawnBloodShot(new Vector3(_dest.x, _dest.y, _dest.z));
            }

            if (Input.GetButtonDown("Interact"))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit)
                {
                    if (hit.collider.CompareTag("Chest"))
                    {
                        hit.collider.GetComponent<ChestController>().openChest();
                    }

                    if (hit.collider.CompareTag("Merchant"))
                    {
                        GUIController.instance.toggleStoreUI(true);
                    }
                }
            }

            if (pController.getPlayerCurrentAmmo() < 30)
            {
                if (Input.GetButtonDown("Sacrifice"))
                {
                    pController.takePlayerHealth();
                    pController.addAmmo(10);
                }
            }

            if (debugMode)
            {
                if (Input.GetKeyDown(KeyCode.F1))
                {
                    GameController.instance.addOrgans("lung", 20);
                    GameController.instance.addOrgans("liver", 20);
                    GameController.instance.addOrgans("kidney", 20);
                    GameController.instance.addOrgans("heart", 20);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GUIController.instance.getStoreUI().activeSelf)
        {
            GUIController.instance.toggleStoreUI(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !GUIController.instance.getStoreUI().activeSelf)
        {
            GUIController.instance.togglePauseScreen(true);
            GameController.instance.isPaused = true;
        }

        //if (Input.GetKeyDown(KeyCode.F3))
        //{
        //    debugMode = !debugMode;
        //}
    }

    #region Sprint Code
    //    if (pController.getHasSprint())
    //    {
    //    if ((Input.GetButtonDown("Sprint")) && ((_horDir > 0 || _horDir< 0) || (_vertDir > 0 || _vertDir< 0)))
    //    {
    //        pMotor.toggleSprint(true);
    //    }

    //    if (Input.GetButtonDown("Sprint") && pMotor.getIsSprinting())
    //    {
    //        pMotor.toggleSprint(false);
    //    }
    //    else if ((_horDir > 0 && _horDir< 0) && (_vertDir > 0 && _vertDir< 0))
    //    {
    //        pMotor.toggleSprint(false);
    //    }
    #endregion
}
