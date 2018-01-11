#pragma strict

function Start () {

}

function Update () {

		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
			Application.LoadLevel(0);
        }

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Application.LoadLevel(1);
		}
}