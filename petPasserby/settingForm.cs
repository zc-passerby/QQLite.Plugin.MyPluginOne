using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            lvi = new ListViewItem("0");
            lvi.SubItems.Add("好友设置");
            lvi.SubItems.Add("开");
            lvi = listView_clusterList.Items.Add(lvi);
            lvi = new ListViewItem("10000");
            lvi.SubItems.Add("默认群设置");
            lvi.SubItems.Add("开");
            lvi = listView_clusterList.Items.Add(lvi);
            //获取群列表
            ClusterList clusterlist = Plugin.Client.ClusterList;
            foreach(KeyValuePair<uint, ClusterInfo> kv in clusterlist)
            {
                ClusterInfo c = kv.Value;
                lvi = new ListViewItem(c.ClusterId.ToString());
                lvi.SubItems.Add(c.Name);
                lvi.SubItems.Add("关");
                lvi = listView_clusterList.Items.Add(lvi);
            }
        }

        private void listView_clusterList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
