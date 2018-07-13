using System;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaCRM.Contanst
{
    class Public
    {
        /// <summary>
        /// Check null of inputs
        /// </summary>
        /// <param name="inputs">TextBox or RichTextBox</param>
        /// <returns>bool</returns>
        public static bool IsNullTextBox(params dynamic[] inputs)
        {
            var isNull = false;

            foreach (var input in inputs)
            {
                if (String.IsNullOrEmpty(input.Text.Trim()))
                {
                    input.BackColor = Color.NavajoWhite;
                    isNull = true;
                }
                else
                {
                    input.BackColor = Color.White;
                }
            }

            if (isNull) MessageBox.Show(Messages.NotEmpty, Messages.Warning, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return isNull;
        }
    }
}
