namespace Data_Structure_Matrix_Advance
{
    partial class FormDataStructureMatrixAdvance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataStructureMatrixAdvance));
            this.ListViewDisplay = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelName = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.ComboBoxCategory = new System.Windows.Forms.ComboBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.GroupBoxRadioButton = new System.Windows.Forms.GroupBox();
            this.RadioButtonNonLinear = new System.Windows.Forms.RadioButton();
            this.RadioButtonLinear = new System.Windows.Forms.RadioButton();
            this.TextBoxDefinition = new System.Windows.Forms.TextBox();
            this.labelDefinition = new System.Windows.Forms.Label();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonModify = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.statusStripMessage = new System.Windows.Forms.StatusStrip();
            this.StatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.GroupBoxRadioButton.SuspendLayout();
            this.statusStripMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListViewDisplay
            // 
            this.ListViewDisplay.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ListViewDisplay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ListViewDisplay.BackgroundImage")));
            this.ListViewDisplay.BackgroundImageTiled = true;
            this.ListViewDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderCategory});
            this.ListViewDisplay.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListViewDisplay.ForeColor = System.Drawing.Color.White;
            this.ListViewDisplay.FullRowSelect = true;
            this.ListViewDisplay.HideSelection = false;
            this.ListViewDisplay.Location = new System.Drawing.Point(258, 12);
            this.ListViewDisplay.Name = "ListViewDisplay";
            this.ListViewDisplay.Size = new System.Drawing.Size(238, 360);
            this.ListViewDisplay.TabIndex = 0;
            this.ListViewDisplay.UseCompatibleStateImageBehavior = false;
            this.ListViewDisplay.View = System.Windows.Forms.View.Details;
            this.ListViewDisplay.Click += new System.EventHandler(this.ListViewDisplay_Click);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 162;
            // 
            // columnHeaderCategory
            // 
            this.columnHeaderCategory.Text = "Category";
            this.columnHeaderCategory.Width = 72;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.CadetBlue;
            this.labelName.Location = new System.Drawing.Point(22, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(114, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name and Search Box";
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(25, 28);
            this.TextBoxName.Multiline = true;
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(128, 31);
            this.TextBoxName.TabIndex = 2;
            this.TextBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxName_KeyPress);
            // 
            // ComboBoxCategory
            // 
            this.ComboBoxCategory.BackColor = System.Drawing.Color.Crimson;
            this.ComboBoxCategory.FormattingEnabled = true;
            this.ComboBoxCategory.Location = new System.Drawing.Point(25, 95);
            this.ComboBoxCategory.Name = "ComboBoxCategory";
            this.ComboBoxCategory.Size = new System.Drawing.Size(128, 21);
            this.ComboBoxCategory.Sorted = true;
            this.ComboBoxCategory.TabIndex = 3;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.BackColor = System.Drawing.Color.CadetBlue;
            this.labelCategory.Location = new System.Drawing.Point(22, 79);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(49, 13);
            this.labelCategory.TabIndex = 4;
            this.labelCategory.Text = "Category";
            // 
            // GroupBoxRadioButton
            // 
            this.GroupBoxRadioButton.Controls.Add(this.RadioButtonNonLinear);
            this.GroupBoxRadioButton.Controls.Add(this.RadioButtonLinear);
            this.GroupBoxRadioButton.Location = new System.Drawing.Point(25, 137);
            this.GroupBoxRadioButton.Name = "GroupBoxRadioButton";
            this.GroupBoxRadioButton.Size = new System.Drawing.Size(128, 100);
            this.GroupBoxRadioButton.TabIndex = 5;
            this.GroupBoxRadioButton.TabStop = false;
            this.GroupBoxRadioButton.Text = "Structure";
            // 
            // RadioButtonNonLinear
            // 
            this.RadioButtonNonLinear.AutoSize = true;
            this.RadioButtonNonLinear.Location = new System.Drawing.Point(6, 55);
            this.RadioButtonNonLinear.Name = "RadioButtonNonLinear";
            this.RadioButtonNonLinear.Size = new System.Drawing.Size(77, 17);
            this.RadioButtonNonLinear.TabIndex = 7;
            this.RadioButtonNonLinear.TabStop = true;
            this.RadioButtonNonLinear.Text = "Non-Linear";
            this.RadioButtonNonLinear.UseVisualStyleBackColor = true;
            // 
            // RadioButtonLinear
            // 
            this.RadioButtonLinear.AutoSize = true;
            this.RadioButtonLinear.Location = new System.Drawing.Point(6, 19);
            this.RadioButtonLinear.Name = "RadioButtonLinear";
            this.RadioButtonLinear.Size = new System.Drawing.Size(54, 17);
            this.RadioButtonLinear.TabIndex = 6;
            this.RadioButtonLinear.TabStop = true;
            this.RadioButtonLinear.Text = "Linear";
            this.RadioButtonLinear.UseVisualStyleBackColor = true;
            // 
            // TextBoxDefinition
            // 
            this.TextBoxDefinition.Location = new System.Drawing.Point(25, 270);
            this.TextBoxDefinition.Multiline = true;
            this.TextBoxDefinition.Name = "TextBoxDefinition";
            this.TextBoxDefinition.Size = new System.Drawing.Size(227, 102);
            this.TextBoxDefinition.TabIndex = 6;
            // 
            // labelDefinition
            // 
            this.labelDefinition.AutoSize = true;
            this.labelDefinition.BackColor = System.Drawing.Color.CadetBlue;
            this.labelDefinition.Location = new System.Drawing.Point(22, 254);
            this.labelDefinition.Name = "labelDefinition";
            this.labelDefinition.Size = new System.Drawing.Size(51, 13);
            this.labelDefinition.TabIndex = 7;
            this.labelDefinition.Text = "Definition";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.BackColor = System.Drawing.Color.DarkGray;
            this.ButtonSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonSearch.Location = new System.Drawing.Point(177, 28);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 31);
            this.ButtonSearch.TabIndex = 8;
            this.ButtonSearch.Text = "SEARCH";
            this.ButtonSearch.UseVisualStyleBackColor = false;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.BackColor = System.Drawing.Color.DarkGray;
            this.ButtonSave.Location = new System.Drawing.Point(339, 378);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 31);
            this.ButtonSave.TabIndex = 9;
            this.ButtonSave.Text = "SAVE";
            this.ButtonSave.UseVisualStyleBackColor = false;
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.BackColor = System.Drawing.Color.DarkGray;
            this.ButtonOpen.Location = new System.Drawing.Point(258, 378);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(75, 31);
            this.ButtonOpen.TabIndex = 10;
            this.ButtonOpen.Text = "OPEN";
            this.ButtonOpen.UseVisualStyleBackColor = false;
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.BackColor = System.Drawing.Color.DarkGray;
            this.ButtonDelete.Location = new System.Drawing.Point(177, 185);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(75, 31);
            this.ButtonDelete.TabIndex = 11;
            this.ButtonDelete.Text = "DELETE";
            this.ButtonDelete.UseVisualStyleBackColor = false;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonModify
            // 
            this.ButtonModify.BackColor = System.Drawing.Color.DarkGray;
            this.ButtonModify.Location = new System.Drawing.Point(177, 127);
            this.ButtonModify.Name = "ButtonModify";
            this.ButtonModify.Size = new System.Drawing.Size(75, 31);
            this.ButtonModify.TabIndex = 12;
            this.ButtonModify.Text = "MODIFY";
            this.ButtonModify.UseVisualStyleBackColor = false;
            this.ButtonModify.Click += new System.EventHandler(this.ButtonModify_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.BackColor = System.Drawing.Color.DarkGray;
            this.ButtonAdd.Location = new System.Drawing.Point(177, 79);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 31);
            this.ButtonAdd.TabIndex = 13;
            this.ButtonAdd.Text = "ADD";
            this.ButtonAdd.UseVisualStyleBackColor = false;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // statusStripMessage
            // 
            this.statusStripMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusMessage});
            this.statusStripMessage.Location = new System.Drawing.Point(0, 411);
            this.statusStripMessage.Name = "statusStripMessage";
            this.statusStripMessage.Size = new System.Drawing.Size(496, 22);
            this.statusStripMessage.TabIndex = 14;
            this.statusStripMessage.Text = "statusStrip1";
            // 
            // StatusMessage
            // 
            this.StatusMessage.Name = "StatusMessage";
            this.StatusMessage.Size = new System.Drawing.Size(53, 17);
            this.StatusMessage.Text = "Message";
            // 
            // ButtonClear
            // 
            this.ButtonClear.BackColor = System.Drawing.Color.DarkGray;
            this.ButtonClear.Location = new System.Drawing.Point(177, 236);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(75, 31);
            this.ButtonClear.TabIndex = 15;
            this.ButtonClear.Text = "CLEAR";
            this.ButtonClear.UseVisualStyleBackColor = false;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // FormDataStructureMatrixAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(496, 433);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.statusStripMessage);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonModify);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.labelDefinition);
            this.Controls.Add(this.TextBoxDefinition);
            this.Controls.Add(this.GroupBoxRadioButton);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.ComboBoxCategory);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.ListViewDisplay);
            this.Name = "FormDataStructureMatrixAdvance";
            this.Text = "Data Structure Matrix Advance";
            this.Load += new System.EventHandler(this.FormDataStructureMatrixAdvance_Load);
            this.GroupBoxRadioButton.ResumeLayout(false);
            this.GroupBoxRadioButton.PerformLayout();
            this.statusStripMessage.ResumeLayout(false);
            this.statusStripMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListViewDisplay;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.ComboBox ComboBoxCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.GroupBox GroupBoxRadioButton;
        private System.Windows.Forms.RadioButton RadioButtonNonLinear;
        private System.Windows.Forms.RadioButton RadioButtonLinear;
        private System.Windows.Forms.TextBox TextBoxDefinition;
        private System.Windows.Forms.Label labelDefinition;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonModify;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.StatusStrip statusStripMessage;
        private System.Windows.Forms.ToolStripStatusLabel StatusMessage;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderCategory;
        private System.Windows.Forms.Button ButtonClear;
    }
}

