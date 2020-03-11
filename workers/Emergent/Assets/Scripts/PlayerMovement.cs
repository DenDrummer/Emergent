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
    private float mouseSensitivity;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpHeight;

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
        #region --- mouse movement ---
        mouseX = -Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        //mouseDelta = new Vector3(mouseX, mouseY * -1);
        //playerCamera.transform.eulerAngles -= new Vector3(mouseY, mouseX);
        transform.eulerAngles -= new Vector3(0, mouseX);
        #endregion

        #region --- movement ---

        #region --- cardinal directions ---
        // TODO: movement in cardinal directions
        #endregion

        #region --- jump ---
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, jumpHeight, 0));
        }
        #endregion
        #endregion
    }
}
