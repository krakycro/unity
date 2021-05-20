using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movez : MonoBehaviour {

    [SerializeField]
    float speed = 4f;
    Vector3 posX, posY;

	// Use this for initialization
	void Start () {
        posX = Camera.main.transform.forward;
        posX.y = 0;
        posX = Vector3.Normalize(posX);
        posY = Quaternion.Euler(new Vector3(0, 90, 0)) * posX;

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            Move();
        }
	}

    void Move()
    {
        Vector3 goY = posY * speed * Time.deltaTime * Input.GetAxis("Hmove");
        Vector3 goX = posX * speed * Time.deltaTime * Input.GetAxis("Vmove");

        Vector3 point = Vector3.Normalize(goX + goY);

        transform.forward = point;
        transform.position += goX;
        transform.position += goY;
    }

    void OnTriggerEnter(Collider other)
    {
        if ( other.ClosestPoint(transform.position).z > 1 )
        {
            Vector3 goZ = speed * Time.deltaTime * new Vector3(0, 5, 0);

            Debug.Log("True");
            transform.position += new Vector3(0, 5, 0);
        }
    }

}
