﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using QQLite.Framework;
using QQLite.Framework.Dapper;
using QQLite.Framework.Entity;

namespace petPasserby
{
    public partial class settingForm : Form
    {
        public petPasserbyPlugin Plugin { get; set; }
        public settingForm(petPasserbyPlugin plugin)
        {
            InitializeComponent();
            this.Icon = QQLite.Framework.License.SoftIcon;
            this.Plugin = plugin;
            initData();
        }

        private void initData()
        {
            ListViewItem lvi;
            //先添加0（好友设置）和10000（默认群设置）
            string SelectSql = "select IsEnabled from GroupConfig where GroupId='0';";
            object friendSwitch = DbHelper.ExecuteScalar(SelectSql);
            SelectSql = "select IsEnabled from GroupConfig where GroupId='10000';";
            object defaultSwitch = DbHelper.ExecuteScalar(SelectSql);
            lvi = new ListViewItem("0");
            lvi.SubItems.Add("好友设置");
            if (friendSwitch != null && friendSwitch.ToString() == "0")
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
            if(defaultSwitch != null && defaultSwitch.ToString() == "0")
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
                SelectSql = "select IsEnabled from GroupConfig where GroupId='" + clusterId + "';";
                object clusterSwitch = DbHelper.ExecuteScalar(SelectSql);
                lvi = new ListViewItem(clusterId);
                lvi.SubItems.Add(clusterInfo.Name);
                if(null != clusterSwitch && clusterSwitch.ToString() == "1")
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
