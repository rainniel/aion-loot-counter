namespace AionLootCounter
{
    partial class FormMain
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonCopyText = new System.Windows.Forms.Button();
            this.LabelTotalBag = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LabelTotalYellow = new System.Windows.Forms.Label();
            this.LabelTotalEternal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LabelTotalMythic = new System.Windows.Forms.Label();
            this.Player6 = new AionLootCounter.Controls.PlayerLoot();
            this.Player5 = new AionLootCounter.Controls.PlayerLoot();
            this.Player4 = new AionLootCounter.Controls.PlayerLoot();
            this.Player3 = new AionLootCounter.Controls.PlayerLoot();
            this.Player2 = new AionLootCounter.Controls.PlayerLoot();
            this.Player1 = new AionLootCounter.Controls.PlayerLoot();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bag";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Yellow";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Eternal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(250, 236);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(120, 30);
            this.ButtonClear.TabIndex = 15;
            this.ButtonClear.Text = "Clear";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // ButtonCopyText
            // 
            this.ButtonCopyText.Location = new System.Drawing.Point(14, 236);
            this.ButtonCopyText.Name = "ButtonCopyText";
            this.ButtonCopyText.Size = new System.Drawing.Size(120, 30);
            this.ButtonCopyText.TabIndex = 14;
            this.ButtonCopyText.Text = "Copy Text";
            this.ButtonCopyText.UseVisualStyleBackColor = true;
            this.ButtonCopyText.Click += new System.EventHandler(this.ButtonCopyText_Click);
            // 
            // LabelTotalBag
            // 
            this.LabelTotalBag.BackColor = System.Drawing.Color.White;
            this.LabelTotalBag.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalBag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.LabelTotalBag.Location = new System.Drawing.Point(151, 204);
            this.LabelTotalBag.Name = "LabelTotalBag";
            this.LabelTotalBag.Size = new System.Drawing.Size(38, 20);
            this.LabelTotalBag.TabIndex = 11;
            this.LabelTotalBag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(112, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelTotalYellow
            // 
            this.LabelTotalYellow.BackColor = System.Drawing.Color.White;
            this.LabelTotalYellow.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalYellow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(183)))), ((int)(((byte)(28)))));
            this.LabelTotalYellow.Location = new System.Drawing.Point(207, 204);
            this.LabelTotalYellow.Name = "LabelTotalYellow";
            this.LabelTotalYellow.Size = new System.Drawing.Size(38, 20);
            this.LabelTotalYellow.TabIndex = 12;
            this.LabelTotalYellow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelTotalEternal
            // 
            this.LabelTotalEternal.BackColor = System.Drawing.Color.White;
            this.LabelTotalEternal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalEternal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(51)))));
            this.LabelTotalEternal.Location = new System.Drawing.Point(263, 204);
            this.LabelTotalEternal.Name = "LabelTotalEternal";
            this.LabelTotalEternal.Size = new System.Drawing.Size(38, 20);
            this.LabelTotalEternal.TabIndex = 13;
            this.LabelTotalEternal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mythic";
            // 
            // LabelTotalMythic
            // 
            this.LabelTotalMythic.BackColor = System.Drawing.Color.White;
            this.LabelTotalMythic.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalMythic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(57)))), ((int)(((byte)(206)))));
            this.LabelTotalMythic.Location = new System.Drawing.Point(319, 204);
            this.LabelTotalMythic.Name = "LabelTotalMythic";
            this.LabelTotalMythic.Size = new System.Drawing.Size(38, 20);
            this.LabelTotalMythic.TabIndex = 16;
            this.LabelTotalMythic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Player6
            // 
            this.Player6.BackColor = System.Drawing.Color.White;
            this.Player6.Bag = 0;
            this.Player6.CountMythic = false;
            this.Player6.Eternal = 0;
            this.Player6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player6.Location = new System.Drawing.Point(15, 178);
            this.Player6.Mythic = 0;
            this.Player6.Name = "Player6";
            this.Player6.PlayerName = "";
            this.Player6.Size = new System.Drawing.Size(354, 23);
            this.Player6.TabIndex = 9;
            this.Player6.Yellow = 0;
            // 
            // Player5
            // 
            this.Player5.BackColor = System.Drawing.Color.White;
            this.Player5.Bag = 0;
            this.Player5.CountMythic = false;
            this.Player5.Eternal = 0;
            this.Player5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player5.Location = new System.Drawing.Point(15, 149);
            this.Player5.Mythic = 0;
            this.Player5.Name = "Player5";
            this.Player5.PlayerName = "";
            this.Player5.Size = new System.Drawing.Size(354, 23);
            this.Player5.TabIndex = 8;
            this.Player5.Yellow = 0;
            // 
            // Player4
            // 
            this.Player4.BackColor = System.Drawing.Color.White;
            this.Player4.Bag = 0;
            this.Player4.CountMythic = false;
            this.Player4.Eternal = 0;
            this.Player4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player4.Location = new System.Drawing.Point(15, 120);
            this.Player4.Mythic = 0;
            this.Player4.Name = "Player4";
            this.Player4.PlayerName = "";
            this.Player4.Size = new System.Drawing.Size(354, 23);
            this.Player4.TabIndex = 7;
            this.Player4.Yellow = 0;
            // 
            // Player3
            // 
            this.Player3.BackColor = System.Drawing.Color.White;
            this.Player3.Bag = 0;
            this.Player3.CountMythic = false;
            this.Player3.Eternal = 0;
            this.Player3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player3.Location = new System.Drawing.Point(15, 91);
            this.Player3.Mythic = 0;
            this.Player3.Name = "Player3";
            this.Player3.PlayerName = "";
            this.Player3.Size = new System.Drawing.Size(354, 23);
            this.Player3.TabIndex = 6;
            this.Player3.Yellow = 0;
            // 
            // Player2
            // 
            this.Player2.BackColor = System.Drawing.Color.White;
            this.Player2.Bag = 0;
            this.Player2.CountMythic = false;
            this.Player2.Eternal = 0;
            this.Player2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2.Location = new System.Drawing.Point(15, 62);
            this.Player2.Mythic = 0;
            this.Player2.Name = "Player2";
            this.Player2.PlayerName = "";
            this.Player2.Size = new System.Drawing.Size(354, 23);
            this.Player2.TabIndex = 5;
            this.Player2.Yellow = 0;
            // 
            // Player1
            // 
            this.Player1.BackColor = System.Drawing.Color.White;
            this.Player1.Bag = 0;
            this.Player1.CountMythic = false;
            this.Player1.Eternal = 0;
            this.Player1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1.Location = new System.Drawing.Point(15, 33);
            this.Player1.Mythic = 0;
            this.Player1.Name = "Player1";
            this.Player1.PlayerName = "";
            this.Player1.Size = new System.Drawing.Size(354, 23);
            this.Player1.TabIndex = 4;
            this.Player1.Yellow = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.LabelTotalMythic);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LabelTotalEternal);
            this.Controls.Add(this.LabelTotalYellow);
            this.Controls.Add(this.LabelTotalBag);
            this.Controls.Add(this.ButtonCopyText);
            this.Controls.Add(this.Player6);
            this.Controls.Add(this.Player5);
            this.Controls.Add(this.Player4);
            this.Controls.Add(this.Player3);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aion Loot Counter";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonClear;
        private AionLootCounter.Controls.PlayerLoot Player1;
        private AionLootCounter.Controls.PlayerLoot Player2;
        private AionLootCounter.Controls.PlayerLoot Player3;
        private AionLootCounter.Controls.PlayerLoot Player4;
        private AionLootCounter.Controls.PlayerLoot Player5;
        private AionLootCounter.Controls.PlayerLoot Player6;
        private System.Windows.Forms.Button ButtonCopyText;
        private System.Windows.Forms.Label LabelTotalBag;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LabelTotalYellow;
        private System.Windows.Forms.Label LabelTotalEternal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LabelTotalMythic;
    }
}

