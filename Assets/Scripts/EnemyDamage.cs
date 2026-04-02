using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;                  //데미지
    public float attackInterval = 1f;       //몇초마다 데미지를 줄지 정하기

    public float attackTimer = 0f;          //누적 시간

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (attackTimer < attackInterval) return;

        PlayerHealth1 playerHealth = other.GetComponent<PlayerHealth1>();

        if(playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            attackTimer = 0f;
        }

    }
}
