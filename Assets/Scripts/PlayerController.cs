using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    private PlayerInput input;

    private GameObject player;
    private Mom mom;
    private ShopInventoryController shopController;
    private SpriteRenderer spriteRenderer;
    private Sprite currentSprite;

    private Rigidbody2D rb2d;
    Vector2 moveInput;
    [SerializeField] float moveSpeed;

    private InteractableObject interactableObject;
    private bool interactionAvailable;
    

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        mom = FindObjectOfType<Mom>();
        shopController = FindObjectOfType<ShopInventoryController>();
        input = new PlayerInput();
        input.Player.Interact.performed += context => OnInteract();
        input.Player.OpenShop.performed += context => OnOpenShop();
        input.Player.Move.performed += ctx => moveInput =ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }


    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 playerVelocity = new Vector2((moveInput.x * moveSpeed), (moveInput.y * moveSpeed));
        rb2d.velocity = playerVelocity;
    }


    public void OnInteract() 
    {
        Debug.Log("IsPressed");
        var interaction = FindObjectOfType<InteractionManager>().GetActiveInteraction();

        if(interaction != default(InteractableObject)) 
            {
                interaction.Interact();
            }
    }

    public void OnOpenShop()
    {
        shopController.OpenShop();
    }

    private void OnEnable()
    {
        input.Player.Enable();
    }

    private void OnDisable()
    {
        input.Player.Disable();
    }

    public void SetPlayerSprite(Sprite newSprite)
    {
        currentSprite = newSprite;
        spriteRenderer.sprite = currentSprite;
    }

    public Sprite GetPlayerSprite()
    {
        return currentSprite;
    }
}
