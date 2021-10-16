using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleLayout : MonoBehaviour
{
  public GameObject empty1;

  public GameObject empty2;

  public GameObject empty3;

  public GameObject empty4;

  public GameObject empty5;

  public GameObject empty6;

  public int taskcount = 1;

  public GameObject findEmpty(int count)
  {
    if (count == 1) {return empty1;}
    else if (count == 2) {return empty2;}
    else if (count == 3) {return empty3;}
    else if (count == 4) {return empty4;}
    else if (count == 5) {return empty5;}
    else {return empty6;}
  }
}
