using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deliver : MonoBehaviour
{
    public TMPro.TextMeshProUGUI uiText;
    protected string[] plates;
    protected int index_plates;
    // Start is called before the first frame update
    void Start()
    {
        plates = new string[6] { "bread", "chicken", "onion", "lettuce", "meat", "potato"};
        RandomSortPlates();
        //foreach (var h in plates) Debug.Log(h);
        index_plates = 0;
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = foodToServe();
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

    public bool interact(GameObject go) {
        bool ret = true;
        bool hasFoodP = ((Utensil)go.GetComponent(typeof(Utensil))).hasFood();
        if (hasFoodP) {
            GameObject foodF = ((Utensil)go.GetComponent(typeof(Utensil))).get();
            Debug.Log(((Food)foodF.GetComponent(typeof(Food))).getType());
            bool sameFood = ((Food)foodF.GetComponent(typeof(Food))).getType().ToLower().Equals(foodToServe().ToLower());
            if (sameFood) nextPlate();
            else ret = false;
            Destroy(foodF);
            Destroy(go);
        }
        return ret;
    }

    public string foodToServe() {
        return plates[index_plates];
    }

    public void nextPlate() {
        index_plates++;
        if (index_plates >= plates.Length) SceneManager.LoadScene(0);
    }



}
