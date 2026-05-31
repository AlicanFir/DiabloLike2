using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CheckOutOfRadius", story: "[Self] checks if [Target] is out of [radius]", category: "Action", id: "1463bf112b5253c53382cd18cc3ae0d9")]
public partial class CheckOutOfRadiusAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> Radius;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        //si no colisiono con player
        if (!Physics.Raycast(Self.Value.transform.position,
                Target.Value.transform.position - Self.Value.transform.position,
                Radius))
        {
            return Status.Success;
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

