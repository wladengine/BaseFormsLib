using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EducServLib;

namespace BaseFormsLib
{
    public delegate void ComboEventHandler();
    public partial class MultiSelectCombo : UserControl
    {
        private SortedList _selectedIds;
        private List<string> lItems;        
        private int iChangedIndex;
        private bool sidNO; 
        
        public ComboEventHandler selectedIndexChanged;
        public bool isMultiChoice;
        public List<string> lSelected;
        
        public MultiSelectCombo()
        {
            _selectedIds = new SortedList();
            lItems = new List<string>();            
            lSelected = new List<string>();
            InitializeComponent();           
        }

        public ComboBox ComboObject
        {
            get { return this.Combo; }
        }

        public SortedList SelectedIds
        {
            get { return _selectedIds; }
            set { _selectedIds = value; }
        }

        public List<int?> SelectedIdsInt
        {
            get 
            {
                List<int?> lst = new List<int?>();
                foreach (int? item in _selectedIds)
                    lst.Add(item);

                return lst; 
            }            
        }

        public List<string> SelectedIdsString
        {
            get
            {
                List<string> lst = new List<string>();
                foreach (string item in _selectedIds)
                    lst.Add(item);

                return lst;
            }             
        } 

        //функция заполнения комбобокса
        public void FillCombo(List<KeyValuePair<string, string>> lstValues, bool hasNo, bool hasAll)
        {
            ComboServ.FillCombo(Combo, lstValues, hasNo, hasAll);            
        }

        //функция заполнения комбобокса
        public void FillCombo(List<string> lstValues, bool hasNo, bool hasAll)
        {
            ComboServ.FillCombo(Combo, lstValues, hasNo, hasAll);
        }    

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = Combo.SelectedIndex;

            if (isMultiChoice && i != iChangedIndex)
            {
                RemoveLast();
                isMultiChoice = false;
            }
            if (!sidNO && selectedIndexChanged != null)
            {
                selectedIndexChanged();
            }
            iChangedIndex = i;
        }

        private void ComboBoxEx_Resize(object sender, EventArgs e)
        {
            this.Combo.Width = this.Width - this.btnSelect.Width - 3;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string,string>>();
            foreach(KeyValuePair<string,string> item in Combo.Items)
            {
                lst.Add(item);
            }

            MultiChoice mc = new MultiChoice(this, lst, SelectedIdsString);
            mc.ShowDialog();
        }


        public void RemoveLast()
        {
            if (isMultiChoice)
                if (Combo.Items.Count > 1)
                    this.Combo.Items.RemoveAt(Combo.Items.Count - 1);
        }

        public void FillWithSelected(List<string> list)
        {
            lSelected = list;

            string sItem = Util.BuildStringWithCollection(lSelected);

            if (isMultiChoice)
            {
                RemoveLast();
                isMultiChoice = false;
            }
            //isMultiChoice = true;

            AddItem(sItem);

            sidNO = true;
            SelectedItem = sItem;
            sidNO = false;

            isMultiChoice = true;
            if (selectedIndexChanged != null)
                selectedIndexChanged();
        }
    }
}
