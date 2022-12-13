using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChCreatPanelScr : MonoBehaviour
{
    private Camera gameCamera;
    private PlayerControls plControls;
    public GameObject TargetCh;
    public int BodyDiffID = 1;


    public void BodyDiffIDSet()
    {
        BodyDiffID += 1;
    }

    public void RngBodyValues()
    {
        TargetCh.GetComponent<BodyForm>().BRngSet();
    }

    void SelectBody()
    {
        Ray detectionRay = gameCamera.ScreenPointToRay(plControls.PlayerInput.MousePosition.ReadValue<Vector2>());
        RaycastHit2D detectionRayHit = Physics2D.GetRayIntersection(detectionRay);
        if (detectionRayHit.collider != null && detectionRayHit.collider.tag == "BodyTag")
        {
            TargetCh = detectionRayHit.collider.gameObject;
            BodyDiffIDSet();
        }
    }

    void Start()
    {
        gameCamera = Camera.main;
        plControls.PlayerInput.MouseLClick.started += _ => StartedClick();
        plControls.PlayerInput.MouseLClick.performed += _ => EndedClick();

        if (TargetCh == null)
        {
            TargetCh = GameObject.Find("PlSoul").transform.parent.transform.parent.transform.GetChild(0).gameObject;
            BodyDiffIDSet();
        }
    }

    void StartedClick()
    {
    }

    void EndedClick()
    {
        SelectBody();
    }


    void Awake()
    {
        plControls = new PlayerControls();
    }

    void OnEnable()
    {
        plControls.Enable();
    }

    void OnDisable()
    {
        plControls.Disable();
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}