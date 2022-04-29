using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementInput;
    private Vector2 lookInput;
    private bool ability = false;

    public bool ball = false;
    public float speed = 5f;

    public bool aim = false;

    void Update() {
        /*transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
        if(ability) {
            ability = false;
            print("ability");
        }*/

    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnAbility(InputAction.CallbackContext ctx) => ability = true;


    public void OnBall(InputAction.CallbackContext ctx) => ball = true;

    public void OnLook(InputAction.CallbackContext ctx) => lookInput = ctx.ReadValue<Vector2>();

    public void OnAim(InputAction.CallbackContext ctx) => aim = true;

    public void ResetAbility() {
        this.ability = false;
    }

    public void ResetBall() {
        this.ball = false;
    }

    public void PrintStuff() {
        print("test");
    }

    

    public Vector2 GetLookInput(){
        return lookInput;
    }

    public Vector2 GetMovementInput() {
        return movementInput;
    }
    public bool GetAbility() {
        bool toReturn = ability;
        if(ability) {
            ability = false;
        }
        return toReturn;
    }

    public bool GetBall() {
        bool toReturn = ball;
        if(ball) {
            ball = false;
        }
        return toReturn;
    }

    public bool GetAim() {
        bool toReturn = aim;
        if(aim) {
            aim = false;
        }
        return toReturn;
    }
}

