using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiceRoll : MonoBehaviour
{
    public GameObject Textbox;
    public int TheNumber;

    public void RandomGenerate()
    {
        TheNumber = Random.Range(0, 7);
        Textbox.GetComponent<Text>().text = "    " + TheNumber;
    }


}
