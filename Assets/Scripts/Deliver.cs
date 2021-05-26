using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deliver : MonoBehaviour
{
    protected string[] plates;
    protected int index_plates;
    // Start is called before the first frame update
    void Start()
    {
        plates = new string[7] {"Tamato", "Chicken", "Bread", "Lettuce", "Meat", "Onion", "Potato"};
        RandomSortPlates();
        Debug.Log(plates);
        index_plates = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomSortPlates() {
        for (int i = plates.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i+1);
            string temp = plates[i];
            plates[i] = plates[randomIndex];
            plates[randomIndex] = temp;
        }
    }

    public void interact(GameObject go) {
        bool hasFoodP = ((Utensil)go.GetComponent(typeof(Utensil))).hasFood();
        if (hasFoodP) {
            GameObject foodF = ((Utensil)go.GetComponent(typeof(Utensil))).get();
            bool sameFood = ((Food)foodF.GetComponent(typeof(Food))).getType().Equals(foodToServe());
            if (sameFood) index_plates++;
            //else playerMovement.loseLive();
            Destroy(go);
        }
    }

    public string foodToServe() {
        return plates[index_plates];
    }

    public void nextPlate() {
        index_plates++;
        if (index_plates >= plates.Length) SceneManager.LoadScene(1);
    }


}
