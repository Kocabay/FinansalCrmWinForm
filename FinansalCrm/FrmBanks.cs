using DevExpress.Data.ODataLinq.Helpers;
using FinansalCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinansalCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        FinansalCrmDbEntities db = new FinansalCrmDbEntities();
        private void FrmBanks_Load(object sender, EventArgs e)
        {

            //Banka Bakiyelerii

            var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var vakifBankBalance = db.Banks.Where(x => x.BankTitle == "VakıfBank").Select(y => y.BankBalance).FirstOrDefault();
            var isBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();

            lblIsBankBalance.Text = isBankBalance.ToString() + "TL";
            lblVakifBankBalance.Text = vakifBankBalance.ToString() + "TL";
            lblZiraatBankBalance.Text = ziraatBankBalance.ToString() + "TL";


            // Banka Hareketleri

            var bankProcesses1 = db.BankProcesses.OrderByDescending(x=>x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text = bankProcesses1.Description + " " + bankProcesses1.Amount + "TL" + " " + bankProcesses1.ProcessDate;


            var bankProcesses2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = bankProcesses2.Description + " " + bankProcesses2.Amount + "TL" + " " + bankProcesses2.ProcessDate;


            var bankProcesses3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = bankProcesses3.Description + " " + bankProcesses3.Amount + "TL" + " " + bankProcesses3.ProcessDate;


            var bankProcesses4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = bankProcesses4.Description + " " + bankProcesses4.Amount + "TL" + " " + bankProcesses4.ProcessDate;


            var bankProcesses5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = bankProcesses5.Description + " " + bankProcesses5.Amount + "TL" + " " + bankProcesses5.ProcessDate;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBillFrom_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }
    }
}
