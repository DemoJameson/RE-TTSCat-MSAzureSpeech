using System.Collections.Generic;
using BilibiliDM_PluginFramework;
using Re_TTSCat.Data;

namespace Re_TTSCat;

public static class CustomUserNameExtension
{
    public static string GetCustomUserName(this DanmakuModel model)
    {
        Dictionary<int, string> usernames = new();
        foreach (var line in Vars.CurrentConf.CustomUserNames.Split('\n'))
        {
            var strings = line.Split('=');
            if (strings.Length != 2)
            {
                continue;
            }

            if (!int.TryParse(strings[0], out var userid))
            {
                continue;
            }

            if (string.IsNullOrWhiteSpace(strings[1]))
            {
                continue;
            }

            usernames[userid] = strings[1];
        }

        if (usernames.TryGetValue(model.UserID, out var username))
        {
            return username;
        }
        else
        {
            return model.UserName;
        }
    }
}