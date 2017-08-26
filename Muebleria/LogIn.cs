using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muebleria
{
    public partial class LogIn : Form
    {
        informatica_industrial_dbEntities db = new informatica_industrial_dbEntities();
        //static List<int> usuario = new List<int>();
        static int idUsuario;
        static int idIdioma;

        public static int IdUsuario
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
            }
        }

        public static int IdIdioma
        {
            get
            {
                return idIdioma;
            }

            set
            {
                idIdioma = value;
            }
        }

        public LogIn()
        {
            InitializeComponent();
            tbUsername.Text = "mati@gmail.com";
            tbpass.Text = "mati";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            RegexUtilities utilities = new RegexUtilities();
            if(!String.IsNullOrEmpty(tbUsername.Text) && !String.IsNullOrEmpty(tbpass.Text))
            {
                if (utilities.IsValidEmail(tbUsername.Text))
                {
                    var query = from usuarios in db.users
                                where usuarios.Mail == tbUsername.Text &&
                                usuarios.Password == tbpass.Text
                                select new { id = usuarios.idUsers, idioma = usuarios.idLanguage };

                    try   //si existe algun dato en la lista, es xq el mail existe
                    {
                        foreach (var c in query)
                        {
                            IdUsuario = c.id;
                            idIdioma = c.idioma;
                        }
                        Menu menu = new Menu();
                        this.Hide();
                        menu.ShowDialog();
                        this.Close();

                    }
                    catch
                    {
                        MessageBox.Show("Compruebe los datos y vuelva a intentarlo.");
                        return;
                    }
                }
                else
                    MessageBox.Show("Compruebe los datos y vuelva a intentarlo.");
            }
            else
                MessageBox.Show("Compruebe los datos y vuelva a intentarlo.");

        }
    }
}
