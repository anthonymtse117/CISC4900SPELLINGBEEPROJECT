using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour {

	public AudioSource correctSound;
	public AudioSource IncorrectSound;
	public AudioSource WinSound;
	public int LettersCorrect = 0;
	public string CurrentWord;
	public Transform[] spawnPoints = new Transform[16];
	public Transform[] letterLocations = new Transform[11];
	public GameObject Letter1;
	public GameObject[] Letters = new GameObject[25];
	public GameObject[] Underlines = new GameObject[14]; 
	public char currentLetter;
	public int letterCount = 0;
	public AudioClip[] wordAuds = new AudioClip[100];
	public AudioClip wordAud;
	public AudioSource audioSource; 
	public string[] wordsArray = new string[12];
	public int rnd;
	public float spawntimer = 1;
	public string difficulty;

	// Use this for initialization
	void Start () {

		difficulty = PlayerPrefs.GetString ("Difficulty");
			
		if(difficulty == "EASY")
			rnd = Random.Range (0,33);
		
		if (difficulty == "MEDIUM")
			rnd = Random.Range (34, 66);

		if (difficulty == "HARD")
			rnd = Random.Range (67, 99);
		
		spawnPoints = new Transform[] {
			GameObject.Find ("Location1").transform,
			GameObject.Find ("Location2").transform,
			GameObject.Find ("Location3").transform,
			GameObject.Find ("Location4").transform,
			GameObject.Find ("Location5").transform,
			GameObject.Find ("Location6").transform,
			GameObject.Find ("Location7").transform,
			GameObject.Find ("Location8").transform,
			GameObject.Find ("Location9").transform,
			GameObject.Find ("Location10").transform,
			GameObject.Find ("Location11").transform,
			GameObject.Find ("Location12").transform,
			GameObject.Find ("Location13").transform,
			GameObject.Find ("Location14").transform,
			GameObject.Find ("Location15").transform,
			GameObject.Find ("Location16").transform,
			GameObject.Find ("Location17").transform,
		};

		wordsArray = new string[] {

			"ABATE",
			"ABDICATE",
			"ABERRATION",
			"ABSTAIN",
			"ADVERSITY",
			"AESTHETIC",
			"AMICABLE",
			"ANACHRONISTIC",
			"ARID",
			"ASYLUM",
			"BENEVOLENT",
			"BIAS",
			"BOISTEROUS",
			"BRAZEN",
			"BRUSQUE",
			"CAMARADERIE",
			"CANNY",
			"CAPACIOUS",
			"CAPITULATE",
			"CLAIRVOYANT",
			"COLLABORATE",
			"COMPASSION",
			"COMPROMISE",
			"CONDESCENDING",
			"CONDITIONAL",
			"CONFORMIST",
			"CONUNDRUM",
			"CONVERGENCE",
			"DELETERIOUS",
			"DEMAGOGUE",
			"DIGRESSION",
			"DILIGENT",
			"DISCREDIT",
			"DISDAIN",
			"DIVERGENT",
			"EMPATHY",
			"EMULATE",
			"ENERVATING",
			"EPHEMERAL",
			"EVANESCENT",
			"EXEMPLARY",
			"EXTERNUATING",
			"FLORID",
			"FORBEARANCE",
			"FORTITUDE",
			"FORTUITOUS",
			"FOSTER",
			"FRAUGHT",
			"FRUGAL",
			"HACKNEYED",
			"HAUGHTY",
			"HEDONIST",
			"HYPOTHESIS",
			"IMPETUOUS",
			"IMPUTE",
			"INCONSEQUENTIAL",
			"INEVITABLE",
			"INTREPID",
			"INTUITIVE",
			"JUBILLATION",
			"LOBBYIST",
			"LONGEVITY",
			"MUNDANE",
			"NONCHALANT",
			"OPULENT",
			"ORATOR",
			"OSTENTATIOUS",
			"PARCHED",
			"PERFIDIOUS",
			"PRAGMATIC",
			"PRECOCIOUS",
			"PRETENTIOUS",
			"PROCRASTINATE",
			"PROSAIC",
			"PROSPERITY",
			"PROVOCATIVE",
			"PRUDENT",
			"QUERULOUS",
			"RANCOROUS",
			"RECLUSIVE",
			"RECONCILIATION",
			"RENOVATION",
			"RESTRAINED",
			"REVERENCE",
			"SAGACITY",
			"SCRUTINIZE",
			"SPONTANEOUS",
			"SPURIOUS",
			"SUBMISSIVE",
			"SUBSTANTIATE",
			"SUBTLE",
			"SUPERFICIAL",
			"SUPERFLUOUS",
			"SURREPTITIOUS",
			"TACTFUL",
			"TENACIOUS",
			"TRANSIENT",
			"VENERABLE",
			"VINDICATE",
			"WARY",
		};
			


		wordAuds = new AudioClip[] {

			(AudioClip)Resources.Load("Audio/Abate"),
			(AudioClip)Resources.Load("Audio/Abdicate"),
			(AudioClip)Resources.Load("Audio/Aberration"),
			(AudioClip)Resources.Load("Audio/Abstain"),
			(AudioClip)Resources.Load("Audio/Adversity"),
			(AudioClip)Resources.Load("Audio/Aesthetic"),
			(AudioClip)Resources.Load("Audio/Amicable"),
			(AudioClip)Resources.Load("Audio/Anachronistic"),
			(AudioClip)Resources.Load("Audio/Arid"),
			(AudioClip)Resources.Load("Audio/Asylum"),
			(AudioClip)Resources.Load("Audio/Benevolent"),
			(AudioClip)Resources.Load("Audio/Bias"),
			(AudioClip)Resources.Load("Audio/Boisterous"),
			(AudioClip)Resources.Load("Audio/Brazen"),
			(AudioClip)Resources.Load("Audio/Brusque"),
			(AudioClip)Resources.Load("Audio/Camaraderie"),
			(AudioClip)Resources.Load("Audio/Canny"),
			(AudioClip)Resources.Load("Audio/Capacious"),
			(AudioClip)Resources.Load("Audio/Capitulate"),
			(AudioClip)Resources.Load("Audio/Clairvoyant"),
			(AudioClip)Resources.Load("Audio/Collaborate"),
			(AudioClip)Resources.Load("Audio/Compassion"),
			(AudioClip)Resources.Load("Audio/Compromise"),
			(AudioClip)Resources.Load("Audio/Condescending"),
			(AudioClip)Resources.Load("Audio/Conditional"),
			(AudioClip)Resources.Load("Audio/Conformist"),
			(AudioClip)Resources.Load("Audio/Conundrum"),
			(AudioClip)Resources.Load("Audio/Convergence"),
			(AudioClip)Resources.Load("Audio/Deleterious"),
			(AudioClip)Resources.Load("Audio/Demagogue"),
			(AudioClip)Resources.Load("Audio/Digression"),
			(AudioClip)Resources.Load("Audio/Diligent"),
			(AudioClip)Resources.Load("Audio/Discredit"),
			(AudioClip)Resources.Load("Audio/Disdain"),
			(AudioClip)Resources.Load("Audio/Divergent"),
			(AudioClip)Resources.Load("Audio/Empathy"),
			(AudioClip)Resources.Load("Audio/Emulate"),
			(AudioClip)Resources.Load("Audio/Enervating"),
			(AudioClip)Resources.Load("Audio/Ephemeral"),
			(AudioClip)Resources.Load("Audio/Evanescent"),
			(AudioClip)Resources.Load("Audio/Exemplary"),
			(AudioClip)Resources.Load("Audio/Externuating"),
			(AudioClip)Resources.Load("Audio/Florid"),
			(AudioClip)Resources.Load("Audio/Forbearance"),
			(AudioClip)Resources.Load("Audio/Fortitude"),
			(AudioClip)Resources.Load("Audio/Fortuitous"),
			(AudioClip)Resources.Load("Audio/Foster"),
			(AudioClip)Resources.Load("Audio/Fraught"),
			(AudioClip)Resources.Load("Audio/Frugal"),
			(AudioClip)Resources.Load("Audio/Hackneyed"),
			(AudioClip)Resources.Load("Audio/Haughty"),
			(AudioClip)Resources.Load("Audio/Hedonist"),
			(AudioClip)Resources.Load("Audio/Hypothesis"),
			(AudioClip)Resources.Load("Audio/Impetuous"),
			(AudioClip)Resources.Load("Audio/Impute"),
			(AudioClip)Resources.Load("Audio/Inconsequential"),
			(AudioClip)Resources.Load("Audio/Inevitable"),
			(AudioClip)Resources.Load("Audio/Intrepid"),
			(AudioClip)Resources.Load("Audio/Intuitive"),
			(AudioClip)Resources.Load("Audio/Jubilation"),
			(AudioClip)Resources.Load("Audio/Lobbyist"),
			(AudioClip)Resources.Load("Audio/Longevity"),
			(AudioClip)Resources.Load("Audio/Mundane"),
			(AudioClip)Resources.Load("Audio/Nonchalant"),
			(AudioClip)Resources.Load("Audio/Opulent"),
			(AudioClip)Resources.Load("Audio/Orator"),
			(AudioClip)Resources.Load("Audio/Ostentatious"),
			(AudioClip)Resources.Load("Audio/Parched"),
			(AudioClip)Resources.Load("Audio/Perfidious"),
			(AudioClip)Resources.Load("Audio/Pragmatic"),
			(AudioClip)Resources.Load("Audio/Procrastinate"),
			(AudioClip)Resources.Load("Audio/Prosaic"),
			(AudioClip)Resources.Load("Audio/Precocious"),
			(AudioClip)Resources.Load("Audio/Prosperity"),
			(AudioClip)Resources.Load("Audio/Provacative"),
			(AudioClip)Resources.Load("Audio/Pretentious"),
			(AudioClip)Resources.Load("Audio/Prudent"),
			(AudioClip)Resources.Load("Audio/Querulous"),
			(AudioClip)Resources.Load("Audio/Rancorous"),
			(AudioClip)Resources.Load("Audio/Reclusive"),
			(AudioClip)Resources.Load("Audio/Reconcilation"),
			(AudioClip)Resources.Load("Audio/Renovation"),
			(AudioClip)Resources.Load("Audio/Restrained"),
			(AudioClip)Resources.Load("Audio/Reverence"),
			(AudioClip)Resources.Load("Audio/Sagacity"),
			(AudioClip)Resources.Load("Audio/Scrutinize"),
			(AudioClip)Resources.Load("Audio/Spontaneous"),
			(AudioClip)Resources.Load("Audio/Spurious"),
			(AudioClip)Resources.Load("Audio/Submissive"),
			(AudioClip)Resources.Load("Audio/Substantiate"),
			(AudioClip)Resources.Load("Audio/Subtle"),
			(AudioClip)Resources.Load("Audio/Superficial"),
			(AudioClip)Resources.Load("Audio/Superfluous"),
			(AudioClip)Resources.Load("Audio/Surreptitious"),
			(AudioClip)Resources.Load("Audio/Tactful"),
			(AudioClip)Resources.Load("Audio/Tenacious"),
			(AudioClip)Resources.Load("Audio/Transient"),
			(AudioClip)Resources.Load("Audio/Venerable"),
			(AudioClip)Resources.Load("Audio/Vindicate"),
			(AudioClip)Resources.Load("Audio/Wary"),

		};

//		sortArray (wordsArray, wordAuds);
	



		shuffle ();
		sortArray (wordsArray, wordAuds);
		CurrentWord = wordsArray[rnd];
		audioSource = GetComponent<AudioSource> ();
		wordAud = wordAuds[rnd];
		audioSource.clip = wordAud;
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {

		CurrentWord = wordsArray [rnd];
		if (LettersCorrect < CurrentWord.Length)
			currentLetter = CurrentWord [LettersCorrect];
		spawntimer -= Time.deltaTime;

			
		for (int i = 0; i < 14; i++){

			if (i < CurrentWord.Length)
				Underlines[i].GetComponent<SpriteRenderer> ().enabled = true;
			else 
				Underlines[i].GetComponent<SpriteRenderer>().enabled = false;

		}

		for (int i = 0; i < 11; i++){

			if (i < CurrentWord.Length)
				Underlines[i].GetComponent<SpriteRenderer> ().enabled = true;
			else 
				Underlines[i].GetComponent<SpriteRenderer>().enabled = false;

		}

		if (spawntimer <= 0 && spawntimer > -3) {
			spawnLetters (CurrentWord, spawnPoints);
			spawntimer = -3;
		}

	}
		
	void spawnLetters(string CurrentWord, Transform[] spawnPoints){
		int i = 0;
		while (i < CurrentWord.Length) {
			spawnOneLetter (i,spawnPoints);
			i++;
		}

		while (i < spawnPoints.Length) {
			int rnd = Random.Range (0, Letters.Length);
			GameObject.Instantiate(Letters[rnd], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);
			i++;
		}
			
	}

	void spawnOneLetter(int i, Transform[] spawnPoints){

		if (CurrentWord [i].CompareTo ('A') == 0 || CurrentWord [i].CompareTo ('a') == 0)
			GameObject.Instantiate (Letters[0], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord [i].CompareTo ('B') == 0 || CurrentWord [i].CompareTo ('b') == 0)
			GameObject.Instantiate (Letters[1], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);
		
		else if (CurrentWord[i].CompareTo('C') == 0 || CurrentWord[i].CompareTo('c') == 0)
			GameObject.Instantiate (Letters[2], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);
		
	    else if (CurrentWord[i].CompareTo('D') == 0 || CurrentWord[i].CompareTo('d') == 0)
			GameObject.Instantiate (Letters[3], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('E') == 0 || CurrentWord[i].CompareTo('e') == 0)
			GameObject.Instantiate (Letters[4], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);
	
		else if (CurrentWord[i].CompareTo('F') == 0 || CurrentWord[i].CompareTo('f') == 0)
			GameObject.Instantiate (Letters[5], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('G') == 0 || CurrentWord[i].CompareTo('g') == 0)
			GameObject.Instantiate (Letters[6], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('H') == 0 || CurrentWord[i].CompareTo('h') == 0)
			GameObject.Instantiate (Letters[7], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('I') == 0 || CurrentWord[i].CompareTo('i') == 0)
			GameObject.Instantiate (Letters[8], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('J') == 0 || CurrentWord[i].CompareTo('j') == 0)
			GameObject.Instantiate (Letters[9], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('K') == 0 || CurrentWord[i].CompareTo('k') == 0)
			GameObject.Instantiate (Letters[10], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('L') == 0 || CurrentWord[i].CompareTo('l') == 0)
			GameObject.Instantiate (Letters[11], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);
				
		else if (CurrentWord[i].CompareTo('M') == 0 || CurrentWord[i].CompareTo('M') == 0)
			GameObject.Instantiate (Letters[12], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('N') == 0 || CurrentWord[i].CompareTo('n') == 0)
			GameObject.Instantiate (Letters[13], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('O') == 0 || CurrentWord[i].CompareTo('o') == 0)
			GameObject.Instantiate (Letters[14], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('P') == 0 || CurrentWord[i].CompareTo('p') == 0)
			GameObject.Instantiate (Letters[15], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('Q') == 0 || CurrentWord[i].CompareTo('q') == 0)
			GameObject.Instantiate (Letters[16], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('R') == 0 || CurrentWord[i].CompareTo('r') == 0)
			GameObject.Instantiate (Letters[17], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('S') == 0 || CurrentWord[i].CompareTo('s') == 0)
			GameObject.Instantiate (Letters[18], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('T') == 0 || CurrentWord[i].CompareTo('t') == 0)
			GameObject.Instantiate (Letters[19], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('U') == 0 || CurrentWord[i].CompareTo('u') == 0)
			GameObject.Instantiate (Letters[20], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('V') == 0 || CurrentWord[i].CompareTo('v') == 0)
			GameObject.Instantiate (Letters[21], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('W') == 0 || CurrentWord[i].CompareTo('w') == 0)
			GameObject.Instantiate (Letters[22], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('X') == 0 || CurrentWord[i].CompareTo('x') == 0)
			GameObject.Instantiate (Letters[23], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('Y') == 0 || CurrentWord[i].CompareTo('y') == 0)
			GameObject.Instantiate (Letters[24], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);

		else if (CurrentWord[i].CompareTo('Z') == 0 || CurrentWord[i].CompareTo('z') == 0)
			GameObject.Instantiate (Letters[25], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), Quaternion.identity);
	}
		
	void shuffle(){
		for (int i = 0; i < spawnPoints.Length; i++) {
			int rnd = Random.Range (0, spawnPoints.Length);
			Transform tempGO = spawnPoints [rnd];
			spawnPoints [rnd] = spawnPoints [i];
			spawnPoints [i] = tempGO;
		}
	}

	void sortArray(string[] wordsArray, AudioClip[] wordAuds){
		string temp;
		AudioClip temp2;
		for (int i = 0; i < wordsArray.Length; i++) {
			for(int j = 0; j< wordsArray.Length; j++){
				if (wordsArray [i].Length <= wordsArray [j].Length) {
					temp = wordsArray [i];
					wordsArray [i] = wordsArray [j];
					wordsArray [j] = temp;
					temp2 = wordAuds [i];
					wordAuds [i] = wordAuds [j];
					wordAuds [j] = temp2;
				}
			}
		}

	}
}

