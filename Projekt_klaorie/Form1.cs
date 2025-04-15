using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Data.SQLite;
using System.Collections;
using System.IO;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Reflection;

namespace Projekt_klaorie
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            ZaladujJedzenie(); //
            ZaladujOsoby();//
            ZaladujSporty();//
            ZaladujTreningi();//
            ZaladujPosilki();
            UkryjWszystko();
            PokazKontroler(Potrawy_box);  
            // pictureBox1.Visible = true;
        }
        #region Inicjalizacja komponentów
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PotrawyBox = new System.Windows.Forms.ListBox();
            this.Potrawy_Usun = new System.Windows.Forms.Button();
            this.Potrawy_box = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Potrawy_Dodaj = new System.Windows.Forms.Button();
            this.Kalorie_potrawy = new System.Windows.Forms.TextBox();
            this.Nazwa_potrawy = new System.Windows.Forms.TextBox();
            this.Osoby_Box = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.Osoby_dodaj = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Osoby_cel = new System.Windows.Forms.TextBox();
            this.Osoby_wzrost = new System.Windows.Forms.TextBox();
            this.Osoby_waga = new System.Windows.Forms.TextBox();
            this.Osoby_plec = new System.Windows.Forms.TextBox();
            this.Osoby_wiek = new System.Windows.Forms.TextBox();
            this.Osoby_nazwisko = new System.Windows.Forms.TextBox();
            this.Osoby_imie = new System.Windows.Forms.TextBox();
            this.Osoby_usun = new System.Windows.Forms.Button();
            this.BoxOsoby = new System.Windows.Forms.ListBox();
            this.Sporty_Box = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Sporty_dodaj = new System.Windows.Forms.Button();
            this.kalorie_sport = new System.Windows.Forms.TextBox();
            this.nazwa_sportu = new System.Windows.Forms.TextBox();
            this.Sporty_usun = new System.Windows.Forms.Button();
            this.SportyBox = new System.Windows.Forms.ListBox();
            this.Posilki_Box = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.Posilki_Box_Box = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.Posilki_dodaj = new System.Windows.Forms.Button();
            this.PosilkiBox = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Posilki_Usuń = new System.Windows.Forms.Button();
            this.PotrawaCombo = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.OsobaCombo = new System.Windows.Forms.ComboBox();
            this.Treningi_Box = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.Treningi_Dodaj = new System.Windows.Forms.Button();
            this.TreningiBox = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Treningi_Usun = new System.Windows.Forms.Button();
            this.SportyCombo = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.TreningiCombo = new System.Windows.Forms.ComboBox();
            this.Statystyki_Box = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBoxStatystyki1 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Srednia_kcal = new System.Windows.Forms.Label();
            this.Bilans_kcal = new System.Windows.Forms.Label();
            this.wykres = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DataDo = new System.Windows.Forms.DateTimePicker();
            this.DataOd = new System.Windows.Forms.DateTimePicker();
            this.StatystykiCombo = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.Potrawy_box.SuspendLayout();
            this.Osoby_Box.SuspendLayout();
            this.Sporty_Box.SuspendLayout();
            this.Posilki_Box.SuspendLayout();
            this.Posilki_Box_Box.SuspendLayout();
            this.Treningi_Box.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Statystyki_Box.SuspendLayout();
            this.groupBoxStatystyki1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wykres)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PotrawyBox
            // 
            this.PotrawyBox.FormattingEnabled = true;
            this.PotrawyBox.Location = new System.Drawing.Point(301, 67);
            this.PotrawyBox.Name = "PotrawyBox";
            this.PotrawyBox.Size = new System.Drawing.Size(264, 342);
            this.PotrawyBox.TabIndex = 0;
            this.PotrawyBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Potrawy_Usun
            // 
            this.Potrawy_Usun.Location = new System.Drawing.Point(352, 430);
            this.Potrawy_Usun.Name = "Potrawy_Usun";
            this.Potrawy_Usun.Size = new System.Drawing.Size(157, 46);
            this.Potrawy_Usun.TabIndex = 1;
            this.Potrawy_Usun.Text = "Usun potrawę";
            this.Potrawy_Usun.UseVisualStyleBackColor = true;
            this.Potrawy_Usun.Click += new System.EventHandler(this.button1_Click);
            // 
            // Potrawy_box
            // 
            this.Potrawy_box.BackColor = System.Drawing.Color.Transparent;
            this.Potrawy_box.Controls.Add(this.label23);
            this.Potrawy_box.Controls.Add(this.label2);
            this.Potrawy_box.Controls.Add(this.label1);
            this.Potrawy_box.Controls.Add(this.Potrawy_Dodaj);
            this.Potrawy_box.Controls.Add(this.Kalorie_potrawy);
            this.Potrawy_box.Controls.Add(this.Nazwa_potrawy);
            this.Potrawy_box.Controls.Add(this.PotrawyBox);
            this.Potrawy_box.Controls.Add(this.Potrawy_Usun);
            this.Potrawy_box.Location = new System.Drawing.Point(1, 25);
            this.Potrawy_box.Name = "Potrawy_box";
            this.Potrawy_box.Size = new System.Drawing.Size(674, 527);
            this.Potrawy_box.TabIndex = 2;
            this.Potrawy_box.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label23.Location = new System.Drawing.Point(22, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(278, 18);
            this.label23.TabIndex = 15;
            this.label23.Text = "Spis dostępnych produktów w bazie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ilość kalorii";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nazwa potrawy";
            // 
            // Potrawy_Dodaj
            // 
            this.Potrawy_Dodaj.Location = new System.Drawing.Point(24, 166);
            this.Potrawy_Dodaj.Name = "Potrawy_Dodaj";
            this.Potrawy_Dodaj.Size = new System.Drawing.Size(165, 45);
            this.Potrawy_Dodaj.TabIndex = 4;
            this.Potrawy_Dodaj.Text = "Dodaj";
            this.Potrawy_Dodaj.UseVisualStyleBackColor = true;
            this.Potrawy_Dodaj.Click += new System.EventHandler(this.Dodaj_button_Click);
            // 
            // Kalorie_potrawy
            // 
            this.Kalorie_potrawy.Location = new System.Drawing.Point(24, 127);
            this.Kalorie_potrawy.Name = "Kalorie_potrawy";
            this.Kalorie_potrawy.Size = new System.Drawing.Size(165, 20);
            this.Kalorie_potrawy.TabIndex = 3;
            this.Kalorie_potrawy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Kalorie_potrawy_KeyPress);
            // 
            // Nazwa_potrawy
            // 
            this.Nazwa_potrawy.Location = new System.Drawing.Point(24, 71);
            this.Nazwa_potrawy.Name = "Nazwa_potrawy";
            this.Nazwa_potrawy.Size = new System.Drawing.Size(165, 20);
            this.Nazwa_potrawy.TabIndex = 2;
            // 
            // Osoby_Box
            // 
            this.Osoby_Box.BackColor = System.Drawing.Color.Transparent;
            this.Osoby_Box.Controls.Add(this.label26);
            this.Osoby_Box.Controls.Add(this.Osoby_dodaj);
            this.Osoby_Box.Controls.Add(this.label9);
            this.Osoby_Box.Controls.Add(this.label8);
            this.Osoby_Box.Controls.Add(this.label7);
            this.Osoby_Box.Controls.Add(this.label6);
            this.Osoby_Box.Controls.Add(this.label5);
            this.Osoby_Box.Controls.Add(this.label4);
            this.Osoby_Box.Controls.Add(this.label3);
            this.Osoby_Box.Controls.Add(this.Osoby_cel);
            this.Osoby_Box.Controls.Add(this.Osoby_wzrost);
            this.Osoby_Box.Controls.Add(this.Osoby_waga);
            this.Osoby_Box.Controls.Add(this.Osoby_plec);
            this.Osoby_Box.Controls.Add(this.Osoby_wiek);
            this.Osoby_Box.Controls.Add(this.Osoby_nazwisko);
            this.Osoby_Box.Controls.Add(this.Osoby_imie);
            this.Osoby_Box.Controls.Add(this.Osoby_usun);
            this.Osoby_Box.Controls.Add(this.BoxOsoby);
            this.Osoby_Box.Location = new System.Drawing.Point(1, 25);
            this.Osoby_Box.Name = "Osoby_Box";
            this.Osoby_Box.Size = new System.Drawing.Size(674, 527);
            this.Osoby_Box.TabIndex = 5;
            this.Osoby_Box.TabStop = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label26.Location = new System.Drawing.Point(17, 14);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(237, 18);
            this.label26.TabIndex = 17;
            this.label26.Text = "Spis dostępnych osób w bazie";
            // 
            // Osoby_dodaj
            // 
            this.Osoby_dodaj.Location = new System.Drawing.Point(25, 307);
            this.Osoby_dodaj.Name = "Osoby_dodaj";
            this.Osoby_dodaj.Size = new System.Drawing.Size(168, 34);
            this.Osoby_dodaj.TabIndex = 16;
            this.Osoby_dodaj.Text = "Dodaj osobę";
            this.Osoby_dodaj.UseVisualStyleBackColor = true;
            this.Osoby_dodaj.Click += new System.EventHandler(this.Osoby_dodaj_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 252);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Cel kaloryczny";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Wzrost (w cm)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Waga (w kg)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Płeć";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Wiek";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nazwisko";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Imię";
            // 
            // Osoby_cel
            // 
            this.Osoby_cel.Location = new System.Drawing.Point(25, 267);
            this.Osoby_cel.Name = "Osoby_cel";
            this.Osoby_cel.Size = new System.Drawing.Size(100, 20);
            this.Osoby_cel.TabIndex = 8;
            this.Osoby_cel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Osoby_cel_KeyPress);
            // 
            // Osoby_wzrost
            // 
            this.Osoby_wzrost.Location = new System.Drawing.Point(163, 217);
            this.Osoby_wzrost.Name = "Osoby_wzrost";
            this.Osoby_wzrost.Size = new System.Drawing.Size(132, 20);
            this.Osoby_wzrost.TabIndex = 7;
            this.Osoby_wzrost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Osoby_wzrost_KeyPress);
            // 
            // Osoby_waga
            // 
            this.Osoby_waga.Location = new System.Drawing.Point(25, 217);
            this.Osoby_waga.Name = "Osoby_waga";
            this.Osoby_waga.Size = new System.Drawing.Size(127, 20);
            this.Osoby_waga.TabIndex = 6;
            this.Osoby_waga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Osoby_waga_KeyPress);
            // 
            // Osoby_plec
            // 
            this.Osoby_plec.Location = new System.Drawing.Point(25, 167);
            this.Osoby_plec.Name = "Osoby_plec";
            this.Osoby_plec.Size = new System.Drawing.Size(127, 20);
            this.Osoby_plec.TabIndex = 5;
            // 
            // Osoby_wiek
            // 
            this.Osoby_wiek.Location = new System.Drawing.Point(25, 124);
            this.Osoby_wiek.Name = "Osoby_wiek";
            this.Osoby_wiek.Size = new System.Drawing.Size(127, 20);
            this.Osoby_wiek.TabIndex = 4;
            this.Osoby_wiek.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Osoby_wiek_KeyPress);
            // 
            // Osoby_nazwisko
            // 
            this.Osoby_nazwisko.Location = new System.Drawing.Point(166, 82);
            this.Osoby_nazwisko.Name = "Osoby_nazwisko";
            this.Osoby_nazwisko.Size = new System.Drawing.Size(129, 20);
            this.Osoby_nazwisko.TabIndex = 3;
            // 
            // Osoby_imie
            // 
            this.Osoby_imie.Location = new System.Drawing.Point(25, 82);
            this.Osoby_imie.Name = "Osoby_imie";
            this.Osoby_imie.Size = new System.Drawing.Size(129, 20);
            this.Osoby_imie.TabIndex = 2;
            // 
            // Osoby_usun
            // 
            this.Osoby_usun.Location = new System.Drawing.Point(405, 396);
            this.Osoby_usun.Name = "Osoby_usun";
            this.Osoby_usun.Size = new System.Drawing.Size(168, 38);
            this.Osoby_usun.TabIndex = 1;
            this.Osoby_usun.Text = "Usun osobę";
            this.Osoby_usun.UseVisualStyleBackColor = true;
            this.Osoby_usun.Click += new System.EventHandler(this.Osoby_usun_Click);
            // 
            // BoxOsoby
            // 
            this.BoxOsoby.FormattingEnabled = true;
            this.BoxOsoby.Location = new System.Drawing.Point(380, 61);
            this.BoxOsoby.Name = "BoxOsoby";
            this.BoxOsoby.Size = new System.Drawing.Size(211, 329);
            this.BoxOsoby.TabIndex = 0;
            this.BoxOsoby.SelectedIndexChanged += new System.EventHandler(this.BoxOsoby_SelectedIndexChanged);
            // 
            // Sporty_Box
            // 
            this.Sporty_Box.BackColor = System.Drawing.Color.Transparent;
            this.Sporty_Box.Controls.Add(this.label25);
            this.Sporty_Box.Controls.Add(this.label10);
            this.Sporty_Box.Controls.Add(this.label11);
            this.Sporty_Box.Controls.Add(this.Sporty_dodaj);
            this.Sporty_Box.Controls.Add(this.kalorie_sport);
            this.Sporty_Box.Controls.Add(this.nazwa_sportu);
            this.Sporty_Box.Controls.Add(this.Sporty_usun);
            this.Sporty_Box.Controls.Add(this.SportyBox);
            this.Sporty_Box.Location = new System.Drawing.Point(5, 25);
            this.Sporty_Box.Name = "Sporty_Box";
            this.Sporty_Box.Size = new System.Drawing.Size(670, 527);
            this.Sporty_Box.TabIndex = 5;
            this.Sporty_Box.TabStop = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label25.Location = new System.Drawing.Point(18, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(260, 18);
            this.label25.TabIndex = 16;
            this.label25.Text = "Spis dostępnych sportów w bazie";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Ilość kalorii";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Nazwa sportu";
            // 
            // Sporty_dodaj
            // 
            this.Sporty_dodaj.Location = new System.Drawing.Point(18, 167);
            this.Sporty_dodaj.Name = "Sporty_dodaj";
            this.Sporty_dodaj.Size = new System.Drawing.Size(155, 36);
            this.Sporty_dodaj.TabIndex = 10;
            this.Sporty_dodaj.Text = "Dodaj";
            this.Sporty_dodaj.UseVisualStyleBackColor = true;
            this.Sporty_dodaj.Click += new System.EventHandler(this.Sporty_dodaj_Click);
            // 
            // kalorie_sport
            // 
            this.kalorie_sport.Location = new System.Drawing.Point(21, 138);
            this.kalorie_sport.Name = "kalorie_sport";
            this.kalorie_sport.Size = new System.Drawing.Size(152, 20);
            this.kalorie_sport.TabIndex = 9;
            this.kalorie_sport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kalorie_sport_KeyPress);
            // 
            // nazwa_sportu
            // 
            this.nazwa_sportu.Location = new System.Drawing.Point(20, 87);
            this.nazwa_sportu.Name = "nazwa_sportu";
            this.nazwa_sportu.Size = new System.Drawing.Size(153, 20);
            this.nazwa_sportu.TabIndex = 8;
            // 
            // Sporty_usun
            // 
            this.Sporty_usun.Location = new System.Drawing.Point(285, 409);
            this.Sporty_usun.Name = "Sporty_usun";
            this.Sporty_usun.Size = new System.Drawing.Size(168, 34);
            this.Sporty_usun.TabIndex = 2;
            this.Sporty_usun.Text = "Usun sport";
            this.Sporty_usun.UseVisualStyleBackColor = true;
            this.Sporty_usun.Click += new System.EventHandler(this.Sporty_usun_Click);
            // 
            // SportyBox
            // 
            this.SportyBox.FormattingEnabled = true;
            this.SportyBox.Location = new System.Drawing.Point(237, 61);
            this.SportyBox.Name = "SportyBox";
            this.SportyBox.Size = new System.Drawing.Size(295, 329);
            this.SportyBox.TabIndex = 0;
            // 
            // Posilki_Box
            // 
            this.Posilki_Box.BackColor = System.Drawing.Color.Transparent;
            this.Posilki_Box.Controls.Add(this.label24);
            this.Posilki_Box.Controls.Add(this.Posilki_Box_Box);
            this.Posilki_Box.Controls.Add(this.label12);
            this.Posilki_Box.Controls.Add(this.OsobaCombo);
            this.Posilki_Box.Location = new System.Drawing.Point(1, 25);
            this.Posilki_Box.Name = "Posilki_Box";
            this.Posilki_Box.Size = new System.Drawing.Size(674, 527);
            this.Posilki_Box.TabIndex = 8;
            this.Posilki_Box.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label24.Location = new System.Drawing.Point(154, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(328, 18);
            this.label24.TabIndex = 16;
            this.label24.Text = "Dodawanie i usuwanie spozytych posiłków";
            // 
            // Posilki_Box_Box
            // 
            this.Posilki_Box_Box.Controls.Add(this.label17);
            this.Posilki_Box_Box.Controls.Add(this.Posilki_dodaj);
            this.Posilki_Box_Box.Controls.Add(this.PosilkiBox);
            this.Posilki_Box_Box.Controls.Add(this.label13);
            this.Posilki_Box_Box.Controls.Add(this.Posilki_Usuń);
            this.Posilki_Box_Box.Controls.Add(this.PotrawaCombo);
            this.Posilki_Box_Box.Controls.Add(this.dateTimePicker1);
            this.Posilki_Box_Box.Location = new System.Drawing.Point(72, 85);
            this.Posilki_Box_Box.Name = "Posilki_Box_Box";
            this.Posilki_Box_Box.Size = new System.Drawing.Size(547, 429);
            this.Posilki_Box_Box.TabIndex = 9;
            this.Posilki_Box_Box.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "Wybór daty posiłku";
            // 
            // Posilki_dodaj
            // 
            this.Posilki_dodaj.Location = new System.Drawing.Point(32, 128);
            this.Posilki_dodaj.Name = "Posilki_dodaj";
            this.Posilki_dodaj.Size = new System.Drawing.Size(165, 47);
            this.Posilki_dodaj.TabIndex = 9;
            this.Posilki_dodaj.Text = "Dodaj posiłek";
            this.Posilki_dodaj.UseVisualStyleBackColor = true;
            this.Posilki_dodaj.Click += new System.EventHandler(this.Posilki_dodaj_Click);
            // 
            // PosilkiBox
            // 
            this.PosilkiBox.FormattingEnabled = true;
            this.PosilkiBox.Location = new System.Drawing.Point(257, 28);
            this.PosilkiBox.Name = "PosilkiBox";
            this.PosilkiBox.Size = new System.Drawing.Size(244, 303);
            this.PosilkiBox.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(140, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Wybór potrawy";
            // 
            // Posilki_Usuń
            // 
            this.Posilki_Usuń.Location = new System.Drawing.Point(296, 351);
            this.Posilki_Usuń.Name = "Posilki_Usuń";
            this.Posilki_Usuń.Size = new System.Drawing.Size(168, 34);
            this.Posilki_Usuń.TabIndex = 3;
            this.Posilki_Usuń.Text = "Usun Posiłek";
            this.Posilki_Usuń.UseVisualStyleBackColor = true;
            this.Posilki_Usuń.Click += new System.EventHandler(this.Posilki_Usuń_Click);
            // 
            // PotrawaCombo
            // 
            this.PotrawaCombo.FormattingEnabled = true;
            this.PotrawaCombo.Location = new System.Drawing.Point(6, 97);
            this.PotrawaCombo.Name = "PotrawaCombo";
            this.PotrawaCombo.Size = new System.Drawing.Size(200, 21);
            this.PotrawaCombo.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 73);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(209, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Wybór osoby";
            // 
            // OsobaCombo
            // 
            this.OsobaCombo.FormattingEnabled = true;
            this.OsobaCombo.Location = new System.Drawing.Point(294, 32);
            this.OsobaCombo.Name = "OsobaCombo";
            this.OsobaCombo.Size = new System.Drawing.Size(121, 21);
            this.OsobaCombo.TabIndex = 5;
            this.OsobaCombo.SelectedIndexChanged += new System.EventHandler(this.OsobaCombo_SelectedIndexChanged);
            // 
            // Treningi_Box
            // 
            this.Treningi_Box.BackColor = System.Drawing.Color.Transparent;
            this.Treningi_Box.Controls.Add(this.label22);
            this.Treningi_Box.Controls.Add(this.groupBox2);
            this.Treningi_Box.Controls.Add(this.label15);
            this.Treningi_Box.Controls.Add(this.TreningiCombo);
            this.Treningi_Box.Location = new System.Drawing.Point(1, 25);
            this.Treningi_Box.Name = "Treningi_Box";
            this.Treningi_Box.Size = new System.Drawing.Size(674, 527);
            this.Treningi_Box.TabIndex = 10;
            this.Treningi_Box.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label22.Location = new System.Drawing.Point(21, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(325, 18);
            this.label22.TabIndex = 15;
            this.label22.Text = "Dodawanie i usuwanie odbytych treningów";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.Treningi_Dodaj);
            this.groupBox2.Controls.Add(this.TreningiBox);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.Treningi_Usun);
            this.groupBox2.Controls.Add(this.SportyCombo);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Location = new System.Drawing.Point(0, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(680, 429);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(28, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Wybór Daty Treningu";
            // 
            // Treningi_Dodaj
            // 
            this.Treningi_Dodaj.Location = new System.Drawing.Point(27, 155);
            this.Treningi_Dodaj.Name = "Treningi_Dodaj";
            this.Treningi_Dodaj.Size = new System.Drawing.Size(204, 47);
            this.Treningi_Dodaj.TabIndex = 9;
            this.Treningi_Dodaj.Text = "Dodaj trening";
            this.Treningi_Dodaj.UseVisualStyleBackColor = true;
            this.Treningi_Dodaj.Click += new System.EventHandler(this.Treningi_Dodaj_Click);
            // 
            // TreningiBox
            // 
            this.TreningiBox.FormattingEnabled = true;
            this.TreningiBox.Location = new System.Drawing.Point(324, 23);
            this.TreningiBox.Name = "TreningiBox";
            this.TreningiBox.Size = new System.Drawing.Size(249, 316);
            this.TreningiBox.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 98);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Wybór Sportu";
            // 
            // Treningi_Usun
            // 
            this.Treningi_Usun.Location = new System.Drawing.Point(368, 361);
            this.Treningi_Usun.Name = "Treningi_Usun";
            this.Treningi_Usun.Size = new System.Drawing.Size(168, 34);
            this.Treningi_Usun.TabIndex = 3;
            this.Treningi_Usun.Text = "Usun trening";
            this.Treningi_Usun.UseVisualStyleBackColor = true;
            this.Treningi_Usun.Click += new System.EventHandler(this.Treningi_Usun_Click);
            // 
            // SportyCombo
            // 
            this.SportyCombo.FormattingEnabled = true;
            this.SportyCombo.Location = new System.Drawing.Point(31, 114);
            this.SportyCombo.Name = "SportyCombo";
            this.SportyCombo.Size = new System.Drawing.Size(200, 21);
            this.SportyCombo.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(31, 60);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 4;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(275, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Wybór osoby";
            // 
            // TreningiCombo
            // 
            this.TreningiCombo.FormattingEnabled = true;
            this.TreningiCombo.Location = new System.Drawing.Point(253, 58);
            this.TreningiCombo.Name = "TreningiCombo";
            this.TreningiCombo.Size = new System.Drawing.Size(121, 21);
            this.TreningiCombo.TabIndex = 5;
            this.TreningiCombo.SelectedIndexChanged += new System.EventHandler(this.TreningiCombo_SelectedIndexChanged);
            // 
            // Statystyki_Box
            // 
            this.Statystyki_Box.BackColor = System.Drawing.Color.Transparent;
            this.Statystyki_Box.Controls.Add(this.label21);
            this.Statystyki_Box.Controls.Add(this.label20);
            this.Statystyki_Box.Controls.Add(this.groupBoxStatystyki1);
            this.Statystyki_Box.Controls.Add(this.StatystykiCombo);
            this.Statystyki_Box.Location = new System.Drawing.Point(1, 28);
            this.Statystyki_Box.Name = "Statystyki_Box";
            this.Statystyki_Box.Size = new System.Drawing.Size(674, 524);
            this.Statystyki_Box.TabIndex = 12;
            this.Statystyki_Box.TabStop = false;
            this.Statystyki_Box.Enter += new System.EventHandler(this.Statystyki_Box_Enter);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label21.Location = new System.Drawing.Point(17, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(303, 18);
            this.label21.TabIndex = 14;
            this.label21.Text = "Statystyki spożytych i spalonyck kalorii";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(277, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 13);
            this.label20.TabIndex = 13;
            this.label20.Text = "Wybór osoby";
            // 
            // groupBoxStatystyki1
            // 
            this.groupBoxStatystyki1.Controls.Add(this.label19);
            this.groupBoxStatystyki1.Controls.Add(this.label18);
            this.groupBoxStatystyki1.Controls.Add(this.Srednia_kcal);
            this.groupBoxStatystyki1.Controls.Add(this.Bilans_kcal);
            this.groupBoxStatystyki1.Controls.Add(this.wykres);
            this.groupBoxStatystyki1.Controls.Add(this.DataDo);
            this.groupBoxStatystyki1.Controls.Add(this.DataOd);
            this.groupBoxStatystyki1.Location = new System.Drawing.Point(4, 91);
            this.groupBoxStatystyki1.Name = "groupBoxStatystyki1";
            this.groupBoxStatystyki1.Size = new System.Drawing.Size(680, 449);
            this.groupBoxStatystyki1.TabIndex = 11;
            this.groupBoxStatystyki1.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(412, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 13);
            this.label19.TabIndex = 11;
            this.label19.Text = "Data do:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(91, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "Data od:";
            // 
            // Srednia_kcal
            // 
            this.Srednia_kcal.AutoSize = true;
            this.Srednia_kcal.Location = new System.Drawing.Point(44, 382);
            this.Srednia_kcal.Name = "Srednia_kcal";
            this.Srednia_kcal.Size = new System.Drawing.Size(43, 13);
            this.Srednia_kcal.TabIndex = 9;
            this.Srednia_kcal.Text = "Średnia";
            // 
            // Bilans_kcal
            // 
            this.Bilans_kcal.AutoSize = true;
            this.Bilans_kcal.Location = new System.Drawing.Point(44, 363);
            this.Bilans_kcal.Name = "Bilans_kcal";
            this.Bilans_kcal.Size = new System.Drawing.Size(38, 13);
            this.Bilans_kcal.TabIndex = 8;
            this.Bilans_kcal.Text = "Bilans:";
            // 
            // wykres
            // 
            chartArea1.Name = "ChartArea1";
            this.wykres.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.wykres.Legends.Add(legend1);
            this.wykres.Location = new System.Drawing.Point(36, 67);
            this.wykres.Name = "wykres";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.wykres.Series.Add(series1);
            this.wykres.Size = new System.Drawing.Size(618, 282);
            this.wykres.TabIndex = 7;
            this.wykres.Text = "chart1";
            // 
            // DataDo
            // 
            this.DataDo.Location = new System.Drawing.Point(415, 38);
            this.DataDo.Name = "DataDo";
            this.DataDo.Size = new System.Drawing.Size(200, 20);
            this.DataDo.TabIndex = 6;
            this.DataDo.ValueChanged += new System.EventHandler(this.DataDo_ValueChanged);
            // 
            // DataOd
            // 
            this.DataOd.Location = new System.Drawing.Point(91, 38);
            this.DataOd.Name = "DataOd";
            this.DataOd.Size = new System.Drawing.Size(200, 20);
            this.DataOd.TabIndex = 5;
            this.DataOd.ValueChanged += new System.EventHandler(this.DataOd_ValueChanged);
            // 
            // StatystykiCombo
            // 
            this.StatystykiCombo.FormattingEnabled = true;
            this.StatystykiCombo.Location = new System.Drawing.Point(278, 64);
            this.StatystykiCombo.Name = "StatystykiCombo";
            this.StatystykiCombo.Size = new System.Drawing.Size(121, 21);
            this.StatystykiCombo.TabIndex = 10;
            this.StatystykiCombo.SelectedIndexChanged += new System.EventHandler(this.StatystykiCombo_SelectedIndexChanged_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(674, 559);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(666, 533);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Potrawy";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(916, 533);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Osoby";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(916, 533);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sporty";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(916, 533);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Posiłki";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(916, 533);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Treningi";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(916, 533);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "Statystyki";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(671, 551);
            this.Controls.Add(this.Treningi_Box);
            this.Controls.Add(this.Potrawy_box);
            this.Controls.Add(this.Posilki_Box);
            this.Controls.Add(this.Sporty_Box);
            this.Controls.Add(this.Osoby_Box);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Statystyki_Box);
            this.Name = "Form1";
            this.Potrawy_box.ResumeLayout(false);
            this.Potrawy_box.PerformLayout();
            this.Osoby_Box.ResumeLayout(false);
            this.Osoby_Box.PerformLayout();
            this.Sporty_Box.ResumeLayout(false);
            this.Sporty_Box.PerformLayout();
            this.Posilki_Box.ResumeLayout(false);
            this.Posilki_Box.PerformLayout();
            this.Posilki_Box_Box.ResumeLayout(false);
            this.Posilki_Box_Box.PerformLayout();
            this.Treningi_Box.ResumeLayout(false);
            this.Treningi_Box.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Statystyki_Box.ResumeLayout(false);
            this.Statystyki_Box.PerformLayout();
            this.groupBoxStatystyki1.ResumeLayout(false);
            this.groupBoxStatystyki1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wykres)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #region .
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void BoxOsoby_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion

        #region Kontener z Potrawami
        private void ZaladujJedzenie()
        {
            PotrawaCombo.Items.Clear();
            PotrawyBox.Items.Clear();
            List<PotrawaClass> potrawy = DostepBaza.WczytajPotrawy();
            foreach (PotrawaClass potrawa in potrawy)
            {
                PotrawyBox.Items.Add(potrawa);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (PotrawyBox.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano potrawy do usunięcia");
                return;
            }
            PotrawaClass selectedPotrawa = PotrawyBox.SelectedItem as PotrawaClass;
            if (selectedPotrawa == null)
            {
                MessageBox.Show("Nie wybrano potrawy do usunięcia");
                return;
            }

            int id = selectedPotrawa.ID_potrawy;
            Console.WriteLine($"Usuwanie potrawy o ID: {id}");
            DostepBaza.UsunPotrawe(selectedPotrawa);
            Console.WriteLine($"Potrawa o ID {id} została usunięta");

            ZaladujJedzenie();
        }
        private void Dodaj_button_Click(object sender, EventArgs e)
        {
            string nazwa = Nazwa_potrawy.Text;
            int kalorie = int.Parse(Kalorie_potrawy.Text);
            DostepBaza.DodajPotrawe(new PotrawaClass { Nazwa = nazwa, Kalorie = kalorie });

            ZaladujJedzenie();
        }
        private void Kalorie_potrawy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Kontener z Osobami
        private void ZaladujOsoby()
        {
            BoxOsoby.Items.Clear();
            List<OsobaClass> osoby = DostepBaza.WczytajOsoby();
            foreach (OsobaClass osoba in osoby)
            {
                BoxOsoby.Items.Add(osoba);
            }
        }
        private void Osoby_dodaj_Click(object sender, EventArgs e)
        {
            string imie = Osoby_imie.Text;
            string nazwisko = Osoby_nazwisko.Text;
            int wiek = int.Parse(Osoby_wiek.Text);
            string plec = Osoby_plec.Text;
            float waga = float.Parse(Osoby_waga.Text);
            int wzrost = int.Parse(Osoby_wzrost.Text);
            int cel = 0;
            if (Osoby_cel.Text != "")
            {
                cel = int.Parse(Osoby_cel.Text);
            }


            OsobaClass nowaOsoba = new OsobaClass
            {
                Imie = imie,
                Nazwisko = nazwisko,
                wiek = wiek,
                plec = plec,
                waga = waga,
                wzrost = wzrost,
                cel = cel
            };

            DostepBaza.DodajOsobe(nowaOsoba);
            ZaladujOsoby();
        }
        private void Osoby_usun_Click(object sender, EventArgs e)
        {
            if (BoxOsoby.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano osoby do usunięcia");
                return;
            }

            OsobaClass selectedOsoba = BoxOsoby.SelectedItem as OsobaClass;
            if (selectedOsoba == null)
            {
                MessageBox.Show("Nie wybrano osoby do usunięcia");
                return;
            }

            int id = selectedOsoba.ID_osoby;
            Console.WriteLine($"Usuwanie osoby o ID: {id}");
            DostepBaza.UsunOsobe(selectedOsoba);
            Console.WriteLine($"Osoba o ID {id} została usunięta");

            ZaladujOsoby();
        }
        private void Osoby_waga_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sprawdź, czy wprowadzony znak jest cyfrą, klawiszem kontrolnym, przecinkiem lub kropką
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Upewnij się, że tylko jeden przecinek lub kropka jest dozwolony
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (sender as TextBox).Text.IndexOfAny(new char[] { ',', '.' }) > -1)
            {
                e.Handled = true;
            }
        }
        private void Osoby_wzrost_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sprawdź, czy wprowadzony znak jest cyfrą, klawiszem kontrolnym, przecinkiem lub kropką
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void Osoby_cel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sprawdź, czy wprowadzony znak jest cyfrą, klawiszem kontrolnym, przecinkiem lub kropką
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void Osoby_wiek_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sprawdź, czy wprowadzony znak jest cyfrą, klawiszem kontrolnym, przecinkiem lub kropką
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        #endregion

        #region Kontener z Sportami
        private void ZaladujSporty()
        {
            SportyCombo.Items.Clear();
            SportyBox.Items.Clear();
            List<SportClass> sporty = DostepBaza.WczytajSporty();
            foreach (SportClass sport in sporty)
            {
                SportyBox.Items.Add(sport);
            }
        }
        private void Sporty_dodaj_Click(object sender, EventArgs e)
        {
            string nazwa = nazwa_sportu.Text;
            int kalorie = int.Parse(kalorie_sport.Text);
            DostepBaza.DodajSport(new SportClass { Nazwa = nazwa, Kalorie = kalorie });
            ZaladujSporty();
        }
        private void Sporty_usun_Click(object sender, EventArgs e)
        {
            if (SportyBox.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano sportu do usunięcia");
                return;
            }
            SportClass selectedSport = SportyBox.SelectedItem as SportClass;
            if (selectedSport == null)
            {
                MessageBox.Show("Nie wybrano sportu do usunięcia");
                return;
            }
            int id = selectedSport.ID_sportu;
            Console.WriteLine($"Usuwanie sportu o ID: {id}");
            DostepBaza.UsunSport(selectedSport);
            Console.WriteLine($"Sport o ID {id} został usunięty");
            ZaladujSporty();
        }
        private void kalorie_sport_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sprawdź, czy wprowadzony znak jest cyfrą, klawiszem kontrolnym, przecinkiem lub kropką
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        #endregion

        #region Menu główne boczne
        private void UkryjWszystko()
        {
            Potrawy_box.Visible = false;
            Osoby_Box.Visible = false;
            Sporty_Box.Visible = false;
            Posilki_Box.Visible = false;
            Posilki_Box_Box.Visible = false;
            Treningi_Box.Visible = false;
            groupBox2.Visible = false;
            Statystyki_Box.Visible = false;
            groupBoxStatystyki1.Visible = false;

            OsobaCombo.SelectedItem = null;
            SportyCombo.SelectedItem = null;
            TreningiCombo.SelectedItem = null;
            StatystykiCombo.SelectedItem = null;


        }
        private void ZaladujDane()
        {
            ZaladujJedzenie();
            ZaladujOsoby();
            ZaladujSporty();
            ZaladujPosilki();
            ZaladujTreningi();
        }
        private void PokazKontroler(Control kontener)
        {
            UkryjWszystko();
            kontener.Visible = true;
            kontener.BringToFront();
            ZaladujDane();
        }
        private void Potrawy_Show_Click(object sender, EventArgs e)
        {
            UkryjWszystko();
            PokazKontroler(Potrawy_box);
        }
        private void Osoby_Show_Click(object sender, EventArgs e)
        {
            OsobaCombo.SelectedItem = null;
            UkryjWszystko();
            PokazKontroler(Osoby_Box);
        }
        private void Sporty_Show_Click(object sender, EventArgs e)
        {
            SportyCombo.SelectedItem = null;
            
            UkryjWszystko();
            PokazKontroler(Sporty_Box);

        }
        private void Posilki_Show_Click(object sender, EventArgs e)
        {
            OsobaCombo.SelectedItem = null;
            UkryjWszystko();
            ZaladujJedzenie();
            PokazKontroler(Posilki_Box);
        }
        private void Treningi_Show_Click(object sender, EventArgs e)
        {
            TreningiCombo.SelectedItem = null;
            UkryjWszystko();
            PokazKontroler(Treningi_Box);

        }
        #endregion

        #region Kontener z Posiłkami
        private void OsobaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OsobaCombo.SelectedIndex == -1)
            {
                Posilki_Box_Box.Visible = false;
            }
            else
            {
                Posilki_Box_Box.Visible = true;
                ZaladujPosilkiOsoby();
            }
        }
        private string FormatOsoba(OsobaClass osoba)
        {
            return $"{osoba.Imie} {osoba.Nazwisko}";
        }
        private string FormatPotrawa(PotrawaClass potrawa)
        {
            return $"{potrawa.Nazwa} ({potrawa.Kalorie} kcal)";
        }
        private void ZaladujPosilki()
        {
            PosilkiBox.Items.Clear();
            OsobaCombo.Items.Clear();
            List<OsobaClass> osoby = DostepBaza.WczytajOsoby();
            foreach (OsobaClass osoba in osoby)
            {
                OsobaCombo.Items.Add(FormatOsoba(osoba));
            }
            ZaladujPosilkiOsoby();
            PosilkiBox.Items.Clear();
            List<PotrawaClass> posilki = DostepBaza.WczytajPotrawy();
            foreach (PotrawaClass potrawa in posilki)
            {
                PotrawaCombo.Items.Add(FormatPotrawa(potrawa));
            }

        }
        private void ZaladujPosilkiOsoby()
        {
            if (OsobaCombo.SelectedIndex == -1)
            {
                return;
            }

            // Pobierz wybraną osobę na podstawie indeksu
            OsobaClass selectedOsoba = DostepBaza.WczytajOsoby()[OsobaCombo.SelectedIndex];

            // Wczytaj posiłki dla wybranej osoby
            List<PosilkiClass> posilki = DostepBaza.WczytajPosilki(selectedOsoba.ID_osoby);

            // Wyczyść listę posiłków
            PosilkiBox.Items.Clear();

            // Dodaj posiłki do listy
            // Dodaj posiłki do listy
            foreach (PosilkiClass posilek in posilki)
            {
                PotrawaClass potrawa = DostepBaza.WybierzPotrawe(posilek.ID_potrawy);
                if (potrawa != null)
                {
                    PosilkiBox.Items.Add(new PosilkiClass.PosilekDisplay { Posilek = posilek, Opis = $"{posilek.Data.ToString("yyyy-MM-dd")} - {potrawa.Nazwa} - ({potrawa.Kalorie} kcal)" });
                }
                else
                {
                    Console.WriteLine($"Nie znaleziono potrawy o ID: {posilek.ID_potrawy}");
                }
            }
        }
        private void Posilki_Usuń_Click(object sender, EventArgs e)
        {
            if (PosilkiBox.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano posiłku do usunięcia");
                return;
            }

            var selectedItem = PosilkiBox.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Nie wybrano posiłku do usunięcia");
                return;
            }

            PosilkiClass selectedPosilek = (PosilkiClass)selectedItem.GetType().GetProperty("Posilek").GetValue(selectedItem, null);
            if (selectedPosilek == null)
            {
                MessageBox.Show("Nie wybrano posiłku do usunięcia");
                return;
            }

            int id = selectedPosilek.ID_posilku;
            Console.WriteLine($"Usuwanie posiłku o ID: {id}");
            DostepBaza.UsunPosilek(selectedPosilek);
            Console.WriteLine($"Posiłek o ID {id} został usunięty");
            ZaladujPosilkiOsoby();
        }
        private void Posilki_dodaj_Click(object sender, EventArgs e)
        {
            if (OsobaCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano osoby");
                return;
            }

            if (PotrawaCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano potrawy");
                return;
            }

            // Pobierz wybraną osobę i potrawę na podstawie indeksu
            OsobaClass selectedOsoba = DostepBaza.WczytajOsoby()[OsobaCombo.SelectedIndex];
            PotrawaClass selectedPotrawa = DostepBaza.WczytajPotrawy()[PotrawaCombo.SelectedIndex];

            // Pobierz datę z dateTimePicker1 i sformatuj ją
            DateTime data = dateTimePicker1.Value;
            string dataFormatted = data.ToString("yyyy-MM-dd");

            // Utwórz nowy posiłek
            PosilkiClass nowyPosilek = new PosilkiClass
            {
                ID_osoby = selectedOsoba.ID_osoby,
                ID_potrawy = selectedPotrawa.ID_potrawy,
                Data = DateTime.Parse(dataFormatted) // Użyj sformatowanej daty
            };

            // Dodaj posiłek do bazy danych
            DostepBaza.DodajPosilek(nowyPosilek);

            // Odśwież listę posiłków
            ZaladujPosilkiOsoby();
        }
        #endregion

        #region Kontener z Treningami
        private string FormatSport(SportClass sport)
        {
            return $"{sport.Nazwa} ({sport.Kalorie} kcal)";
        }
        private void ZaladujTreningi()
        {
            TreningiBox.Items.Clear();
            TreningiCombo.Items.Clear();
            List<OsobaClass> osoby = DostepBaza.WczytajOsoby();
            foreach (OsobaClass osoba in osoby)
            {
                TreningiCombo.Items.Add(FormatOsoba(osoba));
            }
            //ZaladujTreningiOsoby();
            TreningiBox.Items.Clear();
            List<SportClass> sporty = DostepBaza.WczytajSporty();
            foreach (SportClass sport in sporty)
            {
                SportyCombo.Items.Add(FormatSport(sport));
            }
        }
        private void PotrawyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PotrawaCombo.SelectedIndex == -1)
            {
                Posilki_Box_Box.Visible = false;
            }
            else
            {
                Posilki_Box_Box.Visible = true;
                ZaladujTreningiOsoby();
            }
        }
        private void ZaladujTreningiOsoby()
        {
            if (TreningiCombo.SelectedIndex == -1)
            {
                return;
            }

            // Pobierz wybraną osobę na podstawie indeksu
            OsobaClass selectedOsoba = DostepBaza.WczytajOsoby()[TreningiCombo.SelectedIndex];

            // Wczytaj treningi dla wybranej osoby
            List<TreningiClass> treningi = DostepBaza.WczytajTreningi(selectedOsoba.ID_osoby);

            // Wyczyść listę treningów
            TreningiBox.Items.Clear();

            // Dodaj treningi do listy
            foreach (TreningiClass trening in treningi)
            {
                SportClass sport = DostepBaza.WybierzSport(trening.ID_sportu);
                if (sport != null)
                {
                    TreningiBox.Items.Add(new TreningiClass.TreningiDisplay { Trening = trening, Opis = $"{trening.Data.ToString("yyyy-MM-dd")} - {sport.Nazwa} - ({sport.Kalorie} kcal)" });
                }
                else
                {
                    Console.WriteLine($"Nie znaleziono sportu o ID: {trening.ID_sportu}");
                }
            }
        }
        private void Treningi_Usun_Click(object sender, EventArgs e)
        {
            if (TreningiBox.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano treningu do usunięcia");
                return;
            }

            var selectedItem = TreningiBox.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Nie wybrano treningu do usunięcia");
                return;
            }

            TreningiClass selectedTrening = (TreningiClass)selectedItem.GetType().GetProperty("Trening").GetValue(selectedItem, null);
            if (selectedTrening == null)
            {
                MessageBox.Show("Nie wybrano treningu do usunięcia");
                return;
            }

            int id = selectedTrening.ID_treningu;
            Console.WriteLine($"Usuwanie treningu o ID: {id}");
            DostepBaza.UsunTrening(selectedTrening);
            Console.WriteLine($"Trening o ID {id} został usunięty");
            ZaladujTreningiOsoby();
        }
        private void TreningiCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TreningiCombo.SelectedIndex == -1)
            {
                Treningi_Box.Visible = false;
            }
            else
            {
                Treningi_Box.Visible = true;
                groupBox2.Visible = true;
                ZaladujTreningiOsoby();
            }
        }
        private void Treningi_Dodaj_Click(object sender, EventArgs e)
        {
            if (TreningiCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano osoby");
                return;
            }

            if (SportyCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano sportu");
                return;
            }

            // Pobierz wybraną osobę i sport na podstawie indeksu
            OsobaClass selectedOsoba = DostepBaza.WczytajOsoby()[TreningiCombo.SelectedIndex];
            SportClass selectedSport = DostepBaza.WczytajSporty()[SportyCombo.SelectedIndex];

            // Pobierz datę z dateTimePicker2 i sformatuj ją
            DateTime data = dateTimePicker2.Value;
            string dataFormatted = data.ToString("yyyy-MM-dd");

            // Utwórz nowy trening
            TreningiClass nowyTrening = new TreningiClass
            {
                ID_osoby = selectedOsoba.ID_osoby,
                ID_sportu = selectedSport.ID_sportu,
                Data = DateTime.Parse(dataFormatted) // Użyj sformatowanej daty
            };

            // Dodaj trening do bazy danych
            DostepBaza.DodajTrening(nowyTrening);

            // Odśwież listę treningów
            ZaladujTreningiOsoby();
        }
        #endregion

        #region Kontener z Statystykami
        
        private void ZaladujStatystyki()
        {
            StatystykiCombo.Items.Clear();
            List<OsobaClass> osoby = DostepBaza.WczytajOsoby();
            foreach (OsobaClass osoba in osoby)
            {
                StatystykiCombo.Items.Add(FormatOsoba(osoba));
            }
        }
        private void Statystyki_Show_Click(object sender, EventArgs e)
        {
            UkryjWszystko();
            ZaladujStatystyki();

            PokazKontroler(Statystyki_Box);
        }
        private void StatystykiCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StatystykiCombo.SelectedIndex == -1)
            {
                groupBoxStatystyki1.Visible = false;
            }
            else
            {
                groupBoxStatystyki1.Visible = true;
                LadujWykres();

            }
        }
        #endregion

        #region Wykres i raport PDF
        private void StatystykiCombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LadujWykres();
            if (StatystykiCombo.SelectedIndex == -1)
            {

            }
            else
            {

            }
        }
        private void LadujWykres()
        {
            if (StatystykiCombo.SelectedIndex == -1)
            {
                groupBoxStatystyki1.Visible = false;
            }
            else
            {
                groupBoxStatystyki1.Visible = true;
                
                int idOsoby = DostepBaza.WczytajOsoby()[StatystykiCombo.SelectedIndex].ID_osoby;
                DateTime dataOd = DataOd.Value;
                DateTime dataDo = DataDo.Value;

                StatystykiService statystykiService = new StatystykiService();
                var statystyki = statystykiService.PobierzStatystykiWykres(idOsoby, dataOd, dataDo);

                wykres.Series.Clear();
                wykres.ChartAreas.Clear();
                wykres.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("ChartArea1"));

                var seriesPosilki = new System.Windows.Forms.DataVisualization.Charting.Series("Kalorie spożyte");
                seriesPosilki.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                seriesPosilki.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                seriesPosilki.IsValueShownAsLabel = true;

                var seriesTreningi = new System.Windows.Forms.DataVisualization.Charting.Series("Kalorie spalone");
                seriesTreningi.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                seriesTreningi.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                seriesTreningi.IsValueShownAsLabel = true;

                int sumaSpozytychKalorii = 0;
                int sumaSpalonychKalorii = 0;
                int liczbaDni = (dataDo - dataOd).Days + 1;

                foreach (var posilek in statystyki[0].Posilki)
                {
                    seriesPosilki.Points.AddXY(posilek.Data, posilek.Kalorie);
                    sumaSpozytychKalorii += posilek.Kalorie;
                }

                foreach (var trening in statystyki[0].Treningi)
                {
                    seriesTreningi.Points.AddXY(trening.Data, trening.Kalorie);
                    sumaSpalonychKalorii += trening.Kalorie;
                }

                wykres.Series.Add(seriesPosilki);
                wykres.Series.Add(seriesTreningi);

                // Ustawienia dla grupowania słupków
                wykres.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM-yyyy";
                wykres.ChartAreas[0].AxisX.Interval = 1;
                wykres.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
                wykres.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                wykres.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                wykres.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                wykres.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;

                // Oblicz bilans kalorii
                int bilansKalorii = sumaSpozytychKalorii - sumaSpalonychKalorii;
                Bilans_kcal.Text = $"Bilans w wybranym okresie: {bilansKalorii} kcal";

                // Oblicz średnią ilość spożywanych i spalanych kalorii
                double sredniaSpozytychKalorii = (double)sumaSpozytychKalorii / liczbaDni;
                double sredniaSpalonychKalorii = (double)sumaSpalonychKalorii / liczbaDni;
                Srednia_kcal.Text = $"Średnia spożytych na dzień: {sredniaSpozytychKalorii:F2} kcal\nŚrednia spalonych kalorii na dzień: {sredniaSpalonychKalorii:F2} kcal";
            }
        }
        private void DataOd_ValueChanged(object sender, EventArgs e)
        {
            LadujWykres();
        }

        private void DataDo_ValueChanged(object sender, EventArgs e)
        {
            LadujWykres();
        }

        private void Pobierz_Click(object sender, EventArgs e)
        {
            if (StatystykiCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano osoby.");
                return;
            }

            int idOsoby = DostepBaza.WczytajOsoby()[StatystykiCombo.SelectedIndex].ID_osoby;
            DateTime dataOd = DataOd.Value;
            DateTime dataDo = DataDo.Value;

            GenerujRaportPDF(idOsoby, dataOd, dataDo);
        }
        private void GenerujRaportPDF(int idOsoby, DateTime dataOd, DateTime dataDo)
        {
            OsobaClass osoba = DostepBaza.WczytajOsoby().FirstOrDefault(o => o.ID_osoby == idOsoby);
            if (osoba == null)
            {
                MessageBox.Show("Nie znaleziono osoby.");
                return;
            }

            StatystykiService statystykiService = new StatystykiService();
            var statystyki = statystykiService.PobierzStatystykiTabela(idOsoby, dataOd, dataDo);

            // Ustaw nazwę pliku
            string fileName = $"{osoba.Imie} {osoba.Nazwisko} - raport - {DateTime.Now:yyyy-MM-dd}.pdf";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            // Ustaw czcionkę Arial z obsługą polskich znaków
            string arialFontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont bfArial = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bfArial, 12, iTextSharp.text.Font.NORMAL);

            Document document = new Document(PageSize.A4, 50, 50, 50, 50);
            PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
            document.Open();

            // Dodaj dane osoby
            document.Add(new iTextSharp.text.Paragraph(new Phrase($"Raport dla: {osoba.Imie} {osoba.Nazwisko}", font)));
            document.Add(new iTextSharp.text.Paragraph(new Phrase($"Wiek: {osoba.wiek}, Płeć: {osoba.plec}, Waga: {osoba.waga}, Wzrost: {osoba.wzrost}, Cel kaloryczny: {osoba.cel}", font)));
            document.Add(new iTextSharp.text.Paragraph(new Phrase("\n", font)));
            document.Add(new iTextSharp.text.Paragraph(new Phrase($"Okres: {dataOd:yyyy-MM-dd} - {dataDo:yyyy-MM-dd}", font)));
            document.Add(new iTextSharp.text.Paragraph(new Phrase("\n", font)));
            document.Add(new iTextSharp.text.Paragraph(new Phrase("Spożyte posiłki i kaloryczność\n", font)));
            // Dodaj tabelę posiłków
            PdfPTable tabelaPosilkow = new PdfPTable(3);
            tabelaPosilkow.AddCell(new PdfPCell(new Phrase("Data", font)));
            tabelaPosilkow.AddCell(new PdfPCell(new Phrase("Nazwa potrawy", font)));
            tabelaPosilkow.AddCell(new PdfPCell(new Phrase("Spożyte kalorie", font)));

            int sumaSpozytychKalorii = 0;
            int sumaSpalonychKalorii = 0;
            int liczbaDni = (dataDo - dataOd).Days + 1;

            foreach (var posilek in statystyki[0].Posilki)
            {
                PotrawaClass potrawa = DostepBaza.WybierzPotrawe(posilek.ID_potrawy);
                tabelaPosilkow.AddCell(new PdfPCell(new Phrase(posilek.Data.ToString("yyyy-MM-dd"), font)));
                tabelaPosilkow.AddCell(new PdfPCell(new Phrase(potrawa.Nazwa, font)));
                tabelaPosilkow.AddCell(new PdfPCell(new Phrase(potrawa.Kalorie.ToString(), font)));
                sumaSpozytychKalorii += posilek.Kalorie;
            }

            document.Add(tabelaPosilkow);
            document.Add(new iTextSharp.text.Paragraph(new Phrase("\n", font)));
            document.Add(new iTextSharp.text.Paragraph(new Phrase("Wykonane treningi i spalone kalorie\n", font)));

            // Dodaj tabelę treningów
            PdfPTable tabelaTreningow = new PdfPTable(3);
            tabelaTreningow.AddCell(new PdfPCell(new Phrase("Data", font)));
            tabelaTreningow.AddCell(new PdfPCell(new Phrase("Nazwa sportu", font)));
            tabelaTreningow.AddCell(new PdfPCell(new Phrase("Spalone kalorie", font)));

            foreach (var trening in statystyki[0].Treningi)
            {
                SportClass sport = DostepBaza.WybierzSport(trening.ID_sportu);
                tabelaTreningow.AddCell(new PdfPCell(new Phrase(trening.Data.ToString("yyyy-MM-dd"), font)));
                tabelaTreningow.AddCell(new PdfPCell(new Phrase(sport.Nazwa, font)));
                tabelaTreningow.AddCell(new PdfPCell(new Phrase(sport.Kalorie.ToString(), font)));
                sumaSpalonychKalorii += trening.Kalorie;
            }

            document.Add(tabelaTreningow);
            document.Add(new iTextSharp.text.Paragraph(new Phrase("\n", font)));

            // Oblicz bilans kalorii
            int bilansKalorii = sumaSpozytychKalorii - sumaSpalonychKalorii;
            document.Add(new iTextSharp.text.Paragraph(new Phrase($"Bilans kalorii w wybranym okresie: {bilansKalorii} kcal", font)));

            // Oblicz średnią ilość spożywanych i spalanych kalorii
            double sredniaSpozytychKalorii = (double)sumaSpozytychKalorii / liczbaDni;
            double sredniaSpalonychKalorii = (double)sumaSpalonychKalorii / liczbaDni;
            document.Add(new iTextSharp.text.Paragraph(new Phrase($"Średnia spożywanych kalorii na dzień: {sredniaSpozytychKalorii:F2} kcal", font)));
            document.Add(new iTextSharp.text.Paragraph(new Phrase($"Średnia spalanych kalorii na dzień: {sredniaSpalonychKalorii:F2} kcal", font)));
            document.Add(new iTextSharp.text.Paragraph(new Phrase("\n", font)));

            // Dodaj wykres
            var chartImage = new MemoryStream();
            wykres.SaveImage(chartImage, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            iTextSharp.text.Image chartPdfImage = iTextSharp.text.Image.GetInstance(chartImage.ToArray());
            chartPdfImage.ScaleToFit(document.PageSize.Width - 100, document.PageSize.Height / 2); // Dopasuj rozmiar wykresu
            document.Add(chartPdfImage);

            document.Close();

            MessageBox.Show($"Raport został zapisany na pulpicie jako '{fileName}'.");
        }
        public void WyswietlWlasciwosci(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(obj)}");
            }
        }
        #endregion
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    UkryjWszystko();
                    PokazKontroler(Potrawy_box);
                    break;
                case 1:
                    OsobaCombo.SelectedItem = null;
                    UkryjWszystko();
                    PokazKontroler(Osoby_Box);
                    break;
                case 2:
                    SportyCombo.SelectedItem = null;
                    UkryjWszystko();
                    PokazKontroler(Sporty_Box);
                    break;
                case 3:
                    OsobaCombo.SelectedItem = null;
                    UkryjWszystko();
                    ZaladujJedzenie();
                    PokazKontroler(Posilki_Box);
                    break;
                case 4:
                    TreningiCombo.SelectedItem = null;
                    UkryjWszystko();
                    PokazKontroler(Treningi_Box);
                    break;
                case 5:
                    UkryjWszystko();
                    ZaladujStatystyki();
                    PokazKontroler(Statystyki_Box);
                    break;
                default:
                    break;
            }
        }


        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz zamknąć aplikację?", "Zamknij aplikację", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void Statystyki_Box_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            ZaladujTreningiDlaDaty(dateTimePicker2.Value);
        }

        private void ZaladujTreningiDlaDaty(DateTime data)
        {
            if (TreningiCombo.SelectedIndex == -1)
            {
                return;
            }

            // Pobierz wybraną osobę na podstawie indeksu
            OsobaClass selectedOsoba = DostepBaza.WczytajOsoby()[TreningiCombo.SelectedIndex];

            // Wczytaj treningi dla wybranej osoby i daty
            List<TreningiClass> treningi = DostepBaza.WczytajTreningi(selectedOsoba.ID_osoby)
                .Where(t => t.Data.Date == data.Date)
                .ToList();

            // Wyczyść listę treningów
            TreningiBox.Items.Clear();

            // Dodaj treningi do listy
            foreach (TreningiClass trening in treningi)
            {
                SportClass sport = DostepBaza.WybierzSport(trening.ID_sportu);
                if (sport != null)
                {
                    TreningiBox.Items.Add(new TreningiClass.TreningiDisplay { Trening = trening, Opis = $"{trening.Data.ToString("yyyy-MM-dd")} - {sport.Nazwa} - ({sport.Kalorie} kcal)" });
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ZaladujPosilkiDlaDaty(dateTimePicker1.Value);
        }

        private void ZaladujPosilkiDlaDaty(DateTime data)
        {
            if (OsobaCombo.SelectedIndex == -1)
            {
                return;
            }

            // Pobierz wybraną osobę na podstawie indeksu
            OsobaClass selectedOsoba = DostepBaza.WczytajOsoby()[OsobaCombo.SelectedIndex];

            // Wczytaj posiłki dla wybranej osoby i daty
            List<PosilkiClass> posilki = DostepBaza.WczytajPosilki(selectedOsoba.ID_osoby)
                .Where(p => p.Data.Date == data.Date)
                .ToList();

            // Wyczyść listę posiłków
            PosilkiBox.Items.Clear();

            // Dodaj posiłki do listy
            foreach (PosilkiClass posilek in posilki)
            {
                PotrawaClass potrawa = DostepBaza.WybierzPotrawe(posilek.ID_potrawy);
                if (potrawa != null)
                {
                    PosilkiBox.Items.Add(new PosilkiClass.PosilekDisplay { Posilek = posilek, Opis = $"{posilek.Data.ToString("yyyy-MM-dd")} - {potrawa.Nazwa} - ({potrawa.Kalorie} kcal)" });
                }
            }
        }

    }
}
