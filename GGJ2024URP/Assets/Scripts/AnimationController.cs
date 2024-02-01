using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

    Vector2 keybrdInput;
    //bool shiftIsPressed = false;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();

        playerAnimator.SetLayerWeight(1, 0);
        playerAnimator.SetLayerWeight(2, 0);
    }

    void Update()
    {
        keybrdInput = KeyboardInput();
        //CheckLeftShifit();

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)) keybrdInput.y = 1.5f;

        playerAnimator.SetFloat("InputX", keybrdInput.x);
        playerAnimator.SetFloat("InputY", keybrdInput.y);
    }

    Vector2 KeyboardInput()
    {
        Vector2 kbrd = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        return kbrd;
    }

    //void CheckLeftShifit()
    //{
    //    if(Input.GetKey(KeyCode.LeftShift))
    //    {
    //        shiftIsPressed = true;
    //    }
    //    else
    //    {
    //        shiftIsPressed = false;
    //    }
    //}
}
