using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Transform target;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if(player != null)
        {
            target = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0f;

        Vector3 moveDir = direction.normalized;

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if(moveDir != Vector3.zero)
        {
            transform.forward = moveDir;
        }
       
    }
}
