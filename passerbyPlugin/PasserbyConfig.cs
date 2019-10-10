using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QQLite.Framework.SDK;

namespace PasserbyPluginNS
{
    public class CommonDefine
    {
        #region 指令定义
        public const string openPokemonFunc = "开启宝可梦功能";
        public const string closePokemonFunc = "关闭宝可梦功能";
        public const string queryPokemonInfo = "宝可梦信息查询";
        public const string queryPokemonSpeciesStrength = "宝可梦种族值查询";
        public const string queryPokemonEvolvePath = "宝可梦进化路径查询";

        public const string openPokemonFuncSuccess = "开启宝可梦功能_成功";
        public const string openPokemonFuncFailure = "开启宝可梦功能_失败";
        public const string closePokemonFuncSuccess = "关闭宝可梦功能_成功";
        public const string closePokemonFuncFailure = "关闭宝可梦功能_失败";
        public const string queryPokemonInfoSuccess = "宝可梦信息查询_成功";
        public const string queryPokemonInfoFailure = "宝可梦信息查询_失败";
        public const string queryPokemonSpeciesStrengthSuccess = "宝可梦种族值查询_成功";
        public const string queryPokemonSpeciesStrengthFailure = "宝可梦种族值查询_失败";
        public const string queryPokemonInfoIdFailure = "宝可梦全国图鉴编号不正确";
        public const string queryPokemonInfoPokemonNameFailure = "宝可梦名称不正确";
        public const string queryPokemonInfoNotOpen = "宝可梦查询功能未开启";
        #endregion
    }

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
        /// <summary>
        /// 开启宝可梦功能
        /// </summary>
        public CommandDetail openPokemonFunc { get; set; }
        /// <summary>
        /// 关闭宝可梦功能
        /// </summary>
        public CommandDetail closePokemonFunc { get; set; }
        /// <summary>
        /// 查询宝可梦信息
        /// </summary>
        public CommandDetail queryPokemonInfo { get; set; }
    }

    public class LanguageDictionary
    {
        /// <summary>
        /// 开启宝可梦功能成功回复语
        /// </summary>
        public string openPokemonFuncSuccess { get; set; }
        /// <summary>
        /// 开启宝可梦功能失败回复语
        /// </summary>
        public string openPokemonFuncFailure { get; set; }
        /// <summary>
        /// 关闭宝可梦功能成功回复语
        /// </summary>
        public string closePokemonFuncSuccess { get; set; }
        /// <summary>
        /// 关闭宝可梦功能失败回复语
        /// </summary>
        public string closePokemonFuncFailure { get; set; }
        /// <summary>
        /// 查询宝可梦信息成功回复语
        /// </summary>
        public string queryPokemonInfoSuccess { get; set; }

        /// <summary>
        /// 查询宝可梦信息失败回复语
        /// </summary>
        public string queryPokemonInfoFailure { get; set; }
        /// <summary>
        /// 查询宝可梦信息失败回复语 -- id不存在
        /// </summary>
        public string queryPokemonInfoIdFailure { get; set; }

        /// <summary>
        /// 查询宝可梦信息失败回复语 -- 宝可梦名字不存在
        /// </summary>
        public string queryPokemonInfoPokemonNameFailure { get; set; }

        /// <summary>
        /// 查询宝可梦-宝可梦功能未开
        /// </summary>
        public string queryPokemonInfoNotOpen { get; set; }
    }

    /// <summary>
    /// 插件配置类
    /// </summary>
    public class PasserbyConfig : PluginConfig
    {
        // 宝可梦图片存放路径，目前先写死，修改时可以在配置文件中修改然后重新加载插件
        public string PokemonImageBaseDir { get; set; }
        // 命令字典
        public Dictionary<string, CommandDetail> CommandDic { get; set; }
        // 回复语字典
        public Dictionary<string, string> LanguageDic { get; set; }
    }
}
