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

    protected override void Configure(IContainerBuilder builder)
    {
        if(rendering != null)
        {
            builder.RegisterComponent(rendering);
            builder.RegisterComponent(setFindSystem);
            builder.RegisterComponent(uIText);
        }
        else
        {
            Debug.Log("Eror registerComponent(rendering)");
        }
        
    }
}
