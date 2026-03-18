using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          //따라갈 대상
    public Vector3 offset = new Vector3(0f, 12f, -8f);
    //offset -> 카메라가 플레이어에서 얼마나 떨어져있을지 정하는 것

    void LateUpdate()   //플레이어가 먼저 움직인 다음,그 뒤에 카메라가 따라가도록 하기 위해 사용합니다.
    {
        if (target == null) return;

        transform.position = target.position + offset; //플레이어 위치를 기준으로 일정 거리 떨어진 곳에 카메라를 둡니다.
    }
}