
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private Vector2 direccion;
    private float velocidad;
    [Header("Tiempo de vida en segundos")]
    [SerializeField] private float tiempoVida = 10f;

    public void Configurar(Vector2 direccion, float velocidad)
    {
        this.direccion = direccion.normalized;
        this.velocidad = velocidad;

        float angulo = Mathf.Atan2(
            this.direccion.y,
            this.direccion.x
        ) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(
            0f, 0f, angulo - 90f
        );

        Destroy(gameObject, tiempoVida);
    }

    private void Update()
    {
        transform.position += (Vector3)(direccion * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Luna"))
        {
            Time.timeScale = 0f;
        }
    }
}
