using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float speed; //velocidad de plataforma
    [SerializeField] int startingPoint;
    [SerializeField] Transform[] points; //Array de ppuntos de posiciones a los que la plataforma se moverá
    private int i; //Índice del array







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       //Setear la posición inicial de la plataforma
       transform.position = points[startingPoint].position;



    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length) //Mira si la plataforma ha llegado al último punto
            {
                i = 0; //Resetea para que vuelva a empezar la plataforma
            }
        
        }

        //Mueve la plataforma a la posición que esta guardada en el array en el espacio con el valor igual a i
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime); 
    }



}
