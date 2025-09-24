using System.Collections.Generic;
//Se usa la biblioteca de unity y clases de unity
using UnityEngine;

//Se crea una clase en unity, lo cual como bien sabemosm, es una plantilla para crear objetos
//MonoBehaviur le dice que el objeto de juego (GameObject) puede usar funciones como Start() o Update()
public class CreandoMapa : MonoBehaviour
{

    //Se crea una referencia publica para asignarla desde el editor
    // Las variables son de tipo Sprite y esto les dice que son variables que 
    //Actuaran como contenedores para nuestras imágenes de cuadrado, círculo, triangulo.
    public Sprite spriteCuadrado;
    public Sprite spriteTriangulo;
    public Sprite spriteCirculo;

    public List<GameObject> formasCreadas = new List<GameObject>();

    void Start()
    {
        //Dentro de la función de Start() todo se ejecutara al inicio del juego, en esta creamos un bucle for que se ejecutara 3 veces
        //Dentro de este bucle crearemos una variable float que tomara un nuevo valor cada bucle, según el tipo de i que sea. 
        //Dentro crearemos 3 formas con un valor random en X

        for (int i = 0; i < 3; i++)
        {
            float iniciox;

            if (i == 0)
            {
                iniciox = Random.Range(-0.30f, -0.23f);

                CrearFormaHija(new Vector2(iniciox, 0.0f));
                CrearFormaHija(new Vector2(iniciox, 0.3f));
                CrearFormaHija(new Vector2(iniciox, -0.3f));
            }

            if (i == 1)
            {
                iniciox = Random.Range(-0.05f, 0.05f);

                CrearFormaHija(new Vector2(iniciox, 0.0f));
                CrearFormaHija(new Vector2(iniciox, 0.3f));
                CrearFormaHija(new Vector2(iniciox, -0.3f));
            }

            if (i == 2)
            {
                iniciox = Random.Range(0.30f, 0.23f);

                CrearFormaHija(new Vector2(iniciox, 0.0f));
                CrearFormaHija(new Vector2(iniciox, 0.3f));
                CrearFormaHija(new Vector2(iniciox, -0.3f));
            }
        }

        CrearLinea(formasCreadas[1], formasCreadas[3]);
    }

    // Esta es la funcion que se usa para crear las figuras
    void CrearFormaHija (Vector2 posicionLocal)
    {

        Sprite[] formas = { spriteCirculo, spriteCuadrado, spriteTriangulo };

        int tipo = Random.Range(0, 3);

        //Se declara una nueva variable de tipo GameObject y sirve para almacenar el objeto de juego
        GameObject nuevaForma = new GameObject(formas[tipo].name);

        //Cremoas una variable donde le añadimos el componente SpriteRenderer. Esto porque
        //Un GameObject vacío no es visible. Para que pueda mostrar una imagen tiene que ser rendeizado
        SpriteRenderer renderer = nuevaForma.AddComponent<SpriteRenderer>();

        //Se le asigna la propiedad sprite a SpriteForma
        renderer.sprite = formas[tipo];

        renderer.sortingOrder = 1;

        //Se accede a la propiedad de trasform del GameObject creado y .SetParent() establece una realción
        //Entre el padre y el hijo. diciendole que el padre sera quien ejecute el Script
        //Por ultimo this.trasform se refiere a el trasform del objeto padre
        nuevaForma.transform.SetParent(this.transform);

        //Le pasamos a el objeto creado la posición local asginado como paremtro en la función
        nuevaForma.transform.localPosition = posicionLocal;

        formasCreadas.Add(nuevaForma);

        
    }

    void CrearLinea (GameObject primeraForma, GameObject segundaForma)
    {
        GameObject nuevaLinea = new GameObject("Linea");

        LineRenderer linea = nuevaLinea.AddComponent<LineRenderer>();

        linea.positionCount = 2;

        linea.SetPosition(0,primeraForma.transform.position);
        linea.SetPosition(1,segundaForma.transform.position);

        linea.sortingOrder = 1;

        linea.startColor = Color.blue;
    }
}
