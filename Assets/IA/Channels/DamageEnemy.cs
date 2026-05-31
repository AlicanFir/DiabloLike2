using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/DamageEnemy")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "DamageEnemy", message: "Enemy spotted [Target]", category: "Events", id: "24f71f441cd1a2c47f0df27990bda024")]
public sealed partial class DamageEnemy : EventChannel<GameObject> { }

