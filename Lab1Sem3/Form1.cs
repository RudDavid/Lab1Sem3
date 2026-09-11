using System;
using System.Windows.Forms;

namespace Lab1Sem3 {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e) {
      Form2 form2 = new Form2();
      this.Hide();                   
      form2.ShowDialog();  
      this.Show();        
    }

    private void button2_Click(object sender, EventArgs e) {
      Form3 form3 = new Form3();
      this.Hide();
      form3.ShowDialog();
      this.Show();
    }

    private void label1_Click(object sender, EventArgs e) {

    }
  }
}
