using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Structure_Matrix_Advance
{
    public partial class FormDataStructureMatrixAdvance : Form
    {
        public FormDataStructureMatrixAdvance()
        {
            InitializeComponent();
        }
        List<Information> wikiStorageList = new List<Information>();

        #region Utilities
        public void DisplayList()
        {
            listViewDisplay.Items.Clear();

            foreach(var information in wikiStorageList)
            {
                ListViewItem lvItem = new ListViewItem(information.GetName());
                lvItem.SubItems.Add(information.GetCategory());
                listViewDisplay.Items.Add(lvItem);
                
            }
        }


        #endregion Utilities

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Information addInformation = new Information();
            addInformation.SetName(textBoxName.Text);
            addInformation.SetCategory(comboBoxCategory.Text);
            addInformation.SetDefinition(textBoxDefinition.Text);
            wikiStorageList.Add(addInformation);
            DisplayList();
        }

        private void listViewDisplay_Click(object sender, EventArgs e)
        {
            string currentItem = listViewDisplay.SelectedIndices.ToString();
            
            
        }
    }

}
