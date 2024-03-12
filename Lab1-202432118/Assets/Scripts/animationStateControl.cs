using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class animationStateControl : MonoBehaviour
{
    Animator animator;
    int isAngryHash;
    int isDeadHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
        isAngryHash = Animator.StringToHash("provoke");
        isDeadHash = Animator.StringToHash("dead");
    }

    // Update is called once per frame
    void Update()
    {
        bool wPressed = Input.GetKey("w");
        bool sPressed = Input.GetKey("s");
        bool provoke = animator.GetBool(isAngryHash);
        bool dead = animator.GetBool(isDeadHash);

        if (!provoke && wPressed)
        {
            animator.SetBool(isAngryHash, true);
        }
        if (provoke && !wPressed)
        {
            animator.SetBool(isAngryHash, false);
        }

        if (!dead && sPressed)
        {
            animator.SetBool(isDeadHash, true);
        }
        if (dead && !sPressed)
        {
            animator.SetBool(isDeadHash, false);
        }

        if(!wPressed || !sPressed)
        {
            animator.SetBool(isDeadHash, false);
        }
    }
}
