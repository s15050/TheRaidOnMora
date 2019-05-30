using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    //Kamera
    public Camera mainCam;

    //Prędkości
    public float speed = 5f; //Prędkość przesuwania (WASD/strzałki)
    public float rotationSpeed = 1.3f; //Prędkość obracania (Q/E)
    public float zoomSpeed = 40f; //Prędkość zoomu (koło myszy)
    public float mouseRotSpeed = 2f; //Prędkość obracania środkowym przyciskiem myszy

    //Ograniczenia
    public float squarePanClamp = 4.5f; //O ile od początkowej pozycji można przesunąć kamerę (trzeba aktualizować z każdym rozmiarem mapy!)
    public float zoomInClamp = 4f; //Jak blisko można przybliżyć (stałe)
    public float zoomOutClamp = 12f; //Jak daleko można oddalić (zależne od rozmiaru mapy?)

    //Do ograniczania przesuwania:
    private Vector3 startingPos;
    private float rightClamp;
    private float leftClamp;
    private float downClamp;
    private float upClamp;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        rightClamp = startingPos.x + squarePanClamp;
        leftClamp = startingPos.x - squarePanClamp;
        downClamp = startingPos.z - squarePanClamp;
        upClamp = startingPos.z + squarePanClamp;
    }

    // Update is called once per frame
    void Update()
    {
        //Przesuwanie kamery
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (pos.x < rightClamp)
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (pos.x > leftClamp)
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (pos.z > downClamp)
                transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (pos.z < upClamp)
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }

        //Obracanie lewo/prawo
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, 0f, -rotationSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 0f, rotationSpeed);
        }

        //Obracanie przyciśnięciem środkowego przycisku myszy
        //NOPE! Rozpada się przy obracaniu Q/E
        //Być może użyć jakiegoś localRotation?
        /*if (Input.GetMouseButton(2))
        {
            if ((mainCam.transform.rotation.x < 0.70711) && (Input.GetAxis("Mouse Y") > 0))
            {
                mainCam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * mouseRotSpeed, 0, 0)); // -Input.GetAxis("Mouse X") * mouseRotSpeed, 0));
                //transform.Rotate(0f, 0f, -Input.GetAxis("Mouse X") * mouseRotSpeed);
                float X = mainCam.transform.rotation.eulerAngles.x;
                float Y = mainCam.transform.rotation.eulerAngles.y;
                mainCam.transform.rotation = Quaternion.Euler(X, Y, 0);
            }
            else if ((mainCam.transform.rotation.x > 0.3851227) && (Input.GetAxis("Mouse Y") < 0))
            {
                mainCam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * mouseRotSpeed, 0, 0)); // -Input.GetAxis("Mouse X") * mouseRotSpeed, 0));
                //transform.Rotate(0f, 0f, -Input.GetAxis("Mouse X") * mouseRotSpeed);
                float X = mainCam.transform.rotation.eulerAngles.x;
                float Y = mainCam.transform.rotation.eulerAngles.y;
                mainCam.transform.rotation = Quaternion.Euler(X, Y, 0);
            }
        }*/

        //Pomoc
        if (mainCam.transform.rotation.x < 0)
        {
            mainCam.transform.rotation = transform.rotation;
        }

        //Zoom
        float YVal = transform.position.y;
        float zoomVal = Input.GetAxis("Mouse ScrollWheel");
        if ((zoomVal > 0) && (YVal > zoomInClamp))
            gameObject.transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime);
        else if ((zoomVal < 0) && (YVal < zoomOutClamp))
            gameObject.transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime);
    }

    public void ResetCamPosition()
    {
        transform.position = startingPos;
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        mainCam.transform.position = transform.position;
        mainCam.transform.rotation = transform.rotation;
    }
}
