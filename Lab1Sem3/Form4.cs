using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Lab1Sem3.Form3;

namespace Lab1Sem3 {
  public partial class Form4 : Form {
    public Form4() {
      InitializeComponent();
    }

    private void Form4_Load(object sender, EventArgs e) {

      List<SchoolboyInfo> studentsList = SchoolboyInfo.Read();

      if (studentsList != null) {
        dataGridView1.DataSource = studentsList;
      }
    }
  }
}
