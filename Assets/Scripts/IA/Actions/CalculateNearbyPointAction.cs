using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CalculateNearbyPointAction", story: "[Self] calculates NearbyPoint around [LastKnownLocation]", category: "Action", id: "2c07b030dbe09b15d9c7c552e0a1241d")]
public partial class CalculateNearbyPointAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Vector3> LastKnownLocation;
    [SerializeReference] public BlackboardVariable<float> searchRadius;
    [SerializeReference] public BlackboardVariable<Vector3> NearbyPoint;
    [SerializeReference] public BlackboardVariable<int> Tries;

    protected override Status OnStart()
    {
        Vector3 randomPoint;
        do //calculo un punto aleatorio cercano a last known location
        {
            randomPoint = LastKnownLocation.Value + Random.insideUnitSphere * searchRadius;
            //mientras no se alcanzable sigues calculando
            //esto puede caer en un bucle infinito
            
        } while (!NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 0.3f, NavMesh.AllAreas));
        
        //Devuelvo el punto al arbol
        NearbyPoint.Value = randomPoint;
        Tries.Value++;
        return Status.Success;
    }
}

