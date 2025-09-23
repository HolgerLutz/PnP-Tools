using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace SearchQueryTool
{
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            Populate();
        }

        private async void Populate()
        {
            var asm = Assembly.GetExecutingAssembly();

            ProductNameText.Text = Get<AssemblyTitleAttribute>(asm)?.Title ?? asm.GetName().Name;
            VersionText.Text = $"Version {asm.GetName().Version}";
            CompanyText.Text = Get<AssemblyCompanyAttribute>(asm)?.Company ?? string.Empty;
            CopyrightText.Text = Get<AssemblyCopyrightAttribute>(asm)?.Copyright ?? string.Empty;
            DescriptionText.Text = (Get<AssemblyDescriptionAttribute>(asm)?.Description ?? string.Empty).Replace("\\r\\n", Environment.NewLine);

            var desc = DescriptionText.Text;
            ContributorsText.Text = "Nadeem Ishqair (Microsoft)\\r\\nMikael Svenson (@mikaelsvenson)\\r\\nMaximilian Melcher (@maxmelcher)\\r\\nBarry Waldbaum (Microsoft)\\r\\nDan Göran Lunde (@fastlundan)\\r\\nPetter Skodvin-Hvammen (@pettersh)\\r\\nHolger Lutz (Microsoft)".Replace("\\r\\n", Environment.NewLine);

            ProjectLink.Inlines.Clear();
            ProjectLink.Inlines.Add("GitHub Repository");
            ProjectLink.NavigateUri = new Uri("https://aka.ms/sqt");

            await LoadLicensesAsync();
        }

        private static T Get<T>(Assembly a) where T : Attribute =>
            a.GetCustomAttributes(typeof(T), false).FirstOrDefault() as T;

        private void ProjectLink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            }
            catch { /* ignore */ }
            e.Handled = true;
        }

        private void Close_Click(object sender, RoutedEventArgs e) => Close();

        private async Task LoadLicensesAsync()
        {
            try
            {
                var text = await Task.Run(LoadLicensesText);
                LicensesTextBox.Text = text;
            }
            catch
            {
                LicensesTextBox.Text = "Failed to load license information.";
            }
        }

        private string LoadLicensesText()
        {
            // Look for Licenses/Licenses.txt relative to base directory, with fallbacks similar to previous logic
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var content = TryReadLicenses(Path.Combine(baseDir, "Licenses", "Licenses.txt"));
            if (content != null) return content;

            // Probe parent directories (up to 5 levels) for a Licenses folder
            var probe = baseDir;
            for (int i = 0; i < 5 && content == null; i++)
            {
                probe = Path.GetFullPath(Path.Combine(probe, ".."));
                var candidate = Path.Combine(probe, "Licenses", "Licenses.txt");
                content = TryReadLicenses(candidate);
            }

            // Embedded resource fallback (if added as Embedded Resource)
            if (content == null)
            {
                var asm = Assembly.GetExecutingAssembly();
                var resName = asm.GetManifestResourceNames()
                    .FirstOrDefault(n => n.EndsWith("Licenses.Licenses.txt", StringComparison.OrdinalIgnoreCase) || n.EndsWith("Licenses.txt", StringComparison.OrdinalIgnoreCase));
                if (resName != null)
                {
                    using (var stream = asm.GetManifestResourceStream(resName))
                    using (var reader = new StreamReader(stream ?? Stream.Null))
                    {
                        content = reader.ReadToEnd();
                    }
                }
            }

            return content ?? "(No license text found)";
        }

        private static string TryReadLicenses(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    return File.ReadAllText(path, Encoding.UTF8);
                }
            }
            catch { /* ignore */ }
            return null;
        }
    }
}