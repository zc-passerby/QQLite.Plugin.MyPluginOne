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
            this.chCmdInstruct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCmdCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRespKeyInstruct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRespValueWord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRespParamsParam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRespParamsIllustrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_ClusterList = new System.Windows.Forms.TabPage();
            this.listView_clusterList = new System.Windows.Forms.ListView();
            this.tab_CmdSetting = new System.Windows.Forms.TabPage();
            this.gB_modifyCmd = new System.Windows.Forms.GroupBox();
            this.button_cmdSave = new System.Windows.Forms.Button();
            this.button_cmdDefault = new System.Windows.Forms.Button();
            this.cB_softManager = new System.Windows.Forms.CheckBox();
            this.cB_clusterOwner = new System.Windows.Forms.CheckBox();
            this.cB_clusterManager = new System.Windows.Forms.CheckBox();
            this.cB_ChargeQQ = new System.Windows.Forms.CheckBox();
            this.cB_friend = new System.Windows.Forms.CheckBox();
            this.cB_tempConv = new System.Windows.Forms.CheckBox();
            this.cB_cluster = new System.Windows.Forms.CheckBox();
            this.cB_discuss = new System.Windows.Forms.CheckBox();
            this.cB_members = new System.Windows.Forms.CheckBox();
            this.tB_illustrate = new System.Windows.Forms.TextBox();
            this.tB_example = new System.Windows.Forms.TextBox();
            this.tB_command = new System.Windows.Forms.TextBox();
            this.lable_instruct = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lV_cmdList = new System.Windows.Forms.ListView();
            this.tab_RespSetting = new System.Windows.Forms.TabPage();
            this.gB_respSetting = new System.Windows.Forms.GroupBox();
            this.button_respSave = new System.Windows.Forms.Button();
            this.button_respDefault = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tB_respMessage = new System.Windows.Forms.TextBox();
            this.lV_respParams = new System.Windows.Forms.ListView();
            this.lV_respValue = new System.Windows.Forms.ListView();
            this.lV_respKey = new System.Windows.Forms.ListView();
            this.tabControl1.SuspendLayout();
            this.tab_ClusterList.SuspendLayout();
            this.tab_CmdSetting.SuspendLayout();
            this.gB_modifyCmd.SuspendLayout();
            this.tab_RespSetting.SuspendLayout();
            this.gB_respSetting.SuspendLayout();
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
            // chCmdInstruct
            // 
            this.chCmdInstruct.Text = "指令";
            this.chCmdInstruct.Width = 160;
            // 
            // chCmdCommand
            // 
            this.chCmdCommand.Text = "命令";
            this.chCmdCommand.Width = 160;
            // 
            // chRespKeyInstruct
            // 
            this.chRespKeyInstruct.Text = "指令";
            this.chRespKeyInstruct.Width = 135;
            // 
            // chRespValueWord
            // 
            this.chRespValueWord.Text = "回复语";
            this.chRespValueWord.Width = 135;
            // 
            // chRespParamsParam
            // 
            this.chRespParamsParam.Text = "参数";
            this.chRespParamsParam.Width = 175;
            // 
            // chRespParamsIllustrate
            // 
            this.chRespParamsIllustrate.Text = "说明";
            this.chRespParamsIllustrate.Width = 239;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_ClusterList);
            this.tabControl1.Controls.Add(this.tab_CmdSetting);
            this.tabControl1.Controls.Add(this.tab_RespSetting);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(773, 449);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_ClusterList
            // 
            this.tab_ClusterList.Controls.Add(this.listView_clusterList);
            this.tab_ClusterList.Location = new System.Drawing.Point(4, 22);
            this.tab_ClusterList.Name = "tab_ClusterList";
            this.tab_ClusterList.Padding = new System.Windows.Forms.Padding(3);
            this.tab_ClusterList.Size = new System.Drawing.Size(765, 423);
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
            this.listView_clusterList.Size = new System.Drawing.Size(240, 411);
            this.listView_clusterList.TabIndex = 0;
            this.listView_clusterList.UseCompatibleStateImageBehavior = false;
            this.listView_clusterList.View = System.Windows.Forms.View.Details;
            this.listView_clusterList.DoubleClick += new System.EventHandler(this.listView_clusterList_DoubleClick);
            // 
            // tab_CmdSetting
            // 
            this.tab_CmdSetting.Controls.Add(this.gB_modifyCmd);
            this.tab_CmdSetting.Controls.Add(this.lV_cmdList);
            this.tab_CmdSetting.Location = new System.Drawing.Point(4, 22);
            this.tab_CmdSetting.Name = "tab_CmdSetting";
            this.tab_CmdSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tab_CmdSetting.Size = new System.Drawing.Size(765, 423);
            this.tab_CmdSetting.TabIndex = 1;
            this.tab_CmdSetting.Text = "命令语设置";
            this.tab_CmdSetting.UseVisualStyleBackColor = true;
            // 
            // gB_modifyCmd
            // 
            this.gB_modifyCmd.Controls.Add(this.button_cmdSave);
            this.gB_modifyCmd.Controls.Add(this.button_cmdDefault);
            this.gB_modifyCmd.Controls.Add(this.cB_softManager);
            this.gB_modifyCmd.Controls.Add(this.cB_clusterOwner);
            this.gB_modifyCmd.Controls.Add(this.cB_clusterManager);
            this.gB_modifyCmd.Controls.Add(this.cB_ChargeQQ);
            this.gB_modifyCmd.Controls.Add(this.cB_friend);
            this.gB_modifyCmd.Controls.Add(this.cB_tempConv);
            this.gB_modifyCmd.Controls.Add(this.cB_cluster);
            this.gB_modifyCmd.Controls.Add(this.cB_discuss);
            this.gB_modifyCmd.Controls.Add(this.cB_members);
            this.gB_modifyCmd.Controls.Add(this.tB_illustrate);
            this.gB_modifyCmd.Controls.Add(this.tB_example);
            this.gB_modifyCmd.Controls.Add(this.tB_command);
            this.gB_modifyCmd.Controls.Add(this.lable_instruct);
            this.gB_modifyCmd.Controls.Add(this.label6);
            this.gB_modifyCmd.Controls.Add(this.label5);
            this.gB_modifyCmd.Controls.Add(this.label4);
            this.gB_modifyCmd.Controls.Add(this.label3);
            this.gB_modifyCmd.Controls.Add(this.label2);
            this.gB_modifyCmd.Controls.Add(this.label1);
            this.gB_modifyCmd.Location = new System.Drawing.Point(354, 12);
            this.gB_modifyCmd.Name = "gB_modifyCmd";
            this.gB_modifyCmd.Size = new System.Drawing.Size(396, 392);
            this.gB_modifyCmd.TabIndex = 1;
            this.gB_modifyCmd.TabStop = false;
            this.gB_modifyCmd.Text = "修改命令";
            // 
            // button_cmdSave
            // 
            this.button_cmdSave.Location = new System.Drawing.Point(245, 352);
            this.button_cmdSave.Name = "button_cmdSave";
            this.button_cmdSave.Size = new System.Drawing.Size(75, 23);
            this.button_cmdSave.TabIndex = 29;
            this.button_cmdSave.Text = "保存";
            this.button_cmdSave.UseVisualStyleBackColor = true;
            this.button_cmdSave.Click += new System.EventHandler(this.button_cmdSave_Click);
            // 
            // button_cmdDefault
            // 
            this.button_cmdDefault.Location = new System.Drawing.Point(95, 352);
            this.button_cmdDefault.Name = "button_cmdDefault";
            this.button_cmdDefault.Size = new System.Drawing.Size(75, 23);
            this.button_cmdDefault.TabIndex = 28;
            this.button_cmdDefault.Text = "默认值";
            this.button_cmdDefault.UseVisualStyleBackColor = true;
            this.button_cmdDefault.Click += new System.EventHandler(this.button_cmdDefault_Click);
            // 
            // cB_softManager
            // 
            this.cB_softManager.AutoSize = true;
            this.cB_softManager.Location = new System.Drawing.Point(190, 252);
            this.cB_softManager.Name = "cB_softManager";
            this.cB_softManager.Size = new System.Drawing.Size(84, 16);
            this.cB_softManager.TabIndex = 27;
            this.cB_softManager.Text = "软件管理员";
            this.cB_softManager.UseVisualStyleBackColor = true;
            // 
            // cB_clusterOwner
            // 
            this.cB_clusterOwner.AutoSize = true;
            this.cB_clusterOwner.Location = new System.Drawing.Point(74, 274);
            this.cB_clusterOwner.Name = "cB_clusterOwner";
            this.cB_clusterOwner.Size = new System.Drawing.Size(48, 16);
            this.cB_clusterOwner.TabIndex = 26;
            this.cB_clusterOwner.Text = "群主";
            this.cB_clusterOwner.UseVisualStyleBackColor = true;
            // 
            // cB_clusterManager
            // 
            this.cB_clusterManager.AutoSize = true;
            this.cB_clusterManager.Location = new System.Drawing.Point(129, 274);
            this.cB_clusterManager.Name = "cB_clusterManager";
            this.cB_clusterManager.Size = new System.Drawing.Size(120, 16);
            this.cB_clusterManager.TabIndex = 25;
            this.cB_clusterManager.Text = "群管理员(自定义)";
            this.cB_clusterManager.UseVisualStyleBackColor = true;
            // 
            // cB_ChargeQQ
            // 
            this.cB_ChargeQQ.AutoSize = true;
            this.cB_ChargeQQ.Location = new System.Drawing.Point(255, 274);
            this.cB_ChargeQQ.Name = "cB_ChargeQQ";
            this.cB_ChargeQQ.Size = new System.Drawing.Size(108, 16);
            this.cB_ChargeQQ.TabIndex = 24;
            this.cB_ChargeQQ.Text = "负责人QQ(插件)";
            this.cB_ChargeQQ.UseVisualStyleBackColor = true;
            // 
            // cB_friend
            // 
            this.cB_friend.AutoSize = true;
            this.cB_friend.Location = new System.Drawing.Point(74, 312);
            this.cB_friend.Name = "cB_friend";
            this.cB_friend.Size = new System.Drawing.Size(48, 16);
            this.cB_friend.TabIndex = 23;
            this.cB_friend.Text = "好友";
            this.cB_friend.UseVisualStyleBackColor = true;
            // 
            // cB_tempConv
            // 
            this.cB_tempConv.AutoSize = true;
            this.cB_tempConv.Location = new System.Drawing.Point(136, 313);
            this.cB_tempConv.Name = "cB_tempConv";
            this.cB_tempConv.Size = new System.Drawing.Size(72, 16);
            this.cB_tempConv.TabIndex = 22;
            this.cB_tempConv.Text = "临时会话";
            this.cB_tempConv.UseVisualStyleBackColor = true;
            // 
            // cB_cluster
            // 
            this.cB_cluster.AutoSize = true;
            this.cB_cluster.Location = new System.Drawing.Point(228, 312);
            this.cB_cluster.Name = "cB_cluster";
            this.cB_cluster.Size = new System.Drawing.Size(36, 16);
            this.cB_cluster.TabIndex = 21;
            this.cB_cluster.Text = "群";
            this.cB_cluster.UseVisualStyleBackColor = true;
            // 
            // cB_discuss
            // 
            this.cB_discuss.AutoSize = true;
            this.cB_discuss.Location = new System.Drawing.Point(286, 312);
            this.cB_discuss.Name = "cB_discuss";
            this.cB_discuss.Size = new System.Drawing.Size(60, 16);
            this.cB_discuss.TabIndex = 20;
            this.cB_discuss.Text = "讨论组";
            this.cB_discuss.UseVisualStyleBackColor = true;
            // 
            // cB_members
            // 
            this.cB_members.AutoSize = true;
            this.cB_members.Location = new System.Drawing.Point(74, 252);
            this.cB_members.Name = "cB_members";
            this.cB_members.Size = new System.Drawing.Size(96, 16);
            this.cB_members.TabIndex = 19;
            this.cB_members.Text = "好友、群成员";
            this.cB_members.UseVisualStyleBackColor = true;
            // 
            // tB_illustrate
            // 
            this.tB_illustrate.Location = new System.Drawing.Point(74, 190);
            this.tB_illustrate.Multiline = true;
            this.tB_illustrate.Name = "tB_illustrate";
            this.tB_illustrate.ReadOnly = true;
            this.tB_illustrate.Size = new System.Drawing.Size(289, 48);
            this.tB_illustrate.TabIndex = 9;
            // 
            // tB_example
            // 
            this.tB_example.Location = new System.Drawing.Point(74, 135);
            this.tB_example.Multiline = true;
            this.tB_example.Name = "tB_example";
            this.tB_example.ReadOnly = true;
            this.tB_example.Size = new System.Drawing.Size(289, 49);
            this.tB_example.TabIndex = 8;
            // 
            // tB_command
            // 
            this.tB_command.Location = new System.Drawing.Point(74, 49);
            this.tB_command.Multiline = true;
            this.tB_command.Name = "tB_command";
            this.tB_command.Size = new System.Drawing.Size(184, 80);
            this.tB_command.TabIndex = 7;
            // 
            // lable_instruct
            // 
            this.lable_instruct.AutoSize = true;
            this.lable_instruct.Location = new System.Drawing.Point(74, 25);
            this.lable_instruct.Name = "lable_instruct";
            this.lable_instruct.Size = new System.Drawing.Size(41, 12);
            this.lable_instruct.TabIndex = 6;
            this.lable_instruct.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "说明：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "会话：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "权限：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "示例：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "命令：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "指令：";
            // 
            // lV_cmdList
            // 
            this.lV_cmdList.AllowColumnReorder = true;
            this.lV_cmdList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCmdInstruct,
            this.chCmdCommand});
            this.lV_cmdList.FullRowSelect = true;
            this.lV_cmdList.GridLines = true;
            this.lV_cmdList.Location = new System.Drawing.Point(16, 19);
            this.lV_cmdList.MultiSelect = false;
            this.lV_cmdList.Name = "lV_cmdList";
            this.lV_cmdList.Size = new System.Drawing.Size(332, 385);
            this.lV_cmdList.TabIndex = 0;
            this.lV_cmdList.UseCompatibleStateImageBehavior = false;
            this.lV_cmdList.View = System.Windows.Forms.View.Details;
            this.lV_cmdList.SelectedIndexChanged += new System.EventHandler(this.lV_cmdList_SelectedIndexChanged);
            this.lV_cmdList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lV_cmdList_MouseDown);
            // 
            // tab_RespSetting
            // 
            this.tab_RespSetting.Controls.Add(this.gB_respSetting);
            this.tab_RespSetting.Controls.Add(this.lV_respValue);
            this.tab_RespSetting.Controls.Add(this.lV_respKey);
            this.tab_RespSetting.Location = new System.Drawing.Point(4, 22);
            this.tab_RespSetting.Name = "tab_RespSetting";
            this.tab_RespSetting.Size = new System.Drawing.Size(765, 423);
            this.tab_RespSetting.TabIndex = 2;
            this.tab_RespSetting.Text = "回复语设置";
            this.tab_RespSetting.UseVisualStyleBackColor = true;
            // 
            // gB_respSetting
            // 
            this.gB_respSetting.Controls.Add(this.button_respSave);
            this.gB_respSetting.Controls.Add(this.button_respDefault);
            this.gB_respSetting.Controls.Add(this.label7);
            this.gB_respSetting.Controls.Add(this.tB_respMessage);
            this.gB_respSetting.Controls.Add(this.lV_respParams);
            this.gB_respSetting.Location = new System.Drawing.Point(314, 12);
            this.gB_respSetting.Name = "gB_respSetting";
            this.gB_respSetting.Size = new System.Drawing.Size(438, 398);
            this.gB_respSetting.TabIndex = 2;
            this.gB_respSetting.TabStop = false;
            this.gB_respSetting.Text = "修改回复语";
            // 
            // button_respSave
            // 
            this.button_respSave.Location = new System.Drawing.Point(346, 369);
            this.button_respSave.Name = "button_respSave";
            this.button_respSave.Size = new System.Drawing.Size(75, 23);
            this.button_respSave.TabIndex = 4;
            this.button_respSave.Text = "保存";
            this.button_respSave.UseVisualStyleBackColor = true;
            // 
            // button_respDefault
            // 
            this.button_respDefault.Location = new System.Drawing.Point(249, 369);
            this.button_respDefault.Name = "button_respDefault";
            this.button_respDefault.Size = new System.Drawing.Size(75, 23);
            this.button_respDefault.TabIndex = 3;
            this.button_respDefault.Text = "默认值";
            this.button_respDefault.UseVisualStyleBackColor = true;
            this.button_respDefault.Click += new System.EventHandler(this.button_respDefault_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 374);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "双击参数可以自动插入！";
            // 
            // tB_respMessage
            // 
            this.tB_respMessage.Location = new System.Drawing.Point(6, 169);
            this.tB_respMessage.Multiline = true;
            this.tB_respMessage.Name = "tB_respMessage";
            this.tB_respMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB_respMessage.Size = new System.Drawing.Size(426, 197);
            this.tB_respMessage.TabIndex = 1;
            // 
            // lV_respParams
            // 
            this.lV_respParams.AllowColumnReorder = true;
            this.lV_respParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chRespParamsParam,
            this.chRespParamsIllustrate});
            this.lV_respParams.FullRowSelect = true;
            this.lV_respParams.GridLines = true;
            this.lV_respParams.Location = new System.Drawing.Point(6, 20);
            this.lV_respParams.Name = "lV_respParams";
            this.lV_respParams.Size = new System.Drawing.Size(426, 143);
            this.lV_respParams.TabIndex = 0;
            this.lV_respParams.UseCompatibleStateImageBehavior = false;
            this.lV_respParams.View = System.Windows.Forms.View.Details;
            this.lV_respParams.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lV_respParams_MouseDoubleClick);
            // 
            // lV_respValue
            // 
            this.lV_respValue.AllowColumnReorder = true;
            this.lV_respValue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chRespValueWord});
            this.lV_respValue.FullRowSelect = true;
            this.lV_respValue.GridLines = true;
            this.lV_respValue.Location = new System.Drawing.Point(163, 12);
            this.lV_respValue.MultiSelect = false;
            this.lV_respValue.Name = "lV_respValue";
            this.lV_respValue.Size = new System.Drawing.Size(145, 398);
            this.lV_respValue.TabIndex = 1;
            this.lV_respValue.UseCompatibleStateImageBehavior = false;
            this.lV_respValue.View = System.Windows.Forms.View.Details;
            this.lV_respValue.SelectedIndexChanged += new System.EventHandler(this.lV_respValue_SelectedIndexChanged);
            this.lV_respValue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lV_respValue_MouseDown);
            // 
            // lV_respKey
            // 
            this.lV_respKey.AllowColumnReorder = true;
            this.lV_respKey.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chRespKeyInstruct});
            this.lV_respKey.FullRowSelect = true;
            this.lV_respKey.GridLines = true;
            this.lV_respKey.Location = new System.Drawing.Point(12, 12);
            this.lV_respKey.MultiSelect = false;
            this.lV_respKey.Name = "lV_respKey";
            this.lV_respKey.Size = new System.Drawing.Size(145, 398);
            this.lV_respKey.TabIndex = 0;
            this.lV_respKey.UseCompatibleStateImageBehavior = false;
            this.lV_respKey.View = System.Windows.Forms.View.Details;
            this.lV_respKey.SelectedIndexChanged += new System.EventHandler(this.lV_respKey_SelectedIndexChanged);
            this.lV_respKey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lV_respKey_MouseDown);
            // 
            // settingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 473);
            this.Controls.Add(this.tabControl1);
            this.Name = "settingForm";
            this.Text = "插件设置";
            this.tabControl1.ResumeLayout(false);
            this.tab_ClusterList.ResumeLayout(false);
            this.tab_CmdSetting.ResumeLayout(false);
            this.gB_modifyCmd.ResumeLayout(false);
            this.gB_modifyCmd.PerformLayout();
            this.tab_RespSetting.ResumeLayout(false);
            this.gB_respSetting.ResumeLayout(false);
            this.gB_respSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tab_ClusterList;
        private System.Windows.Forms.TabPage tab_CmdSetting;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_RespSetting;
        private System.Windows.Forms.ListView listView_clusterList;
        private GroupBox gB_modifyCmd;
        private ListView lV_cmdList;
        private Label label1;
        private CheckBox cB_softManager;
        private CheckBox cB_clusterOwner;
        private CheckBox cB_clusterManager;
        private CheckBox cB_ChargeQQ;
        private CheckBox cB_friend;
        private CheckBox cB_tempConv;
        private CheckBox cB_cluster;
        private CheckBox cB_discuss;
        private CheckBox cB_members;
        private TextBox tB_illustrate;
        private TextBox tB_example;
        private TextBox tB_command;
        private Label lable_instruct;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button button_cmdSave;
        private Button button_cmdDefault;
        private GroupBox gB_respSetting;
        private Button button_respSave;
        private Button button_respDefault;
        private Label label7;
        private TextBox tB_respMessage;
        private ListView lV_respParams;
        private ListView lV_respValue;
        private ListView lV_respKey;

        //ListView列名 begin
        private System.Windows.Forms.ColumnHeader chCulsterId;
        private System.Windows.Forms.ColumnHeader chClusterName;
        private System.Windows.Forms.ColumnHeader chClusterSwitch;
        private System.Windows.Forms.ColumnHeader chCmdInstruct;
        private System.Windows.Forms.ColumnHeader chCmdCommand;
        private System.Windows.Forms.ColumnHeader chRespKeyInstruct;
        private System.Windows.Forms.ColumnHeader chRespValueWord;
        private System.Windows.Forms.ColumnHeader chRespParamsParam;
        private System.Windows.Forms.ColumnHeader chRespParamsIllustrate;
        //ListView列名 end
    }
}