using UnityEngine;

public class Grab : MonoBehaviour
{
    public float grabDistance;
    public LayerMask grabLayer;
    public Transform holdPoint; 
    private GameObject heldObject;
    public KeyCode grabKey = KeyCode.E;

    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * grabDistance, Color.red);

        if (heldObject == null)
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, grabDistance, grabLayer))
            {
                if (Input.GetKeyDown(grabKey))
                {
                    GrabObject(hit.transform.gameObject);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(grabKey))
            {
                DropObject();
            }
        }
    }

    void GrabObject(GameObject obj)
    {
        heldObject = obj;
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.position = holdPoint.position;
        obj.transform.SetParent(holdPoint);
    }

    void DropObject()
    {
        heldObject.GetComponent<Rigidbody>().useGravity = true;
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
    }
}
