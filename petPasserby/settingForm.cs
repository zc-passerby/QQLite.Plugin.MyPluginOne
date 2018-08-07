using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using QQLite.Framework;
using QQLite.Framework.SDK;
using QQLite.Framework.Tool;
using QQLite.Framework.Dapper;
using QQLite.Framework.Entity;

namespace petPasserby
{
    public partial class settingForm : Form
    {
        #region 指令定义
        public const string openPokemonFunc = "开启宝可梦功能";
        public const string closePokemonFunc = "关闭宝可梦功能";
        public const string queryPokemonInfo = "宝可梦信息查询";
        public const string openPokemonFuncSuccess = "开启宝可梦功能_成功";
        public const string openPokemonFuncFailure = "开启宝可梦功能_失败";
        public const string closePokemonFuncSuccess = "关闭宝可梦功能_成功";
        public const string closePokemonFuncFailure = "关闭宝可梦功能_失败";
        public const string queryPokemonInfoSuccess = "宝可梦信息查询_成功";
        public const string queryPokemonInfoFailure = "宝可梦信息查询_失败";
        public const string queryPokemonInfoIdFailure = "宝可梦全国图鉴编号不正确";
        public const string queryPokemonInfoPokemonNameFailure = "宝可梦名称不正确";
        public const string queryPokemonInfoNotOpen = "宝可梦查询功能未开启";
        #endregion
        public petPasserbyPlugin Plugin { get; set; }
        /// <summary>
        /// 插件配置
        /// </summary>
        public petPasserbyConfig Config { get; set; }
        public settingForm(petPasserbyPlugin plugin)
        {
            InitializeComponent();
            this.Icon = QQLite.Framework.License.SoftIcon;
            this.Plugin = plugin;
            initPluginConfigure();
            initClustListData();
            initCmdListData();
            initRespListData();
            initResParamsData();
        }

        /// <summary>
        /// 根据cmd类型，获取插件命令详情
        /// </summary>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        private CommandDetail getDefaultPluginCommand(string cmdText)
        {
            CommandDetail retCmd = new CommandDetail();
            switch (cmdText)
            {
                case openPokemonFunc:
                    retCmd.Command = "开启宝可梦功能";
                    retCmd.Role = 14;
                    retCmd.DoIM = 15;
                    break;
                case closePokemonFunc:
                    retCmd.Command = "关闭宝可梦功能";
                    retCmd.Role = 14;
                    retCmd.DoIM = 15;
                    break;
                case queryPokemonInfo:
                    retCmd.Command = "查询宝可梦";
                    retCmd.Role = 15;
                    retCmd.DoIM = 15;
                    break;
                default:
                    return null;
            }
            return retCmd;
        }

        private string getDefaultPluginStrParam(string cmdText)
        {
            string retStr = null;
            switch (cmdText)
            {
                case openPokemonFuncSuccess:
                    retStr = "开启宝可梦功能成功";
                    break;
                case openPokemonFuncFailure:
                    retStr = "开启宝可梦功能失败";
                    break;
                case closePokemonFuncSuccess:
                    retStr = "关闭宝可梦功能成功";
                    break;
                case closePokemonFuncFailure:
                    retStr = "关闭宝可梦功能失败";
                    break;
                case queryPokemonInfoSuccess:
                    retStr = "//";
                    break;
                case queryPokemonInfoFailure:
                    retStr = "//";
                    break;
                case queryPokemonInfoNotOpen:
                    retStr = "宝可梦查询功能还没开，请联系管理员开启！";
                    break;
                case queryPokemonInfoIdFailure:
                    retStr = "你输入的全国图鉴编号不存在，请重新查询！";
                    break;
                case queryPokemonInfoPokemonNameFailure:
                    retStr = "你输入的宝可梦名字不存在，请重新输入！";
                    break;
                default:
                    break;
            }
            return retStr;
        }

        private CommandDetail GetPluginConfigCommand(string cmdText)
        {
            CommandDetail retCmd;
            switch (cmdText)
            {
                case openPokemonFunc:
                    retCmd = Config.CommandDic.openPokemonFunc;
                    break;
                case closePokemonFunc:
                    retCmd = Config.CommandDic.closePokemonFunc;
                    break;
                case queryPokemonInfo:
                    retCmd = Config.CommandDic.queryPokemonInfo;
                    break;
                default:
                    return null;
            }
            return retCmd;
        }

        private string GetPluginConfigStrParam(string cmdText)
        {
            string retStr = null;
            switch (cmdText)
            {
                case openPokemonFuncSuccess:
                    retStr = Config.LanguageDic.openPokemonFuncSuccess;
                    break;
                case openPokemonFuncFailure:
                    retStr = Config.LanguageDic.openPokemonFuncFailure;
                    break;
                case closePokemonFuncSuccess:
                    retStr = Config.LanguageDic.closePokemonFuncSuccess;
                    break;
                case closePokemonFuncFailure:
                    retStr = Config.LanguageDic.closePokemonFuncFailure;
                    break;
                case queryPokemonInfoSuccess:
                    retStr = Config.LanguageDic.queryPokemonInfoSuccess;
                    break;
                case queryPokemonInfoFailure:
                    retStr = Config.LanguageDic.queryPokemonInfoFailure;
                    break;
                case queryPokemonInfoNotOpen:
                    retStr = Config.LanguageDic.queryPokemonInfoNotOpen;
                    break;
                case queryPokemonInfoIdFailure:
                    retStr = Config.LanguageDic.queryPokemonInfoIdFailure;
                    break;
                case queryPokemonInfoPokemonNameFailure:
                    retStr = Config.LanguageDic.queryPokemonInfoPokemonNameFailure;
                    break;
                default:
                    break;
            }
            return retStr;
        }

        private bool SetPluginConfigCommand(string cmdText, string Command, int Role, int DoIM)
        {
            switch (cmdText)
            {
                case openPokemonFunc:
                    Config.CommandDic.openPokemonFunc.Command = Command;
                    Config.CommandDic.openPokemonFunc.Role = Role;
                    Config.CommandDic.openPokemonFunc.DoIM = DoIM;
                    return true;
                case closePokemonFunc:
                    Config.CommandDic.closePokemonFunc.Command = Command;
                    Config.CommandDic.closePokemonFunc.Role = Role;
                    Config.CommandDic.closePokemonFunc.DoIM = DoIM;
                    return true;
                case queryPokemonInfo:
                    Config.CommandDic.queryPokemonInfo.Command = Command;
                    Config.CommandDic.queryPokemonInfo.Role = Role;
                    Config.CommandDic.queryPokemonInfo.DoIM = DoIM;
                    return true;
                default:
                    return false;
            }
        }

        private bool SetPluginConfigStrParam(string cmdText, string ParamStr)
        {
            switch (cmdText)
            {
                case openPokemonFuncSuccess:
                    Config.LanguageDic.openPokemonFuncSuccess = ParamStr;
                    return true;
                case openPokemonFuncFailure:
                    Config.LanguageDic.openPokemonFuncFailure = ParamStr;
                    return true;
                case closePokemonFuncSuccess:
                    Config.LanguageDic.closePokemonFuncSuccess = ParamStr;
                    return true;
                case closePokemonFuncFailure:
                    Config.LanguageDic.closePokemonFuncFailure = ParamStr;
                    return true;
                case queryPokemonInfoSuccess:
                    Config.LanguageDic.queryPokemonInfoSuccess = ParamStr;
                    return true;
                case queryPokemonInfoFailure:
                    Config.LanguageDic.queryPokemonInfoFailure = ParamStr;
                    return true;
                case queryPokemonInfoNotOpen:
                    Config.LanguageDic.queryPokemonInfoNotOpen = ParamStr;
                    return true;
                case queryPokemonInfoIdFailure:
                    Config.LanguageDic.queryPokemonInfoIdFailure = ParamStr;
                    return true;
                case queryPokemonInfoPokemonNameFailure:
                    Config.LanguageDic.queryPokemonInfoPokemonNameFailure = ParamStr;
                    return true;
                default:
                    return false;
            }
        }

        private void initPluginConfigure()
        {
            Config = PluginConfig.Init<petPasserbyConfig>(Plugin);
            if (Config.CommandDic == null)
                Config.CommandDic = new CommandDictionary();      
            if (Config.CommandDic.openPokemonFunc == null)
            {
                Config.CommandDic.openPokemonFunc = getDefaultPluginCommand(openPokemonFunc);
            }
            if (Config.CommandDic.closePokemonFunc == null)
            {
                Config.CommandDic.closePokemonFunc = getDefaultPluginCommand(closePokemonFunc);
            }
            if (Config.CommandDic.queryPokemonInfo == null)
            {
                Config.CommandDic.queryPokemonInfo = getDefaultPluginCommand(queryPokemonInfo);
            }
            if (Config.LanguageDic == null)
                Config.LanguageDic = new LanguageDictionary();
            if (Config.LanguageDic.openPokemonFuncSuccess == null)
                Config.LanguageDic.openPokemonFuncSuccess = getDefaultPluginStrParam(openPokemonFuncSuccess);
            if (Config.LanguageDic.openPokemonFuncFailure == null)
                Config.LanguageDic.openPokemonFuncFailure = getDefaultPluginStrParam(openPokemonFuncFailure);
            if (Config.LanguageDic.closePokemonFuncSuccess == null)
                Config.LanguageDic.closePokemonFuncSuccess = getDefaultPluginStrParam(closePokemonFuncSuccess);
            if (Config.LanguageDic.closePokemonFuncFailure == null)
                Config.LanguageDic.closePokemonFuncFailure = getDefaultPluginStrParam(closePokemonFuncFailure);
            if (Config.LanguageDic.queryPokemonInfoSuccess == null)
                Config.LanguageDic.queryPokemonInfoSuccess = getDefaultPluginStrParam(queryPokemonInfoSuccess);
            if (Config.LanguageDic.queryPokemonInfoFailure == null)
                Config.LanguageDic.queryPokemonInfoFailure = getDefaultPluginStrParam(queryPokemonInfoFailure);
            if (Config.LanguageDic.queryPokemonInfoNotOpen == null)
                Config.LanguageDic.queryPokemonInfoNotOpen = getDefaultPluginStrParam(queryPokemonInfoNotOpen);
            if (Config.LanguageDic.queryPokemonInfoIdFailure == null)
                Config.LanguageDic.queryPokemonInfoIdFailure = getDefaultPluginStrParam(queryPokemonInfoIdFailure);
            if (Config.LanguageDic.queryPokemonInfoPokemonNameFailure == null)
                Config.LanguageDic.queryPokemonInfoPokemonNameFailure = getDefaultPluginStrParam(queryPokemonInfoPokemonNameFailure);

            Config.Save();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void initResParamsData()
        {
            ListViewItem lvi;
            lvi = new ListViewItem("[@QQ]");
            lvi.SubItems.Add("主动@发送者");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[发送QQ]");
            lvi.SubItems.Add("发送者的QQ号");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[发送昵称]");
            lvi.SubItems.Add("发送者的昵称");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[群昵称]");
            lvi.SubItems.Add("发送者的群昵称");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[机器人QQ]");
            lvi.SubItems.Add("机器人QQ");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[机器人昵称]");
            lvi.SubItems.Add("机器人昵称");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[随机表情]");
            lvi.SubItems.Add("随机表情");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[时间]");
            lvi.SubItems.Add("当前时间（2018-08-01 00:00:00）");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("-----------------------");
            lvi.SubItems.Add("-----------------------");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[Sn]");
            lvi.SubItems.Add("全国图鉴编号");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[SnJson]");
            lvi.SubItems.Add("各地区图鉴编号（Json格式）");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[NameZh]");
            lvi.SubItems.Add("宝可梦中文名");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[NameJp]");
            lvi.SubItems.Add("宝可梦日文名");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[NameEn]");
            lvi.SubItems.Add("宝可梦英文名");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[ImgUrl]");
            lvi.SubItems.Add("宝可梦图片地址");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[Attribute]");
            lvi.SubItems.Add("宝可梦属性（多属性会以|分隔）");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[Class]");
            lvi.SubItems.Add("宝可梦分类");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[Feature]");
            lvi.SubItems.Add("宝可梦特性");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[HideFeature]");
            lvi.SubItems.Add("宝可梦隐藏特性");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[HP]");
            lvi.SubItems.Add("宝可梦种族值：HP");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[Attack]");
            lvi.SubItems.Add("宝可梦种族值：攻击");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[Defense]");
            lvi.SubItems.Add("宝可梦种族值：防御");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[SpecialAttack]");
            lvi.SubItems.Add("宝可梦种族值：特攻");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[SpecialDefense]");
            lvi.SubItems.Add("宝可梦种族值：特防");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[Speed]");
            lvi.SubItems.Add("宝可梦种族值：速度");
            lV_respParams.Items.Add(lvi);
        }

        private void initClustListData()
        {
            ListViewItem lvi;
            //先添加0（好友设置）和10000（默认群设置）
            string friendSwitch = DbHandler.getClusterIsEnabled("0");
            string defaultSwitch = DbHandler.getClusterIsEnabled("10000");
            lvi = new ListViewItem("0");
            lvi.SubItems.Add("好友设置");
            if (friendSwitch == "0")
            {
                lvi.SubItems.Add("关");
            }
            else
            {
                lvi.SubItems.Add("开");
            }
            lvi = listView_clusterList.Items.Add(lvi);
            lvi = new ListViewItem("10000");
            lvi.SubItems.Add("默认群设置");
            if(defaultSwitch == "0")
            {
                lvi.SubItems.Add("关");
            }
            else
            {
                lvi.SubItems.Add("开");
            }
            lvi = listView_clusterList.Items.Add(lvi);
            //获取群列表
            ClusterList clusterlist = Plugin.Client.ClusterList;
            foreach(KeyValuePair<uint, ClusterInfo> kv in clusterlist)
            {
                ClusterInfo clusterInfo = kv.Value;
                string clusterId = kv.Key.ToString();
                string clusterSwitch = DbHandler.getClusterIsEnabled(clusterId);
                lvi = new ListViewItem(clusterId);
                lvi.SubItems.Add(clusterInfo.Name);
                if(clusterSwitch == "1")
                {
                    lvi.SubItems.Add("开");
                }
                else
                {
                    lvi.SubItems.Add("关");
                }
                lvi = listView_clusterList.Items.Add(lvi);
            }
        }

        private void initCmdListData()
        {
            /*string configJsonStr = PluginConfig.GetJosn(DbBase.RobotQQ, "petPasserby");
            Plugin.OnLog(configJsonStr);
            Config = Json.Deserialize<petPasserbyConfig>(configJsonStr);
            Config.CommandDic.开启宝可梦查询.DoIM = 5;
            Config.Save();
            string configJsonStr = conf.Serialize();
            Plugin.OnLog(configJsonStr);
            conf.CommandDic.openPokemonFunc.Command = "关闭";
            conf.Save();*/
            ListViewItem lvi;
            lvi = new ListViewItem(openPokemonFunc);
            lvi.SubItems.Add(Config.CommandDic.openPokemonFunc.Command);
            lV_cmdList.Items.Add(lvi);
            lvi = new ListViewItem(closePokemonFunc);
            lvi.SubItems.Add(Config.CommandDic.closePokemonFunc.Command);
            lV_cmdList.Items.Add(lvi);
            lvi = new ListViewItem(queryPokemonInfo);
            lvi.SubItems.Add(Config.CommandDic.queryPokemonInfo.Command);
            lV_cmdList.Items.Add(lvi);
            gB_modifyCmd.Visible = false;
        }

        private void initRespListData()
        {
            ListViewItem lvi;

            lvi = new ListViewItem(openPokemonFunc);
            lV_respKey.Items.Add(lvi);

            lvi = new ListViewItem(closePokemonFunc);
            lV_respKey.Items.Add(lvi);

            lvi = new ListViewItem(queryPokemonInfo);
            lV_respKey.Items.Add(lvi);

            lV_respValue.Visible = false;
            gB_respSetting.Visible = false;
        }

        private bool setCommandDetail(string cmdText, CommandDetail cmdInfo)
        {
            string[] example, illustrate;
            switch (cmdText)
            {
                case openPokemonFunc:
                    example = new string[] { "开启宝可梦功能" };
                    illustrate = new string[] { "开启宝可梦功能" };
                    break;
                case closePokemonFunc:
                    example = new string[] { "关闭宝可梦功能" };
                    illustrate = new string[] { "关闭宝可梦功能" };
                    break;
                case queryPokemonInfo:
                    example = new string[] { "查询宝可梦 全国图鉴编号(1-807)/宝可梦名字(支持中、日、英)", "查询宝可梦 123", "查询宝可梦 妙蛙种子" };
                    illustrate = new string[] { "查询宝可梦的详细信息" };
                    break;
                default:
                    gB_modifyCmd.Visible = false;
                    return false;
            }
            lable_instruct.Text = cmdText;
            tB_command.Lines = cmdInfo.Command.Split('|');
            tB_example.Lines = example;
            tB_illustrate.Lines = illustrate;
            cB_members.Checked = (cmdInfo.Role & 1) == 1;
            cB_clusterManager.Checked = ((cmdInfo.Role >> 1) & 1) == 1;
            cB_clusterOwner.Checked = ((cmdInfo.Role >> 2) & 1) == 1;
            cB_softManager.Checked = ((cmdInfo.Role >> 3) & 1) == 1;
            cB_ChargeQQ.Checked = ((cmdInfo.Role >> 5) & 1) == 1;

            cB_friend.Checked = (cmdInfo.DoIM & 1) == 1;
            cB_tempConv.Checked = ((cmdInfo.DoIM >> 1) & 1) == 1;
            cB_cluster.Checked = ((cmdInfo.DoIM >> 2) & 1) == 1;
            cB_discuss.Checked = ((cmdInfo.DoIM >> 3) & 1) == 1;

            return true;
        }

        private void fillRespValueList(string[] valueList)
        {
            lV_respValue.Items.Clear();
            if (valueList.Length == 0)
                return;
            foreach(string value in valueList)
            {
                ListViewItem lvi = new ListViewItem(value);
                lV_respValue.Items.Add(lvi);
            }
        }

        private void listView_clusterList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = listView_clusterList.FocusedItem;
            string clusterId = item.SubItems[0].Text;
            string clusterSwitch = DbHandler.getClusterIsEnabled(clusterId);
            if(clusterSwitch == "0")
            {
                if (DbHandler.setClusterIsEnabled(clusterId, 1))
                    item.SubItems[2].Text = "开";
                else
                    Plugin.OnLog(clusterId + " setClusterIsEnabled failed...");
            }
            else if(clusterSwitch == "1")
            {
                if (DbHandler.setClusterIsEnabled(clusterId, 0))
                    item.SubItems[2].Text = "关";
                else
                    Plugin.OnLog(clusterId + " setClusterIsEnabled failed...");
            }
            else
            {
                if (clusterId == "0" || clusterId == "10000")
                {
                    if(DbHandler.addNewGroupInfo(clusterId, 0))
                        item.SubItems[2].Text = "关";
                    else
                        Plugin.OnLog(clusterId + " add new group info failed...");
                }
                else
                {
                    if (DbHandler.addNewGroupInfo(clusterId, 1))
                        item.SubItems[2].Text = "开";
                    else
                        Plugin.OnLog(clusterId + " add new group info failed...");
                }
            }
        }
        
        private void lV_cmdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = lV_cmdList.SelectedItems[0];
            string cmdText = item.SubItems[0].Text;

            CommandDetail cmdInfo = GetPluginConfigCommand(cmdText);
            if (cmdInfo == null)
                gB_modifyCmd.Visible = false;
            else if (setCommandDetail(cmdText, cmdInfo))
                gB_modifyCmd.Visible = true;
        }

        private void button_cmdDefault_Click(object sender, EventArgs e)
        {
            ListViewItem item = lV_cmdList.SelectedItems[0];
            string cmdText = item.SubItems[0].Text;

            CommandDetail cmdInfo = getDefaultPluginCommand(cmdText);
            if (cmdInfo == null)
                gB_modifyCmd.Visible = false;
            else
                setCommandDetail(cmdText, cmdInfo);
        }

        private void lV_cmdList_MouseDown(object sender, MouseEventArgs e)
        {
            // 获取鼠标点击位置的item
            ListViewItem item = lV_cmdList.GetItemAt(e.X, e.Y);
            if (item == null)
                gB_modifyCmd.Visible = false;
        }

        private void button_cmdSave_Click(object sender, EventArgs e)
        {
            ListViewItem item = lV_cmdList.SelectedItems[0];
            string cmdText = item.SubItems[0].Text;

            int DoIM = 0, Role = 0;
            string Command = "";
            foreach(string cmd in tB_command.Lines)
            {
                if (Command == "")
                    Command = cmd;
                else
                    Command = Command + "|" + cmd;
            }

            if (cB_members.Checked)
                Role += 1;
            if (cB_clusterManager.Checked)
                Role += (1 << 1);
            if (cB_clusterOwner.Checked)
                Role += (1 << 2);
            if (cB_softManager.Checked)
                Role += (1 << 3);
            if (cB_ChargeQQ.Checked)
                Role += (1 << 5);

            if (cB_friend.Checked)
                DoIM += 1;
            if (cB_tempConv.Checked)
                DoIM += (1 << 1);
            if (cB_cluster.Checked)
                DoIM += (1 << 2);
            if (cB_discuss.Checked)
                DoIM += (1 << 3);
            if (SetPluginConfigCommand(cmdText, Command, Role, DoIM))
            {
                item.SubItems[1].Text = Command;
                Config.Save();
            }
            else
            {
                gB_modifyCmd.Visible = false;
            }
        }

        private void lV_respKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = lV_respKey.SelectedItems[0];
            string cmdText = item.SubItems[0].Text;

            string[] respValueList;

            switch (cmdText)
            {
                case openPokemonFunc:
                    respValueList = new string[]
                    {
                        openPokemonFuncSuccess,
                        openPokemonFuncFailure
                    };
                    break;
                case closePokemonFunc:
                    respValueList = new string[]
                    {
                        closePokemonFuncSuccess,
                        closePokemonFuncFailure
                    };
                    break;
                case queryPokemonInfo:
                    respValueList = new string[]
                    {
                        queryPokemonInfoSuccess,
                        queryPokemonInfoFailure,
                        queryPokemonInfoIdFailure,
                        queryPokemonInfoPokemonNameFailure,
                        queryPokemonInfoNotOpen
                    };
                    break;
                default:
                    lV_respValue.Visible = false;
                    gB_respSetting.Visible = false;
                    return;
            }
            fillRespValueList(respValueList);
            lV_respValue.Visible = true;
        }

        private void lV_respKey_MouseDown(object sender, MouseEventArgs e)
        {
            // 获取鼠标点击位置的item
            ListViewItem item = lV_respKey.GetItemAt(e.X, e.Y);
            if (item == null)
            {
                lV_respValue.Visible = false;
                gB_respSetting.Visible = false;
            }
        }

        private void lV_respValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = lV_respValue.SelectedItems[0];
            string cmdText = item.SubItems[0].Text;

            tB_respMessage.Text = "";
            string respMessage = GetPluginConfigStrParam(cmdText);
            if (respMessage == null)
            {
                gB_respSetting.Visible = false;
            }
            else
            {
                tB_respMessage.Text = respMessage;
                gB_respSetting.Visible = true;
            }
        }

        private void lV_respValue_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewItem item = lV_respValue.GetItemAt(e.X, e.Y);
            if (item == null)
                gB_respSetting.Visible = false;
        }

        private void button_respDefault_Click(object sender, EventArgs e)
        {
            ListViewItem item = lV_respValue.SelectedItems[0];
            string cmdText = item.SubItems[0].Text;

            string respMessage = getDefaultPluginStrParam(cmdText);
            if (respMessage == null)
            {
                gB_respSetting.Visible = false;
            }
            else
            {
                tB_respMessage.Text = respMessage;
                gB_respSetting.Visible = true;
            }
        }
    }
}
