/*
------------------------------------------------------------------------------------------
 �����ṩ �� 51���-������
 ��    �� �� ������
       QQ �� 88130278
   EMail  �� LiangSunXiang@139.com
 �� �� �� �� www.51program.net
 ���˲��� �� blog.csdn.net/liangsx
 ��ܰ��ʾ �� ���ð汾�����Ӱ�Ȩ���ݡ�����Ӱ������ʹ��,��ͨ������ע�����δ���Ϣ��лл��
 ע�᷽�� �� ��������ʹٷ�����������ѯ
-------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------------
 ��Ŀ���� �� Vs2008+Winfrom+����ģʽ�ܹ�
 �������� ��
 ������Ϣ ��[����Ա][�汾][��ע][����]
            [Administrator][V1.0][51���-�������Զ�����][2011-5-5 12:35:30]
 �޸���Ϣ ��(1)[����Ա][V1.1][��ע][����]
            (2)[����Ա][V1.2][��ע][����]
--------------------------------------------------------------------------------------------------

*/
namespace Hi.Client
{
    partial class FrmUserEdit
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUsercode = new System.Windows.Forms.TextBox();
            this.lblUsercode = new System.Windows.Forms.Label();
            this.txtUserpassword = new System.Windows.Forms.TextBox();
            this.lblUserpassword = new System.Windows.Forms.Label();
            this.txtRealname = new System.Windows.Forms.TextBox();
            this.lblRealname = new System.Windows.Forms.Label();
            this.txtUsertelephone = new System.Windows.Forms.TextBox();
            this.lblUsertelephone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtQq = new System.Windows.Forms.TextBox();
            this.lblQq = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoBirl = new System.Windows.Forms.RadioButton();
            this.rdoBoy = new System.Windows.Forms.RadioButton();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo0 = new System.Windows.Forms.RadioButton();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.pnlWorkSpace.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWorkSpace
            // 
            this.pnlWorkSpace.Controls.Add(this.cmbDepartment);
            this.pnlWorkSpace.Controls.Add(this.txtRealname);
            this.pnlWorkSpace.Controls.Add(this.groupBox2);
            this.pnlWorkSpace.Controls.Add(this.groupBox1);
            this.pnlWorkSpace.Controls.Add(this.txtUsertelephone);
            this.pnlWorkSpace.Size = new System.Drawing.Size(404, 227);
            // 
            // txtUsercode
            // 
            this.txtUsercode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsercode.Location = new System.Drawing.Point(68, 33);
            this.txtUsercode.MaxLength = 20;
            this.txtUsercode.Name = "txtUsercode";
            this.txtUsercode.Size = new System.Drawing.Size(111, 21);
            this.txtUsercode.TabIndex = 0;
            // 
            // lblUsercode
            // 
            this.lblUsercode.AutoSize = true;
            this.lblUsercode.Location = new System.Drawing.Point(20, 37);
            this.lblUsercode.Name = "lblUsercode";
            this.lblUsercode.Size = new System.Drawing.Size(53, 12);
            this.lblUsercode.TabIndex = 3;
            this.lblUsercode.Text = "�û�����";
            // 
            // txtUserpassword
            // 
            this.txtUserpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserpassword.Location = new System.Drawing.Point(273, 33);
            this.txtUserpassword.MaxLength = 16;
            this.txtUserpassword.Name = "txtUserpassword";
            this.txtUserpassword.Size = new System.Drawing.Size(114, 21);
            this.txtUserpassword.TabIndex = 1;
            // 
            // lblUserpassword
            // 
            this.lblUserpassword.AutoSize = true;
            this.lblUserpassword.Location = new System.Drawing.Point(218, 37);
            this.lblUserpassword.Name = "lblUserpassword";
            this.lblUserpassword.Size = new System.Drawing.Size(59, 12);
            this.lblUserpassword.TabIndex = 4;
            this.lblUserpassword.Text = "��   �룺";
            // 
            // txtRealname
            // 
            this.txtRealname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRealname.Location = new System.Drawing.Point(68, 49);
            this.txtRealname.MaxLength = 30;
            this.txtRealname.Name = "txtRealname";
            this.txtRealname.Size = new System.Drawing.Size(111, 21);
            this.txtRealname.TabIndex = 2;
            // 
            // lblRealname
            // 
            this.lblRealname.AutoSize = true;
            this.lblRealname.Location = new System.Drawing.Point(8, 76);
            this.lblRealname.Name = "lblRealname";
            this.lblRealname.Size = new System.Drawing.Size(65, 12);
            this.lblRealname.TabIndex = 5;
            this.lblRealname.Text = "��ʵ������";
            // 
            // txtUsertelephone
            // 
            this.txtUsertelephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsertelephone.Location = new System.Drawing.Point(275, 49);
            this.txtUsertelephone.Name = "txtUsertelephone";
            this.txtUsertelephone.Size = new System.Drawing.Size(114, 21);
            this.txtUsertelephone.TabIndex = 3;
            // 
            // lblUsertelephone
            // 
            this.lblUsertelephone.AutoSize = true;
            this.lblUsertelephone.Location = new System.Drawing.Point(212, 80);
            this.lblUsertelephone.Name = "lblUsertelephone";
            this.lblUsertelephone.Size = new System.Drawing.Size(65, 12);
            this.lblUsertelephone.TabIndex = 8;
            this.lblUsertelephone.Text = "��ϵ�绰��";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(69, 112);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(111, 21);
            this.txtEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(23, 116);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 12);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email��";
            // 
            // txtQq
            // 
            this.txtQq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQq.Location = new System.Drawing.Point(274, 114);
            this.txtQq.MaxLength = 10;
            this.txtQq.Name = "txtQq";
            this.txtQq.Size = new System.Drawing.Size(114, 21);
            this.txtQq.TabIndex = 5;
            // 
            // lblQq
            // 
            this.lblQq.AutoSize = true;
            this.lblQq.Location = new System.Drawing.Point(239, 118);
            this.lblQq.Name = "lblQq";
            this.lblQq.Size = new System.Drawing.Size(29, 12);
            this.lblQq.TabIndex = 10;
            this.lblQq.Text = "QQ��";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(274, 154);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(114, 21);
            this.txtAddress.TabIndex = 8;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(209, 160);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(59, 12);
            this.lblAddress.TabIndex = 12;
            this.lblAddress.Text = "ס   ַ��";
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Location = new System.Drawing.Point(112, 328);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(100, 21);
            this.txtRemark.TabIndex = 17;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(8, 328);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(53, 12);
            this.lblRemark.TabIndex = 17;
            this.lblRemark.Text = "remark��";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoBirl);
            this.groupBox1.Controls.Add(this.rdoBoy);
            this.groupBox1.Location = new System.Drawing.Point(12, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 39);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "�Ա�";
            // 
            // rdoBirl
            // 
            this.rdoBirl.AutoSize = true;
            this.rdoBirl.Location = new System.Drawing.Point(107, 16);
            this.rdoBirl.Name = "rdoBirl";
            this.rdoBirl.Size = new System.Drawing.Size(35, 16);
            this.rdoBirl.TabIndex = 7;
            this.rdoBirl.TabStop = true;
            this.rdoBirl.Text = "Ů";
            this.rdoBirl.UseVisualStyleBackColor = true;
            // 
            // rdoBoy
            // 
            this.rdoBoy.AutoSize = true;
            this.rdoBoy.Checked = true;
            this.rdoBoy.Location = new System.Drawing.Point(44, 15);
            this.rdoBoy.Name = "rdoBoy";
            this.rdoBoy.Size = new System.Drawing.Size(35, 16);
            this.rdoBoy.TabIndex = 6;
            this.rdoBoy.TabStop = true;
            this.rdoBoy.Text = "��";
            this.rdoBoy.UseVisualStyleBackColor = true;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(68, 130);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(111, 20);
            this.cmbDepartment.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "�������ţ�";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdo2);
            this.groupBox2.Controls.Add(this.rdo0);
            this.groupBox2.Controls.Add(this.rdo1);
            this.groupBox2.Location = new System.Drawing.Point(191, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 44);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "״̬";
            // 
            // rdo2
            // 
            this.rdo2.AutoSize = true;
            this.rdo2.Enabled = false;
            this.rdo2.Location = new System.Drawing.Point(149, 22);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(47, 16);
            this.rdo2.TabIndex = 8;
            this.rdo2.TabStop = true;
            this.rdo2.Text = "ϵͳ";
            this.rdo2.UseVisualStyleBackColor = true;
            // 
            // rdo0
            // 
            this.rdo0.AutoSize = true;
            this.rdo0.Location = new System.Drawing.Point(82, 21);
            this.rdo0.Name = "rdo0";
            this.rdo0.Size = new System.Drawing.Size(47, 16);
            this.rdo0.TabIndex = 7;
            this.rdo0.TabStop = true;
            this.rdo0.Text = "��ֹ";
            this.rdo0.UseVisualStyleBackColor = true;
            // 
            // rdo1
            // 
            this.rdo1.AutoSize = true;
            this.rdo1.Checked = true;
            this.rdo1.Location = new System.Drawing.Point(10, 22);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(47, 16);
            this.rdo1.TabIndex = 6;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "����";
            this.rdo1.UseVisualStyleBackColor = true;
            // 
            // FrmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 252);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsercode);
            this.Controls.Add(this.lblUsercode);
            this.Controls.Add(this.txtUserpassword);
            this.Controls.Add(this.lblRealname);
            this.Controls.Add(this.lblUserpassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblUsertelephone);
            this.Controls.Add(this.txtQq);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblQq);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.lblRemark);
            this.Name = "FrmUserEdit";
            this.Text = "";
            this.Controls.SetChildIndex(this.pnlWorkSpace, 0);
            this.Controls.SetChildIndex(this.lblRemark, 0);
            this.Controls.SetChildIndex(this.txtRemark, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.lblQq, 0);
            this.Controls.SetChildIndex(this.txtAddress, 0);
            this.Controls.SetChildIndex(this.txtQq, 0);
            this.Controls.SetChildIndex(this.lblUsertelephone, 0);
            this.Controls.SetChildIndex(this.lblEmail, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.lblUserpassword, 0);
            this.Controls.SetChildIndex(this.lblRealname, 0);
            this.Controls.SetChildIndex(this.txtUserpassword, 0);
            this.Controls.SetChildIndex(this.lblUsercode, 0);
            this.Controls.SetChildIndex(this.txtUsercode, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.pnlWorkSpace.ResumeLayout(false);
            this.pnlWorkSpace.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsercode;
 private System.Windows.Forms.Label lblUsercode;
 private System.Windows.Forms.TextBox txtUserpassword;
 private System.Windows.Forms.Label lblUserpassword;
 private System.Windows.Forms.TextBox txtRealname;
 private System.Windows.Forms.Label lblRealname;
 private System.Windows.Forms.TextBox txtUsertelephone;
 private System.Windows.Forms.Label lblUsertelephone;
 private System.Windows.Forms.TextBox txtEmail;
 private System.Windows.Forms.Label lblEmail;
 private System.Windows.Forms.TextBox txtQq;
 private System.Windows.Forms.Label lblQq;
 private System.Windows.Forms.TextBox txtAddress;
 private System.Windows.Forms.Label lblAddress;
 private System.Windows.Forms.TextBox txtRemark;
 private System.Windows.Forms.Label lblRemark;
 private System.Windows.Forms.GroupBox groupBox1;
 private System.Windows.Forms.RadioButton rdoBirl;
 private System.Windows.Forms.RadioButton rdoBoy;
 private System.Windows.Forms.ComboBox cmbDepartment;
 private System.Windows.Forms.Label label1;
 private System.Windows.Forms.GroupBox groupBox2;
 private System.Windows.Forms.RadioButton rdo2;
 private System.Windows.Forms.RadioButton rdo0;
 private System.Windows.Forms.RadioButton rdo1;

    }
}
