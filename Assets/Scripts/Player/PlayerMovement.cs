using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 7;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime, Space.World);
    }
}
