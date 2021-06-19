using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolko_krzyzyk
{
    public partial class Form1 : Form
    {
        bool tura = false; // tura ustawina na false oznacza ture gracza ustawiona na true ture AI
        //int licznik_tur = 0;

        int a = 0;
        int b = 0;
        bool przeciwkomputerowi = true;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void trybToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {

        }

        private void informacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kółko i krzyżyk v1.0.0 \nRobert Żyłka 48750 \ninformatyka studia niestacjonarne ");
        }

        private void jakGracToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gra domyślnie jest ustawiona na grę z komputerem,. \nAby zagrać z innym graczem należy w zakładce Menu/Tryb wybrać Dwóch graczy.\n\n" +
                "ZASADY GRY" +
                "\n\n1. Zawsze zaczyna gracz grający X (gracz komputerowy gra O)" +
                "\n2. Gracze wykonują swoje ruchy naprzemiennie aż do wygranej jednego z nich lub do remisu" +
                "\n3. Wygrana następuje gdy w jednej linii (wertykalnej, diagonalnej lub horyzontalnej) znajdą się trzy takie same znaki");
        }

        private void koniecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Uruchom();
        }


        private void Uruchom()
        {


            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;


            label1.Visible = true;
            label1.Text = a.ToString();
            label2.Visible = true;
            label2.Text = b.ToString();

            button10.Enabled = false;
            uruchomToolStripMenuItem.Enabled = false;

        }

        private void buttonClick(object sender, EventArgs e)
        {
            {
                Button btn = (Button)sender;
                if (tura)
                    btn.Text = "O";
                else
                    btn.Text = "X";
                label6.Visible = false;
                tura = !tura;
                btn.Enabled = false;
                Check();
            }
            if ((tura) && (przeciwkomputerowi))
            {
                ruch_komputera();
            }
        }

        private void ruch_komputera()
        {
            Button ruch = null;

            ruch = szukaj_wygranej();
            if (ruch == null)
            {
                ruch = szukaj_bloku();
                if (ruch == null)
                {
                    ruch = szukaj_ruchu();
                }
            }
            if (ruch != null)
            {
                ruch.PerformClick();
                label6.Visible = true;
            }
            
        }
        private Button szukaj_ruchu()
        {
            label6.Visible = true;
            label6.Text = "Uderzę tam gdzie się tego najmniej spodziewasz";
            Button btn = null;
            foreach (Control Ctrl in Controls)
            {
                btn = Ctrl as Button;
                if (btn != null)
                {
                    if (btn.Text == "")
                    {
                        return btn;
                    }
                        
                }
            }
            return null;
        }
        
        private Button szukaj_wygranej()
        {
            label6.Visible = true;
            label6.Text = "W następnym ruch wygram";
            //sprawdzanie horyzontalne
            if ((button1.Text == "O") && (button2.Text == "O") && (button3.Text == ""))
                return button3;
            if ((button4.Text == "O") && (button5.Text == "O") && (button6.Text == ""))
                return button6;
            if ((button7.Text == "O") && (button8.Text == "O") && (button9.Text == ""))
                return button9;

            if ((button1.Text == "O") && (button2.Text == "") && (button3.Text == "O"))
                return button2;
            if ((button4.Text == "O") && (button5.Text == "") && (button6.Text == "O"))
                return button5;
            if ((button7.Text == "O") && (button8.Text == "") && (button9.Text == "O"))
                return button8;

            if ((button1.Text == "") && (button2.Text == "O") && (button3.Text == "O"))
                return button1;
            if ((button4.Text == "") && (button5.Text == "O") && (button6.Text == "O"))
                return button4;
            if ((button7.Text == "") && (button8.Text == "O") && (button9.Text == "O"))
                return button7;
            // sprawdzanie wertykalne
            if ((button1.Text == "O") && (button4.Text == "O") && (button7.Text == ""))
                return button7;
            if ((button2.Text == "O") && (button5.Text == "O") && (button8.Text == ""))
                return button8;
            if ((button3.Text == "O") && (button6.Text == "O") && (button9.Text == ""))
                return button9;

            if ((button1.Text == "O") && (button4.Text == "") && (button7.Text == "O"))
                return button4;
            if ((button2.Text == "O") && (button5.Text == "") && (button8.Text == "O"))
                return button5;
            if ((button3.Text == "O") && (button6.Text == "") && (button9.Text == "O"))
                return button6;

            if ((button1.Text == "") && (button4.Text == "O") && (button7.Text == "O"))
                return button1;
            if ((button2.Text == "") && (button5.Text == "O") && (button8.Text == "O"))
                return button2;
            if ((button3.Text == "") && (button6.Text == "O") && (button9.Text == "O"))
                return button3;
            //sprawdzanie diagonalne
            if ((button1.Text == "O") && (button5.Text == "O") && (button9.Text == ""))
                return button9;
            if ((button1.Text == "O") && (button5.Text == "") && (button9.Text == "O"))
                return button5;
            if ((button1.Text == "") && (button5.Text == "O") && (button9.Text == "O"))
                return button1;

            if ((button3.Text == "O") && (button5.Text == "O") && (button7.Text == ""))
                return button7;
            if ((button3.Text == "O") && (button5.Text == "") && (button7.Text == "O"))
                return button5;
            if ((button3.Text == "") && (button5.Text == "O") && (button7.Text == "O"))
                return button3;

            return null;


        }
        private Button szukaj_bloku()
        {
            label6.Visible = true;
            label6.Text = "Zablokuje twoją wygraną";
            //sprawdzanie horyzontalne
            if ((button1.Text == "X") && (button2.Text == "X") && (button3.Text == ""))
                return button3;
            if ((button4.Text == "X") && (button5.Text == "X") && (button6.Text == ""))
                return button6;
            if ((button7.Text == "X") && (button8.Text == "X") && (button9.Text == ""))
                return button9;

            if ((button1.Text == "X") && (button2.Text == "") && (button3.Text == "X"))
                return button2;
            if ((button4.Text == "X") && (button5.Text == "") && (button6.Text == "X"))
                return button5;
            if ((button7.Text == "X") && (button8.Text == "") && (button9.Text == "X"))
                return button8;

            if ((button1.Text == "") && (button2.Text == "X") && (button3.Text == "X"))
                return button1;
            if ((button4.Text == "") && (button5.Text == "X") && (button6.Text == "X"))
                return button4;
            if ((button7.Text == "") && (button8.Text == "X") && (button9.Text == "X"))
                return button7;
            // sprawdzanie wertykalne
            if ((button1.Text == "X") && (button4.Text == "X") && (button7.Text == ""))
                return button7;
            if ((button2.Text == "X") && (button5.Text == "X") && (button8.Text == ""))
                return button8;
            if ((button3.Text == "X") && (button6.Text == "X") && (button9.Text == ""))
                return button9;

            if ((button1.Text == "X") && (button4.Text == "") && (button7.Text == "X"))
                return button4;
            if ((button2.Text == "X") && (button5.Text == "") && (button8.Text == "X"))
                return button5;
            if ((button3.Text == "X") && (button6.Text == "") && (button9.Text == "X"))
                return button6;

            if ((button1.Text == "") && (button4.Text == "X") && (button7.Text == "X"))
                return button1;
            if ((button2.Text == "") && (button5.Text == "X") && (button8.Text == "X"))
                return button2;
            if ((button3.Text == "") && (button6.Text == "X") && (button9.Text == "X"))
                return button3;
            //sprawdzanie diagonalne
            if ((button1.Text == "X") && (button5.Text == "X") && (button9.Text == ""))
                return button9;
            if ((button1.Text == "X") && (button5.Text == "") && (button9.Text == "X"))
                return button5;
            if ((button1.Text == "") && (button5.Text == "X") && (button9.Text == "X"))
                return button1;

            if ((button3.Text == "X") && (button5.Text == "X") && (button7.Text == ""))
                return button7;
            if ((button3.Text == "X") && (button5.Text == "") && (button7.Text == "X"))
                return button5;
            if ((button3.Text == "") && (button5.Text == "X") && (button7.Text == "X"))
                return button3;

            return null;
        }



        private void Check()
        {
            if (
            button1.Text == "X" && button2.Text == "X" && button3.Text == "X" ||
            button4.Text == "X" && button5.Text == "X" && button6.Text == "X" ||
            button7.Text == "X" && button8.Text == "X" && button9.Text == "X" ||
            button1.Text == "X" && button4.Text == "X" && button7.Text == "X" ||
            button2.Text == "X" && button5.Text == "X" && button8.Text == "X" ||
            button3.Text == "X" && button6.Text == "X" && button9.Text == "X" ||
            button1.Text == "X" && button5.Text == "X" && button9.Text == "X" ||
            button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
                )
            {
                Wygrana();
                label5.Visible = true;
                label5.Text = "Gracz WYGRYWA";
                a = a + 1;
                label1.Text = a.ToString();
            }
            else if (
            button1.Text == "O" && button2.Text == "O" && button3.Text == "O" ||
            button4.Text == "O" && button5.Text == "O" && button6.Text == "O" ||
            button7.Text == "O" && button8.Text == "O" && button9.Text == "O" ||
            button1.Text == "O" && button4.Text == "O" && button7.Text == "O" ||
            button2.Text == "O" && button5.Text == "O" && button8.Text == "O" ||
            button3.Text == "O" && button6.Text == "O" && button9.Text == "O" ||
            button1.Text == "O" && button5.Text == "O" && button9.Text == "O" ||
            button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
                )
            {
                Wygrana();
                label5.Visible = true;
                label5.Text = "Gracz AI WYGRYWA";
                b = b + 1;
                label2.Text = b.ToString();
            }
        }
        private void Wygrana()
        {
            foreach (Control x in this.Controls)
            {

                if (x is Button && x.Tag == "Gra")
                {
                    ((Button)x).Enabled = false;
                }

            }
        }


        private void Reset(object sender, EventArgs e)
        {
            label5.Visible = false;
            foreach (Control x in this.Controls)
            {
                if(x is Button && x.Tag == "Gra")
                {
                    ((Button)x).Enabled = true;
                    ((Button)x).Text = "";
                }
            }
            bool tura = false;
        }

        private void uruchomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uruchom();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            foreach (Control x in this.Controls)
            {
                if (x is Button && x.Tag == "Gra")
                {
                    ((Button)x).Enabled = true;
                    ((Button)x).Text = "";
                }
            }
            bool tura = false;
        }

        private void pojedyńczyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool przeciwkomputerowi = true;
        }

        private void dwóchGraczyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool przeciwkomputerowi = false;
        }
    }
}
