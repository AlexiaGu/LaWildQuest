using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManagerPnj : MonoBehaviour
{
    private static GameManagerPnj instance;
    [SerializeField] private PlayerInput inputs;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;

       
    }

    public static GameManagerPnj GetInstance() { return instance; }

    public PlayerInput GetInputs() { return inputs; }   
}
