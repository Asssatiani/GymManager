using Caliburn.Micro;
using DAL;
using DAL.Models;
using System;
using System.Windows;

namespace GymManager.ViewModels
{
    public class ShellViewModel : Screen
    {
        #region props
        private int? _id;
        private string _lastName;
        private DateTime? _dateFrom;
        private DateTime? _dateTo;
        private string _firstName;
        private BindableCollection<EmployerModel> _employers;
        private EmployerModel _selectedEmployer;
        private EmployerInfoModel _employerInfo;

        public int? Id
        {
            get { return _id; }
            set { _id = value; }
        }        

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }      

        public DateTime? DateFrom
        {
            get { return _dateFrom; }
            set { _dateFrom = value; }
        }       

        public DateTime? DateTo
        {
            get { return _dateTo; }
            set { _dateTo = value; }
        }     

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }       

        public BindableCollection<EmployerModel> Employers
        {
            get { return _employers; }
            set { _employers = value; NotifyOfPropertyChange(() => Employers); }
        }       

        public EmployerModel SelectedEmployer
        {
            get { return _selectedEmployer; }
            set { _selectedEmployer = value; NotifyOfPropertyChange(() => SelectedEmployer); }
        }      

        public EmployerInfoModel EmployerInfo
        {
            get { return _employerInfo; }
            set { _employerInfo = value; NotifyOfPropertyChange(() => EmployerInfo); }
        }
        #endregion

        #region publicMethods
        public ShellViewModel()
        {
            GetEmployers();           
        }       

        public void SearchEmployers()
        {
            GetEmployers();
            EmployerInfo = new EmployerInfoModel();
        }

        public void GetEmployerInfo()
        {
            if (CheckIfEmployerIsSelected(SelectedEmployer))
            {
                DataAccess da = new DataAccess();
                var outModel = da.EmployerInfo(SelectedEmployer.Id);
                if (outModel != null)
                    EmployerInfo = outModel;
                else
                    EmployerInfo = new EmployerInfoModel()
                    {
                        Id = SelectedEmployer.Id
                    };
            }
        }

        public void UpdateInfo()
        {
            if (CheckIfEmployerIsSelected(SelectedEmployer))
            {
                DataAccess da = new DataAccess();
                da.UpdateEmployerInfo(EmployerInfo);
            }
        }
        #endregion

        #region privateMethods
        private void GetEmployers()
        {
            DataAccess da = new DataAccess();
            var outModel = da.GetEmployers(Id, FirstName, LastName, DateFrom, DateTo);

            Employers = new BindableCollection<EmployerModel>(outModel);
        }

        private bool CheckIfEmployerIsSelected<T>(T model)
        {
            if (model == null)
            {
                MessageBox.Show("Employer is not selected!");
                return false;
            }
            return true;
        }
        #endregion

    }
}
