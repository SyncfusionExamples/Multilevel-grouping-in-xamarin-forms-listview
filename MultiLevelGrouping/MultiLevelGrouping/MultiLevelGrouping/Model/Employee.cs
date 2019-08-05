using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Grouping
{
    public class Employee : INotifyPropertyChanged
    {
        #region Fields

        private string employeeName;
        private string contactNumber;
        private ImageSource empimage;
        private string level;
        private string designation;  

        #endregion

        #region Properties

        public string EmployeeName
        {
            get { return employeeName; }
            set
            {
                if (employeeName != value)
                {
                    employeeName = value;
                    this.RaisedOnPropertyChanged("EmployeeName");
                }
            }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set
            {
                if (contactNumber != value)
                {
                    contactNumber = value;
                    this.RaisedOnPropertyChanged("ContactNumber");
                }
            }
        }

        public ImageSource EmployeeImage
        {
            get { return this.empimage; }
            set
            {
                this.empimage = value;
                this.RaisedOnPropertyChanged("EmployeeImage");
            }
        }

        public string Level  
        {
            get { return level; }
            set
            {
                if (level != value)
                {
                    level = value;
                    this.RaisedOnPropertyChanged("Level");
                }
            }
        }

        public string Designation
        {
            get { return designation; }
            set
            {
                if (designation != value)
                {
                    designation = value;
                    this.RaisedOnPropertyChanged("Designation");
                }
            }
        }

        #endregion

        #region Interface Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }
}
