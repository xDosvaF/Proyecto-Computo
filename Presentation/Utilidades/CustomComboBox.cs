using Presentation.Utilidades.Objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Utilidades
{
    public static class CustomComboBox
    {
        public static void insertarItems(this ComboBox combo, OpcionCombo[] items)
        {
            combo.Items.Clear();
            combo.Items.AddRange(items);
            combo.DisplayMember = "Texto";
            combo.ValueMember = "Valor";
            combo.SelectedIndex = 0;
        }

        public static void EstablecerValor(this ComboBox combo, int valor)
        {
            foreach (OpcionCombo opcion in combo.Items)
            {
                if (opcion.Valor == valor)
                {
                    combo.SelectedItem = opcion;
                    break;
                }
            }
        }
    }
}
