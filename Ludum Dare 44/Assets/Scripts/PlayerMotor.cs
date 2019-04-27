using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField, Header("Player Move Speed:")]
    private float playerSpeed = 5f;

    public void playerMove(float _horDir, float _vertDir)
    {
        //Horizontal Movement
        if (_horDir < 0)
        {
            transform.position = new Vector3(transform.position.x - playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }else if (_horDir > 0)
        {
            transform.position = new Vector3(transform.position.x + playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        //Vertical Movement
        if (_vertDir < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - playerSpeed * Time.deltaTime, transform.position.z);
        }
        else if (_vertDir > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + playerSpeed * Time.deltaTime, transform.position.z);
        }
    }

}
