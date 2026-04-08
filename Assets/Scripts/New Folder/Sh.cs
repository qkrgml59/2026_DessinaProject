using UnityEngine;

public class Sh : MonoBehaviour
{
    public GameObject projectilePrefab;   //프리팹
    public float attackInterval = 1f;     //몇초마다 공격할지
    public float attackRange = 10f;       //공격 범위
    public Transform FirePoint;

    private float attackTimer = 0f;
    private PlayerHealth1 playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth1>();
    }

    void Update()
    {
        if (playerHealth != null && playerHealth.IsDead) return;

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackInterval)
        {
            Transform target = FindNearestEnemy();

            if (target != null)
            {
                Shoot(target);
                attackTimer = 0f;
            }
        }
    }

    Transform FindNearestEnemy()        //가장 가까운 적 찾기
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Enemy 태그가 붙은 모든 적을 배열로 가져옴

        Transform nearest = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            //Distance -> 플레이어와 적 사이 거리 계싼 함수

            if (distance < nearestDistance && distance <= attackRange)
            {
                nearestDistance = distance;
                nearest = enemy.transform;
            }
        }

        return nearest;
    }

    void Shoot(Transform target)           //선택도니 적 방향으로 탄환 생성
    {
        Vector3 direction = (target.position - FirePoint.position).normalized;

        GameObject projectile = Instantiate(
            projectilePrefab,
            FirePoint.position,
            Quaternion.LookRotation(direction)
        );

        Projectile projectileScript = projectile.GetComponent<Projectile>();

        if (projectileScript != null)
        {
            projectileScript.SetDirection(direction);
        }

    }
}
