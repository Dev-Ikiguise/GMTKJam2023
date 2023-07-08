using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public GameObject player;
    public float orthoSize = 5f;
    public CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        float playerSizeIncreaser = (player.transform.localScale.x / 2) - 1;

        virtualCamera.m_Lens.OrthographicSize = orthoSize + playerSizeIncreaser;
    }
}
