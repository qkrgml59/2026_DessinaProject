using UnityEngine;

public class xpPickup : MonoBehaviour
{
    public int xpAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerLevel playerLevel = other.GetComponent<PlayerLevel>();

        if (playerLevel != null)
        {
            playerLevel.Addxp(xpAmount);
        }

        Destroy(gameObject);

    }
}
