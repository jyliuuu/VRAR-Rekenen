using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;



public class ContinuousMovement : MonoBehaviour
{
    public float speed = 1;
    public XRNode inputSource;

    public float additionHeight = 0.2f;

    public float gravity = -9.81f;

    private float fallingspeed;

    public LayerMask groundLayer;

    private Vector2 inputAxis;
    private CharacterController character;

    private XROrigin rig;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        //CapsuleFollow();

        Vector3 direction = new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);

        //gravity
        bool isGrounded = CheckGround();

        if (isGrounded)
        {
            fallingspeed = 0;
        }
        else
        {
            fallingspeed += gravity * Time.fixedDeltaTime;
            character.Move(Vector3.up * fallingspeed * Time.fixedDeltaTime);
        }

    }

    bool CheckGround()
    {
        //tells if we're grounded or not
        Vector3 raystart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;

        bool hasHit = Physics.SphereCast(raystart, character.radius, Vector3.down, out RaycastHit hitinfo, rayLength, groundLayer);
        return hasHit;
    }

    //void CapsuleFollow()
    //{
    //    character.height = rig.CameraInOriginSpaceHeight + additionHeight ;

    //    Vector3 capsuleCenter = transform.InverseTransformPoint(rig.Camera.transform.position);

    //    character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);

    //}
}
