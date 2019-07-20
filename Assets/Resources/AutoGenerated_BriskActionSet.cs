// #### AUTO-GENERATED CODE ####
// Please avoid editing
// Copyright © Brisk Technologies

namespace Brisk.Actions {
    public sealed class AutoGenerated_BriskActionSet : Brisk.Actions.ActionSet {
        private readonly System.Collections.Generic.Dictionary<int, System.Func<Brisk.Entities.NetBehaviour, Lidgren.Network.NetIncomingMessage, object[]>> actions =
            new System.Collections.Generic.Dictionary<int, System.Func<Brisk.Entities.NetBehaviour, Lidgren.Network.NetIncomingMessage, object[]>> {
                {0, (bhr, msg) => {
                    ((Structures.Doors.Airlock)bhr).Interact();
                    return new object[]{};
                }},
                {1, (bhr, msg) => {
                    ((Brisk.Entities.NetEntity)bhr).Destroy();
                    return new object[]{};
                }},
        };

        public override void Call(Brisk.Entities.NetEntity entity, byte behaviourId, Lidgren.Network.NetIncomingMessage msg, int actionId, out object[] args) {
            args = null;
            if (actions.TryGetValue(actionId, out var action)) args = action(entity.Behaviour(behaviourId), msg);
            else UnityEngine.Debug.LogError($"Action not found with ID: {actionId}");
        }
    }
    public static class AutoGenerated_BriskActionExtensions {
        public static void Net_Interact(this Structures.Doors.Airlock bhr) {
            bhr.Entity.Peer.Messages.ActionGlobal(0, bhr.Entity.Entity.Id, bhr.Entity.Entity.Behaviour(bhr));
        }
        public static void Net_Destroy(this Brisk.Entities.NetEntity bhr) {
            bhr.Entity.Peer.Messages.ActionLocal(1, bhr.Entity.Entity.Id, bhr.Entity.Entity.Behaviour(bhr));
        }
    }
}