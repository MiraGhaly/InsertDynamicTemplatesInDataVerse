
namespace TemplateTester
{
    partial class TemplateGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.PrimaryEntityID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.template = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PrimaryEntityName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Primary Entity ID";
            // 
            // PrimaryEntityID
            // 
            this.PrimaryEntityID.Location = new System.Drawing.Point(191, 22);
            this.PrimaryEntityID.Name = "PrimaryEntityID";
            this.PrimaryEntityID.Size = new System.Drawing.Size(415, 22);
            this.PrimaryEntityID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Template";
            // 
            // template
            // 
            this.template.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.template.Location = new System.Drawing.Point(191, 85);
            this.template.Multiline = true;
            this.template.Name = "template";
            this.template.Size = new System.Drawing.Size(993, 210);
            this.template.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Replaced Template";
            // 
            // output
            // 
            this.output.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.Location = new System.Drawing.Point(192, 327);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(997, 255);
            this.output.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1211, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 47);
            this.button1.TabIndex = 6;
            this.button1.Text = "Replace Template";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PrimaryEntityName
            // 
            this.PrimaryEntityName.Location = new System.Drawing.Point(192, 48);
            this.PrimaryEntityName.Name = "PrimaryEntityName";
            this.PrimaryEntityName.Size = new System.Drawing.Size(415, 22);
            this.PrimaryEntityName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Primary Entity Name";
            // 
            // TemplateGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 688);
            this.Controls.Add(this.PrimaryEntityName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.template);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PrimaryEntityID);
            this.Controls.Add(this.label1);
            this.Name = "TemplateGenerator";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PrimaryEntityID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox template;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox PrimaryEntityName;
        private System.Windows.Forms.Label label4;
    }
}

