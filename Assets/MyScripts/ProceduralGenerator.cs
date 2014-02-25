using UnityEngine;
using System.Collections;

public class ProceduralGenerator : MonoBehaviour {
	
	public GameObject treePrefab;
	private int treeDist = 6;

	public GameObject waterPrefab;

	public int worldSize; 
	private Random rng;

	//world is set-up. add trees.
	void Awake()
	{

		//Setting up trees.
		int iAdjust = Random.Range (1, 50); //Prevents world from being the same each game.
		int jAdjust = Random.Range (1, 50); //same deal.

		for (int i = -worldSize; i < worldSize; i += treeDist) 
		{
			for(int j = -worldSize; j < worldSize; j += treeDist)
			{
				int iMod = (i+worldSize*iAdjust); 
				int jMod = (j+worldSize*jAdjust);

				//Couldnt get 2d noise to work, So I did 1D noise twice.
				float NoiseValue = (SimplexNoise.Noise.Generate((float)iMod/100)+SimplexNoise.Noise.Generate((float)jMod/100));
				if( (NoiseValue > .4f && NoiseValue < .8f) || NoiseValue < -.6f)
				{
					float xMod = Random.Range(-2,2); //prevents trees from being spawned in a "grid"
					float zMod = Random.Range(-2,2);
					GameObject.Instantiate(treePrefab,new Vector3(i+xMod,0,j+zMod),Quaternion.Euler(90,0,0));
				}
				else if(NoiseValue > .9f)
				{
					GameObject.Instantiate(waterPrefab,new Vector3(i,0,j),Quaternion.Euler (0,0,0));
				}
			}
		}


	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(SimplexNoise.Noise.Generate ((float)Time.frameCount/100));
	}
}
