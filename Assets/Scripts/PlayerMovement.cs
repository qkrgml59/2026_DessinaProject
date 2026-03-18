using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        //플레이어 이동 속도

    //Float은 실수 데이터를 저장하는 자료형 입니다.
    //소수점 단위들은 다 float을 사용한다고 생각하시면 됩니다.

    public float minX = -14f;              //플레이어가 움직일 수 있는 맵 범위입니다.
    public float maxX = 14f;
    public float minZ = -14f;
    public float maxZ = 14f;

    // 이 숫자들이 플레이어가 움직일 수 있는 경기장의 크기라고 보면 됩니다.

    void Update()                    //매 프레임마다 실행됩니다. 즉 게임이 돌아갈때 계속 실행된다고 생각하시면 됩니다.
    {
        float x = Input.GetAxisRaw("Horizontal");         //좌우 입력입니다.    "Horizontal -> 수평 
        float z = Input.GetAxisRaw("Vertical");           //앞뒤 입력입니다.    "Vertical -> 수직
        //유니티에서 사전에 넣어둔 키들이 있어서 이 함수를 사용하는 이유는
        //우리가 이걸 사용하려고 쓰는 겁니당

        Vector3 moveDir = new Vector3(x, 0f, z).normalized;
        //normalized를 쓰는 이유
        //대각선 이동을 하면 보통 더 빨라지는 문제가 생기는데,
        //normalized를 사용하면 방향은 유지하면서 길이를 1로 맞춰서
        //대각선도 같은 속도로 움직이게 됩니다.

        Vector3 nextPosition = transform.position + moveDir * moveSpeed * Time.deltaTime;
        //nextPosition 이동 후 다음 위치를 먼저 계산합니다.
        //지금 위치를 바로 바꾸는 것이 아니라, 먼저 다음 위치를 계산한 뒤
        //그 값을 검사하고 적용합니다.

        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);
        nextPosition.z = Mathf.Clamp(nextPosition.z, minZ, maxZ);
        //Mathf-> 유니티에서 쓰는 수학 관련 기능들을 묶어둔 것입니당
        //Clamp는 숫자가 너무 작아지면 최소값으로, 너무 커지면 최대값으로 잘라주는 함수입니다.
        //예를 들면 저희가 14, -14로 값을 지정해놨는데, 플레이어가 이동하다가 너무 커지거나 작아지면
        //14, -14로 고정시켜줍니다. 그래서 플레이어는 절대 맵 밖으로 못 나갑니다.

        transform.position = nextPosition;     //그리고 최종적으로 계산된 위치를 플레이어에게 적용합니다.
        //transform.position -> 오브젝트의 위치

        if (moveDir != Vector3.zero)
        {
            transform.forward = moveDir;          
            //캐릭터가 움직이는 방향을 바라보게 하는 코드인데
            //이건 꼭 안 넣어도 괜찮지만 넣으면 훨씬 게임처럼 보입니다.
        }
        
        //저희가 아까 맵을 만들 때 벽을 막아두긴 했지만 
        //캐릭터가 벽에 부딫혀서 막히는게 아니라
        //애초에 코드상에서 저희가 최대값 최소값을 고정시켰기 때문에
        //플레이어가 벽 바깥 좌표로 나가지 못하게 했습니다.

    }
}

//## 왜 Rigidbody를 쓰지 않는가

//오브젝트를 움직이는 방법은 크게 두 가지가 있습니다.

//하나는 Rigidbody를 사용해서 물리 엔진으로 움직이는 방식이고,

//다른 하나는 오늘처럼 직접 좌표를 계산해서 움직이는 방식입니다.

//오늘 만드는 게임은 자동차나 점프 게임이 아니라

//뱀파이어 서바이벌류처럼 단순한 평면 이동이 핵심이기 때문에,

//직접 이동 방식이 더 쉽고 더 적합합니다.
