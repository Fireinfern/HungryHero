using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public int PlayerLifes = 5;

    void Awake() {
        instance= this;
    }

    public void decreaseLife() {
        PlayerLifes--;
    }

    public void increaseLife() {
        PlayerLifes++;
    }

}
