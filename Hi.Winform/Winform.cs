/*
------------------------------------------------------------------------------------------
 �����ṩ �� 51���-������
 ��    �� �� ������
       QQ �� 88130278
   EMail  �� LiangSunXiang@139.com
 �� �� �� �� www.51program.net
 ���˲��� �� blog.csdn.net/liangsx
-------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------
 ��Ŀ���� �� ��ɫ�Ӿ�����ϵͳ
 ��Ŀ���� �� �����������
 ������Ϣ ��[����Ա][�汾][��ע][����]
            [Administrator][V1.0][51���-�������Զ�����][2010-8-19 9:14:32]
 �޸���Ϣ ��(1)[����Ա][V1.1][��ע][����]
            (2)[����Ա][V1.2][��ע][����]
-------------------------------------------------------------------------------------------

*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Helper.Code.Create;
namespace Hi.Winform
{
    public class Winform : Helper.Code.Create.StringHelper
    {
        public string Model()
        {
            string strResult = string.Empty;
            StringBuilder strb = new StringBuilder();
            DataTable dt = GetProperty.DataTable;
            foreach(DataRow dr in dt.Rows)
            {
                ColumnInfo cols = GetColumnInfo(dr);
                strb.Append(SummaryCode( cols.Remark));
                strb.AppendLine("public "+CodeCommon.DbTypeToCS(cols.ColumnType) +" "+VarModel(cols.ColumnName) +"{get;set;}");
            }

            strResult = GetProperty.ModuleCode;

            if (!string.IsNullOrEmpty(strResult))
                strResult = strResult.Replace("$Model$", strb.ToString());
            else
                strResult = strb.ToString();

            return strResult;
        }

        /// <summary>
        /// ҵ���߼���
        /// </summary>
        /// <returns></returns>
        public string BLL()
        {
            StringBuilder strb = new StringBuilder();
            DataTable dt = GetProperty.DataTable;
            string className = GetProperty.ClassName;
            
            strb.Append(SummaryCode(className + ""));
            
            //strb.Append(Space(4) + BLLCode(dt, className));


            string strResult = GetProperty.ModuleCode;
            if (strResult != "")
                strResult = strResult.Replace("$BLL$", strb.ToString());
            else
                strResult = strb.ToString();

            return strResult;

        }

       
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string Exists()
        {
            StringBuilder strb = new StringBuilder();
            strb.AppendLine(SummaryCode("�Ƿ���ڸü�¼"));
            strb.AppendLine("#region Exists");
            strb.AppendLine("public bool Exists(string strWhere)");
            strb.AppendLine("{");
            strb.AppendLine("    string strSql = \" select count(*) from " + GetProperty.TableName + " where 1=1 \" + strWhere;");
            strb.AppendLine("    return int.Parse(" + GetOptions.DbHelper + ".ExecuteScalarToStr(strSql))  > 0 ? true : false;");
            strb.AppendLine("}");
            strb.AppendLine("#endregion");
            return strb.ToString();
        }

        public string Add()
        {
            StringBuilder strb = new StringBuilder();
            strb.AppendLine(SummaryCode("����һ������"));
            strb.AppendLine("#region Add");
            strb.AppendLine("public bool Add( " + GetProperty.ClassName + " model)");
            strb.AppendLine("{");
            strb.AppendLine("    " + AddSql2StringBuilder(GetProperty.DataTable));
            strb.AppendLine("    return " + GetOptions.DbHelper + ".ExecuteNonQuery(strSql) > 0 ? true : false;");
            strb.AppendLine("}");
            strb.AppendLine("#endregion");
            return strb.ToString();
        }
        public string Update()
        {
            StringBuilder strb = new StringBuilder();
            strb.AppendLine(SummaryCode("����һ������"));
            strb.AppendLine("#region Update");
            strb.AppendLine("public bool Update(" + GetProperty.ClassName + " model)");
            strb.AppendLine("{");
            strb.AppendLine("    " + UpdateSql2StringBuilder());
            strb.AppendLine("    return " + GetOptions.DbHelper + ".ExecuteNonQuery(strSql) > 0 ? true : false;");
            strb.AppendLine("}");
            strb.AppendLine("#endregion");
            return strb.ToString();
        }

        public string DataReader()
        {
            StringBuilder strb = new StringBuilder();
            strb.AppendLine(SummaryCode("�õ�һ��ʵ������"));
            strb.AppendLine("#region Detail");
            strb.AppendLine("public " + GetProperty.ClassName + " Detail(string id)");
            strb.AppendLine(Space(2) + "{\n");
            strb.AppendLine(Space(2) + "string strSql=" + ListSql() + "+\" where " + GetProperty.KeyName + " = \"+id;");
            strb.AppendLine(Space(4) + "" + VarClass(GetProperty.TableName, 1) + " model = new " + VarClass(GetProperty.TableName, 1) + "();");
            strb.AppendLine(Space(4) + "  System.Data.OleDb.OleDbDataReader  dr = " + GetOptions.DbHelper + ".ExecuteReader(strSql);");

            strb.AppendLine(Space(4) + "if (dr.Read())");
            strb.AppendLine(Space(4) + "{");
            strb.AppendLine(DetailValue());
            strb.AppendLine(Space(4) + "}");
            strb.AppendLine(Space(4) + "dr.Close();");
            strb.AppendLine(Space(4) + "return model;");
            strb.AppendLine(Space(2) + "}");

            strb.AppendLine("#endregion");
            return strb.ToString();
        }


        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string Dal()
        {
            StringBuilder strb = new StringBuilder();
            DataTable dt = GetProperty.DataTable;
            string className = GetProperty.ClassName;
            string table_name = GetProperty.TableName;


            string strValue = GetProperty.ModuleCode;
            if (!string.IsNullOrEmpty(strValue))
            {
                strValue = strValue.Replace("$Add$", AddSql2StringBuilder(dt));
                strValue = strValue.Replace("$Update$", UpdateSql2StringBuilder());
                strValue = strValue.Replace("$Detail$", DetailValue());

            }
            else
            {
                strb.AppendLine(Add());
                strb.AppendLine(Update());
                strb.AppendLine(DataReader());

                strValue = strb.ToString();
            }

            return strValue;
        }

    

        #region ��ʾ��--�б���
        public string ListCs()
        {
            
            DataTable dt = GetProperty.DataTable;
            string strFieldName = "", strFieldText = "",strResult="";
            foreach (DataRow row in dt.Rows)
            {
                strFieldName += row["�ֶ�"].ToString() + ",";
                strFieldText += row["�ֶκ���"].ToString() + ",";
            }
            if (strFieldName.Length > 0)
                strFieldName = strFieldName.Remove(strFieldName.Length - 1, 1);
            if (strFieldText.Length > 0)
                strFieldText = strFieldText.Remove(strFieldText.Length - 1, 1);
            //ģ������
            strResult = GetProperty.ModuleCode;
            if (!string.IsNullOrEmpty(strResult))
            {
                strResult = strResult.Replace("$MyColumnName$", strFieldName);
                strResult = strResult.Replace("$MyColumnTitle$", strFieldText);
            }
            else
                strResult = strFieldName + "\r\n" + strFieldText;
           
            return strResult;
        }
        #endregion 

        #region ��ʾ��--�༭����

        /// <summary>
        /// �༭��ʾ��
        /// </summary>
        /// <returns></returns>
        public string EditCs()
        {
           
            StringBuilder strb = new StringBuilder();
            StringBuilder strb2 = new StringBuilder();
            DataTable dt = GetProperty.DataTable;
            
            string strResult = string.Empty;
            Helper.Code.Create.UIControl _control;

            foreach (DataRow dr in dt.Rows)
            {
                _control = WinFormUI(dr);
                if (_control != null)
                    strb.AppendLine(Space(3) + _control.SetValue);
                else
                    strb.AppendLine(Space(3) + _control.SetValue);
            }

            foreach (DataRow dr in dt.Rows)
            {
                _control = WinFormUI(dr);
                if (_control != null)
                    strb2.AppendLine(Space(3) + _control.GetValue);
            }

            ////ģ������
            strResult = GetProperty.ModuleCode;

            if (!string.IsNullOrEmpty(strResult))
            {
                strResult = strResult.Replace("$GetDetail$", strb2.ToString());
                strResult = strResult.Replace("$SetDetail$", strb.ToString());
            }
            else
            {
                strResult = strb.ToString();
                strResult += strb2.ToString();
            }
            
            return strResult;

        }
      
        #endregion

        #region �������
        /// <summary>
        /// ����UI�ؼ����Դ���
        /// </summary>
        /// <returns></returns>
        public string Designer()
        {
            string strCode = GetProperty.ModuleCode;

            StringBuilder strb = new StringBuilder();

            string allVar = "", allNewVar = "", allUIAdd = "", allUIProperty = "";
            Var(out allVar, out allNewVar, out allUIAdd, out allUIProperty);
            strb.AppendLine(allVar);
            strb.AppendLine(allNewVar);
            strb.AppendLine(allUIAdd);
            strb.AppendLine(allUIProperty);
            if (!string.IsNullOrEmpty(strCode))
            {

                strCode = strCode.Replace("$Var$", allVar);
                strCode = strCode.Replace("$NewVar$", allNewVar);
                strCode = strCode.Replace("$UIAdd$", allUIAdd);
                strCode = strCode.Replace("$UIProperty$", allUIProperty);
            }
            else
                strCode = strb.ToString();
            return strCode;
        }
        /// <summary>
        /// ���弰ʵ����UI�ؼ�
        /// <param name="allVar">private</param>
        /// <param name="allNewVar"> this.txt = new ..</param>
        /// <param name="allUIAdd">this.Controls.Add()</param>
        private void Var(out string allVar, out string allNewVar, out string allUIAdd, out string allUIProperty)
        {
            StringBuilder strbVar = new StringBuilder();
            StringBuilder strbNewVar = new StringBuilder();
            StringBuilder strbUiAdd = new StringBuilder();
            StringBuilder strbUiProperty = new StringBuilder();

            Helper.Code.Create.UIControl ui;
            DataTable dt = GetProperty.DataTable;
            string uiName = "", strVar = "", strNewVar = "", strUIAdd = "", strUiCode = "";
            int index = 0;
            foreach (DataRow row in dt.Rows)
            {
                index++;
                uiName = "";
                strVar = "";
                strNewVar = "";
                strUIAdd = "";
                ui = UI(row, "TextBox", out uiName, out strVar, out strNewVar, out strUIAdd);
                strUiCode = UIProperty(index, uiName, row["�ֶκ���"].ToString(), ui, false);
                strbUiProperty.AppendLine(strUiCode);
                //TextBox������UI�ؼ�
                strbVar.AppendLine(strVar);
                strbNewVar.AppendLine(strNewVar);
                strbUiAdd.AppendLine(strUIAdd);

                //label
                uiName = "";
                strVar = "";
                strNewVar = "";
                strUIAdd = "";
                ui = UI(row, "Label", out uiName, out strVar, out strNewVar, out strUIAdd);
                strbVar.AppendLine(strVar);
                strbNewVar.AppendLine(strNewVar);
                strbUiAdd.AppendLine(strUIAdd);
                strUiCode = UIProperty(index, uiName, row["�ֶκ���"].ToString(), ui, true);
                strbUiProperty.AppendLine(strUiCode);
                
            }

            allVar = strbVar.ToString();
            allNewVar = strbNewVar.ToString();
            allUIAdd = strbUiAdd.ToString();
            allUIProperty = strbUiProperty.ToString();
        }
        /// <summary>
        /// ����Label��TextBox��UI���Դ���
        /// </summary>
        /// <returns></returns>
        private string UIProperty(int index, string uiName, string column_remark, Helper.Code.Create.UIControl ui, bool isLabel)
        {
            StringBuilder strCode = new StringBuilder();
            string strResult = string.Empty;
            int x = 0, y = 30;
           
            if (isLabel)
            {
                if (index % 2 == 0)
                {
                    x = 220;
                    y += 20 * ((int)(index / 2) - 1);
                }
                else if (index > 0 && index % 3 == 0)
                {
                   
                    x = 400;
                    y += 20 * ((int)(index / 3) - 1);
                }
                else
                {
                    x = 8;
                    y += 20 * (index-1);
                   
                }
            }
            if (!isLabel)
            {
                if ( index % 2 == 0)
                {
                    x = 260;
                    y += 20 * ((int)(index / 2) - 1);
                   
                }
                else if (index > 0 && index % 3 == 0)
                {
                    x = 450;
                    y += 20 * ((int)(index / 3) - 1);
                }
                else
                {
                    x = 90;
                    y += 20 * index;
                }

            }
            strResult = ui.UsingCode;
            strResult = strResult.Replace("$TabIndex$", Convert.ToString(index + 1));
            strResult = strResult.Replace("$X$", Convert.ToString(x));
            strResult = strResult.Replace("$Y$", Convert.ToString(y));
            strResult = strResult.Replace("$FieldName$", uiName.Replace("\"", ""));
            strResult = strResult.Replace("$FieldCaption$", column_remark.Replace("\"", ""));
            return strResult;
        }

        /// <summary>
        /// WinForm �ؼ����Դ���
        /// </summary>
        /// <param name="row">�м�¼��</param>
        /// <param name="uiName">UI�ؼ�����</param>
        /// <param name="strVar">�������</param>
        /// <param name="strNewVar">ʵ��������</param>
        /// <param name="strUIAdd">��ӵ�������</param>
        /// <returns></returns>
        private Helper.Code.Create.UIControl UI(DataRow row, string uiCode, out string uiName, out string strVar, out string strNewVar, out string strUIAdd)
        {
            Helper.Code.Create.UIControl ui = new Helper.Code.Create.UIControl();
            string cid, cname;

            StringBuilder strb = new StringBuilder();
            cid = row["�ؼ�"].ToString();
            cname = row["�ֶ�"].ToString();
            if (uiCode == "Label")
                ui = VarControl(uiCode);
            else
            {
                if (cid == "0")
                {
                    ui = VarControl(uiCode);
                }
                else
                {
                    ui = VarControl(int.Parse(cid));
                }
            }
            uiName = ui.Abbreviate + VarModel(cname);

            strVar = " private " + ui.Define + " " + uiName + ";";
            strNewVar = "this." + uiName + " = new " + ui.Define.Trim() + "();";
            strUIAdd = "this.Controls.Add(this." + uiName + ");\r\nthis.Controls.SetChildIndex(this." + uiName + ", 0);";
            
            return ui;

        }

        #endregion

        #region Webҳ��
        public string Aspx()
        {
            string strResult = string.Empty;
            StringBuilder strbRecordField = new StringBuilder();
            StringBuilder strbColumn = new StringBuilder();
            StringBuilder strbTextField = new StringBuilder();
            DataTable dt = GetProperty.DataTable;


            foreach (DataRow dr in dt.Rows)
            {
                ColumnInfo cols = new ColumnInfo();
                cols = GetColumnInfo(dr);
                strbRecordField.AppendLine("<ext:RecordField Name=\"" + cols.ColumnName + "\" />");

                strbColumn.AppendLine("<ext:Column ColumnID=\"" + cols.ColumnName + "\" DataIndex=\"" + cols.ColumnName + "\" Header=\"" + IsNull(cols.Remark, cols.ColumnName) + "\" />");

                strbTextField.AppendLine("<ext:TextField ID=\"txt" + VarModel(cols.ColumnName) + "\" runat=\"server\" FieldLabel=\"" + cols.Remark + "\" Width=\"100\" DataIndex=\"" + cols.ColumnName + "\" />");
            }

            //ģ������
            strResult = GetProperty.ModuleCode;

            if (!string.IsNullOrEmpty(strResult))
            {
                strResult = strResult.Replace("$RecordField$", strbRecordField.ToString());
                strResult = strResult.Replace("$Column$", strbColumn.ToString());
                strResult = strResult.Replace("$TextField$", strbTextField.ToString());
            }
            else
            {
                strResult = strbRecordField.ToString();
                strResult += strbColumn.ToString();
                strResult += strbTextField.ToString();
            }

            return strResult;

        }
       
        /// <summary>
        /// �༭��ʾ��
        /// </summary>
        /// <returns></returns>
        public string Cs()
        {

            StringBuilder strbSet = new StringBuilder();
            StringBuilder strbGet = new StringBuilder();
            DataTable dt = GetProperty.DataTable;

            string strResult = string.Empty;
            Helper.Code.Create.UIControl control;

            foreach (DataRow dr in dt.Rows)
            {
                string setCode = "",getCode="";
                ColumnInfo cols = new ColumnInfo();
                cols = GetColumnInfo(dr);
                control = new Helper.Code.Create.UIControl();
                if (cols.UI != "0" && !string.IsNullOrEmpty(cols.UI))
                    control = VarControl(int.Parse(cols.UI));
                else
                    control = VarControl("TextBoxExt");

                if (control != null)
                {
                    setCode = control.SetValue;
                    setCode = setCode.Replace("$FieldName$", cols.ColumnName);
                    setCode = setCode.Replace("$VarFieldName$",VarModel(cols.ColumnName));
                    setCode = setCode.Replace("$FieldRemark$", IsNull(cols.Remark, cols.ColumnName));
                    strbSet.Append(setCode + "\n");

                    getCode = control.GetValue;
                    getCode = getCode.Replace("$FieldName$", cols.ColumnName);
                    getCode = getCode.Replace("$VarFieldName$", VarModel(cols.ColumnName));
                    getCode = getCode.Replace("$FieldRemark$", IsNull(cols.Remark, cols.ColumnName));
                    strbGet.Append(getCode + "\n");
                }
            }

           

            ////ģ������
            strResult = GetProperty.ModuleCode;

            if (!string.IsNullOrEmpty(strResult))
            {
                strResult = strResult.Replace("$SetDetail$", strbSet.ToString());
                strResult = strResult.Replace("$GetDetail$", strbGet.ToString());
               
            }
            else
            {
                strResult = strbSet.ToString();
                strResult += strbGet.ToString();
            }

            return strResult;

        }

        /// <summary>
        /// �༭��ʾ��
        /// </summary>
        /// <returns></returns>
        public string Cs2()
        {

            StringBuilder strbSet = new StringBuilder();
            StringBuilder strbGet = new StringBuilder();
            DataTable dt = GetProperty.DataTable;

            string strResult = string.Empty;
            Helper.Code.Create.UIControl control;

            foreach (DataRow dr in dt.Rows)
            {
                string setCode = "",getCode="";
                ColumnInfo cols = new ColumnInfo();
                cols = GetColumnInfo(dr);
                control = new Helper.Code.Create.UIControl();
                if (cols.UI != "0" && !string.IsNullOrEmpty(cols.UI))
                    control = VarControl(int.Parse(cols.UI));
                else
                    control = VarControl("TextBoxExt");

                if (control != null)
                {
                    setCode = control.SetValue;
                    setCode = setCode.Replace("$FieldName$", cols.ColumnName);
                    setCode = setCode.Replace("$VarFieldName$",VarModel(cols.ColumnName));
                    setCode = setCode.Replace("$FieldRemark$", IsNull(cols.Remark, cols.ColumnName));
                    strbSet.Append(setCode + "\n");

                    getCode = control.GetValue;
                    getCode = getCode.Replace("$FieldName$", cols.ColumnName);
                    getCode = getCode.Replace("$VarFieldName$", VarModel(cols.ColumnName));
                    getCode = getCode.Replace("$FieldRemark$", IsNull(cols.Remark, cols.ColumnName));
                    strbGet.Append(getCode + "\n");
                }
            }

           

            ////ģ������
            strResult = GetProperty.ModuleCode;

            if (!string.IsNullOrEmpty(strResult))
            {
                strResult = strResult.Replace("$SetDetail$", strbSet.ToString());
                strResult = strResult.Replace("$GetDetail$", strbGet.ToString());
               
            }
            else
            {
                strResult = strbSet.ToString();
                strResult += strbGet.ToString();
            }

            return strResult;

        }
        #endregion 
    }
}
