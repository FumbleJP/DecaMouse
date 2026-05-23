namespace DecaMouse
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this._tbCooldownX = new System.Windows.Forms.TrackBar();
			this._tbDistanceX = new System.Windows.Forms.TrackBar();
			this._tbDirectionChangeX = new System.Windows.Forms.TrackBar();
			this._timSampling = new System.Windows.Forms.Timer(this.components);
			this._tcSettings = new System.Windows.Forms.TabControl();
			this._tpSettingsX = new System.Windows.Forms.TabPage();
			this._grpActionX = new System.Windows.Forms.GroupBox();
			this._radBigMouseX = new System.Windows.Forms.RadioButton();
			this._radCenterMouseX = new System.Windows.Forms.RadioButton();
			this._radNoneX = new System.Windows.Forms.RadioButton();
			this._grpSettingsX = new System.Windows.Forms.GroupBox();
			this._lblCooldownX = new System.Windows.Forms.Label();
			this._lblCooldownXL = new System.Windows.Forms.Label();
			this._lblCooldownXR = new System.Windows.Forms.Label();
			this._lblDistanceX = new System.Windows.Forms.Label();
			this._lblDistanceXL = new System.Windows.Forms.Label();
			this._lblDistanceXR = new System.Windows.Forms.Label();
			this._lblDirectionChangeX = new System.Windows.Forms.Label();
			this._lblDirectionChangeXL = new System.Windows.Forms.Label();
			this._lblDirectionChangeXR = new System.Windows.Forms.Label();
			this.tpSettingsY = new System.Windows.Forms.TabPage();
			this._grpActionY = new System.Windows.Forms.GroupBox();
			this._radBigMouseY = new System.Windows.Forms.RadioButton();
			this._radCenterMouseY = new System.Windows.Forms.RadioButton();
			this._radNoneY = new System.Windows.Forms.RadioButton();
			this._grpSettingsY = new System.Windows.Forms.GroupBox();
			this._lblCooldownY = new System.Windows.Forms.Label();
			this._lblCooldownYL = new System.Windows.Forms.Label();
			this._tbCooldownY = new System.Windows.Forms.TrackBar();
			this._lblCooldownYR = new System.Windows.Forms.Label();
			this._lblDistanceY = new System.Windows.Forms.Label();
			this._lblDistanceYL = new System.Windows.Forms.Label();
			this._tbDistanceY = new System.Windows.Forms.TrackBar();
			this._lblDistanceYR = new System.Windows.Forms.Label();
			this._lblDirectionChangeY = new System.Windows.Forms.Label();
			this._lblDirectionChangeYL = new System.Windows.Forms.Label();
			this._tbDirectionChangeY = new System.Windows.Forms.TrackBar();
			this._lblDirectionChangeYR = new System.Windows.Forms.Label();
			this._tbIncrease = new System.Windows.Forms.TrackBar();
			this._lblBigMouse = new System.Windows.Forms.Label();
			this._lblBigMouseL = new System.Windows.Forms.Label();
			this._lblBigMouseR = new System.Windows.Forms.Label();
			this._lblCheckX = new System.Windows.Forms.Label();
			this._lblCheckY = new System.Windows.Forms.Label();
			this._lblValueX = new System.Windows.Forms.Label();
			this._lblValueY = new System.Windows.Forms.Label();
			this._lblApplicationTitle = new System.Windows.Forms.Label();
			this._lblApplicationVersion = new System.Windows.Forms.Label();
			this._lblApplicationCopyright = new System.Windows.Forms.Label();
			this._grpMouseSettings = new System.Windows.Forms.GroupBox();
			this._chkAutoExec = new System.Windows.Forms.CheckBox();
			this._niTray = new System.Windows.Forms.NotifyIcon(this.components);
			this._cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
			this._tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this._tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this._tbCooldownX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbDistanceX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbDirectionChangeX)).BeginInit();
			this._tcSettings.SuspendLayout();
			this._tpSettingsX.SuspendLayout();
			this._grpActionX.SuspendLayout();
			this._grpSettingsX.SuspendLayout();
			this.tpSettingsY.SuspendLayout();
			this._grpActionY.SuspendLayout();
			this._grpSettingsY.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._tbCooldownY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbDistanceY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbDirectionChangeY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbIncrease)).BeginInit();
			this._grpMouseSettings.SuspendLayout();
			this._cmsTray.SuspendLayout();
			this.SuspendLayout();
			// 
			// _tbCooldownX
			// 
			resources.ApplyResources(this._tbCooldownX, "_tbCooldownX");
			this._tbCooldownX.Maximum = 100;
			this._tbCooldownX.Minimum = 20;
			this._tbCooldownX.Name = "_tbCooldownX";
			this._tbCooldownX.TickFrequency = 0;
			this._tbCooldownX.TickStyle = System.Windows.Forms.TickStyle.None;
			this._tbCooldownX.Value = 20;
			this._tbCooldownX.Scroll += new System.EventHandler(this._tbCooldown_Scroll);
			// 
			// _tbDistanceX
			// 
			resources.ApplyResources(this._tbDistanceX, "_tbDistanceX");
			this._tbDistanceX.Maximum = 100;
			this._tbDistanceX.Minimum = 5;
			this._tbDistanceX.Name = "_tbDistanceX";
			this._tbDistanceX.TickFrequency = 0;
			this._tbDistanceX.TickStyle = System.Windows.Forms.TickStyle.None;
			this._tbDistanceX.Value = 5;
			this._tbDistanceX.Scroll += new System.EventHandler(this._tbDistance_Scroll);
			// 
			// _tbDirectionChangeX
			// 
			resources.ApplyResources(this._tbDirectionChangeX, "_tbDirectionChangeX");
			this._tbDirectionChangeX.LargeChange = 1;
			this._tbDirectionChangeX.Maximum = 20;
			this._tbDirectionChangeX.Minimum = 1;
			this._tbDirectionChangeX.Name = "_tbDirectionChangeX";
			this._tbDirectionChangeX.TickFrequency = 0;
			this._tbDirectionChangeX.TickStyle = System.Windows.Forms.TickStyle.None;
			this._tbDirectionChangeX.Value = 1;
			this._tbDirectionChangeX.Scroll += new System.EventHandler(this._tbDirectionChange_Scroll);
			// 
			// _timSampling
			// 
			this._timSampling.Interval = 20;
			this._timSampling.Tick += new System.EventHandler(this._timSample_Tick);
			// 
			// _tcSettings
			// 
			resources.ApplyResources(this._tcSettings, "_tcSettings");
			this._tcSettings.Controls.Add(this._tpSettingsX);
			this._tcSettings.Controls.Add(this.tpSettingsY);
			this._tcSettings.Name = "_tcSettings";
			this._tcSettings.SelectedIndex = 0;
			// 
			// _tpSettingsX
			// 
			resources.ApplyResources(this._tpSettingsX, "_tpSettingsX");
			this._tpSettingsX.Controls.Add(this._grpActionX);
			this._tpSettingsX.Controls.Add(this._grpSettingsX);
			this._tpSettingsX.Name = "_tpSettingsX";
			this._tpSettingsX.UseVisualStyleBackColor = true;
			// 
			// _grpActionX
			// 
			resources.ApplyResources(this._grpActionX, "_grpActionX");
			this._grpActionX.Controls.Add(this._radBigMouseX);
			this._grpActionX.Controls.Add(this._radCenterMouseX);
			this._grpActionX.Controls.Add(this._radNoneX);
			this._grpActionX.Name = "_grpActionX";
			this._grpActionX.TabStop = false;
			// 
			// _radBigMouseX
			// 
			resources.ApplyResources(this._radBigMouseX, "_radBigMouseX");
			this._radBigMouseX.Name = "_radBigMouseX";
			this._radBigMouseX.TabStop = true;
			this._radBigMouseX.UseVisualStyleBackColor = true;
			this._radBigMouseX.CheckedChanged += new System.EventHandler(this._radBigMouseX_CheckedChanged);
			// 
			// _radCenterMouseX
			// 
			resources.ApplyResources(this._radCenterMouseX, "_radCenterMouseX");
			this._radCenterMouseX.Name = "_radCenterMouseX";
			this._radCenterMouseX.TabStop = true;
			this._radCenterMouseX.UseVisualStyleBackColor = true;
			this._radCenterMouseX.CheckedChanged += new System.EventHandler(this._radCenterMouseX_CheckedChanged);
			// 
			// _radNoneX
			// 
			resources.ApplyResources(this._radNoneX, "_radNoneX");
			this._radNoneX.Name = "_radNoneX";
			this._radNoneX.TabStop = true;
			this._radNoneX.UseVisualStyleBackColor = true;
			this._radNoneX.CheckedChanged += new System.EventHandler(this._radNoneX_CheckedChanged);
			// 
			// _grpSettingsX
			// 
			resources.ApplyResources(this._grpSettingsX, "_grpSettingsX");
			this._grpSettingsX.Controls.Add(this._lblCooldownX);
			this._grpSettingsX.Controls.Add(this._lblCooldownXL);
			this._grpSettingsX.Controls.Add(this._tbCooldownX);
			this._grpSettingsX.Controls.Add(this._lblCooldownXR);
			this._grpSettingsX.Controls.Add(this._lblDistanceX);
			this._grpSettingsX.Controls.Add(this._lblDistanceXL);
			this._grpSettingsX.Controls.Add(this._tbDistanceX);
			this._grpSettingsX.Controls.Add(this._lblDistanceXR);
			this._grpSettingsX.Controls.Add(this._lblDirectionChangeX);
			this._grpSettingsX.Controls.Add(this._lblDirectionChangeXL);
			this._grpSettingsX.Controls.Add(this._tbDirectionChangeX);
			this._grpSettingsX.Controls.Add(this._lblDirectionChangeXR);
			this._grpSettingsX.Name = "_grpSettingsX";
			this._grpSettingsX.TabStop = false;
			// 
			// _lblCooldownX
			// 
			resources.ApplyResources(this._lblCooldownX, "_lblCooldownX");
			this._lblCooldownX.Name = "_lblCooldownX";
			// 
			// _lblCooldownXL
			// 
			resources.ApplyResources(this._lblCooldownXL, "_lblCooldownXL");
			this._lblCooldownXL.Name = "_lblCooldownXL";
			// 
			// _lblCooldownXR
			// 
			resources.ApplyResources(this._lblCooldownXR, "_lblCooldownXR");
			this._lblCooldownXR.Name = "_lblCooldownXR";
			// 
			// _lblDistanceX
			// 
			resources.ApplyResources(this._lblDistanceX, "_lblDistanceX");
			this._lblDistanceX.Name = "_lblDistanceX";
			// 
			// _lblDistanceXL
			// 
			resources.ApplyResources(this._lblDistanceXL, "_lblDistanceXL");
			this._lblDistanceXL.Name = "_lblDistanceXL";
			// 
			// _lblDistanceXR
			// 
			resources.ApplyResources(this._lblDistanceXR, "_lblDistanceXR");
			this._lblDistanceXR.Name = "_lblDistanceXR";
			// 
			// _lblDirectionChangeX
			// 
			resources.ApplyResources(this._lblDirectionChangeX, "_lblDirectionChangeX");
			this._lblDirectionChangeX.Name = "_lblDirectionChangeX";
			// 
			// _lblDirectionChangeXL
			// 
			resources.ApplyResources(this._lblDirectionChangeXL, "_lblDirectionChangeXL");
			this._lblDirectionChangeXL.Name = "_lblDirectionChangeXL";
			// 
			// _lblDirectionChangeXR
			// 
			resources.ApplyResources(this._lblDirectionChangeXR, "_lblDirectionChangeXR");
			this._lblDirectionChangeXR.Name = "_lblDirectionChangeXR";
			// 
			// tpSettingsY
			// 
			resources.ApplyResources(this.tpSettingsY, "tpSettingsY");
			this.tpSettingsY.Controls.Add(this._grpActionY);
			this.tpSettingsY.Controls.Add(this._grpSettingsY);
			this.tpSettingsY.Name = "tpSettingsY";
			this.tpSettingsY.UseVisualStyleBackColor = true;
			// 
			// _grpActionY
			// 
			resources.ApplyResources(this._grpActionY, "_grpActionY");
			this._grpActionY.Controls.Add(this._radBigMouseY);
			this._grpActionY.Controls.Add(this._radCenterMouseY);
			this._grpActionY.Controls.Add(this._radNoneY);
			this._grpActionY.Name = "_grpActionY";
			this._grpActionY.TabStop = false;
			// 
			// _radBigMouseY
			// 
			resources.ApplyResources(this._radBigMouseY, "_radBigMouseY");
			this._radBigMouseY.Name = "_radBigMouseY";
			this._radBigMouseY.TabStop = true;
			this._radBigMouseY.UseVisualStyleBackColor = true;
			this._radBigMouseY.CheckedChanged += new System.EventHandler(this._radBigMouseY_CheckedChanged);
			// 
			// _radCenterMouseY
			// 
			resources.ApplyResources(this._radCenterMouseY, "_radCenterMouseY");
			this._radCenterMouseY.Name = "_radCenterMouseY";
			this._radCenterMouseY.TabStop = true;
			this._radCenterMouseY.UseVisualStyleBackColor = true;
			this._radCenterMouseY.CheckedChanged += new System.EventHandler(this._radCenterMouseY_CheckedChanged);
			// 
			// _radNoneY
			// 
			resources.ApplyResources(this._radNoneY, "_radNoneY");
			this._radNoneY.Name = "_radNoneY";
			this._radNoneY.TabStop = true;
			this._radNoneY.UseVisualStyleBackColor = true;
			this._radNoneY.CheckedChanged += new System.EventHandler(this._radNoneY_CheckedChanged);
			// 
			// _grpSettingsY
			// 
			resources.ApplyResources(this._grpSettingsY, "_grpSettingsY");
			this._grpSettingsY.Controls.Add(this._lblCooldownY);
			this._grpSettingsY.Controls.Add(this._lblCooldownYL);
			this._grpSettingsY.Controls.Add(this._tbCooldownY);
			this._grpSettingsY.Controls.Add(this._lblCooldownYR);
			this._grpSettingsY.Controls.Add(this._lblDistanceY);
			this._grpSettingsY.Controls.Add(this._lblDistanceYL);
			this._grpSettingsY.Controls.Add(this._tbDistanceY);
			this._grpSettingsY.Controls.Add(this._lblDistanceYR);
			this._grpSettingsY.Controls.Add(this._lblDirectionChangeY);
			this._grpSettingsY.Controls.Add(this._lblDirectionChangeYL);
			this._grpSettingsY.Controls.Add(this._tbDirectionChangeY);
			this._grpSettingsY.Controls.Add(this._lblDirectionChangeYR);
			this._grpSettingsY.Name = "_grpSettingsY";
			this._grpSettingsY.TabStop = false;
			// 
			// _lblCooldownY
			// 
			resources.ApplyResources(this._lblCooldownY, "_lblCooldownY");
			this._lblCooldownY.Name = "_lblCooldownY";
			// 
			// _lblCooldownYL
			// 
			resources.ApplyResources(this._lblCooldownYL, "_lblCooldownYL");
			this._lblCooldownYL.Name = "_lblCooldownYL";
			// 
			// _tbCooldownY
			// 
			resources.ApplyResources(this._tbCooldownY, "_tbCooldownY");
			this._tbCooldownY.Maximum = 100;
			this._tbCooldownY.Minimum = 20;
			this._tbCooldownY.Name = "_tbCooldownY";
			this._tbCooldownY.TickFrequency = 0;
			this._tbCooldownY.TickStyle = System.Windows.Forms.TickStyle.None;
			this._tbCooldownY.Value = 20;
			this._tbCooldownY.Scroll += new System.EventHandler(this._tbCooldownY_Scroll);
			// 
			// _lblCooldownYR
			// 
			resources.ApplyResources(this._lblCooldownYR, "_lblCooldownYR");
			this._lblCooldownYR.Name = "_lblCooldownYR";
			// 
			// _lblDistanceY
			// 
			resources.ApplyResources(this._lblDistanceY, "_lblDistanceY");
			this._lblDistanceY.Name = "_lblDistanceY";
			// 
			// _lblDistanceYL
			// 
			resources.ApplyResources(this._lblDistanceYL, "_lblDistanceYL");
			this._lblDistanceYL.Name = "_lblDistanceYL";
			// 
			// _tbDistanceY
			// 
			resources.ApplyResources(this._tbDistanceY, "_tbDistanceY");
			this._tbDistanceY.Maximum = 100;
			this._tbDistanceY.Minimum = 5;
			this._tbDistanceY.Name = "_tbDistanceY";
			this._tbDistanceY.TickFrequency = 0;
			this._tbDistanceY.TickStyle = System.Windows.Forms.TickStyle.None;
			this._tbDistanceY.Value = 5;
			this._tbDistanceY.Scroll += new System.EventHandler(this._tbDistanceY_Scroll);
			// 
			// _lblDistanceYR
			// 
			resources.ApplyResources(this._lblDistanceYR, "_lblDistanceYR");
			this._lblDistanceYR.Name = "_lblDistanceYR";
			// 
			// _lblDirectionChangeY
			// 
			resources.ApplyResources(this._lblDirectionChangeY, "_lblDirectionChangeY");
			this._lblDirectionChangeY.Name = "_lblDirectionChangeY";
			// 
			// _lblDirectionChangeYL
			// 
			resources.ApplyResources(this._lblDirectionChangeYL, "_lblDirectionChangeYL");
			this._lblDirectionChangeYL.Name = "_lblDirectionChangeYL";
			// 
			// _tbDirectionChangeY
			// 
			resources.ApplyResources(this._tbDirectionChangeY, "_tbDirectionChangeY");
			this._tbDirectionChangeY.LargeChange = 1;
			this._tbDirectionChangeY.Maximum = 20;
			this._tbDirectionChangeY.Minimum = 1;
			this._tbDirectionChangeY.Name = "_tbDirectionChangeY";
			this._tbDirectionChangeY.TickFrequency = 0;
			this._tbDirectionChangeY.TickStyle = System.Windows.Forms.TickStyle.None;
			this._tbDirectionChangeY.Value = 1;
			this._tbDirectionChangeY.Scroll += new System.EventHandler(this._tbDirectionChangeY_Scroll);
			// 
			// _lblDirectionChangeYR
			// 
			resources.ApplyResources(this._lblDirectionChangeYR, "_lblDirectionChangeYR");
			this._lblDirectionChangeYR.Name = "_lblDirectionChangeYR";
			// 
			// _tbIncrease
			// 
			resources.ApplyResources(this._tbIncrease, "_tbIncrease");
			this._tbIncrease.LargeChange = 8;
			this._tbIncrease.Maximum = 64;
			this._tbIncrease.Minimum = 8;
			this._tbIncrease.Name = "_tbIncrease";
			this._tbIncrease.TickFrequency = 0;
			this._tbIncrease.TickStyle = System.Windows.Forms.TickStyle.None;
			this._tbIncrease.Value = 8;
			// 
			// _lblBigMouse
			// 
			resources.ApplyResources(this._lblBigMouse, "_lblBigMouse");
			this._lblBigMouse.Name = "_lblBigMouse";
			// 
			// _lblBigMouseL
			// 
			resources.ApplyResources(this._lblBigMouseL, "_lblBigMouseL");
			this._lblBigMouseL.Name = "_lblBigMouseL";
			// 
			// _lblBigMouseR
			// 
			resources.ApplyResources(this._lblBigMouseR, "_lblBigMouseR");
			this._lblBigMouseR.Name = "_lblBigMouseR";
			// 
			// _lblCheckX
			// 
			resources.ApplyResources(this._lblCheckX, "_lblCheckX");
			this._lblCheckX.Name = "_lblCheckX";
			// 
			// _lblCheckY
			// 
			resources.ApplyResources(this._lblCheckY, "_lblCheckY");
			this._lblCheckY.Name = "_lblCheckY";
			// 
			// _lblValueX
			// 
			resources.ApplyResources(this._lblValueX, "_lblValueX");
			this._lblValueX.Name = "_lblValueX";
			// 
			// _lblValueY
			// 
			resources.ApplyResources(this._lblValueY, "_lblValueY");
			this._lblValueY.Name = "_lblValueY";
			// 
			// _lblApplicationTitle
			// 
			resources.ApplyResources(this._lblApplicationTitle, "_lblApplicationTitle");
			this._lblApplicationTitle.BackColor = System.Drawing.Color.Transparent;
			this._lblApplicationTitle.Name = "_lblApplicationTitle";
			// 
			// _lblApplicationVersion
			// 
			resources.ApplyResources(this._lblApplicationVersion, "_lblApplicationVersion");
			this._lblApplicationVersion.Name = "_lblApplicationVersion";
			// 
			// _lblApplicationCopyright
			// 
			resources.ApplyResources(this._lblApplicationCopyright, "_lblApplicationCopyright");
			this._lblApplicationCopyright.Name = "_lblApplicationCopyright";
			// 
			// _grpMouseSettings
			// 
			resources.ApplyResources(this._grpMouseSettings, "_grpMouseSettings");
			this._grpMouseSettings.Controls.Add(this._lblBigMouse);
			this._grpMouseSettings.Controls.Add(this._lblBigMouseL);
			this._grpMouseSettings.Controls.Add(this._tbIncrease);
			this._grpMouseSettings.Controls.Add(this._lblBigMouseR);
			this._grpMouseSettings.Name = "_grpMouseSettings";
			this._grpMouseSettings.TabStop = false;
			// 
			// _chkAutoExec
			// 
			resources.ApplyResources(this._chkAutoExec, "_chkAutoExec");
			this._chkAutoExec.AutoCheck = false;
			this._chkAutoExec.Name = "_chkAutoExec";
			this._chkAutoExec.UseVisualStyleBackColor = true;
			this._chkAutoExec.Click += new System.EventHandler(this._chkAutoExec_Click);
			// 
			// _niTray
			// 
			resources.ApplyResources(this._niTray, "_niTray");
			this._niTray.ContextMenuStrip = this._cmsTray;
			this._niTray.DoubleClick += new System.EventHandler(this._niTray_DoubleClick);
			// 
			// _cmsTray
			// 
			resources.ApplyResources(this._cmsTray, "_cmsTray");
			this._cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmiSettings,
            this.toolStripSeparator1,
            this._tsmiExit});
			this._cmsTray.Name = "_cmsTray";
			// 
			// _tsmiSettings
			// 
			resources.ApplyResources(this._tsmiSettings, "_tsmiSettings");
			this._tsmiSettings.Name = "_tsmiSettings";
			this._tsmiSettings.Click += new System.EventHandler(this._tsmiSettings_Click);
			// 
			// toolStripSeparator1
			// 
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			// 
			// _tsmiExit
			// 
			resources.ApplyResources(this._tsmiExit, "_tsmiExit");
			this._tsmiExit.Name = "_tsmiExit";
			this._tsmiExit.Click += new System.EventHandler(this._tsmiExit_Click);
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._chkAutoExec);
			this.Controls.Add(this._tcSettings);
			this.Controls.Add(this._grpMouseSettings);
			this.Controls.Add(this._lblCheckX);
			this.Controls.Add(this._lblValueX);
			this.Controls.Add(this._lblCheckY);
			this.Controls.Add(this._lblValueY);
			this.Controls.Add(this._lblApplicationCopyright);
			this.Controls.Add(this._lblApplicationVersion);
			this.Controls.Add(this._lblApplicationTitle);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this._tbCooldownX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._tbDistanceX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._tbDirectionChangeX)).EndInit();
			this._tcSettings.ResumeLayout(false);
			this._tpSettingsX.ResumeLayout(false);
			this._grpActionX.ResumeLayout(false);
			this._grpActionX.PerformLayout();
			this._grpSettingsX.ResumeLayout(false);
			this._grpSettingsX.PerformLayout();
			this.tpSettingsY.ResumeLayout(false);
			this._grpActionY.ResumeLayout(false);
			this._grpActionY.PerformLayout();
			this._grpSettingsY.ResumeLayout(false);
			this._grpSettingsY.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._tbCooldownY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._tbDistanceY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._tbDirectionChangeY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._tbIncrease)).EndInit();
			this._grpMouseSettings.ResumeLayout(false);
			this._grpMouseSettings.PerformLayout();
			this._cmsTray.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TrackBar _tbCooldownX;
		private System.Windows.Forms.TrackBar _tbDistanceX;
		private System.Windows.Forms.TrackBar _tbDirectionChangeX;
		private System.Windows.Forms.Timer _timSampling;
		private System.Windows.Forms.TabControl _tcSettings;
		private System.Windows.Forms.TabPage _tpSettingsX;
		private System.Windows.Forms.TabPage tpSettingsY;
		private System.Windows.Forms.Label _lblCooldownXR;
		private System.Windows.Forms.Label _lblDistanceXR;
		private System.Windows.Forms.Label _lblDistanceXL;
		private System.Windows.Forms.Label _lblCooldownXL;
		private System.Windows.Forms.Label _lblDirectionChangeX;
		private System.Windows.Forms.Label _lblDistanceX;
		private System.Windows.Forms.Label _lblCooldownX;
		private System.Windows.Forms.GroupBox _grpSettingsX;
		private System.Windows.Forms.GroupBox _grpActionX;
		private System.Windows.Forms.RadioButton _radBigMouseX;
		private System.Windows.Forms.RadioButton _radNoneX;
		private System.Windows.Forms.RadioButton _radCenterMouseX;
		private System.Windows.Forms.Label _lblDirectionChangeXR;
		private System.Windows.Forms.Label _lblDirectionChangeXL;
		private System.Windows.Forms.GroupBox _grpSettingsY;
		private System.Windows.Forms.Label _lblCooldownY;
		private System.Windows.Forms.TrackBar _tbDirectionChangeY;
		private System.Windows.Forms.Label _lblCooldownYR;
		private System.Windows.Forms.TrackBar _tbDistanceY;
		private System.Windows.Forms.Label _lblDirectionChangeYR;
		private System.Windows.Forms.TrackBar _tbCooldownY;
		private System.Windows.Forms.Label _lblDistanceYR;
		private System.Windows.Forms.Label _lblDistanceY;
		private System.Windows.Forms.Label _lblDirectionChangeYL;
		private System.Windows.Forms.Label _lblDirectionChangeY;
		private System.Windows.Forms.Label _lblDistanceYL;
		private System.Windows.Forms.Label _lblCooldownYL;
		private System.Windows.Forms.GroupBox _grpActionY;
		private System.Windows.Forms.RadioButton _radBigMouseY;
		private System.Windows.Forms.RadioButton _radNoneY;
		private System.Windows.Forms.RadioButton _radCenterMouseY;
		private System.Windows.Forms.TrackBar _tbIncrease;
		private System.Windows.Forms.Label _lblBigMouse;
		private System.Windows.Forms.Label _lblBigMouseL;
		private System.Windows.Forms.Label _lblBigMouseR;
		private System.Windows.Forms.Label _lblCheckX;
		private System.Windows.Forms.Label _lblCheckY;
		private System.Windows.Forms.Label _lblValueX;
		private System.Windows.Forms.Label _lblValueY;
		private System.Windows.Forms.Label _lblApplicationTitle;
		private System.Windows.Forms.Label _lblApplicationVersion;
		private System.Windows.Forms.Label _lblApplicationCopyright;
		private System.Windows.Forms.GroupBox _grpMouseSettings;
		private System.Windows.Forms.CheckBox _chkAutoExec;
		private System.Windows.Forms.NotifyIcon _niTray;
		private System.Windows.Forms.ContextMenuStrip _cmsTray;
		private System.Windows.Forms.ToolStripMenuItem _tsmiSettings;
		private System.Windows.Forms.ToolStripMenuItem _tsmiExit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}

