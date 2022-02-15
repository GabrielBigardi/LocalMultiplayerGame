
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


public class PlayerAssign : MonoBehaviour
{
    public Transform mapBoundings;
    public Camera defaultCamera;

    public GameObject twoPlayersPanel;
    public GameObject fourPlayersPanel;

    public List<PlayerInput> players = new List<PlayerInput>();
    public List<Transform> startingPoints;
    public List<LayerMask> playerLayers;

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        defaultCamera.gameObject.SetActive(false);
        players.Add(playerInput);

        if (players.Count < 2)
        {
            twoPlayersPanel.SetActive(false);
            fourPlayersPanel.SetActive(false);
        }
        else if(players.Count == 2)
        {
            twoPlayersPanel.SetActive(true);
            fourPlayersPanel.SetActive(false);
        }else if (players.Count > 2)
        {
            twoPlayersPanel.SetActive(false);
            fourPlayersPanel.SetActive(true);
        }

        Transform playerParent = playerInput.transform.parent;
        int layerToAdd = (int)Mathf.Log(playerLayers[players.Count - 1].value, 2);

        playerParent.position = startingPoints[players.Count - 1].position;
        playerParent.GetComponentInChildren<CinemachineVirtualCamera>().gameObject.layer = layerToAdd;
        playerParent.GetComponentInChildren<Camera>().gameObject.layer = layerToAdd;
        playerParent.GetComponentInChildren<Camera>().cullingMask |= 1 << layerToAdd;
        playerParent.GetComponentInChildren<CinemachineConfiner>().m_BoundingShape2D = mapBoundings.GetComponent<PolygonCollider2D>();

    }

    //public CinemachineTargetGroup targetGroup;
    //public List<Transform> players;
    //public int redTeamCount;
    //public int greenTeamCount;
    //
    //int nextTeamColor = 0;
    //
    //public void OnPlayerJoined(PlayerInput playerInput)
    //{
    //    targetGroup.AddMember(playerInput.transform, 1, 0);
    //
    //    players.Add(playerInput.transform);
    //
    //    //TODO: assign player to a team
    //    playerInput.transform.GetComponent<PlayerEntity>().core.nameText.SetText($"Player {players.FindIndex(x => x == playerInput.transform)}");
    //    foreach (var nameText in playerInput.transform.GetComponent<PlayerEntity>().core.nameTextOutlines)
    //    {
    //        nameText.SetText($"Player {players.FindIndex(x => x == playerInput.transform)}");
    //    }
    //
    //    playerInput.transform.GetComponent<PlayerEntity>().SetTeam(nextTeamColor);
    //    playerInput.transform.position = new Vector3(-6.16f, -3.5f, 0f);
    //
    //    nextTeamColor = nextTeamColor == 0 ? 1 : 0;
    //}
}
