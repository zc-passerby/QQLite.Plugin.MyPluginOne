using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QQLite.Framework;
using QQLite.Framework.Event;
using QQLite.Framework.QQEnum;
using QQLite.Framework.SDK;
using QQLite.Framework.Tool;
using QQLite.Framework.Entity;
using QQLite.Framework.Dapper;
using System.Data;
using System.Text.RegularExpressions;

namespace petPasserby
{
    public class petPasserbyPlugin : QQLite.Framework.SDK.Plugin
    {
        public settingForm setForm = null;
        public petPasserbyPlugin()
        {
            //插件名
            this.PluginName = "精灵宝可梦";
            //插件简介
            this.Description = "精灵宝可梦相关数据的查询";
            //插件说明
            this.Note = "精灵宝可梦";
            // 插件版本
            this.Version = new Version("1.0.0.1");
            // 插件发布地址
            this.PluginUrl = "请期待";
            // 插件开发者
            this.Author = "Passerby";
            // 开发者地址
            this.AuthorUrl = "请期待";
            // 开发者QQ
            this.AuthorQQ = 450343225;
        }

        #region 插件执行时必要的函数（overwrite）
        /// <summary>安装插件</summary>
        /// <returns>null：安装插件成功，string：错误信息</returns>
        public override string Install()
        {
            return null;
        }

        /// <summary>卸载插件</summary>
        /// <returns>null：卸载插件成功，string：错误信息</returns>
        public override string UnInstall()
        {
            return null;
        }

        /// <summary>升级插件</summary>
        /// <param name="version">数据库记录的版本</param>
        /// <returns>null：升级插件成功，string：错误信息</returns>
        public override string Update(Version version)
        {
            return null;
        }

        /// <summary>运行插件</summary>
        /// <returns>null：运行插件成功，string：错误信息</returns>
        public override string Start()
        {
            if(!CheckRobotAuthorization())
            {
                OnLog("机器人授权已到期，请联系作者！");
                return "机器人授权已到期,请联系作者：" + AuthorQQ.ToString();
            }

            //PluginConfig pc = PluginConfig.Init<PluginConfig>(this, "abc");
            //pc.IsEncrypt = true;
            //PluginConfig.GetJosn(this, "QQLite.Plugin.InterfacePlugin");
            //pc.Save();

            string dataSource = "QQ\\" + DbBase.RobotQQ.ToString() + "\\DataBase\\QQLite.Plugin.52Poke.db";
            DbHelper.setSqlLiteConnection(dataSource);
            //OnLog("set connectionstr successful:" + DbHelper.getConnectionStr());

            string LogFilePath = "./pokemonLog.txt";
            QQLog.WriteLogFile = LogFilePath;

            this.SDK = new QQClientSDK();

            #region 事件订阅
            this.SDK.ReceiveClusterIM += SDK_ReceiveClusterIM;
            #endregion

            return null;
        }

        /// <summary>停止运行插件</summary>
        /// <returns>null：停止插件成功，string：错误信息</returns>
        public override string Stop()
        {
            DbHelper.closeConnection();
            setForm = null;
            return null;
        }

        /// <summary>显示插件窗体</summary>
        /// <returns>null：显示窗口成功，string：错误信息</returns>
        public override string ShowForm()
        {
            if (setForm == null)
                setForm = new settingForm(this);
            setForm.ShowDialog();
            //new settingForm(this).ShowDialog();
            return null;
        }

        /// <summary>异常的处理</summary>
        /// <param name="e">异常</param>
        public override void ProcessException(Exception e)
        {
            QQLog.PluginDebugLog(this, e);
        }
        #endregion

        #region 授权检测
        public bool CheckRobotAuthorization()
        {
            uint uiRobotQQ = Client.QQ;
            return true;
        }
        #endregion

        #region 事件处理
        private void SDK_ReceiveClusterIM(object sender, ClusterIMEventArgs e)
        {
            if (e.Cancel)
            {
                OnLog("已被其他插件使用，该插件不再处理");
                return;
            }
            //string messageDisplay = e.SendTime.ToString("yyyy-MM-dd HH:mm:ss:ms") + " " + e.SenderName + "[@QQ](" + e.Sender.ToString() + ")说：" + e.Message;
            //OnLog(messageDisplay);
            //string abc = "[@QQ][头像]\r\n[QQ]，[昵称]，[发送QQ]，[发送昵称]，[机器人QQ]，[机器人昵称]，[随机表情]，[时间]\r\n[var][发送QQ]|[随机表情]|[时间][/var]\r\nヾ(≧O≦)〃嗷~，你说话了！";
            //abc = PluginExtension.ReplaceVariable(e, abc, true);
            //OnLog(abc);
            //SendExtension.SendClusterIM(Client, e.ClusterInfo.ClusterId, abc);
            ClusterInfo clusterInfo = e.ClusterInfo;
            if (!clusterInfo.CanSend || DbHandler.getClusterIsEnabled(clusterInfo.ClusterId.ToString()) != "1")
            {
                OnLog("本群未启用该功能");
                return;
            }
            string message = Regex.Replace(e.Message, "[\f\n\r\t\v\\s+]", "");
            OnLog(message);
            Regex r = new Regex("^查询宝可梦");
            if(r.IsMatch(message))
            {
                int pokeId = r.Replace(message, "").ToInt();
                string strPokeId = pokeId.ToString();
                if(pokeId > 0 && pokeId < 10)
                {
                    strPokeId = "00" + strPokeId;
                }
                else if(pokeId >=10 && pokeId < 100)
                {
                    strPokeId = "0" + strPokeId;
                }
                else if(pokeId > 807 || pokeId <= 0)
                {
                    string sendStr = "请使用 查询宝可梦 宝可梦编号(1-807)";
                    SendExtension.SendClusterIM(Client, e.ClusterInfo.ClusterId, PluginExtension.ReplaceVariable(e, sendStr, true));
                    e.Cancel = true;
                    return;
                }
                string queryString = "select * from pokemonInfo where Sn='" + strPokeId + "';";
                /* 使用IDataReader
                IDataReader dataReader = DbHelper.ExecuteReader(queryString);
                OnLog(queryString);
                OnLog(dataReader.FieldCount.ToString());
                while(dataReader.Read())
                {
                    string Sn = dataReader.GetString(0);
                    string Name = dataReader.GetString(1);
                    string imgUrl = "[Image]" + dataReader.GetString(2) + "[/Image]";
                    string sendStr = imgUrl + "\n宝可梦名字：" + Name + "\n全国图鉴编号：" + Sn;
                    SendExtension.SendClusterIM(Client, e.ClusterInfo.ClusterId, PluginExtension.ReplaceVariable(e, sendStr, true));
                }
                */
                /* dataRow的新建方法
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("AAA");
                dt1.Columns.Add(new DataColumn("BBB", typeof(int)));
                DataRow dr1 = dt1.NewRow();
                dr1["AAA"] = "test";
                dr1["BBB"] = 1;
                */
                /* 使用DataTable */
                DataTable dt = DbHelper.ExecuteQuery(queryString);
                foreach (DataRow row in dt.Rows)
                {
                    string Sn = row["Sn"].ToString();                           //全国图鉴
                    string NameZh = row["NameZh"].ToString();                   //中文名
                    string NameJp = row["NameJp"].ToString();                   //日文名
                    string NameEn = row["NameEn"].ToString();                   //英文名
                    string imgUrl = row["ImgUrl"].ToString();                   //图片Url
                    string Attribute = row["Attribute"].ToString();             //属性
                    string pokeClass = row["Class"].ToString();                 //种类
                    string Feature = row["Feature"].ToString();                 //普通特性
                    string HideFeature = row["HideFeature"].ToString();         //隐藏特性
                    string HP = row["HP"].ToString();                           //种族值HP
                    string Attack = row["Attack"].ToString();                   //种族值攻击
                    string Defense = row["Defense"].ToString();                 //种族值防御
                    string SpecialAttack = row["SpecialAttack"].ToString();     //种族值特攻
                    string SpecialDefense = row["SpecialDefense"].ToString();   //种族值特防
                    string Speed = row["Speed"].ToString();                     //种族值速度
                    string sendStr = "[Image]{0}[/Image]\n" +
                        "宝可梦名字：{1} {2} {3}\n" +
                        "全国图鉴编号：{4}\n属性：{5}\n分类：{6}\n" +
                        "特性：{7}\n隐藏特性：{8}\n" +
                        "种族值：\n" +
                        "HP:{9} 攻击:{10} 防御:{11} 特攻:{12} 特防:{13} 速度:{14}";
                    sendStr = string.Format(sendStr, imgUrl, NameZh, NameJp, NameEn, Sn,
                                            Attribute, pokeClass, Feature, HideFeature,
                                            HP, Attack, Defense, SpecialAttack, SpecialDefense, Speed);
                    SendExtension.SendClusterIM(Client, e.ClusterInfo.ClusterId, PluginExtension.ReplaceVariable(e, sendStr, true));
                }
                e.Cancel = true;
                return;
            }
        }
        #endregion

        #region 功能处理
        /// <summary>
        /// 替换宝可梦相关的参数
        /// </summary>
        /// <param name="strSrc"></param>
        /// <param name="varRow"></param>
        /// <returns></returns>
        public string ReplacePokemonVariable(string strSrc, DataRow varRow)
        {
            string strRet = strSrc;
            DataColumnCollection varDtCol = varRow.Table.Columns;

            strRet = strRet.Replace("[Sn]", varDtCol.Contains("Sn") ? varRow["Sn"].ToString() : "");
            strRet = strRet.Replace("[NameZh]", varDtCol.Contains("NameZh") ? varRow["NameZh"].ToString() : "");
            strRet = strRet.Replace("[NameJp]", varDtCol.Contains("NameJp") ? varRow["NameJp"].ToString() : "");
            strRet = strRet.Replace("[NameEn]", varDtCol.Contains("NameEn")? varRow["NameEn"].ToString() : "");
            strRet = strRet.Replace("[ImgUrl]", varDtCol.Contains("ImgUrl") ? varRow["ImgUrl"].ToString() : "");
            strRet = strRet.Replace("[Attribute]", varDtCol.Contains("Attribute") ? varRow["Attribute"].ToString() : "");
            strRet = strRet.Replace("[Class]", varDtCol.Contains("Class") ? varRow["Class"].ToString() : "");
            strRet = strRet.Replace("[Feature]", varDtCol.Contains("Feature") ? varRow["Feature"].ToString() : "");
            strRet = strRet.Replace("[HideFeature]", varDtCol.Contains("HideFeature") ? varRow["HideFeature"].ToString() : "");
            strRet = strRet.Replace("[HP]", varDtCol.Contains("HP") ? varRow["HP"].ToString() : "");
            strRet = strRet.Replace("[Attack]", varDtCol.Contains("Attack") ? varRow["Attack"].ToString() : "");
            strRet = strRet.Replace("[Defense]", varDtCol.Contains("Defense") ? varRow["Defense"].ToString() : "");
            strRet = strRet.Replace("[SpecialAttack]", varDtCol.Contains("SpecialAttack") ? varRow["SpecialAttack"].ToString() : "");
            strRet = strRet.Replace("[SpecialDefense]", varDtCol.Contains("SpecialDefense") ? varRow["SpecialDefense"].ToString() : "");
            strRet = strRet.Replace("[Speed]", varDtCol.Contains("Speed") ? varRow["Speed"].ToString() : "");

            return strRet;
        }
        #endregion
    }
}
