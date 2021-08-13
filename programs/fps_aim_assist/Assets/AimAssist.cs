using UnityEngine;
using UnityEngine.UI;

public class AimAssist : MonoBehaviour
{
    public GameObject player;
    public GameObject reticle;

    Vector3 aimDownPos;
    Vector3 notAimingPos;
    bool gunAiming;
    bool gunMoving;
    Ray ray;
    RaycastHit hit;
    void Start()
    {
        aimDownPos = new Vector3(0.15f, -0.45f, 0.45f);
        notAimingPos = new Vector3(1f, -0.75f, 1.15f);
        gunAiming = false;
        gunMoving = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            gunMoving = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            gunMoving = true;
        }

        if (gunMoving)
        {
            if (gunAiming)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, notAimingPos, 50f * Time.smoothDeltaTime);
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, aimDownPos, 50f * Time.smoothDeltaTime);
            }
        }

        if (transform.localPosition == aimDownPos)
        {
            gunAiming = true;
            gunMoving = false;
        }
        else if (transform.localPosition == notAimingPos)
        {
            gunAiming = false;
            gunMoving = false;
        }

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) )
        {
            if (hit.collider.tag == "Enemy" && Input.GetMouseButtonDown(1))
            {
                player.transform.LookAt(hit.collider.transform.localPosition);
                Vector3 rotation = new Vector3(0f, player.transform.localEulerAngles.y, 0f);
                player.transform.localEulerAngles = rotation;
                reticle.GetComponent<Image>().color = Color.black;
            }
            else if (hit.collider.tag != "Enemy" || Input.GetMouseButtonUp(1))
            {
                reticle.GetComponent<Image>().color = Color.white;
            }
        }

    }
}
