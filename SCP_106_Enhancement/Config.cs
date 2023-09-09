using Exiled.API.Interfaces;
using System.ComponentModel;

namespace scp106
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        [Description("The hint text to be sent to the player who was attacked by SCP-106")]
        public string CaughtHintText { get; set; } = "You have been caught in a pocket dimension by <color=red>%attacker%</color>";

        [Description("Caught to PD player hint duration")]
        public float CaughtHintDuration { get; set; } = 5.0F;

        [Description("A hint to send to the player who escaped from the PD")]
        public string EscapedHintText { get; set; } = "<color=green>Congratulations! You have escaped from the pocket dimension!</color>";

        [Description("Escaped PD hint duration")]
        public float EscapedHintDuration { get; set; } = 5.0F;
    }
}