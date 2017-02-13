using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SoftwareDependencies
{
    public class program
    {
        public string name;
        public List<program> dependencies = new List<program>();
        public List<program> isDependedBy = new List<program>();
        List<string> testing = new List<string>();
        bool installed = false;
        public program(string name)
        {
            this.name = name;
        }
        public void addDependency(program dependency)
        {
            this.dependencies.Add(dependency);
            dependency.addIsDependedBy(this);
        }
        public void addIsDependedBy(program dependedBy)
        {
            this.isDependedBy.Add(dependedBy);
        }        
        public void test2(program p,program a)
        {
            if (p.dependencies.Contains(a)) MessageBox.Show(" The addition is successful");            
        }
    }
}