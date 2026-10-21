using Unity.VisualScripting;
using UnityEngine;

public class SlimeFollow : MonoBehaviour
{

    public Transform target; //put the chef player in the editor
    public float speed = 3f;

    //public bool wave1Start = true;

    Rigidbody2D body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // slime position changes. transform is slime. target is chef. speed is speed

    }
}
