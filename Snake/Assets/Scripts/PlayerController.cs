using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 5;
    public float rotateSpeed = 20;

    public GameObject bodyPrefab;

    private GameObject lastBodyPart;

    void Start()
    {
        lastBodyPart = transform.gameObject;
        Spawn();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 100, Color.green);

        Ray mouseRay;
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mouseRay, out hit) && hit.transform.tag == "Ground")
        {
            Vector3 mousePosition = hit.point;
            mousePosition.y = transform.position.y;

            //Vector3 dir = Vector3.RotateTowards(transform.position, mousePosition, rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(hit.point);
            //transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Food")
        {
            Destroy(other.gameObject);
            Spawn();            
        }
    }

    void Spawn()
    {
        Vector3 spawnLocation = lastBodyPart.transform.position;
        spawnLocation.z = spawnLocation.z - 1;
        GameObject newestSpawn = Instantiate(bodyPrefab, spawnLocation, Quaternion.identity) as GameObject;
        newestSpawn.GetComponent<Follower>().target = lastBodyPart;
        lastBodyPart = newestSpawn;
    }

}
