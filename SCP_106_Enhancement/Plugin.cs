using System;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.Commands.Reload;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp049;
using PlayerRoles;
using PlayerRoles.PlayableScps.Scp106;
using PluginAPI.Events;
using static MapGeneration.ImageGenerator;

namespace scp106
{
    public sealed class Plugin : Plugin<Config>
    {
        public override PluginPriority Priority { get; } = PluginPriority.Lower;
        public override string Name { get; } = "SCP 106 Enhancement";

        public override string Author { get; } = "alone";

        public override string Prefix { get; } = "SCP106_Enhancement";

        public override void OnEnabled()
        {
            Log.Info("Plugin enabled");
            Exiled.Events.Handlers.Player.Hurting += OnAttack;
            Exiled.Events.Handlers.Player.EscapingPocketDimension += OnEscaping;
        }

        public override void OnDisabled()
        {
            Log.Info("Plugin disabled");
        }

        public void OnEscaping(EscapingPocketDimensionEventArgs ev)
        {
            ev.Player.ShowHint(Config.EscapedHintText, Config.EscapedHintDuration);
        }

        public void OnAttack(HurtingEventArgs ev)
        {
            if (ev.Attacker.Role == RoleTypeId.Scp106)
            {
                ev.Player.ShowHint(Config.CaughtHintText.Replace("%attacker%", ev.Attacker.Nickname), Config.CaughtHintDuration);
                ev.Player.EnableEffect(EffectType.Corroding);
            }
        }
    }
}