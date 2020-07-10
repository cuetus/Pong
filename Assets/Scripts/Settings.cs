using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty
{
    Easy,   //0
    Normal, //1
    Hard    //2
}

public class Settings : MonoBehaviour
{
    static public Difficulty difficulty = Difficulty.Normal;
    static public int rounds = 10;
}
