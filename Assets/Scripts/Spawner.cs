using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] spawnPoints;
    int rondomCube;
    int rondomSpawn;
    public static bool cubeIsSpawned = false;
    GameObject cube;
   
    public static int thisWay;
   
    List<GameObject> cubeT = new List<GameObject>();
    
    public static int whichCube;
    public GameObject objectCheck;
    public static bool portalIsDown;
    public TextMeshProUGUI health;
    public TextMeshProUGUI scoret;
    int lives = 3;
    int score = 0;
    int index;
 
    public Transform objectiveCheck;
    public Transform portal;
    public Transform spawnDist;
    bool canspawn = true;
    List<float> destroyDisty=new List<float>();
    List<float> destroyDistx = new List<float>();
    List<float> distForSpawn = new List<float>();
    
    float minValy;
    float minValyI;
    float minValx;
    int destroyIndex;
  

    void Awake()
    {
        lives = 3;
       
        cube = Instantiate(cubes[0], spawnPoints[0]);
        cubeT.Add(cube);
        
        whichCube = 0;
        
        cubeIsSpawned = true;
        health.text = "Lives : " + lives;
        scoret.text = "Score : " + score;
    }
    private void Start()
    {
        lives = 3;
        
    }
   
    void Update()
    {
        
        
      
        for (int i = 0; i < cubeT.Count; i++)
        {
            distForSpawn.Add(Mathf.Abs(cubeT[i].transform.position.y - spawnDist.position.y));
            for (int z = 0; z < distForSpawn.Count; z++)
            {
                if (distForSpawn[z] > 2f)
                {
                    canspawn = true;
                }
                else
                {
                    distForSpawn.Clear();
                    canspawn = false;
                    return;
                }
            }
            
        }

       
       
        if (cubeT.Count<5 && canspawn)
        {
            Spawn();
        }

        ScoreKeeper();
    

        if (Input.touchCount==2)
        {
            Time.timeScale = 0;
          
        }
        if (Input.touchCount>=3)
        {
            Time.timeScale = 1;
        }
      

       
            
               
           
            
        
       
       

    }
    public void ScoreKeeper()
    {
        
        
            bool isEmpty = !destroyDisty.Any();
            if (isEmpty) {
                
            destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - portal.position.y));
            destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - portal.position.y));
            destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - portal.position.y));
            destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - portal.position.y));
            destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - portal.position.y));



            }
            else if(!isEmpty)
            {
            for (int i = 0; i < cubeT.Count; i++)
            {
                destroyDisty[i]= Mathf.Abs(cubeT[i].transform.position.y - portal.position.y);
            }
            }
            bool isEmptyx = !destroyDistx.Any();
            
            if (isEmptyx)
            {
            destroyDistx.Add(Mathf.Abs(cubeT[0].transform.position.x - portal.position.x));
            destroyDistx.Add(Mathf.Abs(cubeT[0].transform.position.x - portal.position.x));
            destroyDistx.Add(Mathf.Abs(cubeT[0].transform.position.x - portal.position.x));
            destroyDistx.Add(Mathf.Abs(cubeT[0].transform.position.x - portal.position.x));
            destroyDistx.Add(Mathf.Abs(cubeT[0].transform.position.x - portal.position.x));
          
            }
            else if (!isEmpty)
           {
            for (int a = 0; a < cubeT.Count; a++)
            {
               destroyDistx[a] = Mathf.Abs(cubeT[a].transform.position.x - portal.position.x);
            }
            }
            

        
        
              minValy = destroyDisty.Min();
              
              

              index = destroyDisty.IndexOf(minValy);
        

        minValx = Mathf.Abs (cubeT[index].transform.position.x - portal.position.x);
        minValyI = Mathf.Abs (cubeT[index].transform.position.y - portal.position.y);
        if (minValyI < 1.2f && minValx <= 0.1f)
            //burayı değiştir portalın şekli değişirse
            {
                

                ColorOf.isCubeGone = true;
                ColorOfGround.ısCubeGoneGround = true;
                ChosePortal.portalIsGone = true;
                score++;
                scoret.text = "Score : " + score;
                Destroy(cubeT[index]);
                cubeT.RemoveAt(index);
            Debug.Log(index + "index" + destroyIndex + "destroyindex"+"score");



        }
        else if (minValyI < 0.5f)
            {
                if (lives == 1)
                {

                    
                    if (lives == 1)
                    {
                        lives--;
                    }
                    Time.timeScale = 0;
                    health.text = "Lives : " + lives;
                    SceneManager.LoadScene("GameOver");

                }
                else if (lives > 1)
                {


                    ColorOf.isCubeGone = true;
                    ColorOfGround.ısCubeGoneGround = true;
                ChosePortal.portalIsGone = true;
                lives--;
                    health.text = "Lives : " + lives;
                    Destroy(cubeT[index]);
                    cubeT.RemoveAt(index);
                Debug.Log(index + "index" + destroyIndex + "destroyindex"+"lives");



            }

            }


       
    }
 
    public void Spawn()
    {
        
        rondomSpawn = Random.Range(0, spawnPoints.Length);
        rondomCube = Random.Range(0, cubes.Length);
        whichCube = rondomCube;
        cube = Instantiate(cubes[rondomCube], spawnPoints[rondomSpawn]);


        cubeT.Add(cube);
  


        cubeIsSpawned = true;

    }
  
}

