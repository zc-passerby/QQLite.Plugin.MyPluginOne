using System;
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
            string SelectSql = "select IsEnabled from GroupConfig where GroupId='" + clusterId + "';";
            object clusterSwitch = DbHelper.ExecuteScalar(SelectSql);
            if(null != clusterSwitch)
            {
                string updateSql = "update GroupConfig set IsEnabled={0} where GroupId='{1}';";
                if (clusterSwitch.ToString() == "0")
                {
                    updateSql = string.Format(updateSql, 1, clusterId);
                    item.SubItems[2].Text = "开";
                }
                else
                {
                    updateSql = string.Format(updateSql, 0, clusterId);
                    item.SubItems[2].Text = "关";
                }
                if (DbHelper.ExecuteNonQuery(updateSql) != 1)
                {
                    Plugin.OnLog("update Failed...");
                }
            }
            else
            {
                string insertSql = "insert into GroupConfig (GroupId,IsEnabled) values('{0}',{1});";
                if (clusterId == "0" || clusterId == "10000")
                {
                    insertSql = string.Format(insertSql, clusterId, 0);
                    item.SubItems[2].Text = "关";
                }
                else
                {
                    insertSql = string.Format(insertSql, clusterId, 1);
                    item.SubItems[2].Text = "开";
                }
                if (DbHelper.ExecuteNonQuery(insertSql) != 1)
                {
                    Plugin.OnLog("insert Failed...");
                }
            }
        }
    }
}
