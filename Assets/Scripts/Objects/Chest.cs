using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] graphisms;
    [SerializeField] private Sprite[] openSprite;
    [SerializeField] private Sprite[] closedSprite;

    private GameManager manager;

    private InputAction interactAction;
    
    private bool isReach = false;
    private bool open = false;

    private void Start()
    {
        manager = GameManager.GetInstance();
        interactAction = manager.GetInputs().actions.FindAction("Interact");
    }

    private void Update()
    {
        float _interact = interactAction.ReadValue<float>();

        if (isReach && _interact > 0)
        {
            Open();
        }
        else if (!isReach)
        {
            Close();
        }
    }

    private void Open()
    {
        open = true;
        for(int i=0;i<graphisms.length;i++)
        {
            graphisms[i].sprite=openSprite[i];
        }
    }
    private void Close()
    {
        open = false;
        for(int i=0;i<graphisms.length;i++)
        {
            graphisms[i].sprite=closedSprite[i];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReach = false;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
