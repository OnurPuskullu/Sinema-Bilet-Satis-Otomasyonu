using SinemaBiletSatışOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaBiletSatışOtomasyonu
{
    public partial class Form2 : Form
    {
        public Form2(List<Movie> _movies,Form1 _form1)
        {
            InitializeComponent();
            movies = _movies;
            form1 = _form1;
        }
        List<Movie> movies;
        Form1 form1;
        Movie selectedMovie;
        Session selectedSession;


        public void ListDetail(int movieIndex,string _time,string _date)
        {
            selectedMovie = movies[movieIndex];
            selectedSession = selectedMovie.sessions.Find(session => session.time == _time && session.date == _date);
            lblTime.Text = $"{_date}-{_time}";
            lblMinute.Text = selectedMovie.minute;
            lblPrice.Text = selectedMovie.price.ToString() +" tl";
            pbSelectedPicture.Image = Image.FromFile(selectedMovie.picturePath);
            lblCategory.Text = selectedMovie.category.ToString();
            CheckChairsStatus();
        }
        private void CheckChairsStatus()
        {
            foreach (Control item in grbChairs.Controls) 
            {
                if (item is Button)
                {
                    string row = item.Tag.ToString();
                    string number = item.Text;
                    item.Enabled = true;
                    foreach (Chair chair in selectedSession.chairs)
                    {
                        if (chair.row == row && chair.number == number)
                        {
                            if (chair.status)
                            {
                                item.BackColor = Color.Red;
                                item.Enabled = false;
                            }
                            else
                            {
                                item.BackColor = Color.Green;
                            }
                            break;
                        }
                    }
                }
            }
        }
        List<Chair> chairs = new List<Chair>();
        private void button19_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string row = button.Tag.ToString();
            string number = button.Text;
            Chair chair = selectedSession.chairs.Find(c => c.row == row && c.number == number);
            if(button.BackColor.Name!="Blue")
            {
                chairs.Add(chair);
                button.BackColor = Color.Blue;
            }
            else
            {
                chairs.Remove(chair);
                button.BackColor = Color.Green;
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (chairs.Count == 0)
            {
                MessageBox.Show("Lütfen en az 1 koltuk seçiniz.");
                return;
            }
            Sales sales = new Sales();
            sales.movieName = selectedMovie.movieName;
            sales.count = chairs.Count;
            sales.sessionTime = $"{selectedSession.date}-{selectedSession.time}";
            sales.totalPrice = CalculatePrice();

            foreach (Chair chair in chairs)
            {
                chair.status = true;
            }
            MessageBox.Show(sales.ToString());
            ChangePage();
        }

        private void ChangePage()
        {
            rbsmall.Checked = rbmid.Checked = rblarge.Checked = false;
            chairs.Clear();
            this.Hide();
            form1.Show();
        }

        private decimal CalculatePrice()
        {
            decimal price = selectedMovie.price * chairs.Count;
            if(rbsmall.Checked)
            {
                price += 3;
            }
            else if(rbmid.Checked)
            {
                price += 6;
            }
            else if(rblarge.Checked)
            {
                price += 9;
            }
            return price;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChangePage();
        }
    }
}
