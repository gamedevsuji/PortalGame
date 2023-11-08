using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoSingleton<InputController>
{

    [SerializeField]private PlayerInput playerInput;
    [SerializeField] private Controls controls;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private bool navigateInput;
    private bool placeCubeInput;
    private float zoomInInput;
    private float zoomOutInput;


    public Vector2 GetPlayerMovement() => moveInput;
    public Vector2 GetLook() => lookInput;
    public bool GetNavigate() => navigateInput;
    public bool GetCubePlacement() => placeCubeInput;

    public float GetZoomIn() => zoomInInput;
    public float GetZoomOut() => zoomOutInput;


    private void Awake() => controls = new Controls();

    private void OnEnable() 
    { 
        controls.Gameplay.Move.Enable();
        controls.Gameplay.Look.Enable();
        controls.Gameplay.Navigate.Enable();
        controls.Gameplay.PlaceCube.Enable();
        controls.Gameplay.ZoomIn.Enable();
        controls.Gameplay.ZoomOut.Enable();


        controls.Gameplay.Move.started += OnMovementInput;
        controls.Gameplay.Move.performed += OnMovementInput;
        controls.Gameplay.Move.canceled += OnMovementInput;

        controls.Gameplay.Look.started += OnLookInput;
        controls.Gameplay.Look.performed += OnLookInput;
        controls.Gameplay.Look.canceled += OnLookInput;

        controls.Gameplay.Navigate.started += OnNavigate;
        controls.Gameplay.Navigate.canceled += OnNavigate;

        controls.Gameplay.PlaceCube.started += OnPlaceCube;
        controls.Gameplay.PlaceCube.canceled += OnPlaceCube;

        controls.Gameplay.ZoomIn.started += OnZoomIn;
        controls.Gameplay.ZoomIn.performed += OnZoomIn;
        controls.Gameplay.ZoomIn.canceled += OnZoomIn;

        controls.Gameplay.ZoomOut.started += OnZoomOut;
        controls.Gameplay.ZoomOut.performed += OnZoomOut;
        controls.Gameplay.ZoomOut.canceled += OnZoomOut;

    }

    private void OnDisable() 
    {
        controls.Gameplay.Move.Disable();
        controls.Gameplay.Look.Disable();
        controls.Gameplay.Navigate.Disable();
        controls.Gameplay.PlaceCube.Disable();
        controls.Gameplay.ZoomIn.Disable();
        controls.Gameplay.ZoomOut.Disable();



        controls.Gameplay.Move.started -= OnMovementInput;
        controls.Gameplay.Move.performed -= OnMovementInput;
        controls.Gameplay.Move.canceled -= OnMovementInput;

        controls.Gameplay.Look.started -= OnLookInput;
        controls.Gameplay.Look.performed -= OnLookInput;
        controls.Gameplay.Look.canceled -= OnLookInput;

        controls.Gameplay.Navigate.started -= OnNavigate;
        controls.Gameplay.Navigate.canceled -= OnNavigate;

        controls.Gameplay.PlaceCube.started -= OnPlaceCube;
        controls.Gameplay.PlaceCube.canceled -= OnPlaceCube;

        controls.Gameplay.ZoomIn.started -= OnZoomIn;
        controls.Gameplay.ZoomIn.performed -= OnZoomIn;
        controls.Gameplay.ZoomIn.canceled -= OnZoomIn;

        controls.Gameplay.ZoomOut.started -= OnZoomOut;
        controls.Gameplay.ZoomOut.performed -= OnZoomOut;
        controls.Gameplay.ZoomOut.canceled -= OnZoomOut;
    }

    private void OnMovementInput(InputAction.CallbackContext context) => moveInput = context.ReadValue<Vector2>();
    private void OnLookInput(InputAction.CallbackContext context) => lookInput = context.ReadValue<Vector2>();
    private void OnNavigate(InputAction.CallbackContext context) => navigateInput = context.ReadValueAsButton();
    private void OnPlaceCube(InputAction.CallbackContext context) => placeCubeInput = context.ReadValueAsButton();
    private void OnZoomIn(InputAction.CallbackContext context) => zoomInInput = context.ReadValue<float>();

    private void OnZoomOut(InputAction.CallbackContext context) => zoomOutInput = context.ReadValue<float>();

}
