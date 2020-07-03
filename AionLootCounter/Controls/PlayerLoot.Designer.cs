namespace AionLootCounter.Controls
{
    partial class PlayerLoot
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextName = new System.Windows.Forms.TextBox();
            this.NumBag = new System.Windows.Forms.NumericUpDown();
            this.NumYellow = new System.Windows.Forms.NumericUpDown();
            this.NumEternal = new System.Windows.Forms.NumericUpDown();
            this.NumMythic = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumBag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumEternal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMythic)).BeginInit();
            this.SuspendLayout();
            // 
            // TextName
            // 
            this.TextName.Location = new System.Drawing.Point(0, 0);
            this.TextName.MaxLength = 30;
            this.TextName.Name = "TextName";
            this.TextName.Size = new System.Drawing.Size(130, 23);
            this.TextName.TabIndex = 0;
            // 
            // NumBag
            // 
            this.NumBag.BackColor = System.Drawing.Color.White;
            this.NumBag.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumBag.ForeColor = System.Drawing.Color.White;
            this.NumBag.Location = new System.Drawing.Point(136, 0);
            this.NumBag.Name = "NumBag";
            this.NumBag.ReadOnly = true;
            this.NumBag.Size = new System.Drawing.Size(50, 23);
            this.NumBag.TabIndex = 1;
            this.NumBag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumBag.ValueChanged += new System.EventHandler(this.NumBag_ValueChanged);
            // 
            // NumYellow
            // 
            this.NumYellow.BackColor = System.Drawing.Color.White;
            this.NumYellow.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumYellow.ForeColor = System.Drawing.Color.White;
            this.NumYellow.Location = new System.Drawing.Point(192, 0);
            this.NumYellow.Name = "NumYellow";
            this.NumYellow.ReadOnly = true;
            this.NumYellow.Size = new System.Drawing.Size(50, 23);
            this.NumYellow.TabIndex = 2;
            this.NumYellow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumYellow.ValueChanged += new System.EventHandler(this.NumYellow_ValueChanged);
            // 
            // NumEternal
            // 
            this.NumEternal.BackColor = System.Drawing.Color.White;
            this.NumEternal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumEternal.ForeColor = System.Drawing.Color.White;
            this.NumEternal.Location = new System.Drawing.Point(248, 0);
            this.NumEternal.Name = "NumEternal";
            this.NumEternal.ReadOnly = true;
            this.NumEternal.Size = new System.Drawing.Size(50, 23);
            this.NumEternal.TabIndex = 3;
            this.NumEternal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumEternal.ValueChanged += new System.EventHandler(this.NumEternal_ValueChanged);
            // 
            // NumMythic
            // 
            this.NumMythic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NumMythic.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumMythic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NumMythic.Location = new System.Drawing.Point(304, 0);
            this.NumMythic.Name = "NumMythic";
            this.NumMythic.ReadOnly = true;
            this.NumMythic.Size = new System.Drawing.Size(50, 23);
            this.NumMythic.TabIndex = 4;
            this.NumMythic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumMythic.ValueChanged += new System.EventHandler(this.NumMythic_ValueChanged);
            // 
            // PlayerLoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.NumMythic);
            this.Controls.Add(this.NumEternal);
            this.Controls.Add(this.NumYellow);
            this.Controls.Add(this.NumBag);
            this.Controls.Add(this.TextName);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PlayerLoot";
            this.Size = new System.Drawing.Size(354, 23);
            ((System.ComponentModel.ISupportInitialize)(this.NumBag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumEternal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMythic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextName;
        private System.Windows.Forms.NumericUpDown NumBag;
        private System.Windows.Forms.NumericUpDown NumYellow;
        private System.Windows.Forms.NumericUpDown NumEternal;
        private System.Windows.Forms.NumericUpDown NumMythic;
    }
}
