using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QQLite.Framework;
using QQLite.Framework.Dapper;
using QQLite.Framework.Entity;
using QQLite.Framework.Event;
using QQLite.Framework.SDK;
using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PasserbyPluginNS
{
    public class PasserbyPlugin : QQLite.Framework.SDK.Plugin
    {
        // 设置窗体实例
        public SettingForm setForm = null;

        // 插件配置
        public PasserbyConfig Config { get; set; }

        // 宝可梦图片列表
        public List<string> evolveImgList = null;
        public List<string> megaEvolveImgList = null;
        public List<string> transformImgList = null;
        public List<string> speciesStrengthImgList = null;
        public List<string> typeOppositeImgList = null;

        public PasserbyPlugin()
        {
            // 插件名
            this.PluginName = "Passerby全能插件";
            // 插件简介
            this.Description = "用到什么功能就加什么功能吧";
            // 插件说明
            this.Note = "嘻嘻嘻";
            // 插件版本
            this.Version = new Version("2019.12.03.1100");
            // 插件发布地址
            this.PluginUrl = "http://zc-passerby.com";
            // 插件开发者
            this.Author = "Passerby";
            // 开发者地址
            this.AuthorUrl = "http://blog.zc-passerby.com";
            // 开发者QQ
            this.AuthorQQ = 450343225;

            this.setForm = null;
        }

        #region 插件执行时必要的函数（overwrite）
        /// <summary>
        /// 安装插件
        /// </summary>
        /// <returns>null：安装插件成功，string：错误信息</returns>
        public override string Install()
        {
            return null;
        }

        /// <summary>
        /// 卸载插件
        /// </summary>
        /// <returns>null：卸载插件成功，string：错误信息</returns>
        public override string UnInstall()
        {
            return null;
        }

        /// <summary>
        /// 升级插件
        /// </summary>
        /// <param name="version">数据库记录的版本</param>
        /// <returns>null：升级插件成功，string：错误信息</returns>
        public override string Update(Version version)
        {
            this.Install();
            return null;
        }

        /// <summary>
        /// 运行插件
        /// </summary>
        /// <returns>null：运行插件成功，string：错误信息</returns>
        public override string Start()
        {
            // 初始化插件配置
            this.Config = PluginConfig.Init<PasserbyConfig>(this, "PasserbyPlugin");
            if (this.Config.PokemonImageBaseDir == "" || this.Config.PokemonImageBaseDir.IsEmpty() || this.Config.PokemonImageBaseDir.IsNull())
                this.Config.PokemonImageBaseDir = "D:\\PokemonImages";
            OnLog("pokemonDir:" + this.Config.PokemonImageBaseDir);
            // 获取宝可梦文件列表
            this.evolveImgList = getPokemonImgList(this.Config.PokemonImageBaseDir + "\\evolveImg");
            this.megaEvolveImgList = getPokemonImgList(this.Config.PokemonImageBaseDir + "\\megaEvolveImg");
            this.speciesStrengthImgList = getPokemonImgList(this.Config.PokemonImageBaseDir + "\\speciesStrength");
            this.transformImgList = getPokemonImgList(this.Config.PokemonImageBaseDir + "\\transformImg");
            this.typeOppositeImgList = getPokemonImgList(this.Config.PokemonImageBaseDir + "\\typeOpposite");
            // sqlite连接字符串
            string dataSource = "QQ\\" + DbBase.RobotQQ.ToString() + "\\DataBase\\52Poke.db3";
            SQLiteHelper.setConnectionString(dataSource);

            this.SDK = new QQClientSDK();

            #region 事件订阅
            // 订阅群消息
            this.SDK.ReceiveClusterIM += SDK_ReceiveClusterIM;
            #endregion

            return null;
        }

        /// <summary>
        /// 停止运行插件
        /// </summary>
        /// <returns>null：停止插件成功，string：错误信息</returns>
        public override string Stop()
        {
            return null;
        }

        /// <summary>
        /// 显示插件窗体
        /// </summary>
        /// <returns>null：显示窗口成功，string：错误信息</returns>
        public override string ShowForm()
        {
            if (this.setForm == null)
                this.setForm = new SettingForm(this);

            setForm.ShowDialog();
            return null;
        }

        /// <summary>
        /// 异常的处理
        /// </summary>
        /// <param name="e">异常</param>
        public override void ProcessException(Exception e)
        {
            QQLog.PluginDebugLog(this, e);
        }
        #endregion

        #region 事件处理
        private void SDK_ReceiveClusterIM(object sender, ClusterIMEventArgs eventArgs)
        {
            // 判断是否已经被别的插件处理过
            if (eventArgs.Cancel)
            {
                OnLog("已被其他插件使用，该插件不再处理");
                return;
            }

            // 开始处理群消息
            ClusterInfo clusterInfo = eventArgs.ClusterInfo;
            if (!clusterInfo.CanSend || SQLiteHandler.getClusterIsEnabled(clusterInfo.ClusterId.ToString()) != "1")
            {
                OnLog("本群未启用该功能");
                return;
            }
            // 去除消息中的空格回车制表符等
            string message = Regex.Replace(eventArgs.Message, "[\f\n\r\t\v\\s+]", "");
            // 开始匹配查询功能
            // 初版直接写死：查 种族值 宝可梦
            if (message.StartsWith("查"))
            {
                Regex r = new Regex("查");
                string msgContent = r.Replace(message, "");
                int pokemonId;
                string sendStr;
                DataSet ds;
                if (int.TryParse(msgContent, out pokemonId))
                {
                    if (pokemonId > 0 && pokemonId < 10)
                        msgContent = "00" + pokemonId.ToString();
                    else if (pokemonId >= 10 && pokemonId < 100)
                        msgContent = "0" + pokemonId.ToString();
                    else if (pokemonId >= 100 && pokemonId <= 890)
                        msgContent = pokemonId.ToString();
                    else
                    {
                        sendStr = "宝可梦编号不存在[1-890]";
                        sendQueryFailureClusterMsg(sendStr, CommonDefine.queryPokemonInfoIdFailure, eventArgs);
                        return;
                    }
                    ds = SQLiteHandler.getPokemonInfoBySn(msgContent);
                }
                else
                {
                    ds = SQLiteHandler.getPokemonInfoByName(msgContent);
                }
                if (ds.Tables.Count == 0 || (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0))
                {
                    sendStr = "宝可梦编号不存在[1-890]";
                    sendQueryFailureClusterMsg(sendStr, CommonDefine.queryPokemonInfoFailure, eventArgs);
                    return;
                }
                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        sendStr = "嘻嘻嘻，就不告诉你";
                        sendQuerySuccessClusterMsg(sendStr, CommonDefine.queryPokemonInfoSuccess, row, eventArgs);
                    }
                }
                return;

            }
            else if (message.StartsWith("种族值"))
            {
                Regex r = new Regex("种族值");
                string msgContent = r.Replace(message, "");
                string sendStr = "";
                foreach (string imgName in this.speciesStrengthImgList)
                    if (-1 != imgName.IndexOf(msgContent))
                        sendStr = sendStr + imgName + "：[Image]" + string.Format("{0}\\speciesStrength\\{1}", this.Config.PokemonImageBaseDir, imgName) + "[/Image]\r\n";
                if (sendStr == "")
                    sendStr = "[@QQ]请确定该宝可梦是否存在！";
                else
                    sendStr = "[@QQ]\r\n" + sendStr;
                SendExtension.SendClusterIM(Client, eventArgs.ClusterInfo.ClusterId, PluginExtension.ReplaceVariable(eventArgs, sendStr, true));
                eventArgs.Cancel = true;
                return;
            }
            else if (message.StartsWith("进化"))
            {
                Regex r = new Regex("进化");
                string msgContent = r.Replace(message, "");
                string sendStr = "";
                if (File.Exists(string.Format("{0}\\evolveImg\\{1}.png", this.Config.PokemonImageBaseDir, msgContent)))
                    sendStr = sendStr + "[Image]" + string.Format("{0}\\evolveImg\\{1}.png", this.Config.PokemonImageBaseDir, msgContent) + "[/Image]\r\n";
                if (File.Exists(string.Format("{0}\\megaEvolveImg\\{1}.png", this.Config.PokemonImageBaseDir, msgContent)))
                    sendStr = sendStr + "超级进化：[Image]" + string.Format("{0}\\megaEvolveImg\\{1}.png", this.Config.PokemonImageBaseDir, msgContent) + "[/Image]\r\n";
                if (File.Exists(string.Format("{0}\\transformImg\\{1}.png", this.Config.PokemonImageBaseDir, msgContent)))
                    sendStr = sendStr + "形态变化：[Image]" + string.Format("{0}\\transformImg\\{1}.png", this.Config.PokemonImageBaseDir, msgContent) + "[/Image]\r\n";
                if (sendStr == "")
                    sendStr = "[@QQ]请确定该宝可梦是否存在！";
                else
                    sendStr = "[@QQ]\r\n" + sendStr;
                SendExtension.SendClusterIM(Client, eventArgs.ClusterInfo.ClusterId, PluginExtension.ReplaceVariable(eventArgs, sendStr, true));
                eventArgs.Cancel = true;
                return;
            }
            else if (message.StartsWith("弱点"))
            {
                Regex r = new Regex("弱点");
                string msgContent = r.Replace(message, "");
                string sendStr = "";
                if (File.Exists(string.Format("{0}\\typeOpposite\\{1}_反转对战.png", this.Config.PokemonImageBaseDir, msgContent)))
                    sendStr = sendStr + "攻击：[Image]" + string.Format("{0}\\typeOpposite\\{1}_反转对战.png", this.Config.PokemonImageBaseDir, msgContent) + "[/Image]\r\n";
                if (File.Exists(string.Format("{0}\\typeOpposite\\{1}_一般.png", this.Config.PokemonImageBaseDir, msgContent)))
                    sendStr = sendStr + "防御：[Image]" + string.Format("{0}\\typeOpposite\\{1}_一般.png", this.Config.PokemonImageBaseDir, msgContent) + "[/Image]\r\n";
                if (sendStr == "")
                    sendStr = "[@QQ]请确定该宝可梦是否存在！";
                else
                    sendStr = "[@QQ]\r\n" + sendStr;
                SendExtension.SendClusterIM(Client, eventArgs.ClusterInfo.ClusterId, PluginExtension.ReplaceVariable(eventArgs, sendStr, true));
                eventArgs.Cancel = true;
                return;
            }
        }
        #endregion

        #region 功能函数
        private List<string> getPokemonImgList(string directoryPath)
        {
            List<string> fileList = new List<string>();
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            foreach(FileInfo file in directory.GetFiles())
                fileList.Add(file.Name);
            return fileList;
        }

        private string ReplacePokemonVariable(string strSrc, DataRow varRow)
        {
            JObject jObject;
            string varString;
            string strRet = strSrc;
            DataColumnCollection varDtCol = varRow.Table.Columns;

            strRet = strRet.Replace("[Sn]", varDtCol.Contains("Sn") ? varRow["Sn"].ToString() : "");
            strRet = strRet.Replace("[NameZh]", varDtCol.Contains("NameZh") ? varRow["NameZh"].ToString() : "");
            strRet = strRet.Replace("[NameJp]", varDtCol.Contains("NameJp") ? varRow["NameJp"].ToString() : "");
            strRet = strRet.Replace("[NameEn]", varDtCol.Contains("NameEn") ? varRow["NameEn"].ToString() : "");
            strRet = strRet.Replace("[ImgUrl]", varDtCol.Contains("ImgUrl") ? varRow["ImgUrl"].ToString() : "");
            strRet = strRet.Replace("[Type]", varDtCol.Contains("Type") ? varRow["Type"].ToString() : "");
            strRet = strRet.Replace("[Category]", varDtCol.Contains("Category") ? varRow["Category"].ToString() : "");
            strRet = strRet.Replace("[Ability]", varDtCol.Contains("Ability") ? varRow["Ability"].ToString() : "");
            strRet = strRet.Replace("[HiddenAbility]", varDtCol.Contains("HiddenAbility") ? varRow["HiddenAbility"].ToString() : "无");
            strRet = strRet.Replace("[100Experience]", varDtCol.Contains("100Experience") ? varRow["100Experience"].ToString() : "");
            strRet = strRet.Replace("[Height]", varDtCol.Contains("Height") ? varRow["Height"].ToString() : "");
            strRet = strRet.Replace("[Weight]", varDtCol.Contains("Weight") ? varRow["Weight"].ToString() : "");
            strRet = strRet.Replace("[BookColor]", varDtCol.Contains("BookColor") ? varRow["BookColor"].ToString() : "");
            strRet = strRet.Replace("[CatchRate]", varDtCol.Contains("CatchRate") ? varRow["CatchRate"].ToString() : "");
            strRet = strRet.Replace("[FullCatchRate]", varDtCol.Contains("FullCatchRate") ? varRow["FullCatchRate"].ToString() : "");
            strRet = strRet.Replace("[GenderRatio]", varDtCol.Contains("GenderRatio") ? varRow["GenderRatio"].ToString() : "");
            strRet = strRet.Replace("[EggGroup]", varDtCol.Contains("EggGroup") ? varRow["EggGroup"].ToString() : "");
            strRet = strRet.Replace("[EggCycle]", varDtCol.Contains("EggCycle") ? varRow["EggCycle"].ToString() : "");
            /*
            strRet = strRet.Replace("[HP]", varDtCol.Contains("HP") ? varRow["HP"].ToString() : "");
            strRet = strRet.Replace("[Attack]", varDtCol.Contains("Attack") ? varRow["Attack"].ToString() : "");
            strRet = strRet.Replace("[Defense]", varDtCol.Contains("Defense") ? varRow["Defense"].ToString() : "");
            strRet = strRet.Replace("[SpecialAttack]", varDtCol.Contains("SpecialAttack") ? varRow["SpecialAttack"].ToString() : "");
            strRet = strRet.Replace("[SpecialDefense]", varDtCol.Contains("SpecialDefense") ? varRow["SpecialDefense"].ToString() : "");
            strRet = strRet.Replace("[Speed]", varDtCol.Contains("Speed") ? varRow["Speed"].ToString() : "");
            */
            // 
            

            // 解析地区图鉴编号
            varString = "";
            if (varDtCol.Contains("ReginalSn"))
            {
                jObject = (JObject)JsonConvert.DeserializeObject(varRow["ReginalSn"].ToString());
                foreach (var item in jObject)
                    varString = string.Format("{0}{1}:{2} ", varString, item.Key, item.Value);
            }
            strRet = strRet.Replace("[ReginalSn]", varString);

            // 解析对战努力值和经验
            if (varDtCol.Contains("EffortValueYield"))
            {
                JToken jToken;
                jObject = (JObject)JsonConvert.DeserializeObject(varRow["EffortValueYield"].ToString());
                string hp = "", attack = "", defense = "", sAttack = "", sDefense = "", speed = "", exp = "", battleExp = "";
                if (jObject.TryGetValue("ＨＰ", out jToken))
                    hp = jToken.ToString();
                if (jObject.TryGetValue("攻击", out jToken))
                    attack = jToken.ToString();
                if (jObject.TryGetValue("防御", out jToken))
                    defense = jToken.ToString();
                if (jObject.TryGetValue("特攻", out jToken))
                    sAttack = jToken.ToString();
                if (jObject.TryGetValue("特防", out jToken))
                    sDefense = jToken.ToString();
                if (jObject.TryGetValue("速度", out jToken))
                    speed = jToken.ToString();
                if (jObject.TryGetValue("基础经验值：", out jToken))
                    exp = jToken.ToString();
                if (jObject.TryGetValue("对战经验值：", out jToken))
                    battleExp = jToken.ToString();
                // 对战努力值
                varString = string.Format("HP:{0} 攻击:{1} 防御:{2} 特攻:{3} 特防:{4} 速度:{5}", hp, attack, defense, sAttack, sDefense, speed);
                strRet = strRet.Replace("[EffortValueYield]", varString);
                // 对战经验值
                varString = string.Format("基础经验值:{0}, 50级宝可梦对战经验值:{1}", exp, battleExp);
                strRet = strRet.Replace("[BattleExperience]", varString);
            }
            strRet = strRet.Replace("[EffortValueYield]", "");
            strRet = strRet.Replace("[BattleExperience]", "");

            return strRet;
        }

        private void sendQuerySuccessClusterMsg(string sendStr, string LanguageDicKey, DataRow row, ClusterIMEventArgs eventArgs)
        {
            if (Config.LanguageDic.ContainsKey(LanguageDicKey))
                sendStr = Config.LanguageDic[LanguageDicKey];
            sendStr = ReplacePokemonVariable(sendStr, row);
            SendExtension.SendClusterIM(Client, eventArgs.ClusterInfo.ClusterId, PluginExtension.ReplaceVariable(eventArgs, sendStr, true));
            eventArgs.Cancel = true;
        }

        private void sendQueryFailureClusterMsg(string sendStr, string LanguageDicKey, ClusterIMEventArgs eventArgs)
        {
            if (Config.LanguageDic.ContainsKey(LanguageDicKey))
                sendStr = Config.LanguageDic[LanguageDicKey];
            SendExtension.SendClusterIM(Client, eventArgs.ClusterInfo.ClusterId, PluginExtension.ReplaceVariable(eventArgs, sendStr, true));
            eventArgs.Cancel = true;
        }
        #endregion
    }
}
