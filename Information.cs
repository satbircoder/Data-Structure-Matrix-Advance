using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure_Matrix_Advance
{
    //6.1 Create a separate class file to hold the four data items of the Data Structure (use the Data Structure Matrix as a guide). Use private properties for the fields
    //which must be of type “string”. The class file must have separate setters and getters, add an appropriate IComparable for the Name attribute. Save the class as “Information.cs”.
    class Information : IComparable<Information>
    {
        private string name;
        private string category;
        private string structure;
        private string definition;
    
        public Information()
        {

        }
        public Information(string newName, string newCategory, string newStructure, string newDefinition)
        {
            SetName(newName);
            SetCategory(newCategory);
            SetStructure(newStructure);
            SetDefinition(newDefinition);
        }
       
        public string GetName()
        {
            return name.ToUpper();
        }
        public void SetName(string aName)
        {
            name = aName.ToUpper();
        }
        public string GetCategory()
        {
            return category.ToUpper();
        }
        public void SetCategory(string aCategory)
        {
            category = aCategory.ToUpper();
        }
        public string GetStructure()
        {
            return structure;
        }
        public void SetStructure(string aStructure)
        {
            structure = aStructure;
        }
        public string GetDefinition()
        {
            return definition;
        }
        public void SetDefinition(string aDefinition)
        {
            definition = aDefinition;
        }
        public int CompareTo(Information other)
        {
            return this.name.CompareTo(other.name);
        }
       
    }

}
