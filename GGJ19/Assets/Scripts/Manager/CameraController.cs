using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

    public static CameraController Instance;
    
    public Transform target;

    public float maxHorizontalDeviation = 2;
    public float maxVerticalDeviation = 1;

    public float horizontalOffset = -2;

    public float verticalOffset = -2;

    public Camera Camera;

    void Awake()
    {
        Instance = this;
        Camera = GetComponent<Camera>();
    }

    Vector3 aux = new Vector3();
    float auxXVel = 0;
    float auxYVel = 0;
    float vO;


	void Update () {
        if (target != null)
        {

            aux = transform.position;
            //Debug.Log(transform.position.x + " <> " + target.position.x);
            if (transform.position.y > target.position.y + (maxVerticalDeviation - vO))
            {
                aux.Set(aux.x, target.position.y + (maxVerticalDeviation - vO), aux.z);
            }
            if (transform.position.y < target.position.y - (maxVerticalDeviation + vO))
            {
                aux.Set(aux.x, target.position.y - (maxVerticalDeviation + vO), aux.z);
            }
            //transform.position = aux;


            if (transform.position.x > target.position.x + (maxHorizontalDeviation - horizontalOffset))
            {
                aux.Set(target.position.x + (maxHorizontalDeviation - horizontalOffset), aux.y, aux.z);
            }
            if (transform.position.x < target.position.x - (maxHorizontalDeviation + horizontalOffset))
            {
                aux.Set(target.position.x - (maxHorizontalDeviation + horizontalOffset), aux.y, aux.z);
            }


                
        }

        transform.position = Vector3.Lerp(aux, transform.position, 0.7f);//0.94f);
	}


    Vector3 gizmoLineLeftUp;
    Vector3 gizmoLineRightUp;
    Vector3 gizmoLineLeftDown;
    Vector3 gizmoLineRightDown;


    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        gizmoLineLeftUp = transform.position + Vector3.left * (maxHorizontalDeviation - horizontalOffset) + Vector3.up * (maxVerticalDeviation + verticalOffset);
        gizmoLineLeftDown = transform.position + Vector3.left * (maxHorizontalDeviation - horizontalOffset) + Vector3.down * (maxVerticalDeviation - verticalOffset);
        gizmoLineRightUp = transform.position + Vector3.right * (maxHorizontalDeviation + horizontalOffset) + Vector3.up * (maxVerticalDeviation + verticalOffset);
        gizmoLineRightDown = transform.position + Vector3.right * (maxHorizontalDeviation + horizontalOffset) + Vector3.down * (maxVerticalDeviation - verticalOffset);



        Gizmos.DrawLine(gizmoLineLeftUp, gizmoLineLeftDown);
        Gizmos.DrawLine(gizmoLineLeftDown, gizmoLineRightDown);
        Gizmos.DrawLine(gizmoLineRightDown, gizmoLineRightUp);
        Gizmos.DrawLine(gizmoLineRightUp, gizmoLineLeftUp);
    }


}
