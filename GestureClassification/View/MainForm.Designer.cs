namespace GestureClassification.View
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ErrorMeanLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OverallAccuracyLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CentroidTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.KNNTextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NumofTimesTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.KTextBox = new System.Windows.Forms.TextBox();
            this.ErrorVarianceLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ClassificationButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ExpectedClassLabel = new System.Windows.Forms.Label();
            this.ClassLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ErrorVarianceLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.ErrorMeanLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.OverallAccuracyLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1005, 480);
            this.splitContainer1.SplitterDistance = 399;
            this.splitContainer1.TabIndex = 0;
            // 
            // ErrorMeanLabel
            // 
            this.ErrorMeanLabel.AutoSize = true;
            this.ErrorMeanLabel.Location = new System.Drawing.Point(169, 367);
            this.ErrorMeanLabel.Name = "ErrorMeanLabel";
            this.ErrorMeanLabel.Size = new System.Drawing.Size(0, 13);
            this.ErrorMeanLabel.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Error Mean :";
            // 
            // OverallAccuracyLabel
            // 
            this.OverallAccuracyLabel.AutoSize = true;
            this.OverallAccuracyLabel.Location = new System.Drawing.Point(169, 325);
            this.OverallAccuracyLabel.Name = "OverallAccuracyLabel";
            this.OverallAccuracyLabel.Size = new System.Drawing.Size(0, 13);
            this.OverallAccuracyLabel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Overall Accuracy :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(399, 258);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Closing Eyes";
            this.Column1.Name = "Column1";
            this.Column1.Width = 92;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Looking Down";
            this.Column2.Name = "Column2";
            this.Column2.Width = 101;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Looking Front";
            this.Column3.Name = "Column3";
            this.Column3.Width = 97;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Looking Left";
            this.Column4.Name = "Column4";
            this.Column4.Width = 91;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.CentroidTextBox);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.KNNTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 179);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Training and Scoring";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Centroid Point";
            // 
            // CentroidTextBox
            // 
            this.CentroidTextBox.Location = new System.Drawing.Point(133, 84);
            this.CentroidTextBox.Name = "CentroidTextBox";
            this.CentroidTextBox.Size = new System.Drawing.Size(100, 20);
            this.CentroidTextBox.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(92, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "Train and Score";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "KNN";
            // 
            // KNNTextBox
            // 
            this.KNNTextBox.Location = new System.Drawing.Point(133, 37);
            this.KNNTextBox.Name = "KNNTextBox";
            this.KNNTextBox.Size = new System.Drawing.Size(100, 20);
            this.KNNTextBox.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.comboBox1.AllowDrop = true;
            this.comboBox1.DisplayMember = "0";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Bayesian Classification",
            "K-NN Classification"});
            this.comboBox1.Location = new System.Drawing.Point(233, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.NumofTimesTextBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.KTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 179);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Validation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Number of Times";
            // 
            // NumofTimesTextBox
            // 
            this.NumofTimesTextBox.Location = new System.Drawing.Point(133, 84);
            this.NumofTimesTextBox.Name = "NumofTimesTextBox";
            this.NumofTimesTextBox.Size = new System.Drawing.Size(100, 20);
            this.NumofTimesTextBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Validate!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "K-fold";
            // 
            // KTextBox
            // 
            this.KTextBox.Location = new System.Drawing.Point(133, 37);
            this.KTextBox.Name = "KTextBox";
            this.KTextBox.Size = new System.Drawing.Size(100, 20);
            this.KTextBox.TabIndex = 0;
            // 
            // ErrorVarianceLabel
            // 
            this.ErrorVarianceLabel.AutoSize = true;
            this.ErrorVarianceLabel.Location = new System.Drawing.Point(169, 409);
            this.ErrorVarianceLabel.Name = "ErrorVarianceLabel";
            this.ErrorVarianceLabel.Size = new System.Drawing.Size(0, 13);
            this.ErrorVarianceLabel.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 409);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Error Variance :";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(284, 39);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ClassLabel);
            this.splitContainer2.Panel2.Controls.Add(this.ExpectedClassLabel);
            this.splitContainer2.Panel2.Controls.Add(this.label9);
            this.splitContainer2.Panel2.Controls.Add(this.label7);
            this.splitContainer2.Panel2.Controls.Add(this.ClassificationButton);
            this.splitContainer2.Size = new System.Drawing.Size(315, 438);
            this.splitContainer2.SplitterDistance = 318;
            this.splitContainer2.TabIndex = 3;
            // 
            // ClassificationButton
            // 
            this.ClassificationButton.Location = new System.Drawing.Point(209, 31);
            this.ClassificationButton.Name = "ClassificationButton";
            this.ClassificationButton.Size = new System.Drawing.Size(97, 47);
            this.ClassificationButton.TabIndex = 0;
            this.ClassificationButton.Text = "Classify!";
            this.ClassificationButton.UseVisualStyleBackColor = true;
            this.ClassificationButton.Click += new System.EventHandler(this.ClassificationButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Class";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Expected Class";
            // 
            // ExpectedClassLabel
            // 
            this.ExpectedClassLabel.AutoSize = true;
            this.ExpectedClassLabel.Location = new System.Drawing.Point(102, 71);
            this.ExpectedClassLabel.Name = "ExpectedClassLabel";
            this.ExpectedClassLabel.Size = new System.Drawing.Size(0, 13);
            this.ExpectedClassLabel.TabIndex = 2;
            // 
            // ClassLabel
            // 
            this.ClassLabel.AutoSize = true;
            this.ClassLabel.Location = new System.Drawing.Point(102, 28);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(0, 13);
            this.ClassLabel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 480);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label OverallAccuracyLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NumofTimesTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KTextBox;
        private System.Windows.Forms.Label ErrorMeanLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CentroidTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox KNNTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label ErrorVarianceLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button ClassificationButton;
        private System.Windows.Forms.Label ClassLabel;
        private System.Windows.Forms.Label ExpectedClassLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
    }
}

