using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure_Matrix_Advance
{
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
            return name;
        }
        public void SetName(string aName)
        {
            name = aName.ToUpper();
        }
        public string GetCategory()
        {
            return category;
        }
        public void SetCategory(string aCategory)
        {
            category = aCategory;
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
