using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifeTimeScope : LifetimeScope
{
    [SerializeField] private Rendering rendering;
    [SerializeField] private SetFindSystem setFindSystem;
    [SerializeField] private UIText uIText;
    [SerializeField] private RaycastCheck reycastCheck;
    [SerializeField] private LevelManager levelManager;

    protected override void Configure(IContainerBuilder builder)
    {
        if(rendering != null)
        {
            builder.RegisterComponent(rendering);
            builder.RegisterComponent(setFindSystem);
            builder.RegisterComponent(uIText);
            builder.RegisterComponent(reycastCheck);
            builder.RegisterComponent(levelManager);
        }
        else
        {
            Debug.Log("Eror registerComponent(rendering)");
        }
        
    }
}
