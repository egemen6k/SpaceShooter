using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float Horizontal;
    private float Vertical;
    public float _speed = 5f;
    IInput IInput;
    // Start is called before the first frame update
    void Start()
    {
        IInput = GetComponent<IInput>();
        if (IInput == null)
        {
            Debug.LogError("Input is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = IInput.Horizontal();
        Vertical = IInput.Vertical();

        Vector3 direction = new Vector3(Horizontal, Vertical, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x > 11.4f)
        {
            transform.position = new Vector3(-11.4f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.4f)
        {
            transform.position = new Vector3(11.4f, transform.position.y, 0);
        }
    }
}
