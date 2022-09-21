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
            ListViewDisplay.Items.Clear();
            wikiStorageList.Sort();
            foreach(var information in wikiStorageList)
            {
                ListViewItem lvItem = new ListViewItem(information.GetName());
                lvItem.SubItems.Add(information.GetCategory());
                ListViewDisplay.Items.Add(lvItem);
                
            }
            

        }

        private void ClearInput()
        {
            TextBoxName.Clear();
            TextBoxDefinition.Clear();
            ComboBoxCategory.Text = "";
            foreach(RadioButton rb in GroupBoxRadioButton.Controls.OfType<RadioButton>())
            {
                rb.Checked = false;
            }
        }
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ClearInput();
            ListViewDisplay.SelectedItems.Clear();
        }


        private void FormDataStructureMatrixAdvance_Load(object sender, EventArgs e)
        {
            ListLoader();
            DisplayList();
            CategoryLoad();
                     
        }

        private void CategoryLoad()
        {
            if(File.Exists("Category.txt"))
                {
                string[] category = File.ReadAllLines("Category.txt");
                foreach (var item in category)
                {
                    ComboBoxCategory.Items.Add(item);
                }
            }
            else
            {
                StatusMessage.Text = "File is not available to load";
            }
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
           Information loadSelfTree = new Information("Self-Balanced Tree", "Tree", "Non-Linear", "Self-Balancing Trees are height-balanced  trees that automatically keeps height as small as possible when insertion and deletion operations are performed on tree. The height is typically maintained in order of Log n so that all operations take O(Log n) time on average.");
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

        #region AddButton
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if(DuplicateCheck() == false)
            {
                if(!string.IsNullOrEmpty(TextBoxName.Text) && !string.IsNullOrEmpty(ComboBoxCategory.Text) 
                         && !string.IsNullOrEmpty(GetRadioButton()) && !string.IsNullOrEmpty(TextBoxDefinition.Text))
                {
                    Information addInformation = new Information();
                    addInformation.SetName(TextBoxName.Text);
                    addInformation.SetCategory(ComboBoxCategory.Text);
                    addInformation.SetStructure(GetRadioButton());
                    addInformation.SetDefinition(TextBoxDefinition.Text);
                    wikiStorageList.Add(addInformation);
                }
                else
                {
                    StatusMessage.Text = "All Fields Must Have Data in it to add";
                }
                
            }
            else
            {
                StatusMessage.Text = "Already Exists";
            }
            
            DisplayList();
            ClearInput();
        }

        #endregion AddButton

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

        #region RadioButton

        private void SetRadioButton(int structure)
        {
            foreach(RadioButton rb in GroupBoxRadioButton.Controls.OfType<RadioButton>())
            {
                if(rb.Text == wikiStorageList[structure].GetStructure())
                {
                    rb.Checked = true;
                }
                else
                {
                    rb.Checked = false;
                }
            }
        }

        private string GetRadioButton()
        {
            string rbstructure = "";
            foreach(RadioButton rb in GroupBoxRadioButton.Controls.OfType<RadioButton>())
            {
                if(rb.Checked)
                {
                    rbstructure = rb.Text;
                    break;
                }
                else
                {
                    statusStripMessage.Text = "Not a structure type";
                    rbstructure = statusStripMessage.Text;                }
                
            }
            return rbstructure;

        }


        #endregion RadioButton

        #region Duplicate Check

        private bool DuplicateCheck()
        {
            bool found = false;
            foreach(var item in wikiStorageList)
            {
                if(item.GetName() == TextBoxName.Text)
                {
                    found = true;
                    break;
                }
                else
                {
                    found = false;
                }
            }
            return found;
        }

        #endregion Duplicate Check

        #region Delete
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (ListViewDisplay.FocusedItem != null && TextBoxName.Text != "" && ComboBoxCategory.Text != "" && TextBoxDefinition.Text != "" 
                && GetRadioButton() != null)
            {
                for (int i = 0; i < wikiStorageList.Count; i++)
                {
                    if (ListViewDisplay.Items[i].Selected)
                    {
                        var confirmation = MessageBox.Show("Are You Sure You want to delete " + wikiStorageList[i].GetName(), "System Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(confirmation == DialogResult.Yes)
                        {
                            wikiStorageList.RemoveAt(i);
                            break;
                        }
                        else
                        {
                            StatusMessage.Text = "User Has Canceled to delete";
                            break;
                        }
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Select the item from the list and none of the data field should be empty", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            
            
           
            DisplayList();
            ClearInput();
        }

        #endregion Delete

        #region Modify
        private void ButtonModify_Click(object sender, EventArgs e)
        {
            int currentItem = ListViewDisplay.SelectedIndices[0];
            wikiStorageList[currentItem].SetName(TextBoxName.Text);
            wikiStorageList[currentItem].SetCategory(ComboBoxCategory.Text);
            wikiStorageList[currentItem].SetStructure(GetRadioButton());
            wikiStorageList[currentItem].SetDefinition(TextBoxDefinition.Text);
            DisplayList();
        }

        #endregion Modify

        #region Search
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(TextBoxName.Text))
            {
                Information findData = new Information();
                findData.SetName(TextBoxName.Text.ToUpper());
                int found = wikiStorageList.BinarySearch(findData);
                if(found >= 0)
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
                    StatusMessage.Text = "NOt in the List";
                }
            }
            

        }

        #endregion Search
    }

}
