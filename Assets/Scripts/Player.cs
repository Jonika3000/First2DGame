using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Player : MonoBehaviour
{
    public float speed; 
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    string currentAnimation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(movementHorizontal, movementVertical, 0) * speed * Time.deltaTime;
        if (movementHorizontal == 0 && movementVertical == 0)
        {
            ChangeAnim("PlayerIdle");
        }
        else if (movementHorizontal != 0)
        {
            ChangeAnim("PlayerWalk");
        }
        else if (movementVertical > 0)
        {
            ChangeAnim("PlayerWalkUp");
        }
        else if (movementVertical < 0)
        {
            ChangeAnim("PlayerWalkDown");
        } 
        if (sr)
            sr.flipX = movementHorizontal < 0 ? true : false; 
    }
    private void ChangeAnim(string animation)
    {
        if (currentAnimation == animation) return;
        currentAnimation = animation;
        animator.Play(currentAnimation);
    }
}
