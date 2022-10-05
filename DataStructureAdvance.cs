using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Linq.Expressions;
using System.Diagnostics;
// Satbir Singh
// Date: 05/10/2022
// Student ID 30048567
// Data Structure Matrix Using Class Structure
//6.16 All code is required to be adequately commented. Map the programming criteria and
//features to your code/methods by adding comments above the method signatures. Ensure your code is compliant with the CITEMS coding standards (refer http://www.citems.com.au/).
namespace Data_Structure_Matrix_Advance
{
    public partial class FormDataStructureMatrixAdvance : Form
    {
        public FormDataStructureMatrixAdvance()
        {
            InitializeComponent();
        }
        //6.2 Create a global List<T> of type Information called Wiki.
        List<Information> wikiStorageList = new List<Information>();
        string fileName = "Definition.bin";

        //6.3 Create a button method to ADD a new item to the list.
        //Use a TextBox for the Name input, ComboBox for the Category, Radio group for the Structure and Multiline TextBox for the Definition.
       
        #region AddButton
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Information addInformation = new Information();
            if (InputStringCheck().Equals(true))
            {
                try
                {
                    if (ValidName(TextBoxName.Text).Equals(false))
                    {
                        addInformation.SetName(TextBoxName.Text);
                        addInformation.SetCategory(ComboBoxCategory.Text);
                        addInformation.SetStructure(GetRadioButton());
                        addInformation.SetDefinition(TextBoxDefinition.Text);
                        wikiStorageList.Add(addInformation);

                        if (!ComboBoxCategory.Items.Equals(addInformation.GetCategory()))// Adding Item to Category as well 
                        {
                            ComboBoxCategory.Items.Add(addInformation.GetCategory());
                        }
                        DisplayList();
                        int addIndex = wikiStorageList.BinarySearch(addInformation);// Selecting the Item After Added
                        wikiStorageList.ElementAt(addIndex);
                        ListViewDisplay.Items[addIndex].Selected = true;
                        ListViewDisplay.Focus();
                        StatusLabel.Text = "Added Successfully";
                        
                    }
                    else
                    {
                        StatusLabel.Text = "Already Exists";
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Something Went Wrong Please Try Again", "Add Button Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                StatusLabel.Text = "All Fields Must Have Data in it to add";
            }
            ClearInput();
        }

        #endregion AddButton

        //6.4 Create a custom method to populate the ComboBox when the Form Load method is called. The six categories must be read from a simple text file.
        #region Category Load From Text File
        private void CategoryLoad()
        {
            if (File.Exists("Category.txt"))// Checking File for existing
            {
                string[] category = File.ReadAllLines("Category.txt");//Reading from FIle 
                foreach (var item in category)
                {
                    ComboBoxCategory.Items.Add(item);//Adding Category items
                }
            }
            else
            {
                StatusLabel.Text = "File is not available to load";
            }
        }

        #endregion

        //6.5 Create a custom ValidName method which will take a parameter string value from the Textbox Name and returns a Boolean after checking for duplicates.
        //Use the built in List<T> method “Exists” to answer this requirement.
        #region Duplicate Check

        private bool ValidName(string checkName)//Checking Name for existing
        {
            bool valid = false;
            if (wikiStorageList.Exists(x => x.GetName().Equals(checkName.ToUpper())))
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            return valid;
        }
        #endregion Duplicate Check

        //6.6 Create two methods to highlight and return the values from the Radio button GroupBox.
        //The first method must return a string value from the selected radio button (Linear or Non-Linear).
        //The second method must send an integer index which will highlight an appropriate radio button.
        #region RadioButton

        private void SetRadioButton(int structure)
        {
            foreach (RadioButton rb in GroupBoxRadioButton.Controls.OfType<RadioButton>())// Setting Radio button Checked  
            {
                if (rb.Text == wikiStorageList[structure].GetStructure())
                {
                    rb.Checked = true;
                }
                else
                {
                    rb.Checked = false;
                }
            }
        }

        private string GetRadioButton()// for getting Structure from selection of the Radio Button
        {
            string rbstructure = "";
            foreach (RadioButton rb in GroupBoxRadioButton.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    rbstructure = rb.Text;
                    break;
                }
                else
                {
                    statusStripMessage.Text = "Not a structure type";
                    rbstructure = statusStripMessage.Text;
                }

            }
            return rbstructure;

        }


        #endregion RadioButton

        //6.7 Create a button method that will delete the currently selected record in the ListView.
        //Ensure the user has the option to backout of this action by using a dialog box. Display an updated version of the sorted list at the end of this process.
        #region Delete
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (ListViewDisplay.SelectedItems.Count != 0 || !string.IsNullOrEmpty(TextBoxName.Text))// Work only if text box is data in it and selected item from the List View
            {
                try
                {
                    for (int i = 0; i < wikiStorageList.Count; i++)
                    {
                        if (ListViewDisplay.Items[i].Selected || TextBoxName.Text.ToUpper().Equals(wikiStorageList[i].GetName()))// if Get the item to delete
                        {
                            var confirmation = MessageBox.Show("Are You Sure You want to delete " + wikiStorageList[i].GetName(), "System Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (confirmation == DialogResult.Yes)
                            {
                                StatusLabel.Text = wikiStorageList[i].GetName() + " Has Been Deleted Successfully";
                                wikiStorageList.RemoveAt(i);
                                DisplayList();
                                break;
                            }
                            else if (confirmation == DialogResult.No)
                            {
                                StatusLabel.Text = "User Has Canceled to Delete";
                            }
                        }
                        else
                        {
                            StatusLabel.Text = "Item not in the List";
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something Went Wrong please try again", "Delete Button Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Select The Item from the List OR Enter the name of the item in Name TextBox to delete",
                    "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearInput();
        }

        #endregion Delete

        //6.8 Create a button method that will save the edited record of the currently selected item in the ListView.
        //All the changes in the input controls will be written back to the list. Display an updated version of the sorted list at the end of this process.
        #region Modify
        private void ButtonModify_Click(object sender, EventArgs e)
        {
            if (ListViewDisplay.SelectedItems.Count != 0 && InputStringCheck().Equals(true))
            {
                try
                {
                    int currentItem = ListViewDisplay.FocusedItem.Index;//finding index of the current selected item
                    var confirmation = MessageBox.Show("Are You Sure to Edit " + wikiStorageList[currentItem].GetName(), "Edit Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmation == DialogResult.Yes)// Modifying if User Select Yes
                    {
                        StatusLabel.Text = wikiStorageList[currentItem].GetName() + " has been modified on user's Request";
                        wikiStorageList[currentItem].SetName(TextBoxName.Text);
                        wikiStorageList[currentItem].SetCategory(ComboBoxCategory.Text);
                        wikiStorageList[currentItem].SetStructure(GetRadioButton());
                        wikiStorageList[currentItem].SetDefinition(TextBoxDefinition.Text);
                        DisplayList();
                        ClearInput();
                    }
                    else
                    {
                        StatusLabel.Text = "User Has Canceled Modification";
                    }


                }
                catch (IOException)
                {
                    MessageBox.Show("Something Went Wrong Please Try Again");
                }
            }
            else
            {
                StatusLabel.Text = "Please select the Item from list to modify";
            }

        }
        #endregion Modify

        //6.9 Create a single custom method that will sort and then display the Name and Category from the wiki information in the list.
        #region Display
        public void DisplayList()
        {
            ListViewDisplay.Items.Clear();
            wikiStorageList.Sort();
            foreach (var information in wikiStorageList)
            {
                ListViewItem lvItem = new ListViewItem(information.GetName());
                lvItem.SubItems.Add(information.GetCategory());
                ListViewDisplay.Items.Add(lvItem);

            }
        }
        #endregion Display

        //6.10 Create a button method that will use the builtin binary search to find a Data Structure name.
        //If the record is found the associated details will populate the appropriate input controls and highlight the name in the ListView.
        //At the end of the search process the search input TextBox must be cleared.
        #region Search
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxName.Text))
            {
                try
                {
                    Information findData = new Information();
                    findData.SetName(TextBoxName.Text);
                    int found = wikiStorageList.BinarySearch(findData);//Built in Binary Search Method and setting the focus on the item if found it 
                    if (found >= 0)
                    {
                        ListViewDisplay.SelectedItems.Clear();
                        ListViewDisplay.Items[found].Selected = true;
                        ListViewDisplay.Focus();
                        TextBoxName.Text = wikiStorageList[found].GetName();
                        ComboBoxCategory.Text = wikiStorageList[found].GetCategory();
                        SetRadioButton(found);
                        TextBoxDefinition.Text = wikiStorageList[found].GetDefinition();

                    }
                    else
                    {
                        StatusLabel.Text = "Searched Item is not in the List";
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Something Went Wrong Please Try Again");
                }
            }
            else
            {
                MessageBox.Show("Enter the Name in Search Box", "Search Informatio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        #endregion Search

        //6.11 Create a ListView event so a user can select a Data Structure Name
        //from the list of Names and the associated information will be displayed in the related text boxes combo box and radio button.
        #region ClickDisplay
        private void ListViewDisplay_Click(object sender, EventArgs e)
        {
            int currentItem = ListViewDisplay.SelectedIndices[0];
            TextBoxName.Text = wikiStorageList[currentItem].GetName();
            ComboBoxCategory.Text = wikiStorageList[currentItem].GetCategory();
            SetRadioButton(currentItem);
            TextBoxDefinition.Text = wikiStorageList[currentItem].GetDefinition();
        }

        #endregion Click Display

        //6.12 Create a custom method that will clear and reset the TextBoxes, ComboBox and Radio button
        #region Reset_Input
        private void ClearInput()// Clearing Everything from the fields
        {
            TextBoxName.Clear();
            TextBoxDefinition.Clear();
            ComboBoxCategory.Text = "";
            foreach (RadioButton rb in GroupBoxRadioButton.Controls.OfType<RadioButton>())
            {
                rb.Checked = false;
            }
           
        }
        #endregion Reset_Input

        //6.13 Create a double click event on the Name TextBox to clear the TextBboxes, ComboBox and Radio button.
        #region Double_Click TextBox
        private void TextBoxName_DoubleClick(object sender, EventArgs e)
        {
            ClearInput();
        }
        #endregion Double_Click TextBox

        //6.14 Create two buttons for the manual open and save option;
        //this must use a dialog box to select a file or rename a saved file. All Wiki data is stored/retrieved using a binary reader/writer file format.
        #region Save
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();// save file dialog filtering and saving file on user request 
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.Filter = "BIN |*.bin";
            saveFileDialog.Title = "Save Binary File";
            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr.Equals(DialogResult.Cancel))
            {
                saveFileDialog.FileName = fileName;
                StatusLabel.Text = "File Has been Saved with Default Name As " + Path.GetFileName(this.fileName);
            }
            if (dr.Equals(DialogResult.OK))
            {
                fileName = saveFileDialog.FileName;
                StatusLabel.Text = "File Has been saved with " + Path.GetFileName(fileName);
            }
            try
            {
                using (var stream = File.Open(fileName, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))// writting on to file using binary writer
                    {
                        foreach (var item in wikiStorageList)
                        {
                            writer.Write(item.GetName());
                            writer.Write(item.GetCategory());
                            writer.Write(item.GetStructure());
                            writer.Write(item.GetDefinition());
                        }
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Unable to Save File", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion Save

        #region Open
        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "BIN |*.bin";
            openFileDialog.Title = "Open Saved File";
            DialogResult or = openFileDialog.ShowDialog();
            if (or.Equals(DialogResult.OK))
            {
                fileName = openFileDialog.FileName;
                StatusLabel.Text = Path.GetFileName(fileName) + " Has Been Loaded";
            }
            if (or.Equals(DialogResult.Cancel))
            {
                StatusLabel.Text = "User Has Canceled to Open File";
            }
            try
            {
                wikiStorageList.Clear();
                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        while (stream.Position < stream.Length)
                        {
                            Information newDefinition = new Information();
                            newDefinition.SetName(reader.ReadString());
                            newDefinition.SetCategory(reader.ReadString());
                            newDefinition.SetStructure(reader.ReadString());
                            newDefinition.SetDefinition(reader.ReadString());
                            wikiStorageList.Add(newDefinition);
                        }

                    }

                }
                DisplayList();
            }
            catch (IOException)
            {
                MessageBox.Show("Unable to Open FIle", "Open File Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Open

        //6.15 The Wiki application will save data when the form closes. 

        #region Form_Closed Save
        private void FormDataStructureMatrixAdvance_FormClosed(object sender, FormClosedEventArgs e)// Saving file with lastData.bin name on form closing
        {
            string fileName = "lastData.bin";
           SaveFileDialog saveFileDialog = new SaveFileDialog();
           saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.FileName = fileName;
            try
            {
                using (var stream = File.Open(fileName, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        foreach (var item in wikiStorageList)
                        {
                            writer.Write(item.GetName());
                            writer.Write(item.GetCategory());
                            writer.Write(item.GetStructure());
                            writer.Write(item.GetDefinition());
                        }
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Unable to Save File", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        #endregion Form_Closed Save

        // FormLoad Methods, Null Input check method, Clear Button Code
        #region Utilities
        private void ButtonClear_Click(object sender, EventArgs e)// Can use clear button to clear text boxes and list view focus
        {
            if(InputStringCheck()==true || ListViewDisplay.SelectedItems.Count !=0)

            {
                ClearInput();
                StatusLabel.Text = "All Fields Cleared Successfully";
                ListViewDisplay.SelectedItems.Clear();
            }
            else
            {
                StatusLabel.Text = "Nothing to Clear";
            }

        }
        private void FormDataStructureMatrixAdvance_Load(object sender, EventArgs e)// display the data using constructor from class through List loader method and radio button to uncheck
        {
            ListLoader();
            DisplayList();
            CategoryLoad();
            StatusMessage.Text = "Message:";
            foreach(RadioButton rb in GroupBoxRadioButton.Controls.OfType<RadioButton>())// setting radio button to false 
            {
                rb.Checked = false;
            }
        }
        private bool InputStringCheck()// Function to check values in data fields 
        {
            if(!string.IsNullOrEmpty(TextBoxName.Text) && !string.IsNullOrEmpty(TextBoxDefinition.Text) 
                && !string.IsNullOrEmpty(ComboBoxCategory.Text) && !string.IsNullOrEmpty(GetRadioButton()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void FormDataStructureMatrixAdvance_MouseMove(object sender, MouseEventArgs e)
        {
            StatusLabel.Text = "";
        }
       
        private void ListLoader()// Loaded list using Class Constructor
        {
           Information loadArray = new Information("Array", "Array", "Linear", "Arrays are used to store multiple values in a single variable, instead of declaring separate variables for each value.");
           wikiStorageList.Add(loadArray);
           Information load2DArray = new Information("2D Dimensional Array", "Array", "Linear", "Two-dimensional (2D) arrays are indexed by two subscripts, one for the row and one for the column. Each element in the 2D array must by the same type, either a primitive type or object type.");
           wikiStorageList.Add(load2DArray);
           Information loadList = new Information("List", "List", "Linear", "A list is a sequence of elements. In its simplest form, a list can be implemented as an array. However, the term list usually refers to a linked list with each element of the list (called a node) containing pointers to one or more other list items.");
           wikiStorageList.Add(loadList);
           Information loadLinkList = new Information("Linked List", "List", "Linear", "A linked list is a linear collection of data elements whose order is not given by their physical placement in memory. Instead, each element points to the next. It is a data structure consisting of a collection of nodes which together represent a sequence.");
           wikiStorageList.Add(loadLinkList);
           Information loadSelfTree = new Information("Self Balanced Tree", "Tree", "Non-Linear", "Self-Balancing Trees are height-balanced  trees that automatically keeps height as small as possible when insertion and deletion operations are performed on tree. The height is typically maintained in order of Log n so that all operations take O(Log n) time on average.");
           wikiStorageList.Add(loadSelfTree);
           Information loadHeap = new Information("Heap", "Tree", "Non-Linear", "It is a complete binary tree that satisfies the heap property, where any given node is always greater than its child node/s and the key of the root node is the largest among all other nodes. This property is also called max heap property and reverse to it is known as Min heap property.");
           wikiStorageList.Add(loadHeap);
           Information loadBinaryTree = new Information("Binary Search Tree", "Tree", "Non-Linear", "Binary Search Tree		Non-Linear	Binary search tree is a data structure that quickly allows us to maintain a sorted list of numbers.");
           wikiStorageList.Add(loadBinaryTree);
           Information loadGraph = new Information("Graph", "Graphs", "Non-Linear", "A graph is a data structure that organizes data according to the relationships of its elements in a geometric space. The elements are usually vertices (points in the graph) and edges (the connections between vertices).");
           wikiStorageList.Add(loadGraph);
           Information loadSet = new Information("Set", "Abstract", "Non-Linear", "A set of collection of objects need not to be in any particular order. It is just applying the mathematical concepts in computer where elements should not be repeated and they should have valid reason to be in the set.");
           wikiStorageList.Add(loadSet);
           Information loadQueue = new Information("Queue", "Abstract", "Linear", "A queue is a sequential collection where elements are added to the end of the queue, and removed from the beginning. It is a FIFO data structure (first in, first out ). It is most efficiently implemented with a doubly-linked list.");
           wikiStorageList.Add(loadQueue);
           Information loadStack = new Information("Stack", "Abstarct", "Linear", "A stack is a sequential collection of elements where only the last element (at the top of the stack) can be modified. A new element can be pushed onto the stack, in which case, it becomes the last element of the stack, and the stack's length increases by 1.");
           wikiStorageList.Add(loadStack);
           Information loadHashTable = new Information("Hash Table", "Hash", "Non-Linear", "A hash table or hash map is a type of associative array where the keys are the computed hashes of their values");
           wikiStorageList.Add(loadHashTable);
        }

        #endregion Utilities 

        // Key Press and Copy Paste Event Control for textbox name and Category only for KEY_Press
        #region Invalid Character 

        private void Key_Press(object sender, KeyPressEventArgs e)// handling character and only allows ctrl key to perform
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsLetterOrDigit(e.KeyChar)
                && !char.IsSeparator(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.Handled.Equals(true))
            {
                StatusLabel.Text = "Invalid Input";
            }
            else
            {
                StatusLabel.Text = "";
            }
        }
        private void TextBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Key_Press(sender,e);
        }
        private void ComboBoxCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            Key_Press(sender, e);
        }
        private void TextBoxName_TextChanged(object sender, EventArgs e)// handling copy and paste of symbols
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TextBoxName.Text, "([^0-9][^a-z][^A-Z])"+ "([^0-9][^a-z][^A-Z]+)^*$"))
            {
                TextBoxName.Text = "";
                StatusLabel.Text = "Only Letter and Digits Allowed";
                
            }
            else
            {
                TextBoxName.Text = ((TextBox)sender).Text;

            }
        }
        #endregion Invalid Character

        
        private void TextDocument(string text)
        {
            string myFile = "TestFile.txt";
            if (!File.Exists(myFile))
            {
                File.Create(myFile);

            }
            TextWriterTraceListener myTextListener = new TextWriterTraceListener(myFile);
            Trace.Listeners.Add(myTextListener);
            Trace.Write(text);
            Trace.Flush();

        }
        
    }

}
