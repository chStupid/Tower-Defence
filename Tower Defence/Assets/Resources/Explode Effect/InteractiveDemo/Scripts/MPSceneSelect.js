#pragma strict

var MPselGridInt : int = -1;
var MPselStrings : String[] = ["Projectiles", "Auras", "Sprays", "Modular"];

	
	function OnGUI ()
	{
		MPselGridInt = GUI.SelectionGrid (Rect (Screen.width /2 - 175, Screen.height - 50, 800, 25), MPselGridInt, MPselStrings, 10);
			
		 if (MPselGridInt == 0){
             Application.LoadLevel("magic_projectiles");
         }
         
         if (MPselGridInt == 1){
             Application.LoadLevel("magic_aura");
         }
         
         if (MPselGridInt == 2){
             Application.LoadLevel("magic_sprays");
         }
         
         if (MPselGridInt == 3){
             Application.LoadLevel("magic_modular");
         }
         
//         if (MPselGridInt == 4){
//             Application.LoadLevel("Scene5");
//         }
//         
//         if (MPselGridInt == 5){
//             Application.LoadLevel("Scene6");
//         }
//         
//         if (MPselGridInt == 6){
//             Application.LoadLevel("Scene7");
//         }
//         
//         if (MPselGridInt == 7){
//             Application.LoadLevel("Scene8");
//         }
//         
//         if (MPselGridInt == 8){
//             Application.LoadLevel("Scene9");
//         }   
//         
//         if (MPselGridInt == 9){
//             Application.LoadLevel("Scene10");
//         }
	}