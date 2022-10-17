using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagement
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            labelIndicate1.ForeColor = System.Drawing.Color.Red;
            labelIndicate2.ForeColor = System.Drawing.Color.Black;
            labelIndicate3.ForeColor = System.Drawing.Color.Black;
            labelIndicate4.ForeColor = System.Drawing.Color.Black;

           panel1.Visible = true;
           panel2.Visible = false;

        }

        private void btnAddDagnosis_Click(object sender, EventArgs e)
        {
            labelIndicate2.ForeColor = System.Drawing.Color.Red;
            labelIndicate1.ForeColor = System.Drawing.Color.Black;
            labelIndicate3.ForeColor = System.Drawing.Color.Black;
            labelIndicate4.ForeColor = System.Drawing.Color.Black;
           // panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
           
        }

        private void btnFullHistory_Click(object sender, EventArgs e)
        {
            labelIndicate3.ForeColor = System.Drawing.Color.Red;
            labelIndicate2.ForeColor = System.Drawing.Color.Black;
            labelIndicate1.ForeColor = System.Drawing.Color.Black;
            labelIndicate4.ForeColor = System.Drawing.Color.Black;
            panel3.Visible = true;
            panel4.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-ME1AHQH\\SQLEXPRESS01;Initial Catalog=HospitalManagement;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from AddPatients inner join PatientMore on AddPatients.pid = PatientMore.pid";
            
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];


        }

        private void btnHospitalInformation_Click(object sender, EventArgs e)
        {
            labelIndicate4.ForeColor = System.Drawing.Color.Red;
            labelIndicate2.ForeColor = System.Drawing.Color.Black;
            labelIndicate3.ForeColor = System.Drawing.Color.Black;
            labelIndicate1.ForeColor = System.Drawing.Color.Black;

            panel4.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
     
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void textBlood_TextChanged(object sender, EventArgs e)
        {

        }



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                String name = txtName.Text;
                String address = txtAddress.Text;
                Int64 contact = Convert.ToInt64(txtContact.Text);
                int age = Convert.ToInt32(txtAge.Text);
                String gender = comboGender.Text;
                String blood = txtBlood.Text;
                String any = txtAny.Text;
                int pid = Convert.ToInt32(txtPid.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-ME1AHQH\\SQLEXPRESS01;Initial Catalog=HospitalManagement;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "insert into AddPatients values ('" + name + "', '" + address + "', " + contact + ", " + age + ", '" + gender + "', '" + blood + "', '" + any + "'," + pid + ")";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                MessageBox.Show("data insert successfully");
            }

            catch (Exception)
            {
                MessageBox.Show("Invalid data format or invalid pid ");
            }

            txtName.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtAge.Clear();
            txtBlood.Clear();
            txtAny.Clear();
            txtPid.Clear();
            comboGender.ResetText();
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                int pid = Convert.ToInt32(textBox1.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-ME1AHQH\\SQLEXPRESS01;Initial Catalog=HospitalManagement;Integrated Security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from AddPatients where pid = " + pid + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int pid = Convert.ToInt32(textBox1.Text);
                String sympt = txtSymptoms.Text;
                String diag = txtDiagnosis.Text;
                String medicine = txtMedicines.Text;
                String ward = comboBxRequired.Text;
                String wardType = comboBxWard.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-ME1AHQH\\SQLEXPRESS01;Initial Catalog=HospitalManagement;Integrated Security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into PatientMore values (" + pid + ",'" + sympt + "','" + diag + "', '" + medicine + "','" + ward + "','"+ wardType+ "')";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

            }
            catch(Exception)
            {
                MessageBox.Show("Any field is empty 'OR' Data is in WRONG format");
            }
            MessageBox.Show("Data Saved.");
            textBox1.Clear();
            txtDiagnosis.Clear();
            txtMedicines.Clear();
            txtSymptoms.Clear();
            comboBxWard.ResetText();
            comboBxRequired.ResetText();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
