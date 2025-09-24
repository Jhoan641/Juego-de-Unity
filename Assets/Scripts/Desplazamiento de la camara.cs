using UnityEngine;

public class Desplazamientodelacamara : MonoBehaviour
{   
    //la velocidad a la que se arrastrara la pantalla del videojuego.
    public float velocidadArrastre = 1f;

    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    public float scrollMin = 2f;
    public float scrollMax = 5f;

    private Camera camaraPrincipal;

    public float velocidadScroll = 5f;

    //Guarda la ultima posición del ratón,con el fin de poder calcular cuanto se ha movido
    private Vector3 ultimaPosicion;

    private void Start()
    {
        camaraPrincipal = GetComponent<Camera>();
    }
    void Update()
    {
        // 1. Detectar el primer click del botón izquierdo (botón 0), usando la función GetMouseButtonDown
        if (Input.GetMouseButtonDown(0))
        {
            // Guardamos la posición actual del ratón para usarla como punto de referencia.
            ultimaPosicion = Input.mousePosition;
        }

        // 2. Detectar MIENTRAS el botón derecho está presionado
        if (Input.GetMouseButton(0))
        {
            // Calculamos la diferencia de posición desde el último frame, esto se guardara en la variable delta.
            Vector3 delta = Input.mousePosition - ultimaPosicion;

            // Movemos la cámara en la dirección OPUESTA al movimiento del ratón. esto mediante la varaible -delta.x y -delta.y. Al decir que es -delta quiere decir que se movera en la dirección opuesta.
            // Usamos Time.deltaTime para que el movimiento sea fluido sin importar los FPS.
            transform.Translate(-delta.x * velocidadArrastre * Time.deltaTime, -delta.y * velocidadArrastre * Time.deltaTime, 0);

            // Actualizamos la última posición para el siguiente frame.
            ultimaPosicion = Input.mousePosition;

        }

        // --- Lógica de Límites ---
        // 1. Guardamos la posición actual en una variable temporal, esto para poder asignarla más tarde
        Vector3 posicionClampeada = transform.position;

        // 2. "Clampeamos" o limitamos los valores X e Y de esa variable.
        posicionClampeada.x = Mathf.Clamp(posicionClampeada.x, minX, maxX);
        posicionClampeada.y = Mathf.Clamp(posicionClampeada.y, minY, maxY);

        // 3. Asignamos la variable ya corregida de vuelta a la posición de la cámara.
        transform.position = posicionClampeada;




        //Scroll del ratón

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        camaraPrincipal.orthographicSize -= scrollInput * velocidadScroll;

        camaraPrincipal.orthographicSize = Mathf.Clamp(camaraPrincipal.orthographicSize, 2f, 5f);



    }
}
