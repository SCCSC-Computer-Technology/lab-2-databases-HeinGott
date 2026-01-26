using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H_Gottberg_Lab_2
{
    public partial class Form1 : Form
    {      

        public Form1()
        {
            InitializeComponent();
        }

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cityDBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cityDBDataSet.City' table.
            this.cityTableAdapter.Fill(this.cityDBDataSet.City);

        }

        //Start -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //calls a method to sort population in ascending order
        private void btnSortPopulationAscending_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.sortAscending(this.cityDBDataSet.City);
        }

        //calls a method to sort population in descending order
        private void btnSortPopulationDescending_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.sortDescending(this.cityDBDataSet.City);
        }

        //calls a method to sort the cities in alphabetical order
        private void btnSortPopulationAlphabetically_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.sortAlphabetically(this.cityDBDataSet.City);
        }

        //calls a method to get the total population of the database
        private void btnGetTotalPopulation_Click(object sender, EventArgs e)
        {            
            int totalPopulation = (int)this.cityTableAdapter.getTotalPopulation();
            MessageBox.Show($"Total Population:\n\n{totalPopulation:N0}", "Total Population", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //calls a method to get the average population of the database
        private void btnGetAveragePopulation_Click(object sender, EventArgs e)
        {
            double averagePopulation = (double)this.cityTableAdapter.getAveragePopulation();
            MessageBox.Show($"Average Population:\n\n{averagePopulation:N0}", "Average Population", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //calls a method to get the highest population in the database
        private void btnGetHighestPopulation_Click(object sender, EventArgs e)
        {
            int highestPopulation = (int)this.cityTableAdapter.getHighestPopulation();
            string cityName = (string)this.cityTableAdapter.getCityNameHighestPopulation();
            MessageBox.Show($"Highest Population:\n\n{cityName}: {highestPopulation:N0}", "Highest Population", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //calls a method to get the lowest population in the database
        private void btnGetLowestPopulation_Click(object sender, EventArgs e)
        {
            int lowestPopulation = (int)this.cityTableAdapter.getLowestPopulation();
            string cityName = (string)this.cityTableAdapter.getCityNameLowestPopulation();
            MessageBox.Show($"Lowest Population:\n\n{cityName}: {lowestPopulation:N0}", "Lowest Population", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnExitProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you!");
            this.Close();
        }
    }
}
