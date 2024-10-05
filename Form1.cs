
namespace ClinicalEncounter
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            this.ChangeEnabled(true);


            this.listBox1.Enabled = false; 
            this.textBox2.Enabled = true;
            this.button4.Enabled = false;
            this.button3.Enabled = true;
            this.button5.Enabled = false;
            this.button2.Enabled = true;






        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var pathing = "C:\\Users\\Comp\\source\\repos\\ClinicalEncounter\\ClinicalEncounter\\notes.txt"; // easily switchable to some database like SQL
            string[] lines_read = File.ReadAllLines(pathing, Encoding.UTF8);
            richTextBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            this.ChangeEnabled(true);

         
            

            this.button3.Enabled = false; 
            this.textBox2.Enabled = false;

            foreach (string line_by_line in lines_read)
            {
                string[] single_words = line_by_line.Split('|'); 

                string word = single_words[1] + " (Note: " + single_words[0] + ")"; 
               

                foreach (var item in listBox1.SelectedItems)
                {
                    // use a loop to find an item in listbox1 

                    if (item.ToString() == word) // if that item is same as word
                    {
                        textBox2.AppendText(single_words[0]); // we will add up to textbox2 specific words (NoteID)

                        textBox3.AppendText(single_words[1]); // same with texbox3 for name


                        // words[2] date

                        string[] date_as_month = single_words[2].Split(' ');

                        int single_month = 0; // procedure for doing the date, dates[1] is written with words but to make it a date
                        // we have to set up a number instead of word
                        if (date_as_month[1] == "January")
                        {
                            single_month = 1;
                        }
                        if (date_as_month[1] == "February")
                        {
                            single_month = 2;
                        }

                        if (date_as_month[1] == "March")
                        {
                            single_month = 3;
                        }

                        if (date_as_month[1] == "April")
                        {
                            single_month = 4;
                        }

                        if (date_as_month[1] == "May")
                        {
                            single_month = 5;
                        }
                        if (date_as_month[1] == "June")
                        {
                            single_month = 6;
                        }
                        if (date_as_month[1] == "July")
                        {
                            single_month = 7;
                        }
                        if (date_as_month[1] == "August")
                        {
                            single_month = 8;
                        }
                        if (date_as_month[1] == "September")
                        {
                            single_month = 9;
                        }
                        if (date_as_month[1] == "October")
                        {
                            single_month = 10;
                        }
                        if (date_as_month[1] == "November")
                        {
                            single_month = 11;
                        }
                        if (date_as_month[1] == "December")
                        {
                            single_month = 12;
                        }

                    
                        dateTimePicker1.Value = new DateTime(int.Parse(date_as_month[2]), single_month, int.Parse(date_as_month[0]));
                        string[] problems = single_words[3].Split(';');
                        foreach(var prob in problems) { 
                            listBox3.Items.Add(prob);
                           
                        }

                        string notetxt = "";
                        foreach(var pt in single_words[4]) 
                            // differences
                        {
                            if(pt == ';')
                            {

                                notetxt += "\n";
                            }
                            else
                            {
                                notetxt += pt;
                            }

                            
                          
                        }

                        string sentnc = "";
                        for(int i = 4;i < single_words[4].Length;i++)
                        {

                            if (single_words[4][i] == ';')
                            {
                                break;
                            }

                            sentnc += single_words[4][i];
                        }
                        listBox2.Items.Add(sentnc); 

                        richTextBox1.AppendText(notetxt); 


                    }


                }

                


            }

           

        }

        private void label1_Click(object sender, EventArgs e) 
        {
           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e) 
        {
            var path = "C:\\Users\\Comp\\source\\repos\\ClinicalEncounter\\ClinicalEncounter\\notes.txt";
            string[] lines_of_text = File.ReadAllLines(path, Encoding.UTF8);

            foreach (string single_line in lines_of_text)
            {
                string[] words = single_line.Split('|');

                string single_word =  words[1] + " (Note: " + words[0] + ")";


                listBox1.Items.Add(single_word); 
            }
           
            dateTimePicker1.CustomFormat = "dd MMM yyyy"; 
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

            this.ChangeEnabled(false);
            listBox1.Enabled = true;
            button1.Enabled = true;


        }

        private void groupBox1_Enter(object sender, EventArgs e) 
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            var path = "C:\\Users\\Comp\\source\\repos\\ClinicalEncounter\\ClinicalEncounter\\notes.txt";
            string lines = File.ReadAllText(path, Encoding.UTF8);
            string[] lines_all = File.ReadAllLines(path, Encoding.UTF8);
            listBox3.Enabled = true;
            string note = textBox2.Text;
           

           if( Regex.IsMatch(note, @"^\d+$") == false)
            {
                MessageBox.Show("Note ID is not a number");
                throw new Exception("Note ID is not a number"); 

            }

            for (int i =0;i<lines_all.Length;i++)
            {

                int number = int.Parse(note);
                string n = "";
                n += lines_all[i][0];
                int number2 = int.Parse(n);

                if( number == number2) 
                {
                    MessageBox.Show("Note ID is not unique");
                    throw new Exception("ID is not unique");
                }

            }

            while(textBox3.Text.Length == 0) 
            {
                MessageBox.Show("Name can not be empty");
                return;


            }


            string name = textBox3.Text;

            // date

            if(dateTimePicker1.Value > DateTime.Today) 
            {
                MessageBox.Show("Date can not be in the future");
                return;
            }

            string date_picker = dateTimePicker1.Value.ToString("dd MMMM yyyy");

            string probs = "";
            foreach (var i in listBox3.Items) {

                probs += i;
                probs += ";"; 


            }
          
            string probs_new = "";
            for (int i = 0;i<probs.Length-1;i++)
            {

                probs_new += probs[i];

            }




           
            while (richTextBox1.Text.Length == 0)
            {
                MessageBox.Show("Note content can not be empty");
                return;


            }

            string rb1 = richTextBox1.Text;




            string richtext = "";

            for (int i = 0; i < rb1.Length; i++)
            {

                if (rb1[i] == '\n')
                {
                    richtext += ";";
                }
                else
                {
                    richtext += rb1[i];
                }

            }
        
            string note_new = note + "|" + name + "|" + date_picker + "|" + probs_new + "|" + richtext;

            lines += "\n";
            lines += note_new;

            listBox1.Enabled = true; 
            string item1 =  name + " (Note: " + note + ")";
            listBox1.Items.Add(item1);

            File.WriteAllText(path, lines, Encoding.UTF8);

            this.ChangeEnabled(true);



            this.button3.Enabled = false;
            this.textBox2.Enabled = false;
            this.button4.Enabled = true;
            this.button5.Enabled = true;




        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            var path = "C:\\Users\\Comp\\source\\repos\\ClinicalEncounter\\ClinicalEncounter\\notes.txt";
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            int counter = 0;
            int check = 0;
         
            foreach (string line in lines)
            {
                string[] words = line.Split('|');

                string word = words[1] + " (Note: " + words[0] + ")";

                foreach (var item in listBox1.SelectedItems)
                {


                    if (item.ToString() == word)
                    {
                      

                        check = 1; 



                      
                        break;

                    }


                }
                if (check == 1) break;
                counter++; 
            }

            if (check == 1)
            {

                string lines_new = "";

                for(int i = 0;i<lines.Length;i++)
                {

                    if (i+1 == counter) 
                    {

                        lines_new += lines[i];
                        continue;

                    }

                    if ( i == counter )
                    {
                      

                    }
                    else
                    {

                        lines_new += lines[i];
                        if(i != lines.Length-1) {
                            lines_new += "\n"; 
                        }
                      

                    }

                }

                File.WriteAllText(path, lines_new, Encoding.UTF8); 


                listBox1.Items.RemoveAt(counter); 

                this.ChangeEnabled(false);
                listBox1.Enabled = true;
                button1.Enabled = true; 

            }


        }

        private void label5_Click(object sender, EventArgs e) 
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
              var path = "C:\\Users\\Comp\\source\\repos\\ClinicalEncounter\\ClinicalEncounter\\notes.txt";
              string[] lines = File.ReadAllLines(path, Encoding.UTF8); 
            int counter = 0;
            int check = 0;
            string s2 = "";
            string date = "";
            string problems = "";
            string bpthing = "";
            foreach (string line in lines)
            {
                string[] words = line.Split('|');

                string word = words[1] + " (Note: " + words[0] + ")";

                foreach (var item in listBox1.SelectedItems)
                {

                    
                    if (item.ToString() == word)
                    {
                        s2 = words[1];
                        date = words[2]; 
                        check = 1;



                         problems = words[3];

                        bpthing = words[4];
                        break;

                    }

                   
                }
                if (check == 1) break;
                counter++;
            }
            
            if(check == 1)
            { 
                string tb3 = textBox3.Text; 
                string rb1 = richTextBox1.Text;
                

                string date_picker = dateTimePicker1.Value.ToString("dd MMMM yyyy"); 

                


                string s = textBox3.Text + " (Note: " + textBox2.Text + ")";
                listBox1.Items.RemoveAt(counter);
               listBox1.Items.Insert(counter, s); 
                string text = File.ReadAllText(path, Encoding.UTF8);
               
                
                text = text.Replace(date, date_picker); 
                text = text.Replace(s2, tb3);

               

                string richtext = "";

                for(int i = 0;i< rb1.Length;i++)
                {

                    if (rb1[i] == '\n')
                    {
                        richtext += ";";
                    }
                    else
                    {
                        richtext += rb1[i];
                    }
                   
                }



                text = text.Replace(bpthing, richtext);





                File.WriteAllText(path, text,Encoding.UTF8);
                this.ChangeEnabled(false);
                listBox1.Enabled = true;
                button1.Enabled = true;

            }


        }

        private void textBox3_TextChanged(object sender, EventArgs e) 
        {

        }


        void ChangeEnabled(bool enabled)
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = enabled;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            var path = "C:\\Users\\Comp\\source\\repos\\ClinicalEncounter\\ClinicalEncounter\\notes.txt";
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            int counter = 0;
            int check = 0;
          
            string problems = "";

            if(listBox1.Enabled == false)
            {
                listBox1.ClearSelected();
                listBox3.Items.Add(textBox4.Text);
                return;
            }

            foreach (string line in lines)
            {
                string[] words = line.Split('|'); 

                string word = words[1] + " (Note: " + words[0] + ")";

                foreach (var item in listBox1.SelectedItems)
                {


                    if (item.ToString() == word)
                    {
                      
                        check = 1;



                        problems = words[3];
                        break;

                    }


                }
                if (check == 1)
                {
                    break;
                }
                counter++;
            }
            if (check == 1)
            {
                string text = File.ReadAllText(path, Encoding.UTF8);
                if (textBox4.Text.Length > 0)
                {

                    string problems_new = problems;
                    problems_new += ";" + textBox4.Text; 
                    text = text.Replace(problems, problems_new);
                    listBox3.Items.Add(textBox4.Text);


                }

                File.WriteAllText(path, text, Encoding.UTF8);

            }

         
        }
    }
}