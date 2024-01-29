using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebuildManager : MonoBehaviour
{
    private PlayerInput _playerInputActions;
    

    [SerializeField] Transform bridgePos;
    [SerializeField] GameObject bridgePrefab;
    // Start is called before the first frame update
    void Start()
    {
        _playerInputActions = GameObject.Find("--Player--").GetComponent<PlayerInput>();
        _playerInputActions.actions["Rebuild"].Enable();
        _playerInputActions.actions["Rebuild"].started += RebuildManager_started;
    }

    private void RebuildManager_started(InputAction.CallbackContext obj)
    {


        Debug.Log("ASIUBDNIAPSDNAIPSUDNAIPUj");
        Instantiate(bridgePrefab, bridgePos);
    }

}
