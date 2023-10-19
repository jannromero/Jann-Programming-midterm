using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 _moveDirection;

    private Rigidbody rb;

    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this); //puts the game controls on the player
        InputManager.SetGameControls();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * _moveDirection;

        Debug.Log("Score: " + score); //score is in debug log
    }

    public void SetMovementDirection(Vector2 currentDirection){
        _moveDirection = currentDirection;
    }

}

