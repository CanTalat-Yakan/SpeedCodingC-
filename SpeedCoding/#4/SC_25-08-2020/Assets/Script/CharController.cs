using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    CharacterController m_controller;
    Camera m_mainCamera;

    float m_camHorizontal;
    float m_camVertical;
    float m_movementSpeed;
    float[] m_movementSpeedArray = new float[3] { 3, 10, 20 };
    float m_jumpVelocity;
    float m_verticalVelocity;

    void Start()
    {
        m_controller = GetComponent<CharacterController>();
        m_mainCamera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        SpeedMovement();

        CharMovement();
        CamMovement();
        JumpCheck();
        CrouchCheck();
    }

    void CharMovement()
    {
        Vector3 m_inputDirection = Input.GetAxisRaw("Vertical") * transform.forward +
                                   Input.GetAxisRaw("Horizontal") * transform.right;
        m_inputDirection = m_inputDirection.normalized;
        if (m_jumpVelocity != 0 && m_controller.isGrounded)
        {
            m_verticalVelocity = m_jumpVelocity;
            m_jumpVelocity = 0;
        }
        m_verticalVelocity += Physics.gravity.y * Time.deltaTime;

        m_inputDirection.y = m_verticalVelocity;

        m_controller.Move(m_inputDirection * m_movementSpeed * Time.deltaTime);
    }

    void CamMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * 250 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 250 * Time.deltaTime;


        m_camVertical += -Mathf.Clamp(mouseY, -60, 60);
        m_camHorizontal += mouseX;

        m_controller.transform.Rotate(Vector3.up * mouseX);
        m_mainCamera.transform.transform.localRotation = Quaternion.Euler(m_camVertical, 0, 0);
    }


    void SpeedMovement()
    {
        m_movementSpeed = m_movementSpeedArray[1];

        if (Input.GetKey(KeyCode.LeftShift))
            m_movementSpeed = m_movementSpeedArray[2];

        if (Input.GetKey(KeyCode.LeftControl))
            m_movementSpeed = m_movementSpeedArray[0];
    }

    void JumpCheck()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_jumpVelocity = 2;
        }
    }

    void CrouchCheck()
    {
        m_controller.height = (Input.GetKey(KeyCode.LeftControl)) ? 1 : 2;
    }
}
