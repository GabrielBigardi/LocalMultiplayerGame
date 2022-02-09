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
        playerInput.transform.GetComponent<PlayerEntity>().core.nameText.SetText($"Player {players.FindIndex(x => x == playerInput.transform)}");
        foreach (var nameText in playerInput.transform.GetComponent<PlayerEntity>().core.nameTextOutlines)
        {
            nameText.SetText($"Player {players.FindIndex(x => x == playerInput.transform)}");
        }

        playerInput.transform.GetComponent<PlayerEntity>().SetTeam(nextTeamColor);
        playerInput.transform.position = new Vector3(-6.16f, -3.5f, 0f);

        nextTeamColor = nextTeamColor == 0 ? 1 : 0;
    }
}
