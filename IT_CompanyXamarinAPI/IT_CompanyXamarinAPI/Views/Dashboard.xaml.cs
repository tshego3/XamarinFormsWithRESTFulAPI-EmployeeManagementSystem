using IT_CompanyXamarinAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT_CompanyXamarinAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            GetEmployeeInfo();
        }

        async void GetEmployeeInfo()
        {
            try
            {
                string url = "http://172.22.32.1:8092/api/employee/getemployeeslist";
                HttpClient client = new HttpClient();
                var result = await client.GetStringAsync(url);

                var EmpList = JsonConvert.DeserializeObject<List<Employees>>(result);

                EList.ItemsSource = null;
                EList.ItemsSource = new ObservableCollection<Employees>(EmpList);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Input Error", ex.Message, "OK");
                return;
            }
        }

        private async void EList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                Employees employee = e.Item as Employees;
                await Navigation.PushAsync(new AddEmployee(employee));

            }
            catch (Exception ex)
            {
                await DisplayAlert("Input Error", ex.Message, "OKay");
                return;
            }
        }

        private void EList_Refreshing(object sender, EventArgs e)
        {
            GetEmployeeInfo();
            EList.IsRefreshing = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Employees NewEmployee = new Employees();
            NewEmployee.Firstname = null;
            NewEmployee.Surname = null;
            NewEmployee.TellNo = null;
            NewEmployee.Email = null;
            Navigation.PushAsync(new AddEmployee(NewEmployee));
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var menu = sender as MenuItem;
                int EmpId = Convert.ToInt32(menu.CommandParameter.ToString());
                string url = $"http://172.22.32.1:8092/api/employee/deleteemployee?EmpId={EmpId}";
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.DeleteAsync(url);
                string result = await response.Content.ReadAsStringAsync();
                Response responseData = JsonConvert.DeserializeObject<Response>(result);
                if (responseData.Status == 1)
                {
                    await DisplayAlert("Info", responseData.Message, "OKay");
                    GetEmployeeInfo();
                }
                else
                {
                    await DisplayAlert("Error", responseData.Message, "Okay");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Input Error", ex.Message, "OKay");
                return;
            }
        }

    }
}