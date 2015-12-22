using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class touch : MonoBehaviour
{
    public LayerMask touchInputmask;
    public Transform ya;
    public bool usemouse = false;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchold;
    private RaycastHit hit;

    void Update()
    {
        //if(usemouse)
#if UNITY_EDITOR
        mouse();
#endif
        //else
        touch1();
    }

    void touch1()
    {
        if (Input.touchCount > 0)
        {
            touchold = new GameObject[touchList.Count];
            touchList.CopyTo(touchold);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);


                if (Physics.Raycast(ray, out hit, touchInputmask))
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);

                    /*if (hit.transform.gameObject.CompareTag("ya"))
                    {
                        var pos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                        Instantiate(ya, pos, ya.transform.rotation);
                    }*/

                    if (touch.phase == TouchPhase.Began)
                    {
                        recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                    {
                        recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Canceled)
                    {
                        recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
            foreach (GameObject g in touchold)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
    void mouse()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            touchold = new GameObject[touchList.Count];
            touchList.CopyTo(touchold);
            touchList.Clear();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, touchInputmask))
            {
                GameObject recipient = hit.transform.gameObject;
                touchList.Add(recipient);

                /*if (hit.transform.gameObject.tag == "ya")
                {
                    var pos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    Instantiate(ya, pos, ya.transform.rotation);
                }*/

                if (Input.GetMouseButtonDown(0))
                {
                    recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButton(0))
                {
                    recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }

            foreach (GameObject g in touchold)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
