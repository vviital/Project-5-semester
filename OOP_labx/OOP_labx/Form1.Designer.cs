namespace OOP_labx
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bProcessList = new System.Windows.Forms.Button();
            this.lbTrustedProcesses = new System.Windows.Forms.ListBox();
            this.bAddToTrusted = new System.Windows.Forms.Button();
            this.bKillProcess = new System.Windows.Forms.Button();
            this.bRemoveFromTrustProcess = new System.Windows.Forms.Button();
            this.bAddToAutorun = new System.Windows.Forms.Button();
            this.bRemoveFromAutorun = new System.Windows.Forms.Button();
            this.lbProcesses = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // bProcessList
            // 
            this.bProcessList.Location = new System.Drawing.Point(12, 226);
            this.bProcessList.Name = "bProcessList";
            this.bProcessList.Size = new System.Drawing.Size(80, 23);
            this.bProcessList.TabIndex = 1;
            this.bProcessList.Text = "List Proc";
            this.bProcessList.UseVisualStyleBackColor = true;
            this.bProcessList.Click += new System.EventHandler(this.bProcessList_Click);
            // 
            // lbTrustedProcesses
            // 
            this.lbTrustedProcesses.FormattingEnabled = true;
            this.lbTrustedProcesses.Location = new System.Drawing.Point(216, 13);
            this.lbTrustedProcesses.Name = "lbTrustedProcesses";
            this.lbTrustedProcesses.Size = new System.Drawing.Size(170, 212);
            this.lbTrustedProcesses.TabIndex = 2;
            // 
            // bAddToTrusted
            // 
            this.bAddToTrusted.Location = new System.Drawing.Point(182, 97);
            this.bAddToTrusted.Name = "bAddToTrusted";
            this.bAddToTrusted.Size = new System.Drawing.Size(28, 23);
            this.bAddToTrusted.TabIndex = 3;
            this.bAddToTrusted.Text = "->";
            this.bAddToTrusted.UseVisualStyleBackColor = true;
            this.bAddToTrusted.Click += new System.EventHandler(this.bAddToTrusted_Click);
            // 
            // bKillProcess
            // 
            this.bKillProcess.Location = new System.Drawing.Point(98, 226);
            this.bKillProcess.Name = "bKillProcess";
            this.bKillProcess.Size = new System.Drawing.Size(77, 23);
            this.bKillProcess.TabIndex = 4;
            this.bKillProcess.Text = "Kill";
            this.bKillProcess.UseVisualStyleBackColor = true;
            this.bKillProcess.Click += new System.EventHandler(this.bKillProcess_Click);
            // 
            // bRemoveFromTrustProcess
            // 
            this.bRemoveFromTrustProcess.Location = new System.Drawing.Point(216, 226);
            this.bRemoveFromTrustProcess.Name = "bRemoveFromTrustProcess";
            this.bRemoveFromTrustProcess.Size = new System.Drawing.Size(170, 52);
            this.bRemoveFromTrustProcess.TabIndex = 5;
            this.bRemoveFromTrustProcess.Text = "Remove";
            this.bRemoveFromTrustProcess.UseVisualStyleBackColor = true;
            this.bRemoveFromTrustProcess.Click += new System.EventHandler(this.bRemoveFromTrustProcess_Click);
            // 
            // bAddToAutorun
            // 
            this.bAddToAutorun.Location = new System.Drawing.Point(13, 255);
            this.bAddToAutorun.Name = "bAddToAutorun";
            this.bAddToAutorun.Size = new System.Drawing.Size(79, 23);
            this.bAddToAutorun.TabIndex = 8;
            this.bAddToAutorun.Text = "+ Autorun";
            this.bAddToAutorun.UseVisualStyleBackColor = true;
            this.bAddToAutorun.Click += new System.EventHandler(this.bAddToAutorun_Click);
            // 
            // bRemoveFromAutorun
            // 
            this.bRemoveFromAutorun.Location = new System.Drawing.Point(98, 255);
            this.bRemoveFromAutorun.Name = "bRemoveFromAutorun";
            this.bRemoveFromAutorun.Size = new System.Drawing.Size(77, 23);
            this.bRemoveFromAutorun.TabIndex = 9;
            this.bRemoveFromAutorun.Text = "- Autorun";
            this.bRemoveFromAutorun.UseVisualStyleBackColor = true;
            this.bRemoveFromAutorun.Click += new System.EventHandler(this.bRemoveFromAutorun_Click);
            // 
            // lbProcesses
            // 
            this.lbProcesses.FormattingEnabled = true;
            this.lbProcesses.Location = new System.Drawing.Point(13, 13);
            this.lbProcesses.Name = "lbProcesses";
            this.lbProcesses.Size = new System.Drawing.Size(162, 212);
            this.lbProcesses.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 312);
            this.Controls.Add(this.bRemoveFromAutorun);
            this.Controls.Add(this.bAddToAutorun);
            this.Controls.Add(this.bRemoveFromTrustProcess);
            this.Controls.Add(this.bKillProcess);
            this.Controls.Add(this.bAddToTrusted);
            this.Controls.Add(this.lbTrustedProcesses);
            this.Controls.Add(this.bProcessList);
            this.Controls.Add(this.lbProcesses);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bProcessList;
        private System.Windows.Forms.ListBox lbTrustedProcesses;
        private System.Windows.Forms.Button bAddToTrusted;
        private System.Windows.Forms.Button bKillProcess;
        private System.Windows.Forms.Button bRemoveFromTrustProcess;
        private System.Windows.Forms.Button bAddToAutorun;
        private System.Windows.Forms.Button bRemoveFromAutorun;
        private System.Windows.Forms.ListBox lbProcesses;
    }
}

