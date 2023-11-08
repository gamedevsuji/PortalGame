using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimation : MonoBehaviour
{

    [SerializeField]private Animator dogAnimator;


    [SerializeField]private string moveDog, stopDog;

    private int move,stop;


    private void Awake()
    {
        move = Animator.StringToHash(moveDog);
        stop = Animator.StringToHash(stopDog);

    }

    public void MoveDog()=>dogAnimator.SetTrigger(move);

    public void StopDog()=>dogAnimator.SetTrigger(stop);


}
