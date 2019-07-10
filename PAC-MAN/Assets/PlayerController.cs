using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 touchStartPos;
    Vector3 touchEndPos;
    enum Directions {
        Right = 0, Left = 1, Up = 2, Down = 3
    };
    int PlayerState;

    // Start is called before the first frame update
    void Start()
    {
        PlayerState = (int)Directions.Left;
    }

    // Update is called once per frame
    void Update()
    {
        DetectFric();
        MovePlayer();
    }

    void DetectFric()
    {
        if (Input.GetMouseButtonDown(0)) {
            this.touchStartPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0)) {
            this.touchEndPos = Input.mousePosition;
        }

        GetDirection();
    }

    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;

        if (Mathf.Abs(directionX) > Mathf.Abs(directionY)) {
            if (directionX > 30) {
                //Right Fric
                PlayerState = (int)Directions.Right;
                Debug.Log("Right");
            }
            else if (directionY < -30) {
                //Left Fric
                PlayerState = (int)Directions.Left;
                Debug.Log("Left");
            }
        }
        else if(Mathf.Abs(directionY) > Mathf.Abs(directionX)){
            if (directionY > 30) {
                //Up Fric
                PlayerState = (int)Directions.Up;
                Debug.Log("Up");
            }
            else if (directionY < -30) {
                //Down Fric
                PlayerState = (int)Directions.Down;
                Debug.Log("Down");
            }
        }
    }


    void MovePlayer() {
        switch (PlayerState) {
            case (int)Directions.Right:
                MoveRight();
                break;

            case (int)Directions.Left:
                MoveLeft();
                break;

            case (int)Directions.Up:
                MoveUp();
                break;

            case (int)Directions.Down:
                MoveDown();
                break;
        }
    }

    void MoveRight() {
        this.transform.Translate(0.1f, 0, 0, Space.World);
        
    }

    void MoveLeft() {
        this.transform.Translate(-0.1f, 0, 0, Space.World);
    }

    void MoveUp() {
        this.transform.Translate(0, 0, 0.1f, Space.World);
    }

    void MoveDown() {
        this.transform.Translate(0, 0, -0.1f, Space.World);
    }
}
