using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SoftwareDependencies
{
    class SoftwareVM : INotifyPropertyChanged
    {
        #region VARIABLES
        List<string> _input,_output;
        List<program> allprograms;
        List<program> installedPrograms = new List<program>();
        const string INPUT_FILE = "Input.txt";
        const string OUTPUT_FILE = "Output.txt";
        #endregion
        #region PROPERTIES
        public List<string> Input
        {
            get { return _input; }
            set { _input = value; OnPropertyChanged(); }
        }
        public List<string> Output
        {
            get { return _output; }
            set { _output = value; OnPropertyChanged(); }
        }
        #endregion
        #region CONSTRUCTOR
        public SoftwareVM()
        {
            _input = new List<string>();
            _output = new List<string>();
            List<string> teams = File.ReadLines(INPUT_FILE).ToList();
            foreach (string st in teams)
            {
                _input.Add(st);
                string[] splitted = st.Split(' ');
                switch (splitted[0])
                {
                    case "DEPEND":
                        {
                            program p = new program(splitted[1]);
                            for (int i =2;i< splitted.Length;i++)
                            {
                                program a = new program(splitted[i]);
                                p.addDependency(a);
                                p.test2(p,a);                               
                            }
                            break;
                        }
                    case "INSTALL":
                        {
                            program p = new program(splitted[1]);
                            foreach(program a in installedPrograms)
                            {
                                if (p == a) { MessageBox.Show("already installed"); break; }
                                else { install(p); }                               
                            }
                            break;
                        }
                    case "REMOVE": break;
                    case "LIST": break;
                }
            }
        }
        #endregion
        #region INSTALL FUNCTION
        public void install(program p)
        {
            foreach (program a in p.dependencies)
            {
                foreach (program q in installedPrograms)
                {
                    if (a != q) install(a);
                    else
                    {
                        MessageBox.Show("Installing " + a.name);
                        installedPrograms.Add(a);
                    }
                }
            }
        }
        #endregion
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// When a property's content changes call this function to raise the PropertyChange flag in XAML.
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
