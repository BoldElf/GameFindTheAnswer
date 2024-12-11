using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifeTimeScope : LifetimeScope
{
    [SerializeField] private Rendering rendering;
    [SerializeField] private SetFindSystem setFindSystem;

    protected override void Configure(IContainerBuilder builder)
    {
        if(rendering != null)
        {
            builder.RegisterComponent(rendering);
            builder.RegisterComponent(setFindSystem);
        }
        else
        {
            Debug.Log("Eror registerComponent(rendering)");
        }
        
    }
}
