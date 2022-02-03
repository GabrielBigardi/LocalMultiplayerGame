using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


public class PlayerAssign : MonoBehaviour
{
    public CinemachineTargetGroup targetGroup;

    public List<Transform> players;
    public int redTeamCount;
    public int greenTeamCount;

    int nextTeamColor = 0;

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        targetGroup.AddMember(playerInput.transform, 1, 0);

        players.Add(playerInput.transform);

        //TODO: assign player to a team
        playerInput.transform.GetComponentInChildren<TMPro.TMP_Text>().SetText($"Player {players.FindIndex(x => x == playerInput.transform)}");
        playerInput.transform.GetComponent<PlayerEntity>().SetTeam(nextTeamColor);

        nextTeamColor = nextTeamColor == 0 ? 1 : 0;
    }
}
