using UnityEngine;

public class Desplazamientodelacamara : MonoBehaviour
{   
    //la velocidad a la que se arrastrara la pantalla del videojuego.
    public float velocidadArrastre = 17f;

    //Guarda la ultima posición del ratón,con el fin de poder calcular cuanto se ha movido
    private Vector3 ultimaPosicion;
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
    }
}
