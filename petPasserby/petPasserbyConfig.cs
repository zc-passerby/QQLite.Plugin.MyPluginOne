using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QQLite.Framework.SDK;

namespace petPasserby
{
    /// <summary>
    /// 命令配置详情
    /// </summary>
    public class CommandDetail
    {
        /// <summary>
        /// 命令（多个命令以|分隔，如：开|开1|开2）
        /// </summary>
        public string Command { get; set; }
        /// <summary>
        /// 会话(好友1 临时会话2 群4 讨论组8)[四位二进制]
        /// </summary>
        public int DoIM { get; set; }
        /// <summary>
        /// 权限(好友、群成员1 群管理员2 群主4 软件管理员8 负责人QQ32)[六位二进制]
        /// </summary>
        public int Role { get; set; }
    }

    /// <summary>
    /// 命令配置字典
    /// </summary>
    public class CommandDictionary
    {
        public CommandDetail 开启宝可梦查询 { get; set; }
        public CommandDetail 关闭宝可梦查询 { get; set; }
        public CommandDetail 查询宝可梦 { get; set; }
    }

    /// <summary>
    /// 插件配置类
    /// </summary>
    public class petPasserbyConfig : PluginConfig
    {
        public CommandDictionary CommandDic { get; set; }
    }
}
