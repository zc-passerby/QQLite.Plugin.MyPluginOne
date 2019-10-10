using QQLite.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PasserbyPluginNS
{
    public partial class SettingForm : Form
    {
        public PasserbyPlugin Plugin { get; set; }
        /// <summary>
        /// 插件配置
        /// </summary>
        public PasserbyConfig Config { get; set; }
        public SettingForm(PasserbyPlugin plugin)
        {
            InitializeComponent();
            this.Icon = QQLite.Framework.License.SoftIcon;
            this.Plugin = plugin;
            this.Config = plugin.Config;

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
                case CommonDefine.openPokemonFunc:
                    retCmd.Command = "开启宝可梦功能";
                    retCmd.Role = 14;
                    retCmd.DoIM = 15;
                    break;
                case CommonDefine.closePokemonFunc:
                    retCmd.Command = "关闭宝可梦功能";
                    retCmd.Role = 14;
                    retCmd.DoIM = 15;
                    break;
                case CommonDefine.queryPokemonInfo:
                    retCmd.Command = "查询宝可梦信息";
                    retCmd.Role = 15;
                    retCmd.DoIM = 15;
                    break;
                case CommonDefine.queryPokemonSpeciesStrength:
                    retCmd.Command = "查询宝可梦种族值";
                    retCmd.Role = 15;
                    retCmd.DoIM = 15;
                    break;
                case CommonDefine.queryPokemonEvolvePath:
                    retCmd.Command = "查询宝可梦进化路径";
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
                case CommonDefine.openPokemonFuncSuccess:
                    retStr = "开启宝可梦功能成功";
                    break;
                case CommonDefine.openPokemonFuncFailure:
                    retStr = "开启宝可梦功能失败";
                    break;
                case CommonDefine.closePokemonFuncSuccess:
                    retStr = "关闭宝可梦功能成功";
                    break;
                case CommonDefine.closePokemonFuncFailure:
                    retStr = "关闭宝可梦功能失败";
                    break;
                case CommonDefine.queryPokemonInfoSuccess:
                    retStr = "//";
                    break;
                case CommonDefine.queryPokemonInfoFailure:
                    retStr = "//";
                    break;
                case CommonDefine.queryPokemonSpeciesStrengthSuccess:
                    retStr = "//";
                    break;
                case CommonDefine.queryPokemonSpeciesStrengthFailure:
                    retStr = "//";
                    break;
                case CommonDefine.queryPokemonInfoNotOpen:
                    retStr = "宝可梦查询功能还没开，请联系管理员开启！";
                    break;
                case CommonDefine.queryPokemonInfoIdFailure:
                    retStr = "你输入的全国图鉴编号不存在，请重新查询！";
                    break;
                case CommonDefine.queryPokemonInfoPokemonNameFailure:
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
            if (Config.CommandDic.TryGetValue(cmdText, out retCmd))
                return retCmd;
            else
                return null;
        }

        private string GetPluginConfigStrParam(string cmdText)
        {
            string retStr = "";
            if (Config.LanguageDic.TryGetValue(cmdText, out retStr))
                return retStr;
            else
                return null;
        }

        private bool SetPluginConfigCommand(string cmdText, string Command, int Role, int DoIM)
        {
            CommandDetail commandDetail;
            if (Config.CommandDic.TryGetValue(cmdText, out commandDetail))
            {
                commandDetail.Command = Command;
                commandDetail.Role = Role;
                commandDetail.DoIM = DoIM;
                Config.CommandDic[cmdText] = commandDetail;
                return true;
            }
            else
                return false;
        }

        private bool SetPluginConfigStrParam(string cmdText, string ParamStr)
        {
            if (Config.LanguageDic.ContainsKey(cmdText))
            {
                Config.LanguageDic[cmdText] = ParamStr;
                return true;
            }
            else
                return false;
        }

        private void initPluginConfigure()
        {
            if (Config.CommandDic == null)
                Config.CommandDic = new Dictionary<string, CommandDetail>();
            if (!Config.CommandDic.ContainsKey(CommonDefine.openPokemonFunc))
                Config.CommandDic.Add(CommonDefine.openPokemonFunc, getDefaultPluginCommand(CommonDefine.openPokemonFunc));
            if (!Config.CommandDic.ContainsKey(CommonDefine.closePokemonFunc))
                Config.CommandDic.Add(CommonDefine.closePokemonFunc, getDefaultPluginCommand(CommonDefine.closePokemonFunc));
            if (!Config.CommandDic.ContainsKey(CommonDefine.queryPokemonInfo))
                Config.CommandDic.Add(CommonDefine.queryPokemonInfo, getDefaultPluginCommand(CommonDefine.queryPokemonInfo));
            if (!Config.CommandDic.ContainsKey(CommonDefine.queryPokemonSpeciesStrength))
                Config.CommandDic.Add(CommonDefine.queryPokemonSpeciesStrength, getDefaultPluginCommand(CommonDefine.queryPokemonSpeciesStrength));
            if (!Config.CommandDic.ContainsKey(CommonDefine.queryPokemonEvolvePath))
                Config.CommandDic.Add(CommonDefine.queryPokemonEvolvePath, getDefaultPluginCommand(CommonDefine.queryPokemonEvolvePath));

            if (Config.LanguageDic == null)
                Config.LanguageDic = new Dictionary<string, string>();
            if (!Config.LanguageDic.ContainsKey(CommonDefine.openPokemonFuncSuccess))
                Config.LanguageDic.Add(CommonDefine.openPokemonFuncSuccess, getDefaultPluginStrParam(CommonDefine.openPokemonFuncSuccess));
            if (!Config.LanguageDic.ContainsKey(CommonDefine.openPokemonFuncFailure))
                Config.LanguageDic.Add(CommonDefine.openPokemonFuncFailure, getDefaultPluginStrParam(CommonDefine.openPokemonFuncFailure));
            if (!Config.LanguageDic.ContainsKey(CommonDefine.closePokemonFuncSuccess))
                Config.LanguageDic.Add(CommonDefine.closePokemonFuncSuccess, getDefaultPluginStrParam(CommonDefine.closePokemonFuncSuccess));
            if (!Config.LanguageDic.ContainsKey(CommonDefine.closePokemonFuncFailure))
                Config.LanguageDic.Add(CommonDefine.closePokemonFuncFailure, getDefaultPluginStrParam(CommonDefine.closePokemonFuncFailure));
            if (!Config.LanguageDic.ContainsKey(CommonDefine.queryPokemonInfoSuccess))
                Config.LanguageDic.Add(CommonDefine.queryPokemonInfoSuccess, getDefaultPluginStrParam(CommonDefine.queryPokemonInfoSuccess));
            if (!Config.LanguageDic.ContainsKey(CommonDefine.queryPokemonInfoFailure))
                Config.LanguageDic.Add(CommonDefine.queryPokemonInfoFailure, getDefaultPluginStrParam(CommonDefine.queryPokemonInfoFailure));
            if (!Config.LanguageDic.ContainsKey(CommonDefine.queryPokemonSpeciesStrengthSuccess))
                Config.LanguageDic.Add(CommonDefine.queryPokemonSpeciesStrengthSuccess, getDefaultPluginStrParam(CommonDefine.queryPokemonSpeciesStrengthSuccess));
            if (!Config.LanguageDic.ContainsKey(CommonDefine.queryPokemonSpeciesStrengthFailure))
                Config.LanguageDic.Add(CommonDefine.queryPokemonSpeciesStrengthFailure, getDefaultPluginStrParam(CommonDefine.queryPokemonSpeciesStrengthFailure));
            if (!Config.LanguageDic.ContainsKey(CommonDefine.queryPokemonInfoNotOpen))
                Config.LanguageDic.Add(CommonDefine.queryPokemonInfoNotOpen, getDefaultPluginStrParam(CommonDefine.queryPokemonInfoNotOpen));
            if (!Config.LanguageDic.ContainsKey(CommonDefine.queryPokemonInfoIdFailure))
                Config.LanguageDic.Add(CommonDefine.queryPokemonInfoIdFailure, getDefaultPluginStrParam(CommonDefine.queryPokemonInfoIdFailure));
            if (!Config.LanguageDic.ContainsKey(CommonDefine.queryPokemonInfoPokemonNameFailure))
                Config.LanguageDic.Add(CommonDefine.queryPokemonInfoPokemonNameFailure, getDefaultPluginStrParam(CommonDefine.queryPokemonInfoPokemonNameFailure));

            // Config.Save();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void initResParamsData()
        {
            ListViewItem lvi;
            lvi = new ListViewItem("[@全体成员]");
            lvi.SubItems.Add("@全体成员(直接使用，后续不用替换了)");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[@QQ]");
            lvi.SubItems.Add("主动@发送者");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[发送QQ]");
            lvi.SubItems.Add("发送者的QQ号");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[发送昵称]");
            lvi.SubItems.Add("发送者的昵称");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[QQ]");
            lvi.SubItems.Add("QQ号");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[昵称]");
            lvi.SubItems.Add("发送者的群昵称");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[头像]");
            lvi.SubItems.Add("头像");
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
            lvi.SubItems.Add("当前时间(2018-08-01 00:00:00)");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("-----------------------");
            lvi.SubItems.Add("-----------------------");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[Sn]");
            lvi.SubItems.Add("全国图鉴编号");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[ReginalSn]");
            lvi.SubItems.Add("各地区图鉴编号(Json格式)");
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

            lvi = new ListViewItem("[Type]");
            lvi.SubItems.Add("宝可梦属性（多属性会以|分隔）");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[Category]");
            lvi.SubItems.Add("宝可梦分类");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[Ability]");
            lvi.SubItems.Add("宝可梦特性");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[HiddenAbility]");
            lvi.SubItems.Add("宝可梦隐藏特性");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[100Experience]");
            lvi.SubItems.Add("宝可梦100级需要的经验");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[Height]");
            lvi.SubItems.Add("宝可梦身高");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[Weight]");
            lvi.SubItems.Add("宝可梦体重");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[BookColor]");
            lvi.SubItems.Add("宝可梦图鉴颜色");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[CatchRate]");
            lvi.SubItems.Add("宝可梦捕捉率");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[FullCatchRate]");
            lvi.SubItems.Add("宝可梦使用普通精灵球满血捕捉率");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[GenderRatio]");
            lvi.SubItems.Add("宝可梦性别比例");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[EggGroup]");
            lvi.SubItems.Add("宝可梦蛋群");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[EggCycle]");
            lvi.SubItems.Add("宝可梦孵化周期");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[EffortValueYield]");
            lvi.SubItems.Add("宝可梦战斗获得的努力值");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[BattleExperience]");
            lvi.SubItems.Add("宝可梦对战经验值");
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

            lvi = new ListViewItem("[speciesStrength]");
            lvi.SubItems.Add("宝可梦种族值");
            lV_respParams.Items.Add(lvi);

            lvi = new ListViewItem("[typeOpposite]");
            lvi.SubItems.Add("宝可梦弱点");
            lV_respParams.Items.Add(lvi);
        }

        private void initClustListData()
        {
            ListViewItem lvi;
            //先添加0（好友设置）和10000（默认群设置）
            string friendSwitch = SQLiteHandler.getClusterIsEnabled("0");
            string defaultSwitch = SQLiteHandler.getClusterIsEnabled("10000");
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
            if (defaultSwitch == "0")
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
            foreach (KeyValuePair<uint, ClusterInfo> kv in clusterlist)
            {
                ClusterInfo clusterInfo = kv.Value;
                string clusterId = kv.Key.ToString();
                string clusterSwitch = SQLiteHandler.getClusterIsEnabled(clusterId);
                lvi = new ListViewItem(clusterId);
                lvi.SubItems.Add(clusterInfo.Name);
                if (clusterSwitch == "1")
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
            /*string configJsonStr = PluginConfig.GetJosn(DbBase.RobotQQ, "Passerby");
            Plugin.OnLog(configJsonStr);
            Config = Json.Deserialize<PasserbyConfig>(configJsonStr);
            Config.CommandDic.开启宝可梦查询.DoIM = 5;
            Config.Save();
            string configJsonStr = conf.Serialize();
            Plugin.OnLog(configJsonStr);
            conf.CommandDic.openPokemonFunc.Command = "关闭";
            conf.Save();*/
            if (Config.CommandDic.ContainsKey(CommonDefine.openPokemonFunc))
            {
                ListViewItem lvi = new ListViewItem(CommonDefine.openPokemonFunc);
                lvi.SubItems.Add(Config.CommandDic[CommonDefine.openPokemonFunc].Command);
                lV_cmdList.Items.Add(lvi);
            }
            if (Config.CommandDic.ContainsKey(CommonDefine.closePokemonFunc))
            {
                ListViewItem lvi = new ListViewItem(CommonDefine.closePokemonFunc);
                lvi.SubItems.Add(Config.CommandDic[CommonDefine.closePokemonFunc].Command);
                lV_cmdList.Items.Add(lvi);
            }
            if (Config.CommandDic.ContainsKey(CommonDefine.queryPokemonInfo))
            {
                ListViewItem lvi = new ListViewItem(CommonDefine.queryPokemonInfo);
                lvi.SubItems.Add(Config.CommandDic[CommonDefine.queryPokemonInfo].Command);
                lV_cmdList.Items.Add(lvi);
            }
            if (Config.CommandDic.ContainsKey(CommonDefine.queryPokemonSpeciesStrength))
            {
                ListViewItem lvi = new ListViewItem(CommonDefine.queryPokemonSpeciesStrength);
                lvi.SubItems.Add(Config.CommandDic[CommonDefine.queryPokemonSpeciesStrength].Command);
                lV_cmdList.Items.Add(lvi);
            }
            if (Config.CommandDic.ContainsKey(CommonDefine.queryPokemonEvolvePath))
            {
                ListViewItem lvi = new ListViewItem(CommonDefine.queryPokemonEvolvePath);
                lvi.SubItems.Add(Config.CommandDic[CommonDefine.queryPokemonEvolvePath].Command);
                lV_cmdList.Items.Add(lvi);
            }
            gB_modifyCmd.Visible = false;
        }

        private void initRespListData()
        {
            ListViewItem lvi;

            lvi = new ListViewItem(CommonDefine.openPokemonFunc);
            lV_respKey.Items.Add(lvi);

            lvi = new ListViewItem(CommonDefine.closePokemonFunc);
            lV_respKey.Items.Add(lvi);

            lvi = new ListViewItem(CommonDefine.queryPokemonInfo);
            lV_respKey.Items.Add(lvi);

            lvi = new ListViewItem(CommonDefine.queryPokemonSpeciesStrength);
            lV_respKey.Items.Add(lvi);

            lvi = new ListViewItem(CommonDefine.queryPokemonEvolvePath);
            lV_respKey.Items.Add(lvi);

            lV_respValue.Visible = false;
            gB_respSetting.Visible = false;
        }

        private bool setCommandDetail(string cmdText, CommandDetail cmdInfo)
        {
            string[] example, illustration;
            switch (cmdText)
            {
                case CommonDefine.openPokemonFunc:
                    example = new string[] { "开启宝可梦功能" };
                    illustration = new string[] { "开启宝可梦功能" };
                    break;
                case CommonDefine.closePokemonFunc:
                    example = new string[] { "关闭宝可梦功能" };
                    illustration = new string[] { "关闭宝可梦功能" };
                    break;
                case CommonDefine.queryPokemonInfo:
                    example = new string[] { "查 全国图鉴编号(1-809)/宝可梦名字(支持中、日、英)", "查询宝可梦 123", "查 妙蛙种子" };
                    illustration = new string[] { "查询宝可梦的详细信息" };
                    break;
                case CommonDefine.queryPokemonSpeciesStrength:
                    example = new string[] { "种族值 全国图鉴编号(1-809)/宝可梦名字(支持中文)", "种族值 妙蛙种子" };
                    illustration = new string[] { "查询宝可梦的种族值" };
                    break;
                case CommonDefine.queryPokemonEvolvePath:
                    example = new string[] { "进化 全国图鉴编号(1-809)/宝可梦名字(支持中文)", "进化 妙蛙种子" };
                    illustration = new string[] { "查询宝可梦的进化路径" };
                    break;
                default:
                    gB_modifyCmd.Visible = false;
                    return false;
            }
            lable_instruct.Text = cmdText;
            tB_command.Lines = cmdInfo.Command.Split('|');
            tB_example.Lines = example;
            tB_illustrate.Lines = illustration;
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
            foreach (string value in valueList)
            {
                ListViewItem lvi = new ListViewItem(value);
                lV_respValue.Items.Add(lvi);
            }
        }

        private void listView_clusterList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = listView_clusterList.FocusedItem;
            string clusterId = item.SubItems[0].Text;
            string clusterSwitch = SQLiteHandler.getClusterIsEnabled(clusterId);
            if (clusterSwitch == "0")
            {
                if (SQLiteHandler.setClusterIsEnabled(clusterId, 1))
                    item.SubItems[2].Text = "开";
                else
                    Plugin.OnLog(clusterId + " setClusterIsEnabled failed...");
            }
            else if (clusterSwitch == "1")
            {
                if (SQLiteHandler.setClusterIsEnabled(clusterId, 0))
                    item.SubItems[2].Text = "关";
                else
                    Plugin.OnLog(clusterId + " setClusterIsEnabled failed...");
            }
            else
            {
                if (clusterId == "0" || clusterId == "10000")
                {
                    if (SQLiteHandler.addNewGroupInfo(clusterId, 0))
                        item.SubItems[2].Text = "关";
                    else
                        Plugin.OnLog(clusterId + " add new group info failed...");
                }
                else
                {
                    if (SQLiteHandler.addNewGroupInfo(clusterId, 1))
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
            foreach (string cmd in tB_command.Lines)
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
                case CommonDefine.openPokemonFunc:
                    respValueList = new string[]
                    {
                        CommonDefine.openPokemonFuncSuccess,
                        CommonDefine.openPokemonFuncFailure
                    };
                    break;
                case CommonDefine.closePokemonFunc:
                    respValueList = new string[]
                    {
                        CommonDefine.closePokemonFuncSuccess,
                        CommonDefine.closePokemonFuncFailure
                    };
                    break;
                case CommonDefine.queryPokemonInfo:
                    respValueList = new string[]
                    {
                        CommonDefine.queryPokemonInfoSuccess,
                        CommonDefine.queryPokemonInfoFailure,
                        CommonDefine.queryPokemonInfoIdFailure,
                        CommonDefine.queryPokemonInfoPokemonNameFailure,
                        CommonDefine.queryPokemonInfoNotOpen
                    };
                    break;
                case CommonDefine.queryPokemonSpeciesStrength:
                    respValueList = new string[]
                    {
                        CommonDefine.queryPokemonSpeciesStrengthSuccess,
                        CommonDefine.queryPokemonSpeciesStrengthFailure
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

        private void lV_respParams_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lV_respParams.SelectedItems[0];
            string paramStr = item.SubItems[0].Text;

            if (paramStr == "" || paramStr == null)
                return;

            int start = tB_respMessage.SelectionStart;
            tB_respMessage.Text = tB_respMessage.Text.Insert(start, paramStr);
            tB_respMessage.SelectionStart = start + paramStr.Length;
            //tB_respMessage.Focus();
            //tB_respMessage.SelectionStart = start;
            //tB_respMessage.SelectionLength = paramStr.Length;
        }

        private void button_respSave_Click(object sender, EventArgs e)
        {
            ListViewItem item = lV_respValue.SelectedItems[0];
            string cmdText = item.SubItems[0].Text;
            string paramStr = tB_respMessage.Text.ToString();
            if (SetPluginConfigStrParam(cmdText, paramStr))
                Config.Save();
        }
    }
}
