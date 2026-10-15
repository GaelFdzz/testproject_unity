
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private float velocidad;
    private float direccion;

    public void Configurar(float direccion, float velocidad)
    {
        this.direccion = direccion;
        this.velocidad = velocidad;

        float rotacion = direccion > 0 ? -90f : 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotacion);
    }

    private void Update()
    {
        transform.position += Vector3.right * direccion * velocidad * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) > 15f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Luna"))
        {
            Time.timeScale = 0f;
        }
    }
}
