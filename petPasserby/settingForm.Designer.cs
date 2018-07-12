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
            this.ClusterList = new System.Windows.Forms.TabPage();
            this.listView_clusterList = new System.Windows.Forms.ListView();
            this.CmdSetting = new System.Windows.Forms.TabPage();
            this.RespSetting = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.ClusterList.SuspendLayout();
            this.SuspendLayout();
            // 
            // chCulsterId
            // 
            this.chCulsterId.Text = "群号";
            // 
            // chClusterName
            // 
            this.chClusterName.Text = "群名称";
            // 
            // chClusterSwitch
            // 
            this.chClusterSwitch.Text = "群开关";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ClusterList);
            this.tabControl1.Controls.Add(this.CmdSetting);
            this.tabControl1.Controls.Add(this.RespSetting);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 416);
            this.tabControl1.TabIndex = 0;
            // 
            // ClusterList
            // 
            this.ClusterList.Controls.Add(this.listView_clusterList);
            this.ClusterList.Location = new System.Drawing.Point(4, 22);
            this.ClusterList.Name = "ClusterList";
            this.ClusterList.Padding = new System.Windows.Forms.Padding(3);
            this.ClusterList.Size = new System.Drawing.Size(570, 390);
            this.ClusterList.TabIndex = 0;
            this.ClusterList.Text = "群列表";
            this.ClusterList.UseVisualStyleBackColor = true;
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
            this.listView_clusterList.Size = new System.Drawing.Size(220, 378);
            this.listView_clusterList.TabIndex = 0;
            this.listView_clusterList.UseCompatibleStateImageBehavior = false;
            this.listView_clusterList.View = System.Windows.Forms.View.Details;
            // 
            // CmdSetting
            // 
            this.CmdSetting.Location = new System.Drawing.Point(4, 22);
            this.CmdSetting.Name = "CmdSetting";
            this.CmdSetting.Padding = new System.Windows.Forms.Padding(3);
            this.CmdSetting.Size = new System.Drawing.Size(570, 390);
            this.CmdSetting.TabIndex = 1;
            this.CmdSetting.Text = "命令语设置";
            this.CmdSetting.UseVisualStyleBackColor = true;
            // 
            // RespSetting
            // 
            this.RespSetting.Location = new System.Drawing.Point(4, 22);
            this.RespSetting.Name = "RespSetting";
            this.RespSetting.Size = new System.Drawing.Size(570, 390);
            this.RespSetting.TabIndex = 2;
            this.RespSetting.Text = "回复语设置";
            this.RespSetting.UseVisualStyleBackColor = true;
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
            this.ClusterList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage ClusterList;
        private System.Windows.Forms.TabPage CmdSetting;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage RespSetting;
        private System.Windows.Forms.ListView listView_clusterList;
        //ListView列名 begin
        private System.Windows.Forms.ColumnHeader chCulsterId;
        private System.Windows.Forms.ColumnHeader chClusterName;
        private System.Windows.Forms.ColumnHeader chClusterSwitch;
        //ListView列名 end
    }
}