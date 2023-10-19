using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{

    float currentTime = 0f;
    float spawnTime = getSpawnTime();
    public GameObject Candy1Prefab;
    public GameObject Candy2Prefab;
    public GameObject Candy3Prefab;

    public int typeOfCandy;

     private int getTypeOfCandy(){
         typeOfCandy = new int (Random.Range(1, 100));
    }

    private int getSpawnTime(){
        int spawnTime = new int (Random.Range(1, 3));
    }

    void Start()
    {
        currentTime = spawnTime; //sets the current time to starting time at initialization
    }

   private void OnTriggerEnter(Collider other){ //box collider isTrigger 
        if(other.transform.tag == "Player"){ //if the candy collides with the player then it will break and give the player a score
            Destroy(gameObject); 
            if(typeOfCandy <= 50){ //each candy provides a different score
                        Player.score += 10;
                    }
                    else if(typeOfCandy > 50 && typeOfCandy <= 90){
                        Player.score += 30;
                    }
                    else if(typeOfCandy > 90 && typeOfCandy <= 100){
                        Player.score += 100;
                    }
        }
        else{ //if it collides with something else (the ground) then the candy will be destroyed without any score given
            Destroy(gameObject); 
        }
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime; //every frame current time counts down by 1
        int i = 0; 

        if(i >= 15){ //controls how many times candy can be spawned
            if(currentTime <= 0){
                    Vector2 randomSpawnPosition = new Vector2(Random.Range(-9, 9), 4); //spawns candy within the frame at a set y value

                    if(typeOfCandy <= 50){ // adds different chances of getting each candy
                        Instantiate(Candy1Prefab, randomSpawnPosition, Quaternion.identity); //spawns candy type 1
                    }
                    else if(typeOfCandy > 50 && typeOfCandy <= 90){
                        Instantiate(Candy2Prefab, randomSpawnPosition, Quaternion.identity); //spawns candy type 2
                    }
                    else if(typeOfCandy > 90 && typeOfCandy <= 100){
                        Instantiate(Candy3Prefab, randomSpawnPosition, Quaternion.identity); //spawns candy type 3
                    }

                    i++;
                    spawnTime = getSpawnTime(); //once the candy is spawned, the timer will reset with a different time
            }
        }

    }
}
