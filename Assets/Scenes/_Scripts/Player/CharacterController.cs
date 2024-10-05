using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Vector3 velocity;
    private LayerMask groundLayers;
    [SerializeField] private LayerMask mask;
    // Start is called before the first frame update

    public void Move(Vector3 moveVector)
    {
        velocity = moveVector / Time.deltaTime;
        transform.position += moveVector;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
