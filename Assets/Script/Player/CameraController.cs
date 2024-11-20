using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    private Transform cameraTransform;

    enum cameraDirection {
        norte,
        sul,
        leste,

        oeste
    }

    [SerializeField] cameraDirection direction;

    void Awake(){
        mainCamera = GameObject.Find("GameCamera");
        cameraTransform = mainCamera.GetComponent<Transform>();
    }

    void Update(){
        switch (direction){
            case cameraDirection.norte:

            break;

            case cameraDirection.sul:

            break;

            case cameraDirection.leste:

            break;

            case cameraDirection.oeste:

            break;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.layer == 13){
            mainCamera.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            Debug.Log("Teleport");
        }
    }


}
