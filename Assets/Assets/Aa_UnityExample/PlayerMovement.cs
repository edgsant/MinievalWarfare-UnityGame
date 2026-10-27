using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, Interactable
{
    public float speed;
    private bool isMoving;
    private bool isDialog;
    private Vector2 input;

    private Animator animator;

    public LayerMask solidObjectsLayer;
    public LayerMask islandLayer;
    public LayerMask interactableLayer;
    public AudioClip choque;
   

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var playerPos = transform.position;
                playerPos.x += input.x;
                playerPos.y += input.y;

                if (!isSolid(playerPos) && isInIsland(playerPos) && !DialogManager.Instance.isOpenDialog())
                {
                    
                    StartCoroutine(Move(playerPos));
                }
            }
        }
        animator.SetBool("isMoving", isMoving);

        if(!DialogManager.Instance.isOpenDialog() && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
        
    }


    IEnumerator Move(Vector3 playerPos)
    {
        isMoving = true;

        while((playerPos -transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = playerPos;

        isMoving = false;
    }

    private bool isSolid(Vector3 playerPos)
    {
        if (Physics2D.OverlapCircle(playerPos, 0.2f, solidObjectsLayer | interactableLayer) != null)
        {
            AudioManagerTutorial.Instance.PlayClip(choque);
            return true;
        }
        return false;
    }

    private bool isInIsland(Vector3 playerPos)
    {
        if (Physics2D.OverlapCircle(playerPos, 0.2f, islandLayer) != null)
        {
             return true;
        }
        return false;
    }

    public void Interact()
    {
        var playerDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + playerDir;
    
        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }
}
