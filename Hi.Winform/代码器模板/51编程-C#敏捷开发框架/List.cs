
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Hi.Common;

namespace Hi.Client
{
    public partial class Frm$ClassName$ : Hi.Client.BaseForm.BaseFormList
    {
        
        public Frm$ClassName$()
        {
           
            this.pageDataGridViewEx1.ClearDataGridView();
            //DataGridViw����
            this.pageDataGridViewEx1.IsShowCheckBox = 1;
            this.pageDataGridViewEx1.MyColumnName = "$MyColumnName$";
            this.pageDataGridViewEx1.MyColumnTitle = "$MyColumnTitle$";
            this.pageDataGridViewEx1.SetDgvHeader();
            
            this.KeyName = "$KeyName$";
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
          
            this.pageDataGridViewEx1.SetNavButtonEnabled(true, true, true, false, false);
            
        }
       
       
        //������Դ
        protected override void  ListData()
        {
            try
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                
                int totalcount = Hi.IBLL.HiInstanceBLL.$ClassName$BLL().TotalCount(dict);
                this.pageDataGridViewEx1.TotalCount = totalcount;
                if (totalcount > 0)
                {
                    this.pageDataGridViewEx1.SetPageButton(true);
                    
                    DataSet ds = Hi.IBLL.HiInstanceBLL.$ClassName$BLL().List(dict,this.pageDataGridViewEx1.CurrentPage,this.pageDataGridViewEx1.PageSize,"id");

                    if (ds != null)
                    {
                        this.pageDataGridViewEx1.MyDataTable = ds.Tables[0];
                        this.pageDataGridViewEx1.BindingData(true);  
                    }
                    //�������費�ɼ�
                    this.pageDataGridViewEx1.ucdgv.Columns[this.KeyName].Visible = false;
                }
                else
                {
                    this.pageDataGridViewEx1.SetPageButton(false);
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.Message);
                
                Error.ErrorMsg(ex);
            }
            
        }
       
        //˫����ͷ�򿪱༭����
        protected override void DoDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DoEdit(null, null);
        }
        protected override void DoEdit(object sender, EventArgs e)
        {
            int rowIndex= this.pageDataGridViewEx1.ucdgv.CurrentRow.Index;
            string id = this.pageDataGridViewEx1.ucdgv.Rows[rowIndex].Cells[this.KeyName].EditedFormattedValue.ToString();//�����ڵ�һ��
            if (string.IsNullOrEmpty(id))
                return;
            ShowEditForm(id, "�༭");
            
        }
        protected override void DoAdd(object sender, EventArgs e)
        {
            ShowEditForm("", "����");
        }
        private void ShowEditForm(string id,string action)
        {
            Frm$ClassName$Edit f = new Frm$ClassName$Edit(new DoRefreshHandler(this.DoQuery));
            f.IdValue = id;
	        f.ShowDialog();
	       
        }
       

        #region ��ѡɾ��
        protected override void DoDelete(object sender, EventArgs e)
        {
            
            string id=string.Empty;
            int selectCount = 0;
            DataGridView dgv = this.pageDataGridViewEx1.ucdgv;

            if (this.SelectCount() == 0)
                return;
			 if (this.pageDataGridViewEx1.IsShowCheckBox > -1)
            {
				//����ģ���ļ����ɴ���
				foreach (DataGridViewRow row in dgv.Rows)
				{
					//�ֶβ�Ϊ���ұ�ѡ��
					if (row.Cells["chkSelect"].EditedFormattedValue.ToString().Equals("True"))
					{
						selectCount++;
						id += Convert.ToString(row.Cells[this.KeyName].Value) + ",";
						
					}
				}
				id = id.Remove(id.Length-1,1);
			}else
			{
				int rowIndex = this.pageDataGridViewEx1.ucdgv.CurrentRow.Index;
                id = this.pageDataGridViewEx1.ucdgv.Rows[rowIndex].Cells[this.KeyName].EditedFormattedValue.ToString();//�����ڵ�һ��
			}
            bool blFlag = Hi.IBLL.HiInstanceBLL.$ClassName$BLL().Delete( id);
            
            if (blFlag)
            {
                this.DoQuery();
            }
        }
        #endregion
    }
}



