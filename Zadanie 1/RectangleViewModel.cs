using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Zadanie_1
{
    internal class RectangleViewModel
    {

        TextBlockClass textBlock;
        ButtonClass button;
        RelayCommand clickCommand;


        public TextBlockClass TextBlock { get { return textBlock; } set { textBlock = value; } }
            
       public ButtonClass Button { get { return button; } set { button = value; } }

       public ICommand ClickCommand { get {return clickCommand; } }


        public RectangleViewModel() {

            TextBlock = new TextBlockClass(400, 200, new SolidColorBrush(Colors.Aquamarine), "Czy umiem już Bindować ?");
            Button = new ButtonClass(250, 125, "Kliknij mnie");
            clickCommand = new RelayCommand(Click);
        }

        private void Click()
        {
            Button.Content = "kIECAIK4EAIH";
            TextBlock.Text = "gSM\\ZLDOBJ@\t4FFE=FM`THŷ8EUř4HZS[GAJM=CC]URVCFEP4JFNAC_NNLM";
            TextBlock.Text = Xor(TextBlock.Text, "admin");
            Button.Content = Xor(Button.Content, "admin");
        }

      
        public class TextBlockClass:INotifyPropertyChanged
        {
            int width;
            int height;
            SolidColorBrush backgroundColor;
            string text;

            public event PropertyChangedEventHandler? PropertyChanged;

            public int Width
            {
                get { return width; }
                set { width = value; }
            }

            public int Height
            { 
                get { return height; } 
                set {  height = value; } 
            }

            public SolidColorBrush BackgroundColor
            {
                 get { return backgroundColor;}
                set
                {
                    backgroundColor = value;
                }
            }

            public string Text
            {
                get { return text; }
                set
                {
                    text = value;
                    OnPropertyChanged(nameof(text));
                }
            }

            public TextBlockClass(int width, int height, SolidColorBrush backgroundColor, string text)
            {
                Width = width;
                Height = height;
                BackgroundColor = backgroundColor;
                Text = text;
             
            }

            private void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        static string Xor(string text, string key)
        {
            string codedString = "";
            for (int i = 0; i < text.Length; i++)
            {
                int charText = text[i] - 'A';
                int charKey = key[i % key.Length] - 'A';
                codedString += (char)((charText ^ charKey) + 'A');
            }
            return codedString;
        }

        public class ButtonClass:INotifyPropertyChanged

        {

            int width;
            int height;
            string content;

            public event PropertyChangedEventHandler? PropertyChanged;

            public int Width
            {
                get { return width; }
                set { width = value; }
            }

            public int Height
            {
                get { return height; }
                set { height = value; }
            }


            public string Content
            {
                get { return content; }
                set
                {
                    content = value;
                    OnPropertyChanged(nameof(content));
                }
            }

            public ButtonClass(int width, int height, string content)
            {
                Width = width;
                Height = height;
                Content = content;
            }

            private void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }







    }
}
