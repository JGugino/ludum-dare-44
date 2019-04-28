using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController pController;
    private PlayerMotor pMotor;

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
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GUIController.instance.getStoreUI().activeSelf)
        {
            GUIController.instance.toggleStoreUI(false);
        }
    }
}
