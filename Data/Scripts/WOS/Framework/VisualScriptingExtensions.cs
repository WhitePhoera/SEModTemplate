#line 2

using System;
using System.Runtime.InteropServices;
using Phoera.Network;
using Phoera.Network.Actions;
using Sandbox.Game;
using Sandbox.Game.Entities.Character.Components;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRageMath;

namespace Phoera.Framework
{
        public static class VisualScriptingExtensions
    {
        private static NetworkAction<long, float> actionSetO2LevelForCharacter;
        private static NetworkAction<long, float> actionSetH2LevelForCharacter;
        private static NetworkAction<long, float> actionSetEnergyLevelForCharacter;
        private static NetworkAction<long, float> actionSetO2LevelForPlayer;
        private static NetworkAction<long, float> actionSetH2LevelForPlayer;
        private static NetworkAction<long, float> actionSetEnergyLevelForPlayer;
        static string EnsureName(this IMyEntity entity)
        {
            if (entity.Name != null)
                return entity.Name;
            var res = entity.Name = entity.EntityId.ToString();
            MyAPIGateway.Entities.SetEntityName(entity, true);
            return res;
        }
        internal static void InitNetwork(NetworkHandlerSystem nhs)
        {
            actionSetO2LevelForCharacter = nhs.CreateAction<long, float>(HandleSetO2LevelForCharacter);
            actionSetH2LevelForCharacter = nhs.CreateAction<long, float>(HandleSetH2LevelForCharacter);
            actionSetEnergyLevelForCharacter = nhs.CreateAction<long, float>(HandleSetEnergyLevelForCharacter);
            actionSetO2LevelForPlayer = nhs.CreateAction<long, float>(HandleSetO2LevelForPlayer);
            actionSetH2LevelForPlayer = nhs.CreateAction<long, float>(HandleSetH2LevelForPlayer);
            actionSetEnergyLevelForPlayer = nhs.CreateAction<long, float>(HandleSetEnergyLevelForPlayer);
        }

        public static void SetO2Level(this IMyCharacter character, float level)
        {
            actionSetO2LevelForCharacter.CallToServer(character.EntityId, level);
        }
        public static float GetO2Level(this IMyCharacter character)
        {
            MyCharacterOxygenComponent comp;
            if (!character.Components.TryGet(out comp))
                return 0;
            return comp.SuitOxygenLevel;
        }
        public static void SetEnergyLevel(this IMyCharacter character, float level)
        {
            actionSetEnergyLevelForCharacter.CallToServer(character.EntityId, level);
        }
        public static float GetH2Level(this IMyCharacter character)
        {
            MyCharacterOxygenComponent comp;
            if (!character.Components.TryGet(out comp))
                return 0;
            return comp.GetGasFillLevel(MyCharacterOxygenComponent.HydrogenId);
        }
        public static void SetH2Level(this IMyCharacter character, float level)
        {
            actionSetH2LevelForCharacter.CallToServer(character.EntityId, level);
        }
        public static void SetH2Level(this IMyPlayer player, float level)
        {
            actionSetH2LevelForPlayer.CallToServer(player.IdentityId, level);
        }
        public static float GetH2Level(this IMyPlayer player)
        {
            return MyVisualScriptLogicProvider.GetPlayersHydrogenLevel(player.IdentityId);
        }
        public static void SetO2Level(this IMyPlayer player, float level)
        {
            actionSetO2LevelForPlayer.CallToServer(player.IdentityId, level);
        }
        public static float GetO2Level(this IMyPlayer player)
        {
            return MyVisualScriptLogicProvider.GetPlayersOxygenLevel(player.IdentityId);
        }
        public static void SetEnergyLevel(this IMyPlayer player, float level)
        {
            actionSetEnergyLevelForPlayer.CallToServer(player.IdentityId, level);
        }
        public static float GetEnergyLevel(this IMyPlayer player)
        {
            return MyVisualScriptLogicProvider.GetPlayersEnergyLevel(player.IdentityId);
        }


        #region Handlers

        private static void HandleSetEnergyLevelForPlayer(ulong sender, long identity, float value)
        {
            MyVisualScriptLogicProvider.SetPlayersEnergyLevel(identity, value);
            if (NetworkHandlerSystem.IsServer && NetworkHandlerSystem.IsMultiplayer)
                actionSetEnergyLevelForPlayer.CallToOthers(identity, value);
        }
        private static void HandleSetH2LevelForPlayer(ulong sender, long identity, float value)
        {
            MyVisualScriptLogicProvider.SetPlayersHydrogenLevel(identity, value);
            if (NetworkHandlerSystem.IsServer && NetworkHandlerSystem.IsMultiplayer)
                actionSetH2LevelForPlayer.CallToOthers(identity, value);
        }

        private static void HandleSetO2LevelForPlayer(ulong sender, long identity, float value)
        {
            MyVisualScriptLogicProvider.SetPlayersOxygenLevel(identity, value);
            if (NetworkHandlerSystem.IsServer && NetworkHandlerSystem.IsMultiplayer)
                actionSetO2LevelForPlayer.CallToOthers(identity, value);
        }
        static void HandleSetEnergyLevelForCharacter(ulong sender, long entityId, float level)
        {
            level = MyMath.Clamp(level, 0, 1);
            IMyEntity character;
            if (!MyAPIGateway.Entities.TryGetEntityById(entityId, out character))
                return;
            MyCharacterOxygenComponent comp;
            if (!character.Components.TryGet(out comp))
                return;
            comp.CharacterGasSource.SetRemainingCapacityByType(MyResourceDistributorComponent.ElectricityId, level * 1E-05f);
            if (NetworkHandlerSystem.IsServer && NetworkHandlerSystem.IsMultiplayer)
                actionSetEnergyLevelForCharacter.CallToOthers(entityId, level);
        }
        static void HandleSetO2LevelForCharacter(ulong sender, long entityId, float level)
        {
            level = MyMath.Clamp(level, 0, 1);
            IMyEntity character;
            if (!MyAPIGateway.Entities.TryGetEntityById(entityId, out character))
                return;
            MyCharacterOxygenComponent comp;
            if (!character.Components.TryGet(out comp))
                return;
            comp.SuitOxygenLevel = level;
            if (NetworkHandlerSystem.IsServer && NetworkHandlerSystem.IsMultiplayer)
                actionSetO2LevelForCharacter.CallToOthers(entityId, level);
        }
        static void HandleSetH2LevelForCharacter(ulong sender, long entityId, float level)
        {
            level = MyMath.Clamp(level, 0, 1);
            IMyEntity character;
            if (!MyAPIGateway.Entities.TryGetEntityById(entityId, out character))
                return;
            MyCharacterOxygenComponent comp;
            if (!character.Components.TryGet(out comp))
                return;
            var h2 = MyCharacterOxygenComponent.HydrogenId;
            comp.UpdateStoredGasLevel(ref h2, level);
            if (NetworkHandlerSystem.IsServer && NetworkHandlerSystem.IsMultiplayer)
                actionSetH2LevelForCharacter.CallToOthers(entityId, level);
        }
        #endregion
    }
}
