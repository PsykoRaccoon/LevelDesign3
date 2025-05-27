using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    public string acceptedTag;
    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag(acceptedTag))
    {
        Destroy(other.gameObject);

        DeliveryManager.Instance.RegisterDelivery();
    }
}

}
