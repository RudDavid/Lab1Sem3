using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Windows.Forms;

namespace Lab1Sem3 {
  public partial class Form3 : Form {
    public Form3() {
      InitializeComponent();
    }

    public class SchoolboyInfo {
      public static string path = "SchoolboysInfo.json";
      public string _firstname { get; set; }
      public string _lastname { get; set; }
      public string _group { get; set; } 
      public int _schoolNumber { get; set; }
      public int _programming { get; set; }
      public int _design { get; set; }

      public SchoolboyInfo() {
      }

      public SchoolboyInfo(string firstname, string lastname, string group, int schoolNumber, int num1, int num2) {
        _firstname = firstname;
        _lastname = lastname;
        _group = group;
        _schoolNumber = schoolNumber;
        _programming = num1;
        _design = num2;
      }

      public static void WriteInFile(SchoolboyInfo newschoolboy) {

        List<SchoolboyInfo> currentList = new List<SchoolboyInfo>();

        if (File.Exists(path)) {
          string existingJson = File.ReadAllText(path);
          if (!string.IsNullOrWhiteSpace(existingJson)) {
            currentList = JsonSerializer.Deserialize<List<SchoolboyInfo>>(existingJson) ?? new List<SchoolboyInfo>();
          }
        }

        currentList.Add(newschoolboy); 
        
        string fullInfo = JsonSerializer.Serialize(currentList, new JsonSerializerOptions { WriteIndented = true });

        if (fullInfo != null) {
          File.WriteAllText(SchoolboyInfo.path, fullInfo);
        } else {
          MessageBox.Show("Error while saving. \n Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }

      public static List<SchoolboyInfo> Read() {
        if (!File.Exists(SchoolboyInfo.path)) {
          return new List<SchoolboyInfo>();
        }

        string readText = File.ReadAllText(SchoolboyInfo.path);

        if (!string.IsNullOrWhiteSpace(readText)) {
          return JsonSerializer.Deserialize<List<SchoolboyInfo>>(readText);
        }
        return new List<SchoolboyInfo>();
      }
    }

    private void Form3_Load(object sender, EventArgs e) {
    }

    private void label3_Click(object sender, EventArgs e) {
    }

    private void button2_Click(object sender, EventArgs e) {
      Form4 form4 = new Form4();
      this.Hide();
      form4.ShowDialog();
      this.Show();
    }

    private void button1_Click(object sender, EventArgs e) {
      int schoolNumber2, programming2, design2;
      if (!string.IsNullOrWhiteSpace(textBox1.Text)) {
        if (!string.IsNullOrWhiteSpace(textBox2.Text)) {
          if (!string.IsNullOrWhiteSpace(textBox3.Text)) {
            if (int.TryParse(textBox4.Text, out schoolNumber2) && (schoolNumber2 > 0)) {
              if (int.TryParse(textBox5.Text, out programming2) && (programming2 > 0)) {
                if (int.TryParse(textBox6.Text, out design2) && (design2 > 0)) {
                  SchoolboyInfo newStudent = new SchoolboyInfo(textBox1.Text, textBox2.Text, textBox3.Text, int.Parse(textBox4.Text), int.Parse(textBox4.Text), int.Parse(textBox4.Text));
                  SchoolboyInfo.WriteInFile(newStudent);
                } else {
                  MessageBox.Show("Error input Design", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              } else {
                MessageBox.Show("Error input Programming", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
            } else {
              MessageBox.Show("Error input School number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          } else {
            MessageBox.Show("Error input Group", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        } else {
          MessageBox.Show("Error input Last name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      } else {
        MessageBox.Show("Error input First name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void button3_Click(object sender, EventArgs e) {
      textBox1.Clear();
      textBox2.Clear();
      textBox3.Clear();
      textBox4.Clear();
    }
  }
}