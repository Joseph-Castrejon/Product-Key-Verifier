using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;

namespace ProductKeyVerifier
{
    public class App 
    {
        //Replace the string here to check other product keys.
        const string ProductKey = "G1CZ0-WE8I4-CJ7IQ-38L89-9O57N";

        [STAThread]
        static public void Main() 
        {
            Key_Input Form = new Key_Input();
            Form.ShowDialog();
        }

        public class Key_Input : Form
        {
            Button EnterKey = new Button();
            Size FormSize = new Size(575,220);
            //Create the components of the form.
            Label MainLabel = new Label();
            Label[] Hyphens = new Label[4];
            TextBox[] KeyStrings = new TextBox[5];


            Size InputSize = new Size(75, 30);
            Font MainLabelFont = new Font(FontFamily.GenericSerif, 20F, FontStyle.Bold);
            Font KeyStringFont = new Font(FontFamily.GenericMonospace, 16F, FontStyle.Regular);
            Font HyphenFont = new Font(FontFamily.GenericMonospace, 16F, FontStyle.Regular);

            public Key_Input()
            {
                InitializeComponent();
            }

            private void InitializeComponent() 
            {
                MainLabel.Text = "Enter the product key below";
                MainLabel.TextAlign = ContentAlignment.MiddleCenter;
                MainLabel.Size = new Size(575, 48);
                MainLabel.Location = new Point(0,10);

                EnterKey.Size = new Size(80,35);
                EnterKey.Text = "Enter";
                EnterKey.Location = new Point(260,140);

                this.Controls.Add(MainLabel);

                //Initialiaze the hyphens.
                for (int x = 0; x < 4; x++) 
                {
                    Hyphens[x] = new Label();
                    Hyphens[x].Font = HyphenFont;
                    Hyphens[x].Text = "-";
                    Hyphens[x].Size = new Size(20,30);
                    Hyphens[x].Location = new Point(x*100 + 130,80);
                    this.Controls.Add(Hyphens[x]);
                }

                //Initialize the text boxes for key strings.
                for (int x = 0; x < KeyStrings.Length; x++) 
                {
                    KeyStrings[x] = new TextBox();
                    KeyStrings[x].Size = InputSize;
                    KeyStrings[x].TextAlign = HorizontalAlignment.Center;
                    KeyStrings[x].Font = KeyStringFont;
                    KeyStrings[x].MaxLength = 5;
                    KeyStrings[x].Multiline = false;
                    KeyStrings[x].Location = new Point(x*100 + 50, 75);
                    KeyStrings[x].CharacterCasing = CharacterCasing.Upper;
                    this.Controls.Add(KeyStrings[x]);
                }

                this.Text = "Software Registration";
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Controls.Add(EnterKey);
                EnterKey.Click += new EventHandler(EnterKey_Click);
                this.Size = FormSize;
                this.MaximumSize = new Size(600,250);


            }

            private void EnterKey_Click(object sender, EventArgs e)
            {
                 
                string[] KeyBlock = new string[5];

                //Read text
                for (int x = 0; x < KeyStrings.Length; x++) 
                {
                    KeyBlock[x] = KeyStrings[x].Text;
                }

                //Add hyphens to sections.
                string EnteredKey = String.Join("-", KeyBlock);

                if (EnteredKey == ProductKey)
                {
                    MessageBox.Show("Software Registration Successful");
                }
                else 
                {
                    MessageBox.Show("Incorrect Product Key", "ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }


            }
        }


    }


}
