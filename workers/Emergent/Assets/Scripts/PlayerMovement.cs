using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private GameObject playerObject;

    [Header("Settings")]
    [SerializeField]
    private float mouseSensitivity = 100f;
    [SerializeField]
    private float moveSpeed = 12f;
    [SerializeField]
    private float jumpHeight = 5f;
    [SerializeField]
    private float fallMult = 2.5f;
    [SerializeField]
    private float lowJumpMult = 2f;


    private float mouseX;
    private float mouseY;
    private Vector3 mouseDelta;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        #region --- mouse movement ---
        mouseX = -Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);
        //mouseDelta = new Vector3(mouseX, mouseY * -1);
        playerCamera.transform.eulerAngles -= new Vector3(mouseY, 0);
        transform.eulerAngles -= new Vector3(0, mouseX);
        #endregion

        #region --- movement ---

        #region --- cardinal directions ---
        float forward = 0;
        float right = 0;

        #region --- get input ---
        // TODO: use buttons instead so it can be remapped by the user.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            forward += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            forward -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            right += 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            right -= 1;
        }
        #endregion

        #region --- move ---
        Vector3 move = transform.right * right + transform.forward * forward;
        move = move * moveSpeed * Time.deltaTime;
        #endregion
        #endregion

        #region --- jump ---
        // TODO: check if player is grounded
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jumpHeight;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMult - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMult - 1) * Time.deltaTime;
        }
        #endregion
        #endregion
    }
}
