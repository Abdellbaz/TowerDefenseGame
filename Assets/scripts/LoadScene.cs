﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{


    public void SceneLoader(string SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);

    }


}