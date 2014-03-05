using UnityEngine;
using System.Collections;

public class ProceduralGenerator : MonoBehaviour {
	
	public GameObject treePrefab;
	public int worldSize; 
	private int treeDist = 6;
	private Random rng;

	//world is set-up. add trees.
	void Awake()
	{

		int Adjust1 = Random.Range (1, 50); //Prevents world from being the same each game.
		int Adjust2 = Random.Range (1, 50); //same deal.
		int Adjust3 = Random.Range (1, 50);
		int Adjust4 = Random.Range (1, 50);

		//start at worldsize+1 to avoid divide by zero errors.
		for (float i = -worldSize+1; i < worldSize; i += treeDist) 
		{
			for(float j = -worldSize+1; j < worldSize; j += treeDist)
			{
				float iMod1 = ((i+worldSize)*Adjust1)/1000; 
				float jMod1 = ((j+worldSize)*Adjust2)/1000;
				float iMod2 = ((i+worldSize)*Adjust3)/1000; 
				float jMod2 = ((j+worldSize)*Adjust4)/1000;

				//Couldnt get 2d noise to work, So I did 1D noise twice.
				float noise1 = (Mathf.PerlinNoise(iMod1,jMod1));
				float noise2 = (Mathf.PerlinNoise(iMod2,jMod2));

				float NoiseValue = (noise1 + noise2)/2;
				if(NoiseValue > .6)
				{
					float xMod = Random.Range(-2,2); //prevents trees from being spawned in a "grid"
					float zMod = Random.Range(-2,2);
					GameObject.Instantiate(treePrefab,new Vector3(i+xMod,0,j+zMod),Quaternion.Euler(90,0,0));
				}	  
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(SimplexNoise.Noise.Generate ((float)Time.frameCount/100));
	}
}
