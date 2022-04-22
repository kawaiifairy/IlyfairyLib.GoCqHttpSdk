﻿using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 艾特QQ
/// </summary>
public sealed class AtChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.at;

    private long qq;

    public long QQ
    {
        get { return qq; }
        set { qq = value; Data["qq"] = value; }
    }

    public AtChunk(long qq)
    {
        QQ = qq;
    }

    internal AtChunk(bool isAll)
    {
        if (isAll)
        {
            qq = -1;
            this.Data["qq"] = "all";
        }
    }

    public static AtChunk All => new(true);

    public static new AtChunk? Parse(JToken json)
    {
        if (json["data"]?.Value<string>("qq") is string qq)
        {
            if (qq == "all")
            {
                return All;
            }
            else
            {
                return new AtChunk(long.Parse(qq));
            }
        }
        return null;
    }
}
