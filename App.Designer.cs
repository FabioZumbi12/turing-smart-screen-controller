using System.Windows.Forms;

namespace Turing_Smart_Screen_Controller
{
    partial class App
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnEditConfig = new System.Windows.Forms.Button();
            this.btnStopPy = new System.Windows.Forms.Button();
            this.lblAlerts = new System.Windows.Forms.Label();
            this.btnLogs = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnTheme = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrereq = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(52, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turing Smart Screen Controller";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Turing_Smart_Screen_Controller.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(10, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "- Minize to hide";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "- Close to stop monitoring";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(6, 48);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(101, 23);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "(Re)Start";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(6, 77);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(101, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEditConfig
            // 
            this.btnEditConfig.Enabled = false;
            this.btnEditConfig.Location = new System.Drawing.Point(6, 48);
            this.btnEditConfig.Name = "btnEditConfig";
            this.btnEditConfig.Size = new System.Drawing.Size(135, 23);
            this.btnEditConfig.TabIndex = 7;
            this.btnEditConfig.Text = "Edit Configuration";
            this.btnEditConfig.UseVisualStyleBackColor = true;
            this.btnEditConfig.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnStopPy
            // 
            this.btnStopPy.Location = new System.Drawing.Point(6, 106);
            this.btnStopPy.Name = "btnStopPy";
            this.btnStopPy.Size = new System.Drawing.Size(101, 23);
            this.btnStopPy.TabIndex = 8;
            this.btnStopPy.Text = "Stop All Py Procs";
            this.btnStopPy.UseVisualStyleBackColor = true;
            this.btnStopPy.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblAlerts
            // 
            this.lblAlerts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAlerts.Location = new System.Drawing.Point(0, 191);
            this.lblAlerts.Name = "lblAlerts";
            this.lblAlerts.Size = new System.Drawing.Size(423, 17);
            this.lblAlerts.TabIndex = 9;
            this.lblAlerts.Text = "Running";
            this.lblAlerts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogs
            // 
            this.btnLogs.Location = new System.Drawing.Point(6, 106);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(135, 23);
            this.btnLogs.TabIndex = 10;
            this.btnLogs.Text = "Open Logs";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(110, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Start on Windows";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnTheme
            // 
            this.btnTheme.Enabled = false;
            this.btnTheme.Location = new System.Drawing.Point(6, 77);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(135, 23);
            this.btnTheme.TabIndex = 12;
            this.btnTheme.Text = "Theme Editor";
            this.btnTheme.UseVisualStyleBackColor = true;
            this.btnTheme.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrereq);
            this.groupBox1.Controls.Add(this.btnRestart);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStopPy);
            this.groupBox1.Location = new System.Drawing.Point(143, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 139);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start and Stop";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEditConfig);
            this.groupBox2.Controls.Add(this.btnTheme);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.btnLogs);
            this.groupBox2.Location = new System.Drawing.Point(262, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 139);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configurations";
            // 
            // btnPrereq
            // 
            this.btnPrereq.Location = new System.Drawing.Point(6, 19);
            this.btnPrereq.Name = "btnPrereq";
            this.btnPrereq.Size = new System.Drawing.Size(101, 23);
            this.btnPrereq.TabIndex = 9;
            this.btnPrereq.Text = "Run Pre Reqs";
            this.btnPrereq.UseVisualStyleBackColor = true;
            this.btnPrereq.Click += new System.EventHandler(this.button7_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 208);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblAlerts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turing Smart Screen Controller";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.App_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Label lblAlerts;
        private CheckBox checkBox1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnRestart;
        private Button btnStop;
        private Button btnEditConfig;
        private Button btnStopPy;
        private Button btnLogs;
        private Button btnTheme;
        private Button btnPrereq;
    }
}

