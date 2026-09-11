using System;
using System.Windows.Forms;

namespace Lab1Sem3 {
  public partial class Form2 : Form {
    public Form2() {
      InitializeComponent();
    }

    private void label3_Click(object sender, EventArgs e) {

    }

    private void textBox1_TextChanged(object sender, EventArgs e) {

    }

    private void button1_Click(object sender, EventArgs e) {

      double speed,
        distance,
        time,
        timeForRepairs,
        speedResult;

      if (double.TryParse(textBox1.Text, out speed) && (speed > 0)) {
        if (double.TryParse(textBox2.Text, out distance) && (distance > 0)) {
          if (double.TryParse(textBox5.Text, out timeForRepairs) && (timeForRepairs > 0)) {

            time = (distance / speed) + timeForRepairs;
            speedResult = distance / time;

            textBox6.Text = time.ToString();
            textBox4.Text = speedResult.ToString();

          } else {
            MessageBox.Show("Incorrect time for repairs entry. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }

        } else {
          MessageBox.Show("Incorrect distance entry. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      } else {
        MessageBox.Show("Incorrect speed entry. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

      }
    }
  }
}
