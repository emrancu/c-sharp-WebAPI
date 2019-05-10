using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace WebAPI
{
    public partial class MainForm : Form
    {
        private TextBox URLFIeld;
        private TextBox responseField;
        private Label loading;
        private Button btnGo;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.URLFIeld = new System.Windows.Forms.TextBox();
            this.responseField = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.loading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // URLFIeld
            // 
            this.URLFIeld.AccessibleName = "URLFIeld";
            this.URLFIeld.Location = new System.Drawing.Point(36, 24);
            this.URLFIeld.Name = "URLFIeld";
            this.URLFIeld.Size = new System.Drawing.Size(508, 20);
            this.URLFIeld.TabIndex = 0;
            this.URLFIeld.Text = "http://company.ogroosoft.com/api/About/2";
            this.URLFIeld.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // responseField
            // 
            this.responseField.AcceptsReturn = true;
            this.responseField.AccessibleName = "responseField";
            this.responseField.CausesValidation = false;
            this.responseField.Location = new System.Drawing.Point(36, 85);
            this.responseField.Multiline = true;
            this.responseField.Name = "responseField";
            this.responseField.Size = new System.Drawing.Size(623, 373);
            this.responseField.TabIndex = 2;
            this.responseField.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnGo
            // 
            this.btnGo.AccessibleName = "btnGo";
            this.btnGo.Location = new System.Drawing.Point(584, 24);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // loading
            // 
            this.loading.AutoSize = true;
            this.loading.Location = new System.Drawing.Point(309, 66);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(45, 13);
            this.loading.TabIndex = 3;
            this.loading.Text = "Loading";
            this.loading.Visible = false;
            // 
            // MainForm
            // 
            this.AccessibleName = "MainForm";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(701, 482);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.responseField);
            this.Controls.Add(this.URLFIeld);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(717, 521);
            this.MinimumSize = new System.Drawing.Size(717, 521);
            this.Name = "MainForm";
            this.Text = "WEB API Calling";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(URLFIeld.Text.ToString(), UriKind.Absolute))  
            {
                loading.Visible = true;
                RestClient rClient = new RestClient();
                rClient.endPoin = URLFIeld.Text;

                string strResponse = string.Empty;

                strResponse = rClient.makeRequest();
                loading.Visible = false;
               
                string about = String.Empty;

                dynamic json = JsonConvert.DeserializeObject(strResponse.ToString());

                responseField.Text = json.resultData.org_name +"\r\n" + json.resultData.about;

            }
              
            
     


        }
    }
}
