using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CreateAnimAndWaitAction", story: "[Anim] plays animation in parameter", category: "Action", id: "6389fdb10f4d334edfccd1b8e6054385")]
public partial class PlayAnimAndWaitAction : Action
{
    [SerializeReference] public BlackboardVariable<Animator> Anim;
    [SerializeReference] public BlackboardVariable<string> ParameterName;

    private float clipTime; //cuanto dura la animacion
    private float timer = 0;

    protected override Status OnStart()
    {
        timer = 0;
        Anim.Value.SetTrigger(ParameterName.Value);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        clipTime = Anim.Value.GetCurrentAnimatorStateInfo(0).length; //longitud de la animacion
        timer += Time.deltaTime;

        return timer >= clipTime ? Status.Success : Status.Running; //condicion? si : no
    }
    
}

