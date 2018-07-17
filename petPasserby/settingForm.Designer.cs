using System.Windows.Forms;

namespace petPasserby
{
    partial class settingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chCulsterId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClusterName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClusterSwitch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_ClusterList = new System.Windows.Forms.TabPage();
            this.listView_clusterList = new System.Windows.Forms.ListView();
            this.tab_CmdSetting = new System.Windows.Forms.TabPage();
            this.tab_RespSetting = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tab_ClusterList.SuspendLayout();
            this.SuspendLayout();
            // 
            // chCulsterId
            // 
            this.chCulsterId.Text = "群号";
            this.chCulsterId.Width = 80;
            // 
            // chClusterName
            // 
            this.chClusterName.Text = "群名称";
            this.chClusterName.Width = 80;
            // 
            // chClusterSwitch
            // 
            this.chClusterSwitch.Text = "群开关";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_ClusterList);
            this.tabControl1.Controls.Add(this.tab_CmdSetting);
            this.tabControl1.Controls.Add(this.tab_RespSetting);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 416);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_ClusterList
            // 
            this.tab_ClusterList.Controls.Add(this.listView_clusterList);
            this.tab_ClusterList.Location = new System.Drawing.Point(4, 22);
            this.tab_ClusterList.Name = "tab_ClusterList";
            this.tab_ClusterList.Padding = new System.Windows.Forms.Padding(3);
            this.tab_ClusterList.Size = new System.Drawing.Size(570, 390);
            this.tab_ClusterList.TabIndex = 0;
            this.tab_ClusterList.Text = "群列表";
            this.tab_ClusterList.UseVisualStyleBackColor = true;
            // 
            // listView_clusterList
            // 
            this.listView_clusterList.AllowColumnReorder = true;
            this.listView_clusterList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCulsterId,
            this.chClusterName,
            this.chClusterSwitch});
            this.listView_clusterList.FullRowSelect = true;
            this.listView_clusterList.GridLines = true;
            this.listView_clusterList.Location = new System.Drawing.Point(6, 6);
            this.listView_clusterList.Name = "listView_clusterList";
            this.listView_clusterList.Size = new System.Drawing.Size(240, 378);
            this.listView_clusterList.TabIndex = 0;
            this.listView_clusterList.UseCompatibleStateImageBehavior = false;
            this.listView_clusterList.View = System.Windows.Forms.View.Details;
            this.listView_clusterList.DoubleClick += new System.EventHandler(this.listView_clusterList_DoubleClick);
            // 
            // tab_CmdSetting
            // 
            this.tab_CmdSetting.Location = new System.Drawing.Point(4, 22);
            this.tab_CmdSetting.Name = "tab_CmdSetting";
            this.tab_CmdSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tab_CmdSetting.Size = new System.Drawing.Size(570, 390);
            this.tab_CmdSetting.TabIndex = 1;
            this.tab_CmdSetting.Text = "命令语设置";
            this.tab_CmdSetting.UseVisualStyleBackColor = true;
            // 
            // tab_RespSetting
            // 
            this.tab_RespSetting.Location = new System.Drawing.Point(4, 22);
            this.tab_RespSetting.Name = "tab_RespSetting";
            this.tab_RespSetting.Size = new System.Drawing.Size(570, 390);
            this.tab_RespSetting.TabIndex = 2;
            this.tab_RespSetting.Text = "回复语设置";
            this.tab_RespSetting.UseVisualStyleBackColor = true;
            // 
            // settingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 440);
            this.Controls.Add(this.tabControl1);
            this.Name = "settingForm";
            this.Text = "插件设置";
            this.tabControl1.ResumeLayout(false);
            this.tab_ClusterList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tab_ClusterList;
        private System.Windows.Forms.TabPage tab_CmdSetting;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_RespSetting;
        private System.Windows.Forms.ListView listView_clusterList;
        //ListView列名 begin
        private System.Windows.Forms.ColumnHeader chCulsterId;
        private System.Windows.Forms.ColumnHeader chClusterName;
        private System.Windows.Forms.ColumnHeader chClusterSwitch;
        //ListView列名 end
    }
}