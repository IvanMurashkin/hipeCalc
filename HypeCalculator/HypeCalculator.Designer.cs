namespace HypeCalculator {
    partial class HypeCalculator {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.btnExit = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.inputDate = new System.Windows.Forms.Label();
            this.Operation = new System.Windows.Forms.Label();
            this.cbOperation = new System.Windows.Forms.ComboBox();
            this.panelBtns = new System.Windows.Forms.Panel();
            this.labelResult = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.labelRes = new System.Windows.Forms.Label();
            this.btnLike = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(302, 306);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(58, 44);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(93, 203);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(121, 20);
            this.textBoxInput.TabIndex = 1;
            // 
            // inputDate
            // 
            this.inputDate.AutoSize = true;
            this.inputDate.Location = new System.Drawing.Point(12, 206);
            this.inputDate.Name = "inputDate";
            this.inputDate.Size = new System.Drawing.Size(55, 13);
            this.inputDate.TabIndex = 2;
            this.inputDate.Text = "Input data";
            // 
            // Operation
            // 
            this.Operation.AutoSize = true;
            this.Operation.Location = new System.Drawing.Point(12, 9);
            this.Operation.Name = "Operation";
            this.Operation.Size = new System.Drawing.Size(53, 13);
            this.Operation.TabIndex = 3;
            this.Operation.Text = "Operation";
            // 
            // cbOperation
            // 
            this.cbOperation.FormattingEnabled = true;
            this.cbOperation.Location = new System.Drawing.Point(93, 9);
            this.cbOperation.Name = "cbOperation";
            this.cbOperation.Size = new System.Drawing.Size(121, 21);
            this.cbOperation.TabIndex = 4;
            this.cbOperation.SelectedIndexChanged += new System.EventHandler(this.cbOperation_SelectedIndexChanged);
            // 
            // panelBtns
            // 
            this.panelBtns.Location = new System.Drawing.Point(18, 48);
            this.panelBtns.Name = "panelBtns";
            this.panelBtns.Size = new System.Drawing.Size(315, 117);
            this.panelBtns.TabIndex = 5;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(15, 260);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(37, 13);
            this.labelResult.TabIndex = 7;
            this.labelResult.Text = "Result";
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(246, 201);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 6;
            this.btnCalc.Text = "Calc";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // labelRes
            // 
            this.labelRes.AutoSize = true;
            this.labelRes.Location = new System.Drawing.Point(93, 259);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(10, 13);
            this.labelRes.TabIndex = 8;
            this.labelRes.Text = " ";
            // 
            // btnLike
            // 
            this.btnLike.Location = new System.Drawing.Point(246, 7);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(75, 23);
            this.btnLike.TabIndex = 9;
            this.btnLike.Text = "Like";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Visible = false;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // HypeCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.btnLike);
            this.Controls.Add(this.labelRes);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.panelBtns);
            this.Controls.Add(this.cbOperation);
            this.Controls.Add(this.Operation);
            this.Controls.Add(this.inputDate);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.btnExit);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "HypeCalculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hype Calculator";
            this.Load += new System.EventHandler(this.HypeCalculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label inputDate;
        private System.Windows.Forms.Label Operation;
        private System.Windows.Forms.ComboBox cbOperation;
        private System.Windows.Forms.Panel panelBtns;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Label labelRes;
        private System.Windows.Forms.Button btnLike;
    }
}

