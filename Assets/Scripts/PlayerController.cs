using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D PlayerRigidBody;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private GameObject ItemFactory;

    private float minY;
    private float maxY;

    [SerializeField]
    private float CameraSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 bounds = 
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
        minY = -bounds.y + 1;
        maxY = bounds.y - 1;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        MovementFunction();
        PlayerBound();
    }

    private void CameraMovement() {
        mainCamera.transform.position += Vector3.right * CameraSpeed * Time.deltaTime;
        transform.position += Vector3.right * CameraSpeed * Time.deltaTime;
        ItemFactory.transform.position += Vector3.right * CameraSpeed * Time.deltaTime;

    }

    private void MovementFunction()
    {
        float MovementY = Input.GetAxis("Vertical");
        if (MovementY != 0)
        {
            Vector3 temp = new Vector3(0.0f, MovementY, 0.0f);
            transform.position += temp * 5.0f * Time.deltaTime;
        }
    }

    private void PlayerBound() {
        if(transform.position.y > maxY) {
            Vector3 temp = transform.position;
            temp.y = maxY;
            transform.position = temp;
        }
        if(transform.position.y < minY) {
            Vector3 temp = transform.position;
            temp.y = minY;
            transform.position = temp;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        switch(other.tag){
            case "Damage":
                PlayerManager.instance.decreaseLife();
                Destroy(other.gameObject);
                if(PlayerManager.instance.PlayerLifes <= 0) {
                    MenuManager.instance.GoLose();
                }
                break;
            case "Coffee":
                Destroy(other.gameObject);
                PlayerManager.instance.increaseLife();
                break;
            default:
                break;
        }
    }
}
