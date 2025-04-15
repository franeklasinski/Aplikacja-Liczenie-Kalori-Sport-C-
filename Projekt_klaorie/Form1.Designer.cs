using System.Windows.Forms;

namespace Projekt_klaorie
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private System.Windows.Forms.ListBox PotrawyBox;
        private System.Windows.Forms.Button Potrawy_Usun;
        private System.Windows.Forms.GroupBox Potrawy_box;
        public System.Windows.Forms.TextBox Kalorie_potrawy;
        private System.Windows.Forms.TextBox Nazwa_potrawy;
        private System.Windows.Forms.Button Potrawy_Dodaj;
        private System.Windows.Forms.GroupBox Osoby_Box;
        private System.Windows.Forms.ListBox BoxOsoby;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Osoby_nazwisko;
        private System.Windows.Forms.TextBox Osoby_imie;
        private System.Windows.Forms.Button Osoby_usun;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Osoby_cel;
        private System.Windows.Forms.TextBox Osoby_wzrost;
        private System.Windows.Forms.TextBox Osoby_waga;
        private System.Windows.Forms.TextBox Osoby_plec;
        private System.Windows.Forms.TextBox Osoby_wiek;
        private System.Windows.Forms.Button Osoby_dodaj;
        private System.Windows.Forms.GroupBox Sporty_Box;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Sporty_dodaj;
        public System.Windows.Forms.TextBox kalorie_sport;
        private System.Windows.Forms.TextBox nazwa_sportu;
        private System.Windows.Forms.Button Sporty_usun;
        private System.Windows.Forms.ListBox SportyBox;
        private System.Windows.Forms.GroupBox Posilki_Box;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox PotrawaCombo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox OsobaCombo;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button Posilki_Usuń;
        private System.Windows.Forms.ListBox PosilkiBox;
        private System.Windows.Forms.GroupBox Posilki_Box_Box;
        private System.Windows.Forms.Button Posilki_dodaj;
        private System.Windows.Forms.GroupBox Treningi_Box;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Treningi_Dodaj;
        private System.Windows.Forms.ListBox TreningiBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button Treningi_Usun;
        private System.Windows.Forms.ComboBox SportyCombo;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox TreningiCombo;
        private System.Windows.Forms.GroupBox Statystyki_Box;
        private System.Windows.Forms.GroupBox groupBoxStatystyki1;
        private System.Windows.Forms.DataVisualization.Charting.Chart wykres;
        private System.Windows.Forms.DateTimePicker DataDo;
        private System.Windows.Forms.DateTimePicker DataOd;
        private System.Windows.Forms.ComboBox StatystykiCombo;
        private System.Windows.Forms.Label Srednia_kcal;
        private System.Windows.Forms.Label Bilans_kcal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label26;
    }
    }

