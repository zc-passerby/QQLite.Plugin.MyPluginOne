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
            //initListViewData();
            initClustListData();
            initCmdListData();
            initRespListData();
        }

        /// <summary>
        /// 根据cmd类型，获取插件命令详情
        /// </summary>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        private CommandDetail getDefaultPluginCommand(enumConfigList cmdType)
        {
            CommandDetail retCmd = new CommandDetail();
            switch (cmdType)
            {
                case enumConfigList.CommandDic_openPokemonFunc:
                    retCmd.Command = "开启宝可梦功能";
                    retCmd.Role = 8;
                    retCmd.DoIM = 5;
                    break;
                case enumConfigList.CommandDic_closePokemonFunc:
                    retCmd.Command = "关闭宝可梦功能";
                    retCmd.Role = 8;
                    retCmd.DoIM = 5;
                    break;
                case enumConfigList.CommandDic_queryPokemonInfo:
                    retCmd.Command = "查询宝可梦";
                    retCmd.Role = 15;
                    retCmd.DoIM = 15;
                    break;
                default:
                    return null;
            }
            return retCmd;
        }

        private string getDefaultPluginStrParam(enumConfigList cmdType)
        {
            string retStr = null;
            switch (cmdType)
            {
                case enumConfigList.LanguageDic_openPokemonFuncSuccess:
                    retStr = "开启宝可梦功能成功";
                    break;
                case enumConfigList.LanguageDic_openPokemonFuncFailure:
                    retStr = "开启宝可梦功能失败";
                    break;
                case enumConfigList.LanguageDic_closePokemonFuncSuccess:
                    retStr = "关闭宝可梦功能成功";
                    break;
                case enumConfigList.LanguageDic_closePokemonFuncFailure:
                    retStr = "关闭宝可梦功能失败";
                    break;
                case enumConfigList.LanguageDic_queryPokemonInfoSuccess:
                    retStr = "//";
                    break;
                case enumConfigList.LanguageDic_queryPokemonInfoFailure:
                    retStr = "//";
                    break;
                default:
                    break;
            }
            return retStr;
        }

        private void initPluginConfigure()
        {
            Config = PluginConfig.Init<petPasserbyConfig>(Plugin);
            if (Config.CommandDic == null)
                Config.CommandDic = new CommandDictionary();      
            if (Config.CommandDic.openPokemonFunc == null)
            {
                Config.CommandDic.openPokemonFunc = getDefaultPluginCommand(enumConfigList.CommandDic_openPokemonFunc);
            }
            if (Config.CommandDic.closePokemonFunc == null)
            {
                Config.CommandDic.closePokemonFunc = getDefaultPluginCommand(enumConfigList.CommandDic_closePokemonFunc);
            }
            if (Config.CommandDic.queryPokemonInfo == null)
            {
                Config.CommandDic.queryPokemonInfo = getDefaultPluginCommand(enumConfigList.CommandDic_queryPokemonInfo);
            }
            if (Config.LanguageDic == null)
                Config.LanguageDic = new LanguageDictionary();
            if (Config.LanguageDic.openPokemonFuncSuccess == null)
                Config.LanguageDic.openPokemonFuncSuccess = getDefaultPluginStrParam(enumConfigList.LanguageDic_openPokemonFuncSuccess);
            if (Config.LanguageDic.openPokemonFuncFailure == null)
                Config.LanguageDic.openPokemonFuncFailure = getDefaultPluginStrParam(enumConfigList.LanguageDic_openPokemonFuncFailure);
            if (Config.LanguageDic.closePokemonFuncSuccess == null)
                Config.LanguageDic.closePokemonFuncSuccess = getDefaultPluginStrParam(enumConfigList.LanguageDic_closePokemonFuncSuccess);
            if (Config.LanguageDic.closePokemonFuncFailure == null)
                Config.LanguageDic.closePokemonFuncFailure = getDefaultPluginStrParam(enumConfigList.LanguageDic_closePokemonFuncFailure);
            if (Config.LanguageDic.queryPokemonInfoSuccess == null)
                Config.LanguageDic.queryPokemonInfoSuccess = getDefaultPluginStrParam(enumConfigList.LanguageDic_queryPokemonInfoSuccess);
            if (Config.LanguageDic.queryPokemonInfoFailure == null)
                Config.LanguageDic.queryPokemonInfoFailure = getDefaultPluginStrParam(enumConfigList.LanguageDic_queryPokemonInfoFailure);

            Config.Save();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void initListViewData()
        {

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
            lvi = new ListViewItem("开启宝可梦功能");
            lvi.SubItems.Add(Config.CommandDic.openPokemonFunc.Command);
            lV_cmdList.Items.Add(lvi);
            lvi = new ListViewItem("关闭宝可梦功能");
            lvi.SubItems.Add(Config.CommandDic.closePokemonFunc.Command);
            lV_cmdList.Items.Add(lvi);
            lvi = new ListViewItem("查询宝可梦");
            lvi.SubItems.Add(Config.CommandDic.queryPokemonInfo.Command);
            lV_cmdList.Items.Add(lvi);
            gB_modifyCmd.Visible = false;
        }

        private void initRespListData()
        {
            ListViewItem lvi;
            lvi = new ListViewItem("宝可梦查询");
            lV_respKey.Items.Add(lvi);

            lV_respValue.Visible = false;
            gB_respSetting.Visible = false;
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
            ListViewItem item = lV_cmdList.FocusedItem;
            string cmdText = item.SubItems[0].Text;

            CommandDetail cmdInfo;
            string[] example, illustrate;
            switch (cmdText)
            {
                case "开启宝可梦功能":
                    example = new string[] { "开启宝可梦功能" };
                    illustrate = new string[] { "开启宝可梦功能" };
                    cmdInfo = Config.CommandDic.openPokemonFunc;
                    break;
                case "关闭宝可梦功能":
                    example = new string[] { "关闭宝可梦功能" };
                    illustrate = new string[] { "关闭宝可梦功能" };
                    cmdInfo = Config.CommandDic.closePokemonFunc;
                    break;
                case "查询宝可梦":
                    example = new string[] { "查询宝可梦 宝可梦ID（1-807）" };
                    illustrate = new string[] { "查询宝可梦的详细信息" };
                    cmdInfo = Config.CommandDic.queryPokemonInfo;
                    break;
                default:
                    gB_modifyCmd.Visible = false;
                    return;
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

            gB_modifyCmd.Visible = true;
        }
    }
}
