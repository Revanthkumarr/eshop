using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GoogleSearchApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SearchGoogle_Click(object sender, RoutedEventArgs e)
        {
            // Get the search query from the TextBox
            string searchQuery = inputTextBox.Text;

            // Perform the Google search and display the result in the WebBrowser control
            string searchResult = await GoogleSearch(searchQuery);
            resultWebBrowser.NavigateToString(searchResult);

            // Show the collapsible area
            resultGrid.Visibility = Visibility.Visible;
        }

        private async void OpenSmallScreen_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the visibility of the small screen
            smallScreen.Visibility = smallScreen.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private async void SearchSmallScreen_Click(object sender, RoutedEventArgs e)
        {
            // Get the search query from the small screen TextBox
            string searchQuery = inputTextBox.Text;

            // Perform the Google search and display the result in the WebBrowser control
            string searchResult = await GoogleSearch(searchQuery);
            resultWebBrowser.NavigateToString(searchResult);

            // Show the collapsible area
            resultGrid.Visibility = Visibility.Visible;

            // Hide the small screen
            smallScreen.Visibility = Visibility.Collapsed;
        }

        private async Task<string> GoogleSearch(string query)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Replace spaces with '+' for the search query
                    string formattedQuery = query.Replace(" ", "+");

                    // Google search URL
                    string googleSearchUrl = $"https://www.google.com/search?q={formattedQuery}";

                    // Perform the search and get the result
                    HttpResponseMessage response = await httpClient.GetAsync(googleSearchUrl);
                    response.EnsureSuccessStatusCode();

                    // Read the content of the result page
                    string htmlContent = await response.Content.ReadAsStringAsync();

                    // Use HtmlAgilityPack to parse the HTML and extract text content
                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(htmlContent);

                    // Select specific elements to extract text (you may need to adjust this based on Google's HTML structure)
                    var resultNodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='BNeawe iBp4i AP7Wnd']");

                    // Extract text content from the selected nodes
                    string resultText = resultNodes != null ? string.Join(Environment.NewLine, resultNodes.Select(node => node.InnerText.Trim())) : "Unable to extract result.";

                    return resultText;
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
