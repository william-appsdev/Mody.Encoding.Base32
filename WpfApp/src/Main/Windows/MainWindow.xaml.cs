using System.Windows;
using System.Windows.Controls;

namespace Mody.Encoding.Base32.WpfApp.Main.Windows
{
    public partial class MainWindow : Window
    {
        private byte[]? _decoderInput;
        private byte[]? _encoderInput;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rdb_Encoder_Hex_Checked(object sender, RoutedEventArgs e)
        {
            if (_encoderInput?.Length > 0 != true)
                return;

            _Tbx_Encoder_Input.Text = Convert.ToHexString(_encoderInput);
        }

        private void Rdb_Encoder_Text_Checked(object sender, RoutedEventArgs e)
        {
            if (_encoderInput?.Length > 0 != true)
                return;

            _Tbx_Encoder_Input.Text = System.Text.Encoding.UTF8.GetString(_encoderInput);
        }

        private void Btn_Decode_Click(object sender, RoutedEventArgs e)
        {
            if (_decoderInput?.Length > 0 != true)
                _Tbx_Decoder_Output.Clear();
            else
                _Tbx_Decoder_Output.Text = Convert.ToHexString(_decoderInput);
        }

        private void Btn_Encode_Click(object sender, RoutedEventArgs e)
        {
            if (_encoderInput?.Length > 0 != true)
                _Tbx_Encoder_Output.Clear();
            else
                try
                {
                    _Tbx_Encoder_Output.Text = Mody.Encoding.Base32NS.Base32.GetString(_encoderInput);
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
                }
        }

        private void Btn_Copy_EncoderOutput_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(_Tbx_Encoder_Output.Text);
        }

        private void Btn_Copy_DecoderOutput_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(_Tbx_Decoder_Output.Text);
        }

        private void Tbx_Encoder_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            string encoderInput = _Tbx_Encoder_Input.Text;

            if (string.IsNullOrWhiteSpace(encoderInput))
            {
                if (_encoderInput != null)
                    _encoderInput = null;
                return;
            }

            if (_Rdb_Encoder_Hex.IsChecked == true)
                try
                {
                    _encoderInput = Convert.FromHexString(encoderInput);
                }
                catch (FormatException ex)
                {
                }
            else if (_Rdb_Encoder_Text.IsChecked == true)
                _encoderInput = System.Text.Encoding.UTF8.GetBytes(encoderInput);
        }

        private void Tbx_Decoder_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            string decoderInput = _Tbx_Decoder_Input.Text;

            if (string.IsNullOrWhiteSpace(decoderInput))
            {
                if (_decoderInput != null)
                    _decoderInput = null;
                return;
            }

            _decoderInput = Mody.Encoding.Base32NS.Base32.GetBytes(decoderInput);
        }
    }
}
