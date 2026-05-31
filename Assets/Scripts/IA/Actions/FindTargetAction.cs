using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FindTarget", story: "[Sensor] is searching", category: "Action", id: "c5b8a6c941aa8856c04407017734b711")]
public partial class FindTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<SensorSystem> Sensor;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<Vector3> lastKnownPosition;
    
    protected override Status OnUpdate()
    {
        //pido que me evalue si encuentra un objetivo
        GameObject possibleTarget = Sensor.Value.SearchTarget();
        
        //si no tengo objetivo todavia y encuentro algo nuevo entonces redefino objetivo
        if (Target.Value == null && possibleTarget != null)
        {
            Target.Value = possibleTarget;
            return Status.Success;
        }

        if (Target.Value != null && possibleTarget == null) //tenia un target pero ha desaparecido :(
        {
            lastKnownPosition.Value = Target.Value.transform.position;
            Target.Value = null;
            return Status.Failure;
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

