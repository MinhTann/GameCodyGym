using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum TargetEnum
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    public float speed;
    public Transform TopLeftTransform;
    public Transform TopRightTransform;
    public Transform BottomLeftTransform;
    public Transform BottomRightTransform;

    private TargetEnum nextTager = TargetEnum.TopLeft; //gan trang thai
    private Transform currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = TopLeftTransform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = currentTarget.position;
        Vector3 moveDirection = targetPosition - transform.position;

        float distance = moveDirection.magnitude; //tinh khoang cach giua 2 toa do

        if(distance > 0.1f)
        {
            //Khi chua toi diem tiep theo thi van tiep tuc di chuyen
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed*Time.deltaTime);
        } else 
        {
            NextTarget(nextTager);
        }
        //Thay doi goc quay theo huong target

        Vector3 direction = currentTarget.position - transform.position;
        Quaternion TargetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = TargetRotation;
    }
    void NextTarget(TargetEnum target)
    {
        switch(target)
        {
            case TargetEnum.TopLeft:
                currentTarget = TopLeftTransform;
                nextTager = TargetEnum.TopRight;
                break;
            case TargetEnum.TopRight:
                currentTarget = TopRightTransform;
                nextTager = TargetEnum.BottomLeft;
                break;
            case TargetEnum.BottomRight:
                currentTarget = BottomRightTransform;
                nextTager = TargetEnum.TopLeft;
                break;
            case TargetEnum.BottomLeft:
                currentTarget = BottomLeftTransform;
                nextTager = TargetEnum.BottomRight;
                break;
        }
    }
}
