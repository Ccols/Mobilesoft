using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiceRoll : MonoBehaviour
{
    public GameObject Textbox;
    public int TheNumber;

    /*
     * The function that does the dice rolling.
     * And places the value to the textbox.
     */
    public void RandomGenerate()
    {
        TheNumber = Random.Range(1, 7);
        Textbox.GetComponent<Text>().text = "    " + TheNumber;
    }


}
