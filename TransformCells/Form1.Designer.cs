namespace TransformCells
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChooseFile = new System.Windows.Forms.Button();
            this.BTransform = new System.Windows.Forms.Button();
            this.OpenBadFile = new System.Windows.Forms.OpenFileDialog();
            this.LabelDescription = new System.Windows.Forms.Label();
            this.LabelState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChooseFile
            // 
            this.ChooseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseFile.Location = new System.Drawing.Point(91, 44);
            this.ChooseFile.Name = "ChooseFile";
            this.ChooseFile.Size = new System.Drawing.Size(184, 44);
            this.ChooseFile.TabIndex = 0;
            this.ChooseFile.Text = "Выбрать файл";
            this.ChooseFile.UseVisualStyleBackColor = true;
            this.ChooseFile.Click += new System.EventHandler(this.ChooseFile_Click);
            // 
            // BTransform
            // 
            this.BTransform.BackColor = System.Drawing.Color.GreenYellow;
            this.BTransform.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BTransform.Location = new System.Drawing.Point(91, 197);
            this.BTransform.Name = "BTransform";
            this.BTransform.Size = new System.Drawing.Size(184, 44);
            this.BTransform.TabIndex = 1;
            this.BTransform.Text = "Преобразовать";
            this.BTransform.UseVisualStyleBackColor = false;
            this.BTransform.Click += new System.EventHandler(this.BTransform_Click);
            // 
            // OpenBadFile
            // 
            this.OpenBadFile.FileName = "OpenBadFile";
            // 
            // LabelDescription
            // 
            this.LabelDescription.AutoSize = true;
            this.LabelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelDescription.Location = new System.Drawing.Point(26, 120);
            this.LabelDescription.Name = "LabelDescription";
            this.LabelDescription.Size = new System.Drawing.Size(91, 16);
            this.LabelDescription.TabIndex = 2;
            this.LabelDescription.Text = "Состояние:";
            // 
            // LabelState
            // 
            this.LabelState.AutoSize = true;
            this.LabelState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelState.Location = new System.Drawing.Point(26, 145);
            this.LabelState.Name = "LabelState";
            this.LabelState.Size = new System.Drawing.Size(84, 16);
            this.LabelState.TabIndex = 3;
            this.LabelState.Text = "Ожидание...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 287);
            this.Controls.Add(this.LabelState);
            this.Controls.Add(this.LabelDescription);
            this.Controls.Add(this.BTransform);
            this.Controls.Add(this.ChooseFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChooseFile;
        private System.Windows.Forms.Button BTransform;
        private System.Windows.Forms.OpenFileDialog OpenBadFile;
        private System.Windows.Forms.Label LabelDescription;
        private System.Windows.Forms.Label LabelState;
    }
}

