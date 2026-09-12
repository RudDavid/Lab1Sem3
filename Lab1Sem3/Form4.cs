using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Lab1Sem3.Form3;

namespace Lab1Sem3 {
  public partial class Form4 : Form {
    public Form4() {
      InitializeComponent();
    }

    private void Form4_Load(object sender, EventArgs e) {

      List<SchoolboyInfo> studentsList = SchoolboyInfo.Read();

      if (studentsList == null || studentsList.Count == 0) {
        MessageBox.Show("File does not exist", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }

      var bestResultsTable = new List<object>();

      for (int schoolNum = 1; schoolNum <= 5; ++schoolNum) {
        var schoolStudents = studentsList.Where(s => s._schoolNumber == schoolNum).ToList();

        if (schoolStudents.Count > 0) {
          int maxScore = schoolStudents.Max(s => s._programming + s._design);

          var bestInSchool = schoolStudents.Where(s => (s._programming + s._design) == maxScore);

          foreach (var student in bestInSchool) {
            // Добавляем анонимный объект с понятными для таблицы свойствами
            bestResultsTable.Add(new {
              School = $"№ {student._schoolNumber}",
              Lastname = student._lastname,
              Firstname = student._firstname,
              Group = student._group,
              Maxscore = maxScore,
              Programming = student._programming,
              Design = student._design
            });
          }
        }
      }
      dataGridView1.DataSource = null;
      dataGridView1.DataSource = bestResultsTable;
    }
  }
}
