
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class movimientoBola : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;

    private Rigidbody2D rigidbody2;
    private bool enSuelo;
    private float movimientoBolita;

    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movimientoBolita = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            movimientoBolita = -1f;

        if (Input.GetKey(KeyCode.RightArrow))
            movimientoBolita = 1f;

        if ((Input.GetKeyDown(KeyCode.Space) ||
             Input.GetKeyDown(KeyCode.UpArrow)) && enSuelo)
        {
            rigidbody2.AddForce(
                Vector2.up * fuerzaSalto,
                ForceMode2D.Impulse
            );

            enSuelo = false;
        }
    }

    private void FixedUpdate()
    {
        rigidbody2.linearVelocity = new Vector2(
            movimientoBolita * velocidad,
            rigidbody2.linearVelocity.y
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
            enSuelo = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
            enSuelo = false;
    }
}
