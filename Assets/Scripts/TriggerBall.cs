using UnityEngine;

public class TriggerBall : MonoBehaviour
{
    public Transform muzzle;
    private BoxCollider boxCollider;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
    }
    private void Update()
    {
        transform.position=muzzle.transform.position;
        if((Input.GetKeyDown(KeyCode.Q)||Input.GetButtonDown("Punch"))&& !Input.GetKey(KeyCode.W))
        {
            boxCollider.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetButtonUp("Punch"))
        {
            boxCollider.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();

            if (otherRigidbody != null)
            {
                
                otherRigidbody.AddForce(0,0,1500);
            }
        }
    }


}