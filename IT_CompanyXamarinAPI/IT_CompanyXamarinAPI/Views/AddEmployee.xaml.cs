using IT_CompanyXamarinAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT_CompanyXamarinAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEmployee : ContentPage
    {
        public AddEmployee(Employees employee )
        {
            InitializeComponent();

            if (employee.Firstname != null && employee.Surname != null && employee.TellNo != null && employee.Email != null)
            {
                txtFirstname.Text = employee.Firstname;
                txtSurname.Text = employee.Surname;
                txtTellNo.Text = employee.TellNo;
                txtEmail.Text = employee.Email;

                txtTellNo.IsEnabled = false;
                BtnAdd.IsVisible = false;
                BtnUpdate.IsVisible = true;
            }
            else
            {
                txtTellNo.IsEnabled = true;
                BtnAdd.IsVisible = true;
                BtnUpdate.IsVisible = false;
            }
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstname.Text))
            {
                await DisplayAlert("Input Error", "Firstname is Required", "OKay");
                return;
            }
            if (string.IsNullOrEmpty(txtSurname.Text))
            {
                await DisplayAlert("Input Error", "Surname is Required", "OKay");
                return;
            }
            if (string.IsNullOrEmpty(txtTellNo.Text))
            {
                await DisplayAlert("Input Error", "Tell No  is Required", "OKay");
                return;
            }

            if (string.IsNullOrEmpty(txtTellNo.Text))
            {
                await DisplayAlert("Input Error", "Tell Number is Required", "OK");
                return;
            }
            //bool b;
            //b = Regex.IsMatch(txtTellNo.Text, @"^[7-9]\d{9}$");
            //if (b == false)
            //{
            //    await DisplayAlert("Input Error", "Invalid Tell Number.", "OKay");
            //    return;
            //}

            //bool bEmail;
            //bEmail = Regex.IsMatch(txtEmail.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            //if (bEmail == false)
            //{
            //    await DisplayAlert("Input Error", "Invalid Email Address.", "OKay");
            //    return;
            //}

            try
            {
                BtnAdd.IsEnabled = false;
                Employees employeeType = new Employees();
                employeeType.Firstname = txtFirstname.Text;
                employeeType.Surname = txtSurname.Text;
                employeeType.TellNo = txtTellNo.Text;
                employeeType.Email = txtEmail.Text;

                string url = "http://172.22.32.1:8092/api/employee/saveemployee";

                HttpClient client = new HttpClient();
                string jsonData = JsonConvert.SerializeObject(employeeType);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();
                Response responseData = JsonConvert.DeserializeObject<Response>(result);
                if (responseData.Status == 1)
                {
                    await Navigation.PopAsync();
                    BtnAdd.IsEnabled = true;
                }
                else
                {
                    await DisplayAlert("Message", responseData.Message, "Okay");
                    BtnAdd.IsEnabled = true;
                    return;
                }

                BtnAdd.IsEnabled = true;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Message", ex.Message, "Okay");
                BtnAdd.IsEnabled = true;
                return;
            }
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstname.Text))
            {
                await DisplayAlert("Input Error", "Firstname is Required", "OKay");
                return;
            }
            if (string.IsNullOrEmpty(txtSurname.Text))
            {
                await DisplayAlert("Input Error", "Surname is Required", "OKay");
                return;
            }
            if (string.IsNullOrEmpty(txtTellNo.Text))
            {
                await DisplayAlert("Input Error", "Tell No  is Required", "OKay");
                return;
            }

            if (string.IsNullOrEmpty(txtTellNo.Text))
            {
                await DisplayAlert("Input Error", "Tell Number is Required", "OK");
                return;
            }
            //bool b;
            //b = Regex.IsMatch(txtTellNo.Text, @"^[7-9]\d{9}$");
            //if (b == false)
            //{
            //    await DisplayAlert("Input Error", "Invalid Tell Number.", "OKay");
            //    return;
            //}

            //bool bEmail;
            //bEmail = Regex.IsMatch(txtEmail.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            //if (bEmail == false)
            //{
            //    await DisplayAlert("Input Error", "Invalid Email Address.", "OKay");
            //    return;
            //}

            try
            {
                BtnUpdate.IsEnabled = false;
                Employees employee = new Employees();
                employee.Firstname = txtFirstname.Text;
                employee.Surname = txtSurname.Text;
                employee.TellNo = txtTellNo.Text;
                employee.Email = txtEmail.Text;

                string url = "http://172.22.32.1:8092/api/employee/updateemployee";
                HttpClient client = new HttpClient();
                string jsonData = JsonConvert.SerializeObject(employee);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();
                Response responseData = JsonConvert.DeserializeObject<Response>(result);
                if (responseData.Status == 1)
                {
                    await DisplayAlert("Message", responseData.Message, "Okay");
                    BtnUpdate.IsEnabled = true;
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Message", responseData.Message, "Okay");
                    BtnUpdate.IsEnabled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Message", ex.Message, "Okay");
                BtnUpdate.IsEnabled = true;
                return;
            }
        }
    }
}