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
            //获取群列表
            ClusterList clusterlist = Plugin.Client.ClusterList;
            foreach(KeyValuePair<uint, ClusterInfo> kv in clusterlist)
            {
                ClusterInfo c = kv.Value;
                ListViewItem lvi = listView_clusterList.Items.Add(c.ClusterId.ToString());
                lvi.SubItems.Add(c.Name);
                lvi.SubItems.Add("关");
            }
        }

        private void listView_clusterList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
