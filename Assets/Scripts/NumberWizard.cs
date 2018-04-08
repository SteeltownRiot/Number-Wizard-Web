/*
 * Author: John Hopson
 * steeltownriot@gmail.com
 * 
 * Created: 22 JAN 2017
 * Last updated: 22 JAN 2017
 * 
 * Details:
 * - Logic behing simple game that uses a binary algorithm to guess a user's chosen number
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	/* 
	 * Ideas:
	 * - User selectable ranges
	 * - Random first guess
	*/
	
	int min;			// Minimum number player can pick
	int max;			// Maximum number  player can pick
	int guess;			// Holds 
	int maxGuesses;		// Holds maximum guesses the wizard is allowed
	public Text edit;	// Holds wizard's guess
	
	// Use this for initialization
	void Start () 
	{
		StartGame();			
	}
	
	// Precondition:  None
	// Postcondition: Starts the Number Wizard game
	void StartGame ()
	{
		min = 1;
		max = 1000;
		guess = Random.Range(min, max + 1);
		maxGuesses = 10;
		
		EditGuess();
		max += 1;
	}
	
	public void GuessHigher()
	{
		min = guess;
		NextGuess();
	}
	
	public void GuessLower()
	{
		max = guess;
		NextGuess();
	}
	
	// Precondition:  User has indicated guess was incorrect
	// Postcondition: Makes a new guess and asks user if the new answer is correct
	void NextGuess()
	{
		guess = (max + min) / 2;
		maxGuesses -= 1;
		
		if ((guess == 1 || guess == 1000) && maxGuesses > 0)
		{
			edit.text = "You tried to cheat me you scallywag!";
			
			StartCoroutine("LoadWinAfterDelay");
		}
		else if (maxGuesses > 0 && (guess != 1 || guess != 1000))
		{
			EditGuess();
		}
		else if (maxGuesses <= 0)
		{
			Application.LoadLevel("Lose");
		}
	}
	
	IEnumerator LoadWinAfterDelay()
	{
		yield return new WaitForSeconds(3);
		Application.LoadLevel("Win");
	}
	
	void EditGuess()
	{
		edit.text = "Is it " + guess.ToString() + "?";
	}
}