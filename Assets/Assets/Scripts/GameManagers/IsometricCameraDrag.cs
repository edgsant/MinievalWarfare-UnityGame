using UnityEngine;
using UnityEngine.InputSystem;

public class IsometricCameraSpan : MonoBehaviour
{


    public float dragSpeed = 10f;
    private Vector3 dragPosition;
    private Vector3 lastMousePos;
    private InputAction mousePressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mousePressed = InputSystem.actions.FindAction("MousePress");
    }

    // Update is called once per frame
    void Update()
    {
        // Cuando se presiona el botón del ratón, guardamos la posición inicial
        if (mousePressed.WasPressedThisFrame())
        {
            lastMousePos = Mouse.current.position.ReadValue();
        }

        // Mientras el botón esté presionado, desplazamos
        if (mousePressed.IsPressed())
        {
            Vector3 currentMousePos = Mouse.current.position.ReadValue();
            Vector3 delta = currentMousePos - lastMousePos;

            // Convertimos el desplazamiento de pantalla a movimiento en el mundo
            Vector3 move = new Vector3(-delta.x, -delta.y, 0) * Time.deltaTime * dragSpeed;
            transform.Translate(move, Space.World);

            lastMousePos = currentMousePos;
        }
    }
}
