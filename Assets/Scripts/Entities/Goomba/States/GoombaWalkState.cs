using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaWalkState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly GoombaEntity _entity;

    int currentWaypoint;

    public GoombaWalkState(StateMachine stateMachine, GoombaEntity goombaEntity)
    {
        _stateMachine = stateMachine;
        _entity = goombaEntity;
    }

    public void Tick()
    {
        if(Vector2.Distance(_entity.transform.position, _entity.core.waypoints[currentWaypoint].position) <= 0.05f)
        {
            if (currentWaypoint == _entity.core.waypoints.Length - 1)
                currentWaypoint = 0;
            else
                currentWaypoint++;
        }
    }

    public void FixedTick()
    {
        _entity.core.rgbd.velocity = new Vector2((_entity.core.waypoints[currentWaypoint].position.x < _entity.transform.position.x ? -1 : 1f), 0f) * _entity.data.moveSpeed * Time.deltaTime;
    }

    public void OnEnter()
    {
        //find nearest waypoint
        int nearestWaypointIndex = 0;
        for (int i = 0; i < _entity.core.waypoints.Length; i++)
        {
            Transform waypoint = _entity.core.waypoints[i];
            if (Vector2.Distance(_entity.transform.position, waypoint.position) < Vector2.Distance(_entity.transform.position, _entity.core.waypoints[nearestWaypointIndex].position))
            {
                nearestWaypointIndex = i;
            }
        }
        currentWaypoint = nearestWaypointIndex;
    }

    public void OnExit()
    {

    }
}
