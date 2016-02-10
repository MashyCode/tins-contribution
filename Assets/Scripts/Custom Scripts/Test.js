#pragma strict

var Player:Transform;
var waypoint:Transform[];

function Start () 
{

}

function Update () 
{
	GetComponent(NavMeshAgent).destination = Player.position;
}