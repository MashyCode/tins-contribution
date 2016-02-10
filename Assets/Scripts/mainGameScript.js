#pragma strict

public class MainGameJavascript
{
	public var seated = false;
	
	function Start () 
	{

	}

	function Update () 
	{
		if(Input.GetMouseButton(2)) 
		{
			seated = !seated;	
		}
	}
}