using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseFormsLib 
{
    public partial class BaseCard : BaseFormEx
    {  
        protected string _Id;        
        protected string _tableName;
        protected string _title;  
        protected bool _isModified;      
               
        public BaseCard()
        {
            InitializeComponent();            
            this.CenterToParent();              
        }

        /// <summary>
        /// Инициализация - сначала ExtraInit(), затем InitHandlers(), затем FillCard()
        /// </summary>
        protected virtual void InitControls()
        {            
            InitFocusHandlers();
                        
            ExtraInit(); 
            InitHandlers();                   
            FillCard();            
    
            if (_Id == null)
            {
                _isModified = true;
                btnSaveChange.Text = Constants.BTN_SAVE_TITLE;
                this.Text = Constants.CARD_TITLE + _title + Constants.CARD_MODIFIED;               
            }
            else
            {
                _isModified = false;                          
                ReadOnlyCard();
            }

            SetReadOnlyFieldsAfterFill();
        }        

        protected virtual bool IsForReadOnly()
        {
            return false;
        }        

        public string Id
        {
            get { return _Id; }
        }

        public string CardTitle
        {
            get { return _title; }
            set { _title = value; }
        }

        protected virtual void ExtraInit()
        {            
        }

        protected virtual void FillCard()
        {
            throw new NotImplementedException();
        }

        protected virtual void InitHandlers()
        {            
        }

        protected virtual void NullHandlers()
        {            
        }
        /// <summary>
        /// Установить часть полей доступных для взаимодействия после заполнения карточки.
        /// </summary>
        protected virtual void SetReadOnlyFieldsAfterFill()
        {
            if (IsForReadOnly())
            {
                btnSaveChange.Enabled = false;
                btnSaveAsNew.Enabled = false;
            }          
        }

        /// <summary>
        /// карточка открывается в режиме read-only
        /// </summary>
        protected virtual void ReadOnlyCard()
        {
            this.Text = Constants.CARD_TITLE + _title + Constants.CARD_READ_ONLY;
            btnSaveChange.Text = Constants.BTN_CHANGE_TITLE;
            
            SetAllFieldsNotEnabled();  
            
            btnClose.Enabled = true;

            if (!IsForReadOnly())
            {
                btnSaveChange.Enabled = true;
                btnSaveAsNew.Enabled = true;
            }
        }

        protected virtual void SetAllFieldsNotEnabled()
        {
            foreach (Control crl in this.Controls)
                crl.Enabled = false;
        }

        /// <summary>
        /// убрать режим read-only
        /// </summary>
        protected virtual void DeleteReadOnlyCard()
        {
            this.Text = Constants.CARD_TITLE + _title + Constants.CARD_MODIFIED;
            btnSaveChange.Text = Constants.BTN_SAVE_TITLE;
                       
            SetAllFieldsEnabled();
            SetReadOnlyFields();
  
            btnSaveAsNew.Enabled = false;    
        }

        protected virtual void SetAllFieldsEnabled()
        {
            foreach (Control crl in this.Controls)
                crl.Enabled = true;
        }

        protected virtual void SetReadOnlyFields()
        {            
        }

        protected virtual bool GetIsOpen()
        {
            return false;
        }
      
        protected virtual void SetIsOpen()
        {            
        }

        protected virtual void DeleteIsOpen()
        {            
        }       

        /// <summary>
        /// on SaveChangeClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveChange_Click(object sender, EventArgs e)
        {
            if (SaveClick() && !_isModified)
                CloseCardAfterSave();       
        }

        //Closing card after save
        protected virtual void CloseCardAfterSave()
        {            
        }

        protected virtual bool SaveClick()
        {
            if (btnSaveChange.Enabled)
            {
                try
                {
                    if (_Id == null)
                    {
                        if (SaveRecord())
                        {                             
                            OnSave();
                            OnSaveNew();
                            _isModified = false;
                            ReadOnlyCard();
                            return true;                            
                        }
                        return false;
                    }
                    else
                    {
                        if (!_isModified)
                        {
                            if (GetIsOpen())
                            {
                                ShowMessageIsOpen();
                                return false;
                            }
                            else
                            {
                                _isModified = true;
                                DeleteReadOnlyCard();                                                           
                                SetIsOpen();
                                return true;
                            }                            
                        }
                        else
                        {
                            if (SaveRecord())
                            {
                                OnSave();
                                _isModified = false;
                                ReadOnlyCard(); 
                                DeleteIsOpen();
                                return true;
                            }
                            return false;
                        }
                    }
                }
                catch (Exception de)
                {                    
                    throw new Exception("Ошибка обновления данных " + de.Message);                                       
                }
            }
            return false;
        }

        /// <summary>
        /// Проверяет карточку на наличие Id и сохраняет данные в случае необходимости
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckCardForNewAndSave()
        {
            if (_Id == null)
            {
                if (MessageBox.Show("Данное действие приведет к сохранению записи, продолжить?", "Сохранить", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return SaveClick();
                else
                    return false;
            }
            else
                return true;
        }

        protected virtual void ShowMessageIsOpen()
        {
            MessageBox.Show("Карточка открыта другим пользователем и поэтому доступна только для чтения", "Ошибка");                            
        }
        
        protected virtual void OnSave()
        {           
        }     
        protected virtual void OnSaveNew()
        {           
        }

        protected virtual void SaveAsNew()
        {
            if (MessageBox.Show("Сделать новую запись в базе?", "Добавление записи", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (_Id != null)
                    {
                        if (!_isModified)
                        {
                            _Id = null;
                            _isModified = true;
                            PrepareForSaveAsNew();
                            DeleteReadOnlyCard();
                            btnSaveChange.Text = Constants.BTN_SAVE_TITLE;                                                                                 
                        }
                    }
                }
                catch (Exception de)
                {
                    throw new Exception("Ошибка обновления данных " + de.Message);
                }
            }
        }

        protected virtual void PrepareForSaveAsNew()
        {
            return;
        }

        protected virtual bool SaveRecord()
        {
            throw new NotImplementedException();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BookCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnClosed();
        }

        protected virtual void OnClosed()
        {
        }

        private void BaseCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isModified)
            {
                if (btnSaveChange.Visible && btnSaveChange.Enabled)
                {
                    DialogResult dr = MessageBox.Show("Сохранить сделанные изменения?", "Сохранить", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Cancel)
                        e.Cancel = true;
                    else if (dr == DialogResult.Yes)
                        if (!SaveClick())
                            e.Cancel = true;
                }             
            }
            
            if (_Id != null && _isModified)
                DeleteIsOpen();            
        }

        private void btnSaveAsNew_Click(object sender, EventArgs e)
        {
            SaveAsNew();
        }              
    }
}