using Exiled.API.Interfaces;
using System;
using System.ComponentModel;

namespace FFRoundEnded
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("The first part of the mvp message")]
        public string MVP1 { get; set; } = "The player with the most kills is";
        [Description("The second part of the mvp message")]
        public string MVP2 { get; set; } = "with";
        [Description("The third part of the mvp message")]
        public string MVP3 { get; set; } = "kills!";
    }
}
