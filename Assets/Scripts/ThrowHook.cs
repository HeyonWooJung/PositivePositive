using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHook : MonoBehaviour
{

    public GameObject hook;
    GameObject curHook;
    Vector2 dest;
    Vector2 rayDir;

    public GameObject GetCurHook()
    {
        return curHook;
    }
    public bool IsHookEnabled()
    {
        return curHook != null;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rayDir = (dest - (Vector2)transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDir, 10, LayerMask.GetMask("Platforms"));
            Debug.DrawRay(transform.position, transform.up, new Color(0, 1, 0));

            curHook = Instantiate(hook, transform.position, Quaternion.identity);

            if (curHook != null)
            {
                if (hit)
                {
                    Debug.Log(" aa " + hit.point + " " + hit.collider.name);
                    dest = hit.point;
                }
                curHook.GetComponent<RopeScript>().dest = dest;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Destroy(curHook);
            gameObject.GetComponent<Player>().SetBoost(false);
        }
    }

}
