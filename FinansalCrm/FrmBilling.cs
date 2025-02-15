using FinansalCrm.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace FinansalCrm
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        FinansalCrmDbEntities db = new FinansalCrmDbEntities();

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnCreat_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            Bills biils = new Bills();
            biils.BiilTitle = title;
            biils.BillAmount = amount;
            biils.BillPeriod = period;
            db.Bills.Add(biils);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı bir şekilde sisteme Eklendi.", "Ödeme Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnBillList_Click(sender,e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBiilId.Text);
            var removeValue = db.Bills.Find(id);
            db.Bills.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı bir şekilde sistemden silindi.", "Ödeme Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnBillList_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;
            int id = int.Parse(txtBiilId.Text);
            var values = db.Bills.Find(id);

            values.BiilTitle = title;
            values.BillAmount = amount;
            values.BillPeriod = period;
          //  db.Bills.AddOrUpdate(values);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı bir şekilde sistemde güncellendi.", "Ödeme Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnBillList_Click(sender, e);
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }
    }
}
