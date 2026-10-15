
using UnityEngine;

public class Generacion : MonoBehaviour
{
    [Header("Configuración del proyectil")]
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private float velocidad = 5f;

    [Header("Dirección del disparo")]
    [SerializeField, Range(0f, 360f)]
    private float angulo = 0f;

    [Header("Frecuencia de disparo")]
    [SerializeField] private float tiempoMinimo = 1f;
    [SerializeField] private float tiempoMaximo = 3f;

    private void Start()
    {
        Invoke(nameof(GenerarProyectil), Random.Range(tiempoMinimo, tiempoMaximo));
    }

    private void GenerarProyectil()
    {
        if (proyectilPrefab == null)
            return;

        float radianes = angulo * Mathf.Deg2Rad;

        Vector2 direccion = new Vector2(
            Mathf.Cos(radianes),
            Mathf.Sin(radianes)
        );

        GameObject nuevoProyectil = Instantiate(
            proyectilPrefab,
            transform.position,
            Quaternion.identity
        );

        Proyectil movimiento =
            nuevoProyectil.GetComponent<Proyectil>();

        if (movimiento != null)
        {
            movimiento.Configurar(direccion, velocidad);
        }

        float siguienteDisparo = Random.Range(
            tiempoMinimo,
            tiempoMaximo
        );

        Invoke(nameof(GenerarProyectil), siguienteDisparo);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}