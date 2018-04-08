/*
 * Author: John Hopson
 * steeltownriot@gmail.com
 * 
 * Created: 22 JAN 2017
 * Last updated: 22 JAN 2017
 * 
 * Details:
 * - Level manager that loads each level or quits the application
*/

using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Precondition:  LevelManager invoked to load a level
	// Postcondition: 
	public void LoadLevel (string name)
	{
		Application.LoadLevel(name);
	}
	
	// Precondition:  LevelManager invoked to quit game
	// Postcondition: Game terminates
	public void QuitRequest ()
	{
		Application.Quit();
	}
}