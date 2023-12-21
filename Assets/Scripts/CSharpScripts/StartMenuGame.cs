using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;

public class StartMenuGame : MonoBehaviour
{
    private void Start()
    {
        RuntimeInitializer.InitializeAsync();
    }
}
