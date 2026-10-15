
using UnityEngine;

public class Generacion : MonoBehaviour
{
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float tiempoMinimo = 1f;
    [SerializeField] private float tiempoMaximo = 3f;
    [SerializeField] private float distanciaLateral = 10f;

    private void Start()
    {
        Invoke(nameof(GenerarProyectil), 1f);
    }

    private void GenerarProyectil()
    {
        int lado = Random.Range(0, 2);

        float direccion = lado == 0 ? 1f : -1f;

        Vector2 posicion = new Vector2(
            transform.position.x + (distanciaLateral * direccion),
            transform.position.y
        );

        GameObject nuevoProyectil = Instantiate(
            proyectilPrefab,
            posicion,
            Quaternion.identity
        );

        Proyectil movimiento = nuevoProyectil.GetComponent<Proyectil>();

        movimiento.Configurar(-direccion, velocidad);

        Invoke(nameof(GenerarProyectil), Random.Range(tiempoMinimo, tiempoMaximo));
    }
}
