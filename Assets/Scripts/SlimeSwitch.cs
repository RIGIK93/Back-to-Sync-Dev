using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSwitch : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Cainos.PixelArtTopDown_Basic.CameraFollow camera;
    [SerializeField] private KeyCode button = KeyCode.S;
    private bool switched = false;
    RIGIK93.HorizontalMovement xMovement1;
    RIGIK93.HorizontalMovement xMovement2;
    RIGIK93.Jump Jump1;
    RIGIK93.Jump Jump2;
    // Start is called before the first frame update
    void Start()
    {
        xMovement1 = player1.GetComponent<RIGIK93.HorizontalMovement>();
        xMovement2 = player2.GetComponent<RIGIK93.HorizontalMovement>();
        Jump1 = player1.GetComponent<RIGIK93.Jump>();
        Jump2 = player2.GetComponent<RIGIK93.Jump>();
        xMovement2.blockInput = true;
        Jump2.blockInput = true;
    }

    void switchPlayers()
    {
        switched = !switched;
        process();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(button)) switchPlayers();
    }

    void process()
    {
        if (switched)
        {
            xMovement1.blockInput = true;
            Jump1.blockInput = true;
            xMovement2.blockInput = false;
            Jump2.blockInput = false;
            camera.target = player2.transform;
        }
        else
        {
            xMovement1.blockInput = false;
            Jump1.blockInput = false;
            xMovement2.blockInput = true;
            Jump2.blockInput = true;
            camera.target = player1.transform;

        }
    }
}
