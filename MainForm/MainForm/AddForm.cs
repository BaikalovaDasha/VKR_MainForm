using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    /// <summary>
    /// Форма добавления в таблицу СЭС.
    /// </summary>
    public partial class AddForm : Form
    {
        /// <summary>
        /// Событие добавления параметров СЭС.
        /// </summary>
        public EventHandler<EventArgs> SPPAdded;

        /// <summary>
        /// Словарь Статуса.
        /// </summary>
        private readonly Dictionary<string, StatusSPP> _comboBoxStatusSPP;

        /// <summary>
        /// Словарь ЭС.
        /// </summary>
        private readonly Dictionary<string, PowerSystem> _comboBoxPowerSystem;

        /// <summary>
        /// Форма добавления СЭС.
        /// </summary>
        public AddForm()
        {
            InitializeComponent();

            string[] typeStatus = { "Действующая", "Вводимая" };

            string[] powerSystem = { "Забайкальская", "Новосибирская" };

            comboBoxStatusSPP.Items.AddRange(new string[]
                 { typeStatus[0], typeStatus[1]});

            comboBoxPowerSystem.Items.AddRange(new string[]
                 { powerSystem[0], powerSystem[1]});

            _comboBoxStatusSPP = new Dictionary<string, StatusSPP>()
            {
                { typeStatus[0], StatusSPP.действующая },
                { typeStatus[1], StatusSPP.вводимая }
            };

            _comboBoxPowerSystem = new Dictionary<string, PowerSystem>()
            {
                { powerSystem[0], PowerSystem.Забайкальская },
                { powerSystem[1], PowerSystem.Novosibirskaya }
            };
        }

        /// <summary>
        /// Контроль ввода значений типа double.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlValueDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlText.CheckInputDouble(e);
        }

        /// <summary>
        /// Контроль ввода значений типа int.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlValueInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlText.CheckInputInt(e);
        }

        /// <summary>
        /// Переменная для записи статуса СЭС.
        /// </summary>
        private StatusSPP _statusSPP;

        /// <summary>
        /// Присваивание статуса СЭС из выпадающего списка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusSPP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = comboBoxStatusSPP.SelectedItem.ToString();

            foreach (var (item, statusSPP) in _comboBoxStatusSPP)
            {
                if (status == item)
                {
                    _statusSPP = statusSPP;

                    if (_statusSPP == StatusSPP.вводимая)
                    {
                        labelUIDSPP.Enabled = false;
                        textBoxUIDSPP.Enabled = false;
                    }
                    else
                    {
                        labelUIDSPP.Enabled = true;
                        textBoxUIDSPP.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Переменная для записи статуса СЭС.
        /// </summary>
        private PowerSystem _powerSystem;

        /// <summary>
        /// Присваивание ЭС из выпадающего списка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PowerSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string powerSystem = comboBoxPowerSystem.SelectedItem.ToString();

            foreach (var (item, system) in _comboBoxPowerSystem)
            {
                if (powerSystem == item)
                {
                    _powerSystem = system;
                }
            }
        }

        /// <summary>
        /// Метод добавления СЭС.
        /// </summary>
        /// <returns></returns>
        public SolarPowerPlant AddSPP()
        {
            var spp = new SolarPowerPlant
            {
                NameSPP = textBoxNameSPP.Text,
                StatusSPP = _statusSPP,
                NodeSPP = (int)ControlText.CheckNumber(textBoxNumSPP.Text),
                PowerSystem = _powerSystem,
                InstalledCapacity = ControlText.CheckNumber(textBoxInstallCapacity.Text),
            };
            if (String.IsNullOrEmpty(textBoxUIDSPP.Text))
            {
                spp.UIDspp = "-";
            }
            else
            {
                spp.UIDspp = textBoxUIDSPP.Text;
            }

            return spp;
        }

        /// <summary>
        /// Добавить параметры в таблицу СЭС.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AddSPP_Click(object sender, EventArgs e)
        {
            try
            {
                var eventArgs = new EventArgsAdded(AddSPP());
                SPPAdded.Invoke(this, eventArgs);
                DialogResult = DialogResult.OK;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            catch
            {
                MessageBox.Show("Вы забыли указать один из параметров!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
