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
            initListViewData();
            initClustListData();
            initCmdListData();
        }

        private void initPluginConfigure()
        {
            Config = PluginConfig.Init<petPasserbyConfig>(Plugin);
            if (Config.CommandDic == null)
                Config.CommandDic = new CommandDictionary();      
            if (Config.CommandDic.openPokemonFunc == null)
            {
                Config.CommandDic.openPokemonFunc = new CommandDetail();
                Config.CommandDic.openPokemonFunc.Command = "开启宝可梦功能";
                Config.CommandDic.openPokemonFunc.Role = 8;
                Config.CommandDic.openPokemonFunc.DoIM = 5;
            }
            if (Config.CommandDic.closePokemonFunc == null)
            {
                Config.CommandDic.closePokemonFunc = new CommandDetail();
                Config.CommandDic.closePokemonFunc.Command = "关闭宝可梦功能";
                Config.CommandDic.closePokemonFunc.Role = 8;
                Config.CommandDic.closePokemonFunc.DoIM = 5;
            }
            if (Config.CommandDic.queryPokemonInfo == null)
            {
                Config.CommandDic.queryPokemonInfo = new CommandDetail();
                Config.CommandDic.queryPokemonInfo.Command = "查询宝可梦";
                Config.CommandDic.queryPokemonInfo.Role = 15;
                Config.CommandDic.queryPokemonInfo.DoIM = 15;
            }
            if (Config.LanguageDic == null)
                Config.LanguageDic = new LanguageDictionary();
            if (Config.LanguageDic.openPokemonFuncSuccess == null)
                Config.LanguageDic.openPokemonFuncSuccess = "开启宝可梦功能成功";
            if (Config.LanguageDic.openPokemonFuncFailure == null)
                Config.LanguageDic.openPokemonFuncFailure = "开启宝可梦功能失败";
            if (Config.LanguageDic.closePokemonFuncSuccess == null)
                Config.LanguageDic.closePokemonFuncSuccess = "关闭宝可梦功能成功";
            if (Config.LanguageDic.closePokemonFuncFailure == null)
                Config.LanguageDic.closePokemonFuncFailure = "关闭宝可梦功能失败";
            if (Config.LanguageDic.openPokemonFuncFailure == null)
                Config.LanguageDic.queryPokemonInfoSuccess = "//";
            if (Config.LanguageDic.openPokemonFuncFailure == null)
                Config.LanguageDic.openPokemonFuncFailure = "//";
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
            //petPasserbyConfig conf = PluginConfig.Init<petPasserbyConfig>(DbBase.RobotQQ, "petPasserby");
            petPasserbyConfig conf = PluginConfig.Init<petPasserbyConfig>(Plugin);
            /*conf.CommandDic = new CommandDictionary();
            conf.CommandDic.开启宝可梦查询 = new CommandDetail();
            conf.CommandDic.开启宝可梦查询.Command = "开启";
            conf.CommandDic.开启宝可梦查询.Role = 8;
            conf.CommandDic.开启宝可梦查询.DoIM = 3;
            conf.Save();*/
            /*string configJsonStr = PluginConfig.GetJosn(DbBase.RobotQQ, "petPasserby");
            Plugin.OnLog(configJsonStr);
            Config = Json.Deserialize<petPasserbyConfig>(configJsonStr);
                Config.CommandDic.开启宝可梦查询.DoIM = 5;
                Config.Save();
            }
            catch (Exception e)
            {
                Plugin.OnLog(e.Message);
                Plugin.OnLog(e.StackTrace);
            }*/
            string configJsonStr = conf.Serialize();
            Plugin.OnLog(configJsonStr);
            conf.CommandDic.openPokemonFunc.Command = "关闭";
            conf.Save();
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
    }
}
