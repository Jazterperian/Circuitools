using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Circuitools
{
    public partial class MainPage : ContentPage
    {
        public SQLcontrol SQL = new SQLcontrol();
        public String[] strq = new string[3];
        public MainPage()
        {
            InitializeComponent();Cone(); LB1F();
        }
        public void Cone()
        {
            if (SQL.Con() == true) { LB2.Text = "ON LINE"; LB2.TextColor = Color.Blue; }
            else { LB2.Text = "OFF LINE"; LB2.TextColor = Color.Red; }
        }
        public void Sqc(string S)
        {
            SQL.SQLcmd = new MySqlConnector.MySqlCommand();
            SQL.SQLcmd.Connection = SQL.SQLconn;
            try
            {
                SQL.SQLconn.Open(); SQL.SQLcmd.CommandText = S; SQL.SQLrd = SQL.SQLcmd.ExecuteReader();
                if (SQL.SQLrd.Read()) { for (int K = 0; K <= (SQL.SQLrd.FieldCount - 1); K++) { strq[K] = Convert.ToString(SQL.SQLrd[K]); } }
                SQL.SQLconn.Close();
            }
            catch (Exception a) { SQL.SQLconn.Close(); DisplayAlert("NT", "PRUEBA" + a, "sv"); }
        }
        void LB1F() { LB1.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { DisplayAlert("xd", "XD", "OK"); }) }); }
        private void BT1_Clicked(object sender, EventArgs e)
        {
            /*sqc("SELECT Pass FROM Licencias WHERE Usuario = '" + ETY1.Text + "'");
            if (strq[0] == ETY2.Text) { Application.Current.MainPage.Navigation.PushAsync(new CR1()); }
            else { DisplayAlert("Alerta", "Usuario no reconocido", "OK"); }*/
            Application.Current.MainPage.Navigation.PushAsync(new CR1());
        }
    }
}
