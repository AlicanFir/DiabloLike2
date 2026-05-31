using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ResetTriggersAction", story: "[Self] resets [TriggerParam]", category: "Action", id: "a6c92e0b28e6dea00e28514fdf65f308")]
public partial class ResetTriggersAction : Action
{
    [SerializeReference] public BlackboardVariable<Animator> Self;
    [SerializeReference] public BlackboardVariable<string> TriggerParam;

    protected override Status OnStart()
    {
        Self.Value.ResetTrigger(TriggerParam.Value);
        return Status.Success;
    }
}

