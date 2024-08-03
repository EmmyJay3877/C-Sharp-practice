using DemoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Dashboard : Form
    {
        Customer customer = new Customer();

        public Dashboard()
        {
            InitializeComponent();

            LoadTestingData();

            WireUpForm();
        }

        private void LoadTestingData()
        {

            customer.CustomerName = "Emmy Jay";
            customer.CheckingAccount = new Account();
            customer.SavingsAccount = new Account();

            customer.CheckingAccount.MakePaymentEvent += UpdateTransactionsTab;
            customer.SavingsAccount.MakePaymentEvent += UpdateTransactionsTab;

            customer.CheckingAccount.MakePaymentEvent += UpdateAccountBalance;
            customer.SavingsAccount.MakePaymentEvent += UpdateAccountBalance;

            customer.CheckingAccount.ErrorMsgEvent += UpdateErrorMsg;

            customer.CheckingAccount.InsufficientAlertEvent += InsufficientBalanceMsg;

            customer.CheckingAccount.AccountName = "Emmy's Checking Account";
            customer.SavingsAccount.AccountName = "Emmy's Savings Account";

            customer.CheckingAccount.AddDeposit("Initial Balance", 155.43M);
            customer.SavingsAccount.AddDeposit("Initial Balance", 98.45M);
        }

        private void WireUpForm()
        {
            customerText.Text = customer.CustomerName;
            checkingTransactions.DataSource = customer.CheckingAccount.Transactions;
            savingsTransactions.DataSource = customer.SavingsAccount.Transactions;
            checkingBalanceValue.Text = string.Format("{0:C2}", customer.CheckingAccount.Balance);
            savingsBalanceValue.Text = string.Format("{0:C2}", customer.SavingsAccount.Balance);
        }

        private void recordTransactionsButton_Click(object sender, EventArgs e)
        {
            Transactions transactions = new Transactions(customer);
            transactions.Show();
        }

        private void UpdateAccountBalance(object sender, EventArgs e)
        {
            checkingBalanceValue.Text = string.Format("{0:C2}", customer.CheckingAccount.Balance);
            savingsBalanceValue.Text = string.Format("{0:C2}", customer.SavingsAccount.Balance);
        }

        private void UpdateTransactionsTab(object sender, EventArgs e)
        {
            checkingTransactions.DataSource = customer.CheckingAccount.Transactions;
            savingsTransactions.DataSource = customer.SavingsAccount.Transactions;
        }

        private void UpdateErrorMsg(object sender, decimal e)
        {
            errorMessage.Text = $"You had an overdraft protection transfer of {string.Format($"{e:C2}")}";
            errorMessage.Visible = true;
        }

        private void InsufficientBalanceMsg(object sender, EventArgs e)
        {
            errorMessage.Text = $"Insufficient Funds in both Accounts";
            errorMessage.Visible = true;
        }
         
        private void errorMessage_Click(object sender, EventArgs e)
        {
            errorMessage.Visible = false;
        }
    }
}
