using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace BaseFormsLib
{
    public partial class BaseList : BaseFormEx
    {        
        protected string _sQuery;
        protected string _tableName;
        protected string _title;                
                
        public BaseList()
        {
            InitializeComponent();              
            this.CenterToParent();          
        }

        //дополнительная инициализация контролов
        protected void InitControls()
        {
            InitFocusHandlers();
            
            ExtraInit();
            if (_title != null && _title.Length > 0)
                this.Text = _title;

            InitHandlers();
            
            UpdateDataGrid();

            if (IsForReadOnly())
                btnAdd.Enabled = btnRemove.Enabled = false;
        }

        protected virtual bool IsForReadOnly()
        {
            return false;
        }

        protected virtual void ExtraInit()
        {            
        }

        public virtual void InitHandlers()
        {            
        }

        public virtual void UpdateDataGrid()
        {
            throw new NotImplementedException();
        }

        //кнопка добавить
        /// <summary>
        /// open new card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenCard(null, this, null);        
        }
            
        /// <summary>
        /// open book card
        /// </summary>
        /// <param name="itemId"></param>
        protected virtual void OpenCard(string itemId)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// open card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCard_Click(object sender, EventArgs e)
        {
            if (Dgv.CurrentCell != null && Dgv.CurrentCell.RowIndex > -1)
            {
                string itemId = Dgv.Rows[Dgv.CurrentCell.RowIndex].Cells["Id"].Value.ToString();
                if (itemId != "")
                    OpenCard(itemId, this, Dgv.CurrentRow.Index);
            }
        }

        protected virtual void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCard_Click(null, null);
        }

        protected virtual void OpenCard(string itemId, BaseFormEx formOwner, int? index)
        {
            OpenCard(itemId);
        }
       
        /// <summary>
        /// remove item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnRemove_Click(object sender, EventArgs e)
        {
            if (IsForReadOnly())
                return;

            if (Dgv.CurrentCell != null && Dgv.CurrentCell.RowIndex > -1)
            {
                if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string itemId = Dgv.CurrentRow.Cells["Id"].Value.ToString();
                    try
                    {
                        Delete(_tableName, itemId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Каскадное удаление запрещено: " + ex.Message, "Ошибка!");
                    }

                    UpdateDataGrid();
                }
            }           
        }

        protected virtual void Delete(string tableName, string id)
        {
            throw new NotImplementedException();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void BookList_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnClosed();
        }

        protected virtual void OnClosed()
        {
            return;
        }        
    }
}
