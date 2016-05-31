using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour
{
    public GameObject target;
    public float speed = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
