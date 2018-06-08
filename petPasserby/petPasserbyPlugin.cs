using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QQLite.Framework;
using QQLite.Framework.Event;
using QQLite.Framework.QQEnum;
using QQLite.Framework.SDK;
using QQLite.Framework.Tool;

namespace petPasserby
{
    public class petPasserbyPlugin : QQLite.Framework.SDK.Plugin
    {
        public petPasserbyPlugin()
        {
            //插件名
            this.PluginName = "口袋精灵2";
            //插件简介
            this.Description = "口袋精灵2群聊版";
            //插件说明
            this.Note = "口袋精灵2群聊版";
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

            this.SDK = new QQClientSDK();

            #region 事件订阅
            this.SDK.ReceiveClusterIM += SDK_ReceiveClusterIM; ;
            #endregion

            return null;
        }

        /// <summary>停止运行插件</summary>
        /// <returns>null：停止插件成功，string：错误信息</returns>
        public override string Stop()
        {
            return null;
        }

        /// <summary>显示插件窗体</summary>
        /// <returns>null：显示窗口成功，string：错误信息</returns>
        public override string ShowForm()
        {
            new settingForm(this).ShowDialog();
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
            throw new NotImplementedException();
        }
        #endregion
    }
}
