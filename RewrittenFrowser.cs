using System;
using System.Windows.Forms;

namespace dotNET_project
{
    public partial class SimpleWebBrowser : Form
    {
        private WebBrowser webBrowser;
        private Button backButton;
        private Button forwardButton;
        private Button reloadButton;
        private Button homeButton;
        private TextBox urlTextBox;

        public SimpleWebBrowser()
        {
            InitializeComponent();
            InitializeBrowser();
        }

        private void InitializeBrowser()
        {
            webBrowser = new WebBrowser();
            webBrowser.Dock = DockStyle.Fill;

            backButton = CreateButton("Back", "Backward.png");
            forwardButton = CreateButton("Forward", "Forward.png");
            reloadButton = CreateButton("Reload", "Reload.png");
            homeButton = CreateButton("Home", "Home.png");

            urlTextBox = new TextBox();
            urlTextBox.Dock = DockStyle.Fill;
            urlTextBox.KeyDown += UrlTextBox_KeyDown;

            TableLayoutPanel buttonPanel = new TableLayoutPanel();
            buttonPanel.Dock = DockStyle.Top;
            buttonPanel.RowCount = 1;
            buttonPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            buttonPanel.Controls.Add(backButton);
            buttonPanel.Controls.Add(forwardButton);
            buttonPanel.Controls.Add(reloadButton);
            buttonPanel.Controls.Add(homeButton);
            buttonPanel.Controls.Add(urlTextBox);

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.RowCount = 1;
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            panel.Controls.Add(buttonPanel);
            panel.Controls.Add(webBrowser);

            Controls.Add(panel);
        }

        private Button CreateButton(string text, string imageFileName)
        {
            Button button = new Button();
            button.Text = text;
            button.Image = Image.FromFile(imageFileName);
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.TextAlign = ContentAlignment.MiddleRight;
            button.Click += Button_Click;
            return button;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button == backButton)
                webBrowser.GoBack();
            else if (button == forwardButton)
                webBrowser.GoForward();
            else if (button == reloadButton)
                webBrowser.Refresh();
            else if (button == homeButton)
                webBrowser.Navigate("https://www.google.com");
        }

        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser.Navigate(urlTextBox.Text);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimpleWebBrowser());
        }
    }
}
