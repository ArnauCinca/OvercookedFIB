using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    protected Food[] plates;
    protected int index_plates;
    protected int level;
    Random random;

    // Start is called before the first frame update
    void Start()
    {
        Random random = new Random();
        //plates = new Food[7] {};
    }

    // Update is called once per frame
    void Update()
    {
        if (index >= plates.Length) {} //Canvi escena

        
    }

    void RandomSortPlates() {
        for (int i = plates.Length - 1; i > 0; i--)
        {
            int randomIndex = random.Next(0, i + 1);
            Food temp = plates[i];
            plates[i] = plates[randomIndex];
            plates[randomIndex] = temp;
        }
    }

    void LoadLevel (int level) {
        SceneManager.LoadScene(1);
        this.level = level;
        RandomSortPlates();
        index = 0; 
    }

    void LoadNextLevel() {
        LoadLevel
    }



}
