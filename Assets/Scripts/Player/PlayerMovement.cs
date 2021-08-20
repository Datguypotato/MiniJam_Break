using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 7;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime, Space.World);
    }
}
